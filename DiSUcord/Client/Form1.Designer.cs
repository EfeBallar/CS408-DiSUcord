namespace CS408ProjectClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            IF100MessageLogs = new RichTextBox();
            SPS101MessageLogs = new RichTextBox();
            IF100SubscribeButton = new Button();
            SPS101SubscribeButton = new Button();
            IF100MessageTextBox = new TextBox();
            SPS101MessageTextBox = new TextBox();
            IF100SendNewMessageButton = new Button();
            SPS101SendNewMessageButton = new Button();
            ConnectionLogs = new RichTextBox();
            label2 = new Label();
            ConnectButton = new Button();
            IPTextBox = new TextBox();
            PortTextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            UsernameTextBox = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            SPS101UnsubscribeButton = new Button();
            IF100UnsubscribeButton = new Button();
            label4 = new Label();
            label1 = new Label();
            label3 = new Label();
            DisconnectButton = new Button();
            SuspendLayout();
            // 
            // IF100MessageLogs
            // 
            IF100MessageLogs.Location = new Point(412, 109);
            IF100MessageLogs.Name = "IF100MessageLogs";
            IF100MessageLogs.Size = new Size(352, 340);
            IF100MessageLogs.TabIndex = 0;
            IF100MessageLogs.Text = "";
            // 
            // SPS101MessageLogs
            // 
            SPS101MessageLogs.Location = new Point(812, 109);
            SPS101MessageLogs.Name = "SPS101MessageLogs";
            SPS101MessageLogs.Size = new Size(352, 340);
            SPS101MessageLogs.TabIndex = 1;
            SPS101MessageLogs.Text = "";
            // 
            // IF100SubscribeButton
            // 
            IF100SubscribeButton.Enabled = false;
            IF100SubscribeButton.Location = new Point(594, 85);
            IF100SubscribeButton.Name = "IF100SubscribeButton";
            IF100SubscribeButton.Size = new Size(80, 23);
            IF100SubscribeButton.TabIndex = 2;
            IF100SubscribeButton.Text = "Subscribe";
            IF100SubscribeButton.UseVisualStyleBackColor = true;
            IF100SubscribeButton.Click += IF100SubscribeButton_Click;
            // 
            // SPS101SubscribeButton
            // 
            SPS101SubscribeButton.Enabled = false;
            SPS101SubscribeButton.Location = new Point(997, 85);
            SPS101SubscribeButton.Name = "SPS101SubscribeButton";
            SPS101SubscribeButton.Size = new Size(80, 23);
            SPS101SubscribeButton.TabIndex = 3;
            SPS101SubscribeButton.Text = "Subscribe";
            SPS101SubscribeButton.UseVisualStyleBackColor = true;
            SPS101SubscribeButton.Click += SPS101SubscribeButton_Click;
            // 
            // IF100MessageTextBox
            // 
            IF100MessageTextBox.Enabled = false;
            IF100MessageTextBox.Location = new Point(471, 482);
            IF100MessageTextBox.Name = "IF100MessageTextBox";
            IF100MessageTextBox.Size = new Size(293, 23);
            IF100MessageTextBox.TabIndex = 4;
            // 
            // SPS101MessageTextBox
            // 
            SPS101MessageTextBox.Enabled = false;
            SPS101MessageTextBox.Location = new Point(871, 482);
            SPS101MessageTextBox.Name = "SPS101MessageTextBox";
            SPS101MessageTextBox.Size = new Size(293, 23);
            SPS101MessageTextBox.TabIndex = 5;
            // 
            // IF100SendNewMessageButton
            // 
            IF100SendNewMessageButton.Enabled = false;
            IF100SendNewMessageButton.Location = new Point(471, 511);
            IF100SendNewMessageButton.Name = "IF100SendNewMessageButton";
            IF100SendNewMessageButton.Size = new Size(75, 23);
            IF100SendNewMessageButton.TabIndex = 6;
            IF100SendNewMessageButton.Text = "Send";
            IF100SendNewMessageButton.UseVisualStyleBackColor = true;
            IF100SendNewMessageButton.Click += IF100SendNewMessageButton_Click;
            // 
            // SPS101SendNewMessageButton
            // 
            SPS101SendNewMessageButton.Enabled = false;
            SPS101SendNewMessageButton.Location = new Point(871, 511);
            SPS101SendNewMessageButton.Name = "SPS101SendNewMessageButton";
            SPS101SendNewMessageButton.Size = new Size(75, 23);
            SPS101SendNewMessageButton.TabIndex = 7;
            SPS101SendNewMessageButton.Text = "Send";
            SPS101SendNewMessageButton.UseVisualStyleBackColor = true;
            SPS101SendNewMessageButton.Click += SPS101SendNewMessageButton_Click;
            // 
            // ConnectionLogs
            // 
            ConnectionLogs.Location = new Point(32, 109);
            ConnectionLogs.Name = "ConnectionLogs";
            ConnectionLogs.Size = new Size(304, 270);
            ConnectionLogs.TabIndex = 8;
            ConnectionLogs.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(812, 85);
            label2.Name = "label2";
            label2.Size = new Size(124, 21);
            label2.TabIndex = 10;
            label2.Text = "SPS 101 Channel";
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(32, 511);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(75, 23);
            ConnectButton.TabIndex = 12;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ServerConnectButton_Click;
            // 
            // IPTextBox
            // 
            IPTextBox.Location = new Point(116, 398);
            IPTextBox.Name = "IPTextBox";
            IPTextBox.Size = new Size(220, 23);
            IPTextBox.TabIndex = 13;
            // 
            // PortTextBox
            // 
            PortTextBox.Location = new Point(116, 430);
            PortTextBox.Name = "PortTextBox";
            PortTextBox.Size = new Size(220, 23);
            PortTextBox.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(32, 432);
            label5.Name = "label5";
            label5.Size = new Size(38, 21);
            label5.TabIndex = 16;
            label5.Text = "Port";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(32, 485);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 17;
            label6.Text = "Username";
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(116, 482);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(220, 23);
            UsernameTextBox.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(32, 85);
            label7.Name = "label7";
            label7.Size = new Size(215, 21);
            label7.TabIndex = 19;
            label7.Text = "Connection/Subscrition Log";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(412, 485);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 20;
            label8.Text = "Message:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(812, 485);
            label9.Name = "label9";
            label9.Size = new Size(56, 15);
            label9.TabIndex = 21;
            label9.Text = "Message:";
            // 
            // SPS101UnsubscribeButton
            // 
            SPS101UnsubscribeButton.Enabled = false;
            SPS101UnsubscribeButton.Location = new Point(1083, 85);
            SPS101UnsubscribeButton.Name = "SPS101UnsubscribeButton";
            SPS101UnsubscribeButton.Size = new Size(81, 23);
            SPS101UnsubscribeButton.TabIndex = 22;
            SPS101UnsubscribeButton.Text = "Unsubscribe";
            SPS101UnsubscribeButton.UseVisualStyleBackColor = true;
            SPS101UnsubscribeButton.Click += SPS101UnsubscribeButton_Click;
            // 
            // IF100UnsubscribeButton
            // 
            IF100UnsubscribeButton.Enabled = false;
            IF100UnsubscribeButton.Location = new Point(680, 85);
            IF100UnsubscribeButton.Name = "IF100UnsubscribeButton";
            IF100UnsubscribeButton.Size = new Size(84, 23);
            IF100UnsubscribeButton.TabIndex = 23;
            IF100UnsubscribeButton.Text = "Unsubscribe";
            IF100UnsubscribeButton.UseVisualStyleBackColor = true;
            IF100UnsubscribeButton.Click += IF100UnsubscribeButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(32, 397);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 25;
            label4.Text = "IP Address";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(412, 85);
            label1.Name = "label1";
            label1.Size = new Size(113, 21);
            label1.TabIndex = 26;
            label1.Text = "IF 100 Channel";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(412, 9);
            label3.Name = "label3";
            label3.Size = new Size(352, 47);
            label3.TabIndex = 27;
            label3.Text = "DiSUcord Client GUI";
            // 
            // DisconnectButton
            // 
            DisconnectButton.Enabled = false;
            DisconnectButton.Location = new Point(32, 540);
            DisconnectButton.Name = "DisconnectButton";
            DisconnectButton.Size = new Size(75, 23);
            DisconnectButton.TabIndex = 28;
            DisconnectButton.Text = "Disconnect";
            DisconnectButton.UseVisualStyleBackColor = true;
            DisconnectButton.Click += DisconnectButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1210, 568);
            Controls.Add(DisconnectButton);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(IF100UnsubscribeButton);
            Controls.Add(SPS101UnsubscribeButton);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(UsernameTextBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(PortTextBox);
            Controls.Add(IPTextBox);
            Controls.Add(ConnectButton);
            Controls.Add(label2);
            Controls.Add(ConnectionLogs);
            Controls.Add(SPS101SendNewMessageButton);
            Controls.Add(IF100SendNewMessageButton);
            Controls.Add(SPS101MessageTextBox);
            Controls.Add(IF100MessageTextBox);
            Controls.Add(SPS101SubscribeButton);
            Controls.Add(IF100SubscribeButton);
            Controls.Add(SPS101MessageLogs);
            Controls.Add(IF100MessageLogs);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox IF100MessageLogs;
        private RichTextBox SPS101MessageLogs;
        private Button IF100SubscribeButton;
        private Button SPS101SubscribeButton;
        private TextBox IF100MessageTextBox;
        private TextBox SPS101MessageTextBox;
        private Button IF100SendNewMessageButton;
        private Button SPS101SendNewMessageButton;
        private RichTextBox ConnectionLogs;
        private Label label2;
        private Button ConnectButton;
        private TextBox IPTextBox;
        private TextBox PortTextBox;
        private Label label5;
        private Label label6;
        private TextBox UsernameTextBox;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button SPS101UnsubscribeButton;
        private Button IF100UnsubscribeButton;
        private Label label4;
        private Label label1;
        private Label label3;
        private Button DisconnectButton;
    }
}