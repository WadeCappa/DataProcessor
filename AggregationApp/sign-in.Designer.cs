
namespace AggregationApp
{
    partial class sign_in
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
            this.cancel = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.serverIPLbl = new System.Windows.Forms.Label();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.resp = new System.Windows.Forms.Panel();
            this.conbtn = new System.Windows.Forms.Button();
            this.respLbl = new System.Windows.Forms.Label();
            this.privatePasswordLbl = new System.Windows.Forms.Label();
            this.authBox = new System.Windows.Forms.CheckBox();
            this.privatePassword = new AggregationApp.MyMaskedBox();
            this.password = new AggregationApp.MyMaskedBox();
            this.username = new AggregationApp.MyMaskedBox();
            this.serverIP = new AggregationApp.MyMaskedBox();
            this.resp.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(12, 272);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(310, 272);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 4;
            this.login.Text = "Connect";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // serverIPLbl
            // 
            this.serverIPLbl.AutoSize = true;
            this.serverIPLbl.Location = new System.Drawing.Point(12, 8);
            this.serverIPLbl.Name = "serverIPLbl";
            this.serverIPLbl.Size = new System.Drawing.Size(51, 13);
            this.serverIPLbl.TabIndex = 2;
            this.serverIPLbl.Text = "Server IP";
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(12, 58);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(57, 13);
            this.usernameLbl.TabIndex = 3;
            this.usernameLbl.Text = "UserName";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(12, 108);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(53, 13);
            this.passwordLbl.TabIndex = 4;
            this.passwordLbl.Text = "Password";
            // 
            // resp
            // 
            this.resp.BackColor = System.Drawing.Color.Red;
            this.resp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resp.Controls.Add(this.conbtn);
            this.resp.Controls.Add(this.respLbl);
            this.resp.Location = new System.Drawing.Point(12, 221);
            this.resp.Name = "resp";
            this.resp.Size = new System.Drawing.Size(373, 30);
            this.resp.TabIndex = 29;
            this.resp.Visible = false;
            // 
            // conbtn
            // 
            this.conbtn.Location = new System.Drawing.Point(221, 2);
            this.conbtn.Name = "conbtn";
            this.conbtn.Size = new System.Drawing.Size(75, 23);
            this.conbtn.TabIndex = 6;
            this.conbtn.Text = "OK";
            this.conbtn.UseVisualStyleBackColor = true;
            this.conbtn.Visible = false;
            this.conbtn.Click += new System.EventHandler(this.conbtn_Click);
            // 
            // respLbl
            // 
            this.respLbl.AutoSize = true;
            this.respLbl.Location = new System.Drawing.Point(77, 7);
            this.respLbl.Name = "respLbl";
            this.respLbl.Size = new System.Drawing.Size(13, 13);
            this.respLbl.TabIndex = 0;
            this.respLbl.Text = "e";
            // 
            // privatePasswordLbl
            // 
            this.privatePasswordLbl.AutoSize = true;
            this.privatePasswordLbl.Enabled = false;
            this.privatePasswordLbl.Location = new System.Drawing.Point(12, 158);
            this.privatePasswordLbl.Name = "privatePasswordLbl";
            this.privatePasswordLbl.Size = new System.Drawing.Size(181, 13);
            this.privatePasswordLbl.TabIndex = 31;
            this.privatePasswordLbl.Text = "Two Factor Authentication Password";
            // 
            // authBox
            // 
            this.authBox.AutoSize = true;
            this.authBox.Location = new System.Drawing.Point(221, 177);
            this.authBox.Name = "authBox";
            this.authBox.Size = new System.Drawing.Size(151, 17);
            this.authBox.TabIndex = 32;
            this.authBox.Text = "Two Factor Authentication";
            this.authBox.UseVisualStyleBackColor = true;
            this.authBox.CheckedChanged += new System.EventHandler(this.authBox_CheckedChanged);
            // 
            // privatePassword
            // 
            this.privatePassword.BorderColor = System.Drawing.Color.Black;
            this.privatePassword.Enabled = false;
            this.privatePassword.Location = new System.Drawing.Point(12, 175);
            this.privatePassword.Name = "privatePassword";
            this.privatePassword.Size = new System.Drawing.Size(181, 20);
            this.privatePassword.TabIndex = 30;
            // 
            // password
            // 
            this.password.BorderColor = System.Drawing.Color.Black;
            this.password.Location = new System.Drawing.Point(12, 125);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(373, 20);
            this.password.TabIndex = 3;
            this.password.Text = "P0@c32e5!#";
            this.password.UseSystemPasswordChar = true;
            // 
            // username
            // 
            this.username.BorderColor = System.Drawing.Color.Black;
            this.username.Location = new System.Drawing.Point(12, 75);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(373, 20);
            this.username.TabIndex = 2;
            this.username.Text = "wrsggl";
            // 
            // serverIP
            // 
            this.serverIP.BorderColor = System.Drawing.Color.Black;
            this.serverIP.Location = new System.Drawing.Point(12, 25);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(373, 20);
            this.serverIP.TabIndex = 1;
            this.serverIP.Text = "134.121.93.107";
            // 
            // sign_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 307);
            this.Controls.Add(this.authBox);
            this.Controls.Add(this.privatePasswordLbl);
            this.Controls.Add(this.privatePassword);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.resp);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.usernameLbl);
            this.Controls.Add(this.serverIPLbl);
            this.Controls.Add(this.login);
            this.Controls.Add(this.cancel);
            this.Name = "sign_in";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.resp.ResumeLayout(false);
            this.resp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label serverIPLbl;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Panel resp;
        private System.Windows.Forms.Button conbtn;
        private System.Windows.Forms.Label respLbl;
        private MyMaskedBox serverIP;
        private MyMaskedBox username;
        private MyMaskedBox password;
        private MyMaskedBox privatePassword;
        private System.Windows.Forms.Label privatePasswordLbl;
        private System.Windows.Forms.CheckBox authBox;
    }
}