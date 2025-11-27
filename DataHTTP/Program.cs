
// Execute this code example in your Visual Studio or Visual Studio Code (VS Code) 
using System;
using System.Net.Http;
using System.Threading.Tasks;
class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();
        string url = "https://worldtimeapi.org/api/timezone/Etc/UTC";

        string response = await client.GetStringAsync(url);
        Console.WriteLine("Response from server:");
        Console.WriteLine(response);
    }
}
