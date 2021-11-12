using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Renci.SshNet;

using System.Reflection;

using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;

using Renci.SshNet.Common;
using Renci.SshNet.Sftp;

namespace AggregationApp
{
    class Protocol
    {


        private string root;

        public Protocol(string path)
        {
            root = path;
        }


        public int countMatchingFiles(Renci.SshNet.SshClient curClient, string path, string extension)
        {
            int output = 0;
            string commandOutput = "";
            using (SshCommand commands = curClient.CreateCommand($"find {path} -mindepth 1 -type f -name '*{extension}' -printf x | wc -c"))
            {
                var asyncExecute = commands.BeginExecute();
                commands.OutputStream.CopyTo(Console.OpenStandardOutput());
                    
                using(var reader = new StreamReader(commands.OutputStream, Encoding.UTF8))
                {
                    Console.Write("In Loop");
                    string result = reader.ReadToEnd();
                    commandOutput += result;
                    Console.Write($"\nstring output from sshcounting command; {commandOutput}");
                    Console.Write(result);               
                }
                Console.Write(commandOutput);

                foreach (char c in commandOutput)
                {
                    Console.Write($"Character: {c}\n");
                    Console.WriteLine(c.ToString());
                    if (char.IsDigit(c))
                    {
                        output *= 10;
                        output += Int32.Parse(char.ToString(c));
                        Console.Write($"character: {c}, output: {output}\n");
                    }
                }

                //commands.EndExecute(asyncExecute);
                
                Console.Write($"Outputing Count results; for {path} with extension {extension}: {output}\n");
                return output;
            }
        }


        public string createUploadSlurmCommand(string path, string keypath, string scriptPath, int cpus, double percentage, double percentage2, int hitcount, double rowpercentage, double colpercentage)
        {
            root = path;
            return $"touch {scriptPath}/analysis_start.s && echo '{this.createSlurmContent(keypath, path, scriptPath, cpus, percentage, percentage2, hitcount, rowpercentage, colpercentage)}' >> {scriptPath}/analysis_start.s";
        }


        public string deleteAllFiles()
        {
            return ($@"rm {root}/TAScli.py && rm {root}/taswork100.py && rm {root}/taswork95.py && rm {root}/ChromoLocations && rm {root}/filter_snps.py && rm {root}/analysis_start.s");
        }


        public void removeFilesFromServer(Renci.SshNet.SshClient inClient)
        {
            using (SshCommand commands = inClient.CreateCommand(deleteAllFiles()))
            {
                var asyncExecute = commands.BeginExecute();
                commands.OutputStream.CopyTo(Console.OpenStandardOutput());
                commands.EndExecute(asyncExecute);
            }
        }



        public int updateProgressBar(ProgressBar inbar, Renci.SshNet.SshClient curClient, string pathToAnalysis, string pathToTarget)
        {
            inbar.Value = (countMatchingFiles(curClient, pathToTarget, ".fastq") / countMatchingFiles(curClient, pathToAnalysis, ".d")) * 100;
            return inbar.Value;
        }



        private string createSlurmContent(string keypath, string targetpath, string scriptPath, int cpus, double percentage, double percentage2, int hitcount, double rowpercentage, double colpercentage)
        {
            string slurm =
$"#!/bin/bash\n#job standard output will go to the file slurm-%j.out (where %j is the job ID)\n#SBATCH --nodes=1   # number of nodes\n#SBATCH --cpus-per-task={cpus}\n#SBATCH --job-name=pro366\n#SBATCH --export=ALL\nmodule add python2.7\nmodule add cd-hit-est\nmodule add muscle\n\nsrun --cpus-per-task={cpus} python {scriptPath}/TAScli.py {targetpath} {keypath} {cpus} {percentage / 100}\n\nwait";
            return slurm;
        }

        public int count_files(Renci.SshNet.SftpClient curClient, string path, string criteria)
        {
            int count = 0;
            try
            {
                foreach (SftpFile file in curClient.ListDirectory(path))
                {
                    if ((file.Name != ".") && (file.Name != "..") && file.Name.EndsWith(criteria))
                    {
                        count += 1;
                    }
                }
                Console.Write($"{count} files found with criteria {criteria}\n");
                return count;
            }
            catch
            {
                Console.Write($"Count files with criteria '{criteria}' FAILED\n");
                return 0;
            }
            Console.Write("This should never be printed\n");

        }


        public void deleteFiles(Renci.SshNet.SftpClient curConnection, string path)
        {
            foreach (SftpFile file in curConnection.ListDirectory(path))
            {
                if ((file.Name != ".") && (file.Name != "..") )
                {
                    Console.Write($"{file.Name} --- {path}/{file.Name}");
                    curConnection.DeleteFile($"{path}/{file.Name}");
                }
            }
        }


        public void uploadFiles(Renci.SshNet.SftpClient curConnection, string path, Label statusLabel, ProgressBar trackPogress)
        {
            //processedfiles = curConnection.ListDirectory($"{targetFileBox.Text}").Where(file => (file.Name != ".") && (file.Name != "..") && file.Name.EndsWith(".fasta")).Count();
            string[] files = { "TAScli.py", "taswork100.py", "taswork95.py", "ChromoLocations", "filter_snps.py" };
            string filepath = $@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\scripts\";
            Console.Write(filepath);

            // curConnection.CreateDirectory($"{path}/Scripts");
            try
            {
                curConnection.ChangeDirectory(path);

                foreach (string file in files)
                {
                    using (var uplfileStream = System.IO.File.OpenRead(filepath + file))
                    {
                        curConnection.UploadFile(uplfileStream, file, true);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            catch
            {
                MessageBox.Show($"Script path does not exist! at path {filepath}");
            }


        }


    }
}




//$"#!/bin/bash # \njob standard output will go to the file slurm-%j.out (where %j is the job ID)\n#SBATCH --time=10-00:00:00   # walltime limit (HH:MM:SS)\n#SBATCH --nodes=1   # number of nodes\n#SBATCH --cpus-per-task={cpus}\n#SBATCH --job-name='pro366'\n#SBATCH --export=ALL\nmodule add python2.7\nmodule add cd-hit-est\nmodule add muscle\nmodule add R3.5.1\n\nsrun --nodes=1 --cpus-per-task={cpus} python {this.root}/TAScli.py {targetpath} {keypath} {cpus} {percentage / 100}\n\n#SBATCH --cpus-per-task=1\nsrun --nodes=1 --cpus-per-task=1 python {this.root}/filter_snips.py {this.root}/Analysis {percentage2 / 100} {hitcount}\n\n#SBATCH --cpus-per-task=1\nsrun --nodes=1 --cpus-per-task=1 python {this.root}/temp.py {this.root}/Analysis {rowpercentage / 100} {colpercentage / 100}\n\nwait";

