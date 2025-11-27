using System;
using System.Net.NetworkInformation;

class Program
{
    static void Main()
    {
        Console.Write("Enter hostname or IP to ping: ");
        string host = Console.ReadLine();

        Ping ping = new Ping();
        PingReply reply = ping.Send(host);

        if (reply.Status == IPStatus.Success)
        {
            Console.WriteLine($"Ping successful. Roundtrip time: {reply.RoundtripTime} ms");
        }
        else
        {
            Console.WriteLine("Ping failed.");
        }
    }
}