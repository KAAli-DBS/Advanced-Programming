using System;
using System.IO;

public class BackupManager
{
    private string sourceDir;
    private string targetDir;
    private Logger logger;

    public BackupManager(string source, string target, Logger log)
    {
        sourceDir = source;
        targetDir = target;
        logger = log;
    }

    public void FullBackup()
    {
        CopyAllFiles(sourceDir, targetDir);
        logger.Log("Full backup completed.");
    }

    public void IncrementalBackup()
    {
        CopyNewOrModifiedFiles(sourceDir, targetDir);
        logger.Log("Incremental backup completed.");
    }

    private void CopyAllFiles(string source, string target)
    {
        foreach (var dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
        {
            Directory.CreateDirectory(dirPath.Replace(source, target));
        }

        foreach (var newPath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
        {
            File.Copy(newPath, newPath.Replace(source, target), true);
        }
    }

    private void CopyNewOrModifiedFiles(string source, string target)
    {
        // Loop through all files in the source folder and its subfolders
        foreach (var filePath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
        {
            // Compute the corresponding target path for this file
            string targetPath = filePath.Replace(source, target);

            // Check if the file does not exist in the target, 
            // OR if it exists but has been modified since the last backup
            if (!File.Exists(targetPath) || File.GetLastWriteTime(filePath) > File.GetLastWriteTime(targetPath))
            {
                // Ensure the target folder exists before copying the file
                // Path.GetDirectoryName gets the parent folder of the file
                Directory.CreateDirectory(Path.GetDirectoryName(targetPath));

                // Copy the file to the target folder
                // The 'true' flag overwrites the file if it already exists
                File.Copy(filePath, targetPath, true);

                // Log the action: which file was copied and to where
                logger.Log($"Copied: {filePath} to {targetPath}");
            }
        }
    }

}