using System;
using System.Net.Sockets;
using System.Reflection;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Enter target IP or hostname: ");
        string host = Console.ReadLine();

        Console.Write("Enter start port: ");
        int startPort = int.Parse(Console.ReadLine());

        Console.Write("Enter end port: ");
        int endPort = int.Parse(Console.ReadLine());

        Console.WriteLine($"\nScanning {host} from port {startPort} to {endPort}...\n");

        var tasks = new Task[endPort - startPort + 1];
        int index = 0;

        SemaphoreSlim semaphore = new SemaphoreSlim(100); // Limit to 100 concurrent scans

        for (int port = startPort; port <= endPort; port++)
        {
            int currentPort = port;
            await semaphore.WaitAsync();

            tasks[index++] = Task.Run(async () =>
            {
                try
                {
                    await ScanPort(host, currentPort);
                }
                finally
                {
                    semaphore.Release();
                }
            });
        }

        Console.WriteLine("\nScan complete.");
        Console.ReadLine();
    }

    static async Task ScanPort(string host, int port)
    {
        using (var client = new TcpClient())
        {
            try
            {
                var connectTask = client.ConnectAsync(host, port);
                var timeoutTask = Task.Delay(1000); // 1-second timeout
                var completed = await Task.WhenAny(connectTask, timeoutTask);

                if (completed == connectTask && client.Connected)
                {
                    Console.WriteLine($"[+] Port {port} is open");
                }
            }
            catch
            {
                // Ignore connection errors
            }
        }
    }

}