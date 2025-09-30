using System;
using System.IO;

public class Logger
{
    private string logFilePath;

    public Logger(string logFile)
    {
        logFilePath = logFile;
    }

    public void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}
