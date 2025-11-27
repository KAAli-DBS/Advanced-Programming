using System;
using System.IO;
using System.Text;
class Example
{
    static void Main()
    {
        // Pretend this is data coming from a client
        string messageFromClient = "Hello DBS-Server!";
        byte[] data = Encoding.UTF8.GetBytes(messageFromClient);

        // A MemoryStream acts like a network stream for demonstration
        MemoryStream stream = new MemoryStream(data);

        // ---- Your lines start here ----
        byte[] buffer = new byte[1024];                 // Step 1: Create empty buffer
        int bytesRead = stream.Read(buffer, 0, 1024);   // Step 2: Read bytes into the buffer

        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);  // Step 3: Convert bytes → text

        Console.WriteLine("Received: " + receivedMessage); // Step 4: Show result
        // ---- Your lines end here ----

        // Print the raw bytes
        Console.Write("Raw bytes: ");
        for (int i = 0; i < bytesRead; i++)
        {
            Console.Write(buffer[i] + " ");
        }
        Console.WriteLine();
    }
}