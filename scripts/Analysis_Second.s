#!/bin/bash

# job standard output will go to the file slurm-%j.out (where %j is the job ID)

#SBATCH --time=10-00:00:00   # walltime limit (HH:MM:SS)
#SBATCH --nodes=1   # number of nodes
#SBATCH --cpus-per-task=1
#SBATCH --partition=atlas    # standard node(s)
#SBATCH --job-name="pro366"
#SBATCH -A wrsggl
#SBATCH --mail-user=marcus.hooker@wsu.edu   # email address
#SBATCH --mail-type=BEGIN
#SBATCH --mail-type=END
#SBATCH --mail-type=FAIL
#SBATCH --export=ALL

module add python
module add cdhit
module add muscle
module add perl
module add r

srun --nodes=1 --cpus-per-task=1 python /project/wrsggl/Analysis/32core/filter_snips.py /project/wrsggl/Analysis/32core/21008/Analysis 0.2 3

wait