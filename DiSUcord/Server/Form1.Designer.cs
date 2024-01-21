
namespace Cs408_Project_Server
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.server_logs = new System.Windows.Forms.RichTextBox();
            this.serverlabel = new System.Windows.Forms.Label();
            this.active_user_logs = new System.Windows.Forms.RichTextBox();
            this.sps_log = new System.Windows.Forms.RichTextBox();
            this.if_logs = new System.Windows.Forms.RichTextBox();
            this.activelabel = new System.Windows.Forms.Label();
            this.spslabel = new System.Windows.Forms.Label();
            this.iflabel = new System.Windows.Forms.Label();
            this.portlabel = new System.Windows.Forms.Label();
            this.port_input = new System.Windows.Forms.TextBox();
            this.port_listen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // server_logs
            // 
            this.server_logs.Enabled = false;
            this.server_logs.Location = new System.Drawing.Point(10, 91);
            this.server_logs.Margin = new System.Windows.Forms.Padding(2);
            this.server_logs.Name = "server_logs";
            this.server_logs.Size = new System.Drawing.Size(181, 353);
            this.server_logs.TabIndex = 0;
            this.server_logs.Text = "";
            // 
            // serverlabel
            // 
            this.serverlabel.AutoSize = true;
            this.serverlabel.Location = new System.Drawing.Point(7, 65);
            this.serverlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.serverlabel.Name = "serverlabel";
            this.serverlabel.Size = new System.Drawing.Size(67, 13);
            this.serverlabel.TabIndex = 6;
            this.serverlabel.Text = "Server Logs:";
            // 
            // active_user_logs
            // 
            this.active_user_logs.Enabled = false;
            this.active_user_logs.Location = new System.Drawing.Point(218, 91);
            this.active_user_logs.Margin = new System.Windows.Forms.Padding(2);
            this.active_user_logs.Name = "active_user_logs";
            this.active_user_logs.Size = new System.Drawing.Size(152, 353);
            this.active_user_logs.TabIndex = 7;
            this.active_user_logs.Text = "";
            // 
            // sps_log
            // 
            this.sps_log.Enabled = false;
            this.sps_log.Location = new System.Drawing.Point(605, 91);
            this.sps_log.Margin = new System.Windows.Forms.Padding(2);
            this.sps_log.Name = "sps_log";
            this.sps_log.Size = new System.Drawing.Size(186, 353);
            this.sps_log.TabIndex = 8;
            this.sps_log.Text = "";
            // 
            // if_logs
            // 
            this.if_logs.Enabled = false;
            this.if_logs.Location = new System.Drawing.Point(403, 91);
            this.if_logs.Margin = new System.Windows.Forms.Padding(2);
            this.if_logs.Name = "if_logs";
            this.if_logs.Size = new System.Drawing.Size(177, 353);
            this.if_logs.TabIndex = 9;
            this.if_logs.Text = "";
            // 
            // activelabel
            // 
            this.activelabel.AutoSize = true;
            this.activelabel.Location = new System.Drawing.Point(215, 65);
            this.activelabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.activelabel.Name = "activelabel";
            this.activelabel.Size = new System.Drawing.Size(70, 13);
            this.activelabel.TabIndex = 10;
            this.activelabel.Text = "Active Users:";
            // 
            // spslabel
            // 
            this.spslabel.AutoSize = true;
            this.spslabel.Location = new System.Drawing.Point(619, 65);
            this.spslabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.spslabel.Name = "spslabel";
            this.spslabel.Size = new System.Drawing.Size(79, 13);
            this.spslabel.TabIndex = 11;
            this.spslabel.Text = "Sps 101  Users";
            this.spslabel.Click += new System.EventHandler(this.spslabel_Click);
            // 
            // iflabel
            // 
            this.iflabel.AutoSize = true;
            this.iflabel.Location = new System.Drawing.Point(400, 65);
            this.iflabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.iflabel.Name = "iflabel";
            this.iflabel.Size = new System.Drawing.Size(67, 13);
            this.iflabel.TabIndex = 12;
            this.iflabel.Text = "IF 100 Users";
            // 
            // portlabel
            // 
            this.portlabel.AutoSize = true;
            this.portlabel.Location = new System.Drawing.Point(7, 7);
            this.portlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.portlabel.Name = "portlabel";
            this.portlabel.Size = new System.Drawing.Size(29, 13);
            this.portlabel.TabIndex = 13;
            this.portlabel.Text = "Port:";
            // 
            // port_input
            // 
            this.port_input.Location = new System.Drawing.Point(46, 7);
            this.port_input.Margin = new System.Windows.Forms.Padding(2);
            this.port_input.Name = "port_input";
            this.port_input.Size = new System.Drawing.Size(76, 20);
            this.port_input.TabIndex = 14;
            // 
            // port_listen
            // 
            this.port_listen.Location = new System.Drawing.Point(133, 7);
            this.port_listen.Margin = new System.Windows.Forms.Padding(2);
            this.port_listen.Name = "port_listen";
            this.port_listen.Size = new System.Drawing.Size(56, 19);
            this.port_listen.TabIndex = 15;
            this.port_listen.Text = "Listen";
            this.port_listen.UseVisualStyleBackColor = true;
            this.port_listen.Click += new System.EventHandler(this.port_listen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(241, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 37);
            this.label1.TabIndex = 16;
            this.label1.Text = "DiSUcord Server GUI";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 519);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.port_listen);
            this.Controls.Add(this.port_input);
            this.Controls.Add(this.portlabel);
            this.Controls.Add(this.iflabel);
            this.Controls.Add(this.spslabel);
            this.Controls.Add(this.activelabel);
            this.Controls.Add(this.if_logs);
            this.Controls.Add(this.sps_log);
            this.Controls.Add(this.active_user_logs);
            this.Controls.Add(this.serverlabel);
            this.Controls.Add(this.server_logs);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox server_logs;
        private System.Windows.Forms.Label serverlabel;
        private System.Windows.Forms.RichTextBox active_user_logs;
        private System.Windows.Forms.RichTextBox sps_log;
        private System.Windows.Forms.RichTextBox if_logs;
        private System.Windows.Forms.Label activelabel;
        private System.Windows.Forms.Label spslabel;
        private System.Windows.Forms.Label iflabel;
        private System.Windows.Forms.Label portlabel;
        private System.Windows.Forms.TextBox port_input;
        private System.Windows.Forms.Button port_listen;
        private System.Windows.Forms.Label label1;
    }
}

