using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS408ProjectClient
{
    public partial class Form1 : Form
    {
        bool terminating = false; //bool to see if there is a connection error between two sides
        bool connected = false; //bool to see if client is connected to server
        bool IF100Subscribed = false; //bool to see if client is subcribed to IF100 Channel
        bool SPS101Subscribed = false; //bool to see if client is subcribed to SPS101 Channel
        bool alreadyWritten = false; //bool to see if an error message regarding shutdown has alrady been written
        bool entered = false; //bool to see if client has sent its username to the server
        Socket clientSocket;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }
        private void ServerConnectButton_Click(object sender, EventArgs e) //what happens when client clicks "connect"
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = IPTextBox.Text;
            int portNum;
            if (UsernameTextBox.Text != "" && Int32.TryParse(PortTextBox.Text, out portNum)) // to see if username box isn't empty and ip and port are valid
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    Byte[] sendbuffer = Encoding.Default.GetBytes(UsernameTextBox.Text);
                    clientSocket.Send(sendbuffer); // client sends its username to server for checking purposes
                    entered = true; //it means that username has been sent to server
                    Thread ReceiveThread = new Thread(Receive); // start the thread for receiving anything from server
                    ReceiveThread.Start();
                }
                catch // if the client can't connect to server
                {
                    ConnectionLogs.AppendText("Could not connect to the server!\n"); 
                    clientSocket.Close();
                }
            }
            else //if the port is invalid or no usarname has been provided
            {
                ConnectionLogs.AppendText("Invalid port or no username is provided!\n");
                clientSocket.Close();
            }
        }
        private void Receive() //function used in a thread for receiving messages from server
        {
            while (entered || connected) // either username is sent for the first time for checking purposes or the client is alrady connected
            {  
                try
                {
                    Byte[] buffer = new Byte[128];
                    clientSocket.Receive(buffer); //try to receive a message from the server, if can't, enter catch block
                    string incomingMessage = Encoding.Default.GetString(buffer).TrimEnd('\0');
                    if (incomingMessage=="pos") // if incoming message is "pos", the username sent before can be used, i.e. it isn't alrady in use by someone else
                    {
                        //change enable property of some buttons
                        ConnectButton.Enabled = false;
                        DisconnectButton.Enabled = true;
                        connected = true; //the client is connected
                        entered = false; //the username check stage is passed
                        IPTextBox.Enabled = false;
                        PortTextBox.Enabled = false;
                        UsernameTextBox.Enabled = false;
                        IF100SubscribeButton.Enabled = true;
                        SPS101SubscribeButton.Enabled = true;
                        ConnectionLogs.AppendText(UsernameTextBox.Text + " is connected!\n");
                    }
                    else if (incomingMessage == "neg") // if incoming message is "neg", the username sent before can't be used, i.e. it is alrady in use by someone else
                    {
                        ConnectionLogs.AppendText("An already existing user is entered: " + UsernameTextBox.Text + "\n");
                        entered = false; //the username check stage is passed, enter another username
                    }
                    else if (incomingMessage.Substring(0, 2) == "mi") //check if incoming message is related with IF100 Channel, can't receive if not subscribed, see the server side for details
                    {
                        IF100MessageLogs.AppendText(incomingMessage.Substring(2) + "\n"); // extract the encoding part and append the original message
                    }
                    else if (incomingMessage.Substring(0, 2) == "ms") //check if incoming message is related with SPS101 Channel, can't receive if not subscribed, see the server side for details
                    {
                        SPS101MessageLogs.AppendText(incomingMessage.Substring(2) + "\n"); // extract the encoding part and append the original message
                    }
                    else if (incomingMessage.Substring(0, 2) == "sd") //check if incoming message is related with server shutdown
                    {
                        ConnectionLogs.AppendText(incomingMessage.Substring(2)); // extract the encoding part and append the original message
                        alreadyWritten = true; //shutdown message has been written to connection logs
                        if (IF100Subscribed || SPS101Subscribed) // if client is subscribed to any one of channels, inform the user that all of its subscriptions are gone due to server shutdown
                        { 
                            ConnectionLogs.AppendText(UsernameTextBox.Text + " has unsubscribed from all of its subsrictions due to server shutdown.\n"); 
                        }
                        IF100Subscribed = false;
                        SPS101Subscribed = false;
                        //change enable property of some buttons and textboxes
                        IF100SubscribeButton.Enabled = false;
                        SPS101SubscribeButton.Enabled = false;
                        IF100UnsubscribeButton.Enabled = false;
                        SPS101UnsubscribeButton.Enabled = false;
                        DisconnectButton.Enabled = false;
                        ConnectButton.Enabled = true;
                        IF100MessageTextBox.Enabled = false;
                        IF100SendNewMessageButton.Enabled = false;
                        SPS101MessageTextBox.Enabled = false;
                        SPS101SendNewMessageButton.Enabled = false;
                        connected = false; //the connection is lost
                        ConnectionLogs.AppendText("Due to server shutdown, both channel histories (if there were any) are deleted.\n");
                        //delete channel histories due to server shutdown
                        IF100MessageTextBox.Clear();
                        SPS101MessageTextBox.Clear();
                        IF100MessageLogs.Clear();
                        SPS101MessageLogs.Clear();
                        IPTextBox.Enabled = true;
                        PortTextBox.Enabled = true;
                        UsernameTextBox.Enabled = true;
                        clientSocket.Close();
                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        //if a message couldn't received from server and no shutdown message has been written
                        if (!alreadyWritten) { ConnectionLogs.AppendText("Couldn't receive message from the server!\n"); }
                        //change the enable property of some buttons and textboxes
                        ConnectButton.Enabled = true;
                        DisconnectButton.Enabled = false;
                        IF100MessageTextBox.Enabled = false;
                        IF100SendNewMessageButton.Enabled = false;
                        SPS101MessageTextBox.Enabled = false;
                        SPS101SendNewMessageButton.Enabled = false;
                    }
                    clientSocket.Close();
                    connected = false; //the connection is lost, since there has been an error while receiving message.
                }
            }
        } 
        private void IF100SendNewMessageButton_Click(object sender, EventArgs e) //what happens when client clicks "send" to IF100 Channel
        {
            string IF100NewMessage = "mi" + IF100MessageTextBox.Text; //encode message to if100 channel message form, the server will understand where the message will be going to
            if (IF100MessageTextBox.Text !="" && IF100NewMessage.Length <= 128) //Check if the message is box isn't empty and it's not too long
            {
                Byte[] buffer = Encoding.Default.GetBytes(IF100NewMessage);
                clientSocket.Send(buffer); // send the encoded message
                IF100MessageTextBox.Text = string.Empty; // make the textbox empty for new messages
            }
            else { ConnectionLogs.AppendText("The message length should be bigger than 0 and smaller than 128!\n"); }
        }
        private void SPS101SendNewMessageButton_Click(object sender, EventArgs e) //what happens when client clicks "send" to SPS101 Channel
        {
            string SPS101NewMessage = "ms" + SPS101MessageTextBox.Text; //encode message to SPS101 channel message form, the server will understand where the message will be going to
            if (SPS101MessageTextBox.Text != "" && SPS101NewMessage.Length <= 128) //Check if the message is box isn't empty and it's not too long
            {
                Byte[] buffer = Encoding.Default.GetBytes(SPS101NewMessage);
                clientSocket.Send(buffer); // send the encoded message
                SPS101MessageTextBox.Text = string.Empty; // make the textbox empty for new messages
            }
            else { ConnectionLogs.AppendText("The message length should be bigger than 0 and smaller than 128!\n"); }
        }
        private void IF100SubscribeButton_Click(object sender, EventArgs e) //what happens when client clicks "subscribe" to IF100 Channel
        {
            //change enable property of some buttons and textboxes
            IF100Subscribed = true;
            IF100SubscribeButton.Enabled = false;
            IF100UnsubscribeButton.Enabled = true;
            IF100MessageTextBox.Enabled = true;
            IF100SendNewMessageButton.Enabled = true;
            ConnectionLogs.AppendText(UsernameTextBox.Text + " has subscribed to IF100.\n");
            string str = "si"; //encode message to IF100 subscription form, the server will understand that the client is subscribed to IF100
            Byte[] buffer = Encoding.Default.GetBytes(str);
            clientSocket.Send(buffer); // send the encoded message 
        }
        private void IF100UnsubscribeButton_Click(object sender, EventArgs e) //what happens when client clicks "unsubscribe" from IF100 Channel
        {
            string str = "ui"; //encode message to IF100 unsubscription form, the server will understand that the client is unsubscribed from IF100
            Byte[] buffer = Encoding.Default.GetBytes(str);
            clientSocket.Send(buffer); // send the encoded message 
            IF100Subscribed = false;
            ConnectionLogs.AppendText(UsernameTextBox.Text + " has unsubscribed from IF100.\n");
            //change the enable property of some buttons and textboxes
            IF100SubscribeButton.Enabled = true;
            IF100UnsubscribeButton.Enabled = false;
            IF100MessageTextBox.Enabled = false;
            IF100SendNewMessageButton.Enabled = false;
            IF100MessageTextBox.Text = string.Empty;
        }
        private void SPS101SubscribeButton_Click(object sender, EventArgs e) //what happens when client clicks "subscribe" to SPS101 Channel
        {
            //change enable property of some buttons and textboxes
            SPS101Subscribed = true;
            SPS101SubscribeButton.Enabled = false;
            SPS101UnsubscribeButton.Enabled = true;
            SPS101MessageTextBox.Enabled = true;
            SPS101SendNewMessageButton.Enabled = true;
            ConnectionLogs.AppendText(UsernameTextBox.Text + " has subscribed to SPS101.\n");
            string str = "sp"; //encode message to SPS101 subscription form, the server will understand that the client is subscribed to SPS101
            Byte[] buffer = Encoding.Default.GetBytes(str);
            clientSocket.Send(buffer); // send the encoded message 
        }
        private void SPS101UnsubscribeButton_Click(object sender, EventArgs e) //what happens when client clicks "unsubscribe" from SPS101 Channel
        {
            string str = "up"; //encode message to SPS101 unsubscription form, the server will understand that the client is unsubscribed from SPS101
            Byte[] buffer = Encoding.Default.GetBytes(str);
            clientSocket.Send(buffer); // send the encoded message 
            SPS101Subscribed = false;
            ConnectionLogs.AppendText(UsernameTextBox.Text + " has unsubscribed from SPS101.\n");
            //change enable property of some buttons and textboxs
            SPS101SubscribeButton.Enabled = true;
            SPS101UnsubscribeButton.Enabled = false;
            SPS101MessageTextBox.Enabled = false;
            SPS101SendNewMessageButton.Enabled = false;
            SPS101MessageTextBox.Text = string.Empty;
        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e) //what happens when client clicks "X" in the client application, indicating exit
        {
            connected = false; //the connection is lost
            terminating = true; //the connection is terminating
            string shutdown = "sd"; //encode message to client shutdown form, the server will understand that the client's application is being shutdown
            try
            {
                Byte[] buffer = Encoding.Default.GetBytes(shutdown);
                clientSocket.Send(buffer); //try to send the encoded shutdown message
            }
            catch
            {
                Environment.Exit(0);
            }
            clientSocket.Close();
            Environment.Exit(0); //close the app
        }
        private void DisconnectButton_Click(object sender, EventArgs e) //what happens when client clicks "Disconnect" in the client application, indicating disconnection
        {
            alreadyWritten = true;
            string str = "dc"; //encode message to client disconnection form, the server will understand that the client is disconnected
            Byte[] buffer = Encoding.Default.GetBytes(str);
            clientSocket.Send(buffer); // send the encoded message
            connected = false; // the connection is lost
            //change enable property of some buttons and textboxs
            DisconnectButton.Enabled = false;
            ConnectButton.Enabled = true;
            SPS101UnsubscribeButton.Enabled = false;
            IF100UnsubscribeButton.Enabled = false;
            SPS101SubscribeButton.Enabled = false;
            IF100SubscribeButton.Enabled = false;
            IF100MessageTextBox.Enabled = false;
            IF100SendNewMessageButton.Enabled = false;
            SPS101MessageTextBox.Enabled = false;
            SPS101SendNewMessageButton.Enabled = false;
            ConnectionLogs.AppendText(UsernameTextBox.Text + " has disconnected!\n");
            if (IF100Subscribed || SPS101Subscribed) // if client is subscribed to any one of the channels, inform the user that all of its subscriptions are gone due to disconnection
            { ConnectionLogs.AppendText(UsernameTextBox.Text + " has unsubscribed from all of its subsrictions due to disconnection.\n"); } 
            IF100Subscribed = false;
            SPS101Subscribed = false;
            terminating = true;
            IPTextBox.Enabled = true;
            PortTextBox.Enabled = true;
            UsernameTextBox.Enabled = true;
            ConnectionLogs.AppendText("Due to disconnection, both channel histories (if there were any) are deleted.\n"); //delete channel histories due to client disconnection
            //clear textboxes
            IF100MessageTextBox.Clear();
            SPS101MessageTextBox.Clear();
            IF100MessageLogs.Clear();
            SPS101MessageLogs.Clear();
            clientSocket.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}