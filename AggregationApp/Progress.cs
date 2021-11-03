using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace AggregationApp
{
    public partial class Progress : Form
    {
        Dictionary<string, string> formData;
        Renci.SshNet.SshClient curClient;

        public Progress(Renci.SshNet.SshClient inClient, Dictionary<string, string> inData)
        {
            Console.Write("In consutrcotr");
            InitializeComponent();

            formData = inData;
            curClient = inClient;
            
        }

        public void execute_program()
        {
            Protocol exeCommands = new Protocol(formData["path"]);
            Label tempReadout = new Label();
            this.Controls.Add(tempReadout);
            tempReadout.Top = 200;
            tempReadout.Left = 200;
            tempReadout.Text = "eeee";

            using (SshCommand commands = curClient.CreateCommand($"{exeCommands.createUploadSlurmCommand(formData["path"], formData["keyfile"], formData["path"], Int32.Parse(formData["cpus1"]), Double.Parse(formData["percentage1"]), Double.Parse(formData["percentage1"]), Int32.Parse(formData["hitcount"]), Double.Parse(formData["rowThreshold"]), Double.Parse(formData["columnThreshold"]))}"))
            {
                var asyncExecute = commands.BeginExecute();
                commands.OutputStream.CopyTo(Console.OpenStandardOutput());
                commands.EndExecute(asyncExecute);
            }

            using (SshCommand commands = curClient.CreateCommand($"cd {formData["path"]} && echo e "))
            {
                // sbatch analysis_start.s
                var asyncExecute = commands.BeginExecute();
                commands.OutputStream.CopyTo(Console.OpenStandardOutput());

                while (true)
                {
                    Console.Write("loop");
                    exeCommands.countMatchingFiles(curClient, formData["path"], ".fastq");
                    System.Threading.Thread.Sleep(2500);
                    tempReadout.Text += "eeeee";
                    //tempReadout.Text = $"{exeCommands.countMatchingFiles(curClient, formData["path"], ".fastq")} / {exeCommands.countMatchingFiles(curClient, $"{formData["path"]}/Analysis/Genotypes", ".d")}";
                }

                commands.EndExecute(asyncExecute);
            }

            using (SshCommand commands = curClient.CreateCommand(exeCommands.deleteAllFiles()))
            {
                var asyncExecute = commands.BeginExecute();
                commands.OutputStream.CopyTo(Console.OpenStandardOutput());
                commands.EndExecute(asyncExecute);
            }

            try
            {
                //using (var client = new Renci.SshNet.SftpClient(serverCredentials))
                //{
                //    client.Connect();
                //    int processedFilesCount = client.ListDirectory($"{path}/Analysis/Genotypes").Where(file => (file.Name != ".") && (file.Name != "..") && file.Name.EndsWith(".d")).Count();
                //    int unprocessedFiles = client.ListDirectory($"{path}").Where(file => (file.Name != ".") && (file.Name != "..") && file.Name.EndsWith(".fasta")).Count();

                //    while (processedFilesCount < unprocessedFiles)
                //    {
                //        progressBar1.Value = processedFilesCount / unprocessedFiles;

                //        System.Threading.Thread.Sleep(5000);

                //        processedFilesCount = client.ListDirectory($"{path}/Analysis/Genotypes").Where(file => (file.Name != ".") && (file.Name != "..") && file.Name.EndsWith(".d")).Count();
                //        unprocessedFiles = client.ListDirectory($"{path}").Where(file => (file.Name != ".") && (file.Name != "..") && file.Name.EndsWith(".fasta")).Count();
                //    }

                //    client.Disconnect();
                //}
            }
            catch
            {

            }
        }

        private void Progress_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }


    }
}


