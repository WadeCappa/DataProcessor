using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Renci.SshNet;

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
                    //if (string.IsNullOrEmpty(result))
                    //{
                    //    Console.Write(result);
                    //    Console.Write("No data recovered from file count");
                    //}
                    //Console.Write(result);
                    //output = Int32.Parse(result);
                    //Console.Write(output);                 
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


        public string createUploadSlurmCommand(string path, string keypath, string targetpath, int cpus, double percentage, double percentage2, int hitcount, double rowpercentage, double colpercentage)
        {
            root = path;
            return $"touch {path}/analysis_start.s && echo '{this.createSlurmContent(keypath, targetpath, cpus, percentage, percentage2, hitcount, rowpercentage, colpercentage)}' >> {path}/analysis_start.s";
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



        private string createSlurmContent(string keypath, string targetpath, int cpus, double percentage, double percentage2, int hitcount, double rowpercentage, double colpercentage)
        {
            string slurm =
$"#!/bin/bash\n#job standard output will go to the file slurm-%j.out (where %j is the job ID)\n#SBATCH --nodes=1   # number of nodes\n#SBATCH --cpus-per-task={cpus}\n#SBATCH --job-name=pro366\n#SBATCH --export=ALL\nmodule add python2.7\nmodule add cd-hit-est\nmodule add muscle\n\nsrun --cpus-per-task={cpus} python {this.root}/TAScli.py {targetpath} {keypath} {cpus} {percentage / 100}\n\nwait";
            return slurm;
        }


    }
}


//$"#!/bin/bash # \njob standard output will go to the file slurm-%j.out (where %j is the job ID)\n#SBATCH --time=10-00:00:00   # walltime limit (HH:MM:SS)\n#SBATCH --nodes=1   # number of nodes\n#SBATCH --cpus-per-task={cpus}\n#SBATCH --job-name='pro366'\n#SBATCH --export=ALL\nmodule add python2.7\nmodule add cd-hit-est\nmodule add muscle\nmodule add R3.5.1\n\nsrun --nodes=1 --cpus-per-task={cpus} python {this.root}/TAScli.py {targetpath} {keypath} {cpus} {percentage / 100}\n\n#SBATCH --cpus-per-task=1\nsrun --nodes=1 --cpus-per-task=1 python {this.root}/filter_snips.py {this.root}/Analysis {percentage2 / 100} {hitcount}\n\n#SBATCH --cpus-per-task=1\nsrun --nodes=1 --cpus-per-task=1 python {this.root}/temp.py {this.root}/Analysis {rowpercentage / 100} {colpercentage / 100}\n\nwait";

