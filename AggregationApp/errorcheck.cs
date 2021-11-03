using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace AggregationApp
{
    class errorcheck
    {
        public static Color errColor = Color.Red;

        static public int checkIfEmpty(MyMaskedBox inbox, Label inlabel)
        {
            if (inbox.Text == "" && inbox.Enabled == true)
            {
                inlabel.ForeColor = errColor;
                inbox.BorderColor = errColor;
                return 1;
            }
            else
            {
                inlabel.ForeColor = default;
                inbox.BorderColor = default;
                return 0;
            }
        }

        static public int findPaths(MyMaskedBox inbox, Label inlabel, Renci.SshNet.ConnectionInfo creds)
        {
            using (var client = new Renci.SshNet.SshClient(creds))
            {
                client.Connect();

                Renci.SshNet.SshCommand checkFile = client.CreateCommand($"[[ -f {inbox.Text} ]] && echo 'exists'");
                string fileExist = checkFile.Execute();

                Renci.SshNet.SshCommand checkDIR = client.CreateCommand($"[ -d {inbox.Text} ] && echo 'exists'");
                string dirExists = checkDIR.Execute();

                if (fileExist != "exists\n" && dirExists != "exists\n")
                {
                    client.Disconnect();
                    inlabel.ForeColor = errColor;
                    inbox.BorderColor = errColor;
                    return 1;
                }
                client.Disconnect();
                inlabel.ForeColor = default;
                inbox.BorderColor = default;
                return 0;            
            }
        }
    }
}
