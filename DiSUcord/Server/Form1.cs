using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cs408_Project_Server
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool listening = false;
        List<string> users = new List<string>();//user names for all the active users connected to the server
        List<string> sps = new List<string>();//user names for all the active users connected to the server and subscribed to Sps101 channel
        List<string> if100 = new List<string>();//user names for all the active users connected to the server and subscribed to If100 channel
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//server socket
        List<Socket> clientSockets = new List<Socket>();//socket lsit for all the active users connected to the server
        List<Socket> IF100Sockets = new List<Socket>();//socket lsit for all the active users connected to the server and subscribed to Sps101 channel
        List<Socket> SPS101Sockets = new List<Socket>();//socket lsit for all the active users connected to the server and subscribed to If100 channel
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {//when shutting down the server inform the clients that server is shutting down  
            
            foreach (Socket client in clientSockets)
            {//sending the encodeded message for shutdown to the clients 
                try
                {
                    string message ="sdThe server has been shutdown!\n";//sd encoding means shutdown
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    client.Send(buffer);
                }
                catch
                {//If anything unexpected happens
                    server_logs.AppendText("The server is closed!\n");
                    terminating = true;
                    serverSocket.Close();
                }

            }
            foreach(Socket client in clientSockets)
            {// closing all the client sockets
                client.Close();
            }
            
            listening = false;//to stop the listening 
            terminating = true;
            serverSocket.Close();//closing the server socket
            Environment.Exit(0);//closing the form
        }
        private void port_listen_Click(object sender, EventArgs e)
        {//Listening proceses
            int serverPort;

            if (Int32.TryParse(port_input.Text, out serverPort))
            {//getting the port input and starting the listening 
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;//for starting to listsen
                port_listen.Enabled = false;//lock the text box 
                Thread acceptThread = new Thread(Accept);//creating a thread using the accept function
                acceptThread.Start();
                server_logs.Enabled = true;
                active_user_logs.Enabled= true;
                if_logs.Enabled=true;
                sps_log.Enabled= true;

                server_logs.AppendText("Started listening on port: " + serverPort + "\n");
            }
            else
            {//if invalid port number is entered
                server_logs.AppendText("Please check port number \n");
            }
        }
        private void Accept()
        {//accepting new clients and starting their threads.
            while (listening)
            {
                try
                {//getting the username in a encoded way 
                    Socket newClient = serverSocket.Accept();
                    Byte[] buffer = new Byte[128];
                    newClient.Receive(buffer);
                    string user_namemsg = Encoding.Default.GetString(buffer);
                    user_namemsg = user_namemsg.Substring(0, user_namemsg.IndexOf("\0"));

                    if (users.Contains(user_namemsg)){// if the username exists in the active users 
                        string AlreadyInUsage = "neg";
                        Byte[] buffer2 = Encoding.Default.GetBytes(AlreadyInUsage);
                        newClient.Send(buffer2);//sending the notification to the client that this name is taken
                        server_logs.AppendText("An already existing user is entered: " + user_namemsg + "\n");
                    }
                    else
                    {// if the username exists in the active users
                        string Connected = "pos";
                        Byte[] buffer_2 = Encoding.Default.GetBytes(Connected);
                        newClient.Send(buffer_2);//send the notificaiton that the user can connect with this username
                        clientSockets.Add(newClient);//creating a socket for the client
                        server_logs.AppendText(user_namemsg+ " is connected.\n");
                        users.Add(user_namemsg);//add the username to active users list
                        active_user_logs.AppendText(user_namemsg + " is connected.\n");//logging the info to the server gui
                        string new_user = user_namemsg;
                        Thread receiveThread = new Thread(() => Receive(newClient, new_user));//open the thread for reciveing purposes
                        receiveThread.Start();
                    }
                }
                catch
                {//If anything goes wrong
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        server_logs.AppendText("One or more sockets stopped working.\n");
                    }

                }
            }
        }
        private void Receive(Socket thisClient,string user_name) 
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {//get the encoded message that contains client's actions 
                    Byte[] buffer = new Byte[128];
                    thisClient.Receive(buffer);
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    try
                    {
                        if (incomingMessage.Substring(0, 2) == "sp")
                        {// with the sp encoding user subscribes to the sps101 channel
                            sps_log.AppendText(user_name + " has subscribed to SPS101.\n");//log the action
                            sps.Add(user_name);//add the username to the sps list
                            server_logs.AppendText(user_name + " has subscribed to SPS101.\n");//log the action
                            SPS101Sockets.Add(thisClient);//add the socket to the sps list for reciving and sending purpouses
                        }
                        else if (incomingMessage.Substring(0, 2) == "up")
                        {// with the up encoding user unsubscribes to the sps101 channel
                            sps_log.AppendText(user_name + " has unsubscribed from SPS101.\n");//log the action
                            server_logs.AppendText(user_name + " has unsubscribed from SPS101.\n");//log the action
                            sps.Remove(user_name);//remove username from the sps list
                            SPS101Sockets.Remove(thisClient);//remove the socket from the sps list
                        }
                        else if (incomingMessage.Substring(0, 2) == "ms")
                        {// with the ms encoding sends a message to the sps channel
                            server_logs.AppendText("A message has been sent to the SPS101 channel, by " + user_name + ".\n");//log the action to the server logs
                            string message = incomingMessage;
                            string encode = message.Substring(0, 2);
                            message = encode + user_name + ":" + message.Substring(2);//format the message
                            if (message != "" && message.Length <= 128)//send the message to the sps101 channel subscribers
                            {
                                Byte[] buffer_2 = Encoding.Default.GetBytes(message);
                                foreach (Socket client in SPS101Sockets)//loop to send the message
                                {
                                    try
                                    {
                                        client.Send(buffer_2);
                                    }
                                    catch
                                    {//If anything goes wrong
                                        server_logs.AppendText("There is a problem! Check the connection...\n");
                                        terminating = true;
                                        serverSocket.Close();
                                    }

                                }
                            }
                        }
                        else if (incomingMessage.Substring(0, 2) == "si")
                        {// with the si encoding user subscribes to the If100 channel
                            if_logs.AppendText(user_name + " has subscribed to IF100.\n");//log the action
                            if100.Add(user_name);//add the username to the If list
                            server_logs.AppendText(user_name + " has subscribed to IF100.\n");//log the action
                            IF100Sockets.Add(thisClient);//add the socket to the If list for reciving and sending purpouses
                        }
                        else if (incomingMessage.Substring(0, 2) == "ui")
                        {// with the ui encoding user unsubscribes to the If100 channel
                            if_logs.AppendText(user_name + " has unsubcribed from IF100.\n");//log action
                            server_logs.AppendText(user_name + " has unsubcribed from IF100.\n");//log action
                            if100.Remove(user_name);//remove the username from the If list
                            IF100Sockets.Remove(thisClient);//remove the socket from the If list
                        }
                        else if (incomingMessage.Substring(0, 2) == "mi")
                        {// with the ms encoding sends a message to the If100 channel subscribers
                            server_logs.AppendText("A message has been sent to the IF100 channel, by " + user_name + ".\n");
                            string message = incomingMessage;
                            string encode = message.Substring(0, 2);
                            message = encode + user_name + ":" + message.Substring(2);
                            if (message != "" && message.Length <= 128)
                            {
                                Byte[] buffer_2 = Encoding.Default.GetBytes(message);
                                foreach (Socket client in IF100Sockets)//loop to send the message
                                {
                                    try
                                    {
                                        client.Send(buffer_2);
                                    }
                                    catch
                                    {//If anything goes wrong
                                        server_logs.AppendText("There is a problem! Check the connection...\n");
                                        terminating = true;
                                        serverSocket.Close();
                                    }

                                }
                            }
                        }
                        else if (incomingMessage.Substring(0, 2) == "dc")
                        {// if the client disconnects from the server
                            if (if100.Contains(user_name))//start removing users info
                            {
                                if100.Remove(user_name);
                                if_logs.AppendText(user_name + " has unsubcribed from IF100.\n");//log the action
                                IF100Sockets.Remove(thisClient);
                            }
                            if (sps.Contains(user_name))
                            {
                                sps.Remove(user_name);
                                sps_log.AppendText(user_name + " has unsubcribed from SPS101.\n");//log the action 
                                SPS101Sockets.Remove(thisClient);
                            }
                            if (users.Contains(user_name))
                            {
                                server_logs.AppendText(user_name + " has disconnected!\n");//log the action
                                users.Remove(user_name);
                            }
                            if (clientSockets.Contains(thisClient))
                            {
                                clientSockets.Remove(thisClient);
                                connected = false;
                                active_user_logs.AppendText(user_name + " has disconnected.\n");//log the action
                                thisClient.Close();//close the client socket
                            }

                        }
                        else if (incomingMessage.Substring(0, 2) == "sd")
                        {// iff the client shutdowns 
                            if (if100.Contains(user_name))//start removing the users info
                            {
                                if100.Remove(user_name);
                                if_logs.AppendText(user_name + " has unsubcribed from IF100.\n");//log the action
                                IF100Sockets.Remove(thisClient);
                            }
                            if (sps.Contains(user_name))
                            {
                                sps.Remove(user_name);
                                SPS101Sockets.Remove(thisClient);
                                sps_log.AppendText(user_name + " has unsubcribed from SPS101.\n");//log the action
                            }
                            if (users.Contains(user_name))
                            {
                                server_logs.AppendText(user_name + "'s client has been shutdown!\n");//log the action
                                users.Remove(user_name);
                            }
                            if (clientSockets.Contains(thisClient))
                            {
                                clientSockets.Remove(thisClient);
                                connected = false;
                                active_user_logs.AppendText(user_name + " has disconnected.\n");//log the action
                                thisClient.Close();//close the client socket
                            }
                        }
                    }
                    catch
                    {// If sometihing goes wrong
                        if (terminating)
                        {
                            listening = false;
                        }
                        else
                        {
                            server_logs.AppendText("Something went wrong while communucating.\n");
                            serverSocket.Close();
                        }

                    }
                }
                catch
                {// If sometihing goes wrong
                    if (!terminating)
                    {
                        server_logs.AppendText(user_name+" has disconnected\n");
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    connected = false;
                }
            }
        }
        private void spslabel_Click(object sender, EventArgs e)
        {
            //created by mistake
        }
    }
}
