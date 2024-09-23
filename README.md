### CopyFilesToTargetPath

  This program was made because oftentimes while modding, I found myself in a situation where I needed to copy 1 or 2 files repeatedly into 10+ unique directories and having to do it often made me want to (unalive) myself.  

####   Please note, this program requires dotnet 8 to run!

  # Usage

Drag and drop a file into the program, the following operations will be done:  
- the program will look for target (relative) paths where the input file originates from on a target_paths.txt file
- the program will save all files in the input file directory that have the same extension as the input file
- the files will then be copied to every path located in target_paths

# Example  
Say we have the following paths in our target_paths.txt  

    message\cn\cnch
    message\eu\eude
    message\eu\euen
    message\eu\eues
    message\eu\eufr
    message\eu\euit
    message\jp\jpja
    message\kr\krko
    message\tw\twch
    message\us\usen
    message\us\uses
    message\us\usfr

We will now show an exampe using these paths with .msbt files

![](https://i.imgur.com/csRbFA8.png)  

Here we have our msbt file and our target paths txt file.
We would then drag and drop this msbt file into the program, and it would create and copy all the files with the same extension as the input file (in this case it would copy all .msbt files if we had multiple) into all of the target directories, resulting in this now:  

![](https://i.imgur.com/OkZ1uQ1.png)
![](https://i.imgur.com/OraotRQ.png)
![](https://i.imgur.com/FzB9wOh.png)
![](https://i.imgur.com/oPEy3aq.png)
