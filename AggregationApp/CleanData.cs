using System;
using System.Collections.Generic;

using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

using System.Data;
using Renci.SshNet;

using System.IO;
using System.Threading.Tasks;

using Renci.SshNet.Common;
using Renci.SshNet.Sftp;


namespace AggregationApp
{
    public partial class CleanData : Form
    {

        public Renci.SshNet.ConnectionInfo serverCredentials;
        private string localScriptPath = "";
        Renci.SshNet.SftpClient current_client;
        Renci.SshNet.SshClient ssh_client;
        private Protocol curProtocol;
        public int processedfiles;
        private int currentPanel;

        private int total_directories = 0;
        private int completed_directories = 0;
        private string slurm_process;

        private int files_done;
        private int files_todo;

        private float global_progress;

        public CleanData()
        {
            InitializeComponent();
            currentPanel = 1;
        }

        public Dictionary<string, string> getFormData()
        {
            var formData = new Dictionary<string, string>()
            {
                { "path", targetFileBox.Text },
                { "keyfile", keyFileBox.Text },
                { "cpus1", cpus1.Text },
                { "percentage1", percentage1.Text },
                { "percentage2", percentage2.Text },
                { "hitcount", hitcnt1.Text },
                { "columnThreshold", threshcol.Text },
                { "rowThreshold", threshrow.Text },
                { "scriptPath", scriptDirectoryBox.Text }
            };
            return formData;            
        }


        private void scriptbtn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePathScript = "c:\\";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = filePathScript;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePathScript = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    scriptDirectoryBox.Text = filePathScript;
                }
            }
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



        private void cancelProgram(object sender, EventArgs e)
        {

        }


        private void localRadio_CheckedChanged(object sender, EventArgs e)
        {
            targetbtn.Enabled = true;
            keybtn.Enabled = true;
            scriptDirectoryBox.Enabled = false;
            scriptDirectoryBoxLbl.Enabled = false;

            cpus1.Enabled = false;
            cpus1Lbl.Enabled = false;

            info.Text = "WARNING: Local process is single-threaded! This will take a very long time.";
        }

        private void remoteRadio_CheckedChanged(object sender, EventArgs e)
        {
            targetbtn.Enabled = false;
            keybtn.Enabled = false;
            scriptDirectoryBox.Enabled = true;
            scriptDirectoryBoxLbl.Enabled = true;

            cpus1.Enabled = true;
            cpus1Lbl.Enabled = true;

            info.Text = "This process will take a few hours.";
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
                errorcheck.checkIfEmpty(scriptDirectoryBox, scriptDirectoryBoxLbl) +
                errorcheck.checkIfEmpty(hitcnt1, hitcnt1Lbl) +
                errorcheck.checkCorrectThreshold(percentage1, percentage1Lbl) == 0
            )
            {
                return true;
            }
       
            currentPanel = 1;
            updateCurrentPanel(1);
            
            return false;
        }



       
        private void startbtn_Click(object sender, EventArgs e)
        {
            if (checkFormIntegreity() == true)
            {
                localScriptPath = $@"{Environment.CurrentDirectory}\scripts\";
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
                            errorcheck.findPaths(scriptDirectoryBox, scriptDirectoryBoxLbl, serverCredentials) +
                            errorcheck.findPaths(keyFileBox, keyFileBoxLbl, serverCredentials) == 0
                        )
                        {
                            cancelbtn.Enabled = true;
                            backBtn.Enabled = false;
                            startbtn.Enabled = false;

                            Protocol exeCommands = new Protocol(targetFileBox.Text);
                            curProtocol = exeCommands;
                            string path = targetFileBox.Text;
                            string scriptPath = scriptDirectoryBox.Text;



                            try
                            {
                                ssh_client = new Renci.SshNet.SshClient(serverCredentials);
                                ssh_client.Connect();

                                try
                                {
                                    var client = new Renci.SshNet.SftpClient(serverCredentials);
                                    client.Connect();
                                    current_client = client;

                                    try
                                    {
                                        remoteProcess.RunWorkerAsync(client);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Background Process FAILED; unknown error.");
                                    }
                                    
                                }
                                catch
                                {
                                    MessageBox.Show("Unexpected error occured while connecting to server.\nCheck your internet connection and try again.");
                                }
                            }

                            catch
                            {
                                MessageBox.Show("Unexpected error occured while connecting to server.\nCheck your internet connection and try again.");
                            }

                            // secondary thread, starts the program


                            info.Text = "Processing Files. This may take some time...";
                            
     

                        }
                        else
                        {
                            currentPanel = 1;
                            updateCurrentPanel(1);
                        }
                    }
                    else if (dialogresult == DialogResult.Cancel)
                    {
                        popup.Dispose();
                    }
                }
                else if 
                (
                    errorcheck.findLocalPaths(keyFileBox, keyFileBoxLbl) +
                    errorcheck.findLocalPaths(targetFileBox, targetFileBoxLbl) == 0
                )
                {
                    Console.Write(Directory.GetCurrentDirectory());
                    Console.Write("local process starting...\n");
                    localProcess.RunWorkerAsync();
                }
                else
                {
                    currentPanel = 1;
                    updateCurrentPanel(1);
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

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void remoteRadio_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private Protocol getProtocol()
        {
            return curProtocol;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;


            e.Result = recordProgress((Renci.SshNet.SftpClient)e.Argument, worker, e);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {                
                info.Text = "Operation Ended";
                progressBar1.Value = 0;
            }
            else
            {

                info.Text = "Operation Successful";
            }

            Console.Write("Testing this exit point\n");

            Protocol exeCommands = getProtocol();

            Console.Write($"scancel {slurm_process}");
         
            using (SshCommand commands = ssh_client.CreateCommand($"scancel {slurm_process}"))
            {
                var asyncExecute = commands.BeginExecute();
                commands.OutputStream.CopyTo(Console.OpenStandardOutput());
                commands.EndExecute(asyncExecute);
            }
            Console.Write("scancel success!\n");

            exeCommands.deleteFiles(current_client, scriptDirectoryBox.Text);           

            current_client.Disconnect();
            ssh_client.Disconnect();

            if (global_progress < 100 && e.Cancelled == false)
            {
                MessageBox.Show("Fatal Error; Check keyfile and .fasta/.fastq paths.");
                info.Text = "Operation Failed!";
            }

            cancelbtn.Enabled = false;
            backBtn.Enabled = true;
            startbtn.Enabled = true;

        }

        int recordProgress( Renci.SshNet.SftpClient client, BackgroundWorker worker, DoWorkEventArgs e)
        {
            Protocol exeCommands = getProtocol();

            exeCommands.uploadFiles(client, scriptDirectoryBox.Text, info, progressBar1);

            Dictionary<string, string> formData = getFormData();

            using (SshCommand commands = ssh_client.CreateCommand($"{exeCommands.createUploadSlurmCommand(formData["path"], formData["keyfile"], formData["scriptPath"], Int32.Parse(formData["cpus1"]), Double.Parse(formData["percentage1"]), Double.Parse(formData["percentage2"]), Int32.Parse(formData["hitcount"]), Double.Parse(formData["rowThreshold"]), Double.Parse(formData["columnThreshold"]))}"))
            {
                var asyncExecute = commands.BeginExecute();
                commands.OutputStream.CopyTo(Console.OpenStandardOutput());
                System.Threading.Thread.Sleep(1500);
                commands.EndExecute(asyncExecute);
            }

            using (SshCommand commands = ssh_client.CreateCommand($"cd {formData["scriptPath"]} && sbatch analysis_start.s"))
            {
                var asyncExecute = commands.BeginExecute();
                commands.OutputStream.CopyTo(Console.OpenStandardOutput());
                System.Threading.Thread.Sleep(500);
                commands.EndExecute(asyncExecute);
            }

            progressBar1.Value = 0;

            total_directories = exeCommands.count_files(client, targetFileBox.Text, ".fastq");
            completed_directories = exeCommands.count_files(client, $"{targetFileBox.Text}/Analysis/Genotypes", ".fastq.d");
            string filePath;

            // Get name of slurm

            getSizeOfSlurm(client);
            long current_size = -1;
            System.Threading.Thread.Sleep(20000);
            Console.Write($"Slurm Process; {slurm_process}\n");
            int attempts = 0;
            int threshold = 10;

            while (attempts < threshold)
            {
                if (getSizeOfSlurm(client) > current_size)
                {
                    attempts = 0;
                    current_size = getSizeOfSlurm(client);
                }
                else
                {
                    attempts++;
                }

                if (worker.CancellationPending)
                {
                    Console.Write("Cancelation Pending\n");
                    e.Cancel = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(5000);
                    completed_directories = exeCommands.count_files(client, $"{targetFileBox.Text}/Analysis/Genotypes", ".fastq.d");
                    Console.Write("Monitoring Progress...\n");                    
                    Console.Write(completed_directories.ToString());
                    float percentage = (float)completed_directories / (float)total_directories;
                    Console.Write($"Percentage:{percentage * 100}%\n");
                    worker.ReportProgress((int)(percentage * 100));
                }
            }
            
            return 0;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.Write(e.ProgressPercentage.ToString());
            this.progressBar1.Value = e.ProgressPercentage;
            info.Text = $"Processed {e.ProgressPercentage}% of target files...";
            global_progress = e.ProgressPercentage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            remoteProcess.CancelAsync();
            localProcess.CancelAsync();

            cancelbtn.Enabled = false;
            info.Text = "Exiting process...";
        }

        private void CleanData_Load(object sender, EventArgs e)
        {

        }


        int recordLocalProgress(BackgroundWorker worker, DoWorkEventArgs e)
        {
            Protocol exeCommands = getProtocol();

            files_todo = Directory.GetFiles(targetFileBox.Text, "*.fastq", SearchOption.TopDirectoryOnly).Length;

            Process.Start(
                $@"python {localScriptPath}/TAScli.py {targetFileBox.Text} {keyFileBox.Text} {cpus1.Text} {Int32.Parse(percentage1.Text) / 100}"
            );

            progressBar1.Value = 0;

            files_done = Directory.GetFiles($"{targetFileBox.Text}/Analysis/Genotypes", "*.fastq.d", SearchOption.TopDirectoryOnly).Length;

            while (files_todo > files_done)
            {
                if (worker.CancellationPending)
                {
                    Console.Write("Cancelation Pending");
                    e.Cancel = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(5000);
                    files_done = Directory.GetFiles($"{targetFileBox.Text}/Analysis/Genotypes", "*.fastq.d", SearchOption.TopDirectoryOnly).Length;
                    Console.Write(files_done.ToString());
                    float percentage = (float)files_todo / (float)files_done;
                    Console.Write($"Percentage:{percentage * 100}%\n");
                    worker.ReportProgress((int)(percentage * 100));
                }
            }
            return 0;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            e.Result = recordLocalProgress(worker, e);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                info.Text = "Operation Ended";
                progressBar1.Value = 0;
            }
            else if (e.Cancelled)
            {

                info.Text = "Canceled";
            }
            else
            {
                info.Text = "Operation Successful";
            }


            Process.Start(
                    "python",
                    "import sys\nsys.exit()"
                );

            Console.Write("Cancel success!\n");
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            info.Text = $"Processed {e.ProgressPercentage}% of target files...";
        }

        private void threshcolLbl_Click(object sender, EventArgs e)
        {

        }


        private long getSizeOfSlurm(Renci.SshNet.SftpClient client)
        {
            long file_size = 0;
            foreach (SftpFile file in client.ListDirectory(scriptDirectoryBox.Text))
            {
                if ((file.Name != ".") && (file.Name != "..") && file.Name.EndsWith(".out"))
                {
                    slurm_process = file.Name.Substring(6, file.Name.Length - 10);
                    file_size = file.Attributes.Size;
                    string filePath = $"{scriptDirectoryBox.Text}/{file.Name}\n";
                    Console.Write($"Size of {filePath}: {file_size}\n");

                }
            }
            return file_size;
        }



    }
}
