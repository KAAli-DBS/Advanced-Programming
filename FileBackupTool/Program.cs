using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Source Directory:");
        string sourceDir = Console.ReadLine();

        Console.WriteLine("Enter Target Directory:");
        string targetDir = Console.ReadLine();

        string logFile = "backup_log.txt";
        Logger logger = new Logger(logFile);
        BackupManager manager = new BackupManager(sourceDir, targetDir, logger);

        while (true)
        {
            Console.WriteLine("=== File Backup & Synchronization Tool ===");
            Console.WriteLine("1) Full Backup");
            Console.WriteLine("2) Incremental Backup");
            Console.WriteLine("3) Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.FullBackup();
                    break;
                case "2":
                    manager.IncrementalBackup();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
