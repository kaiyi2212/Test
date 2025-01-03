using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Class
{
    public class TCPProgram
    {
        public static async Task Main(string[] args)
        {
            // Initialize and start the TCP server
            TcpServer server = new TcpServer("127.0.0.1", 13000);

            // Subscribe to the DataReceived event
            server.DataReceived += OnDataReceived;

            // Start the server asynchronously
            await server.StartAsync();

            // Keep the server running
            Console.WriteLine("Press ENTER to stop the server...");
            Console.ReadLine();

            server.Stop();
        }

        private static void OnDataReceived(object? sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("Event triggered! Data: " + e.Data);

            // You can add further processing logic here
        }
    }
}
