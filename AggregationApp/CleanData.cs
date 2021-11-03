using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Renci.SshNet;


namespace AggregationApp
{
    public partial class CleanData : Form
    {

        public Renci.SshNet.ConnectionInfo serverCredentials;
        public int processedfiles;
        private bool executeProgram;
        private int currentPanel;

        
        public CleanData()
        {
            InitializeComponent();
            executeProgram = true;
            currentPanel = 1;
        }


        public Dictionary<string, string> getFormData()
        {
            var formData = new Dictionary<string, string>()
            {
                {"path", targetFileBox.Text },
                {"keyfile", keyFileBox.Text },
                {"cpus1", cpus1.Text },
                {"percentage1", percentage1.Text },
                {"percentage2", percentage2.Text },
                {"hitcount", hitcnt1.Text },
                {"columnThreshold", threshcol.Text },
                {"rowThreshold", threshrow.Text }
            };
            return formData;            
        }


        private void btnKeyFile(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePathKey = "c:\\";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = filePathKey;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePathKey = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    keyFileBox.Text = filePathKey;
                }
            }
        }


        private void btnTargetFile(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePathTarget = "c:\\";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = filePathTarget;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePathTarget = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    targetFileBox.Text = filePathTarget;
                }
            }
        }


        private void uploadFiles(Renci.SshNet.SftpClient curConnection)
        {
            //processedfiles = curConnection.ListDirectory($"{targetFileBox.Text}").Where(file => (file.Name != ".") && (file.Name != "..") && file.Name.EndsWith(".fasta")).Count();

            string[] files = { "TAScli.py", "taswork100.py", "taswork95.py", "ChromoLocations", "filter_snps.py" };
            string filepath = @"D:\Documents\Profesional\LabJob\AggregationApp2\AggregationApp\AggregationApp\scripts\";
            curConnection.ChangeDirectory(targetFileBox.Text);

            foreach (string file in files)
            {
                using (var uplfileStream = System.IO.File.OpenRead(filepath + file))
                {
                    curConnection.UploadFile(uplfileStream, file, true);
                }
            }
        }

        private ProgressBar drawProgressPage()
        {
            ProgressBar monitorApp = new ProgressBar();
            monitorApp.Location = new Point(51, 51);
            monitorApp.Height = 23;
            monitorApp.Width = 323;

            Button cancelProgram = new Button();
            cancelProgram.Location = new Point(351, 102);
            //cancelProgram.Click = cancelProgram();

            Button finishProgram = new Button();
            finishProgram.Location = new Point(12, 102);
            finishProgram.Enabled = false;

            return monitorApp;
        }


        private void cancelProgram(object sender, EventArgs e)
        {
            executeProgram = false;
        }


        private void localRadio_CheckedChanged(object sender, EventArgs e)
        {
            targetbtn.Enabled = true;
            keybtn.Enabled = true;
        }

        private void remoteRadio_CheckedChanged(object sender, EventArgs e)
        {
            targetbtn.Enabled = false;
            keybtn.Enabled = false;           
        }

        private bool checkFormIntegreity()
        {
            if (
                errorcheck.checkIfEmpty(targetFileBox, targetFileBoxLbl) +
                errorcheck.checkIfEmpty(keyFileBox, keyFileBoxLbl) +
                errorcheck.checkIfEmpty(cpus1, cpus1Lbl) +
                errorcheck.checkIfEmpty(percentage1, percentage1Lbl) +
                errorcheck.checkIfEmpty(percentage2, percentage2Lbl) +
                errorcheck.checkIfEmpty(threshrow, threshrowLbl) +
                errorcheck.checkIfEmpty(threshcol, threshcolLbl) +
                errorcheck.checkIfEmpty(hitcnt1, hitcnt1Lbl) == 0
            )
            {
                return true;
            }
           return false;
        }

       
        private void startbtn_Click(object sender, EventArgs e)
        {

            if (checkFormIntegreity() == true)
            {
                if (remoteRadio.Checked == true)
                {
                    sign_in popup = new sign_in();
                    DialogResult dialogresult = popup.ShowDialog();
                    if (dialogresult == DialogResult.OK)
                    {
                        serverCredentials = popup.returnCredentials();
                        popup.Dispose();
                        if
                        (
                            errorcheck.findPaths(targetFileBox, targetFileBoxLbl, serverCredentials) +
                            errorcheck.findPaths(keyFileBox, keyFileBoxLbl, serverCredentials) == 0
                        )
                        {
                            Protocol exeCommands = new Protocol(targetFileBox.Text);

                            Console.Write("Before drawing new page");
                            Console.Write("Page Drawn");

                            // Next, on a new thread, monitor the progress of the SLURM script 

                            Console.Write("Before File Upload");
                            string path = targetFileBox.Text;
                            using (var client = new Renci.SshNet.SftpClient(serverCredentials))
                            {
                                client.Connect();

                                uploadFiles(client);

                                info.Text = "Uploading Scripts...";
                                int count = 5;
                                do
                                {
                                    System.Threading.Thread.Sleep(1000);
                                    progressBar1.Value += 20;
                                    count--;
                                } while (count > 0);
                                

                                client.Disconnect();
                            }

                            Console.Write("Files uploaded");

                            // On original thread, wait for user input (IE cancel)

                            //ThreadStart threadDelegate = new ThreadStart(progressbar.execute_program);
                            //Thread newThread = new Thread(threadDelegate);
                            //newThread.Start();

                            //DialogResult procResult = progressbar.ShowDialog();

                            info.Text = "Starting Analysis...";
                            progressBar1.Value = 0;
                            using (Renci.SshNet.SshClient client = new Renci.SshNet.SshClient(serverCredentials))
                            {
                                client.Connect();

                                using (SshCommand commands = client.CreateCommand($"{exeCommands.createUploadSlurmCommand(path, keyFileBox.Text, path, Int32.Parse(cpus1.Text), Double.Parse(percentage1.Text), Double.Parse(percentage2.Text), Int32.Parse(hitcnt1.Text), Double.Parse(threshrow.Text), Double.Parse(threshcol.Text))}"))
                                {
                                    var asyncExecute = commands.BeginExecute();
                                    commands.OutputStream.CopyTo(Console.OpenStandardOutput());
                                    commands.EndExecute(asyncExecute);
                                }

                                using (SshCommand commands = client.CreateCommand($"cd {path} && sbatch analysis_start.s"))
                                {
                                    // sbatch analysis_start.s
                                    var asyncExecute = commands.BeginExecute();
                                    commands.OutputStream.CopyTo(Console.OpenStandardOutput());

                                    commands.EndExecute(asyncExecute);
                                }

                                int finishedFiles = 0;
                                int totalFiles = exeCommands.countMatchingFiles(client, path, ".fastq");

                                while (true)
                                {
                                    Console.Write("loop");
                                    finishedFiles = exeCommands.countMatchingFiles(client, $"{path}/Analysis/Genotypes", ".d");
                                    System.Threading.Thread.Sleep(5000);
                                    info.Text = $"{finishedFiles} / {totalFiles}";
                                    // double calcTotal = totalFiles;
                                    // double calcFinished = finishedFiles;
                                    // int progValue = Convert.ToInt32((calcFinished / calcTotal) * 100);
                                    // progressBar1.Value = progValue;
                                }

                                exeCommands.removeFilesFromServer(client);

                                client.Disconnect();
                            }

                            // Upload slurm and python scripts to server, use scp. 
                            // The slurm files must have been edited during RUNTIME to apply changes requested by user. Build this functionality. 
                            // Keep the slurm scripts you want to run kept in a string in the raw code. Create and upload a new file with the contents you require in it at runtime. 
                            // Run the script after you upload it. 
                            // After upload use ssh to run script.
                            // Keep a continuous connection so that two-factor auth does not prevent connection. 
                            // All functionality completed after these steps. 

                        }
                    }
                    else if (dialogresult == DialogResult.Cancel)
                    {
                        popup.Dispose();
                    }
                }
            }
        }

        private void threshrow_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void threshcol_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            currentPanel--;
            updateCurrentPanel(currentPanel);
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            currentPanel++;
            updateCurrentPanel(currentPanel);
        }

        private void updateCurrentPanel(int curpanel)
        {
            switch(curpanel)
            {
                case 1:
                    backBtn.Enabled = false;
                    nextBtn.Enabled = true;
                    thirdProcessPanel.Visible = false;
                    secondProcessPanel.Visible = false;
                    startProcessPanel.Visible = false;
                    firstProcessPanel.Visible = true;
                    positionActivePanel(firstProcessPanel);
                    break;
                case 2:
                    backBtn.Enabled = true;
                    nextBtn.Enabled = true;
                    thirdProcessPanel.Visible = false;
                    secondProcessPanel.Visible = true;
                    startProcessPanel.Visible = false;
                    firstProcessPanel.Visible = false;
                    positionActivePanel(secondProcessPanel);
                    break;
                case 3:
                    backBtn.Enabled = true;
                    nextBtn.Enabled = true;
                    thirdProcessPanel.Visible = true;
                    secondProcessPanel.Visible = false;
                    startProcessPanel.Visible = false;
                    firstProcessPanel.Visible = false;
                    positionActivePanel(thirdProcessPanel);
                    break;
                case 4:
                    backBtn.Enabled = true;
                    nextBtn.Enabled = false;
                    thirdProcessPanel.Visible = false;
                    secondProcessPanel.Visible = false;
                    startProcessPanel.Visible = true;
                    firstProcessPanel.Visible = false;
                    positionActivePanel(startProcessPanel);
                    break;
            }
        }

        private void positionActivePanel(Panel inpanel)
        {
            inpanel.Location = new Point(2, 55);
        }
    }
}
