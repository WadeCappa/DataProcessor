using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AggregationApp
{

    public partial class sign_in : Form
    {
        public string inputIP;
        public string inputUserName;
        public string inputPassword;
        private Renci.SshNet.ConnectionInfo serverCredentials;

        private IDictionary<string, string> remoteCredentials = new Dictionary<string, string>();


        public Renci.SshNet.ConnectionInfo returnCredentials()
        {
            return serverCredentials;
        }

        public sign_in()
        {
            InitializeComponent();
        }


        private void login_Click(object sender, EventArgs e)
        {
            resp.Visible = false;
            if 
            (
                errorcheck.checkIfEmpty(serverIP, serverIPLbl) +
                errorcheck.checkIfEmpty(username, usernameLbl) +
                errorcheck.checkIfEmpty(privatePassword, privatePasswordLbl) +
                errorcheck.checkIfEmpty(password, passwordLbl) == 0
            )
            {
                serverCredentials = new Renci.SshNet.ConnectionInfo(
                    serverIP.Text,
                    username.Text,
                    new Renci.SshNet.PasswordAuthenticationMethod(username.Text, password.Text)
                );

                if (authBox.Checked == true)
                {
                    serverCredentials = new Renci.SshNet.ConnectionInfo (
                        serverIP.Text,
                        username.Text,
                        new Renci.SshNet.PasswordAuthenticationMethod(username.Text, password.Text),
                        new Renci.SshNet.PrivateKeyAuthenticationMethod(privatePassword.Text)
                    );
                }
 

                using (var client = new Renci.SshNet.SftpClient(serverCredentials))
                {
                    try
                    {
                        client.Connect();
                        if (client.IsConnected)
                        {
                            resp.Visible = true;
                            respLbl.Text = "Connected Successfully";
                            conbtn.Visible = true;
                            conbtn.DialogResult = DialogResult.OK;
                            resp.BackColor = Color.LightGreen;
                            inputIP = serverIP.Text;
                            inputUserName = username.Text;
                            inputPassword = password.Text;
                            client.Disconnect();
                        }
                    }
                    catch
                    {
                        resp.Visible = true;
                        respLbl.Text = "Could Not Connect";
                        resp.BackColor = Color.OrangeRed;
                    }
                }
            }
        }

        private void conbtn_Click(object sender, EventArgs e)
        {
            remoteCredentials.Add("IP", inputIP);
            remoteCredentials.Add("username", inputUserName);
            remoteCredentials.Add("password", inputPassword);
            //return (remoteCredentials);
        }


        private void authBox_CheckedChanged(object sender, EventArgs e)
        {
            if (authBox.Checked == true)
            {
                privatePassword.Enabled = true;
                privatePasswordLbl.Enabled = true;
            }
            else
            {
                privatePassword.Enabled = false;
                privatePasswordLbl.Enabled = false;
            }
        }
    }
}
