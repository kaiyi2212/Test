using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpWebApp.Controllers
{
    //class cannot name as TcpClient as TcpClient is used in System.Net.Sockets
    public class TcpClientClass
    {
        private readonly string _serverAddress;
        private readonly int _port;

        public TcpClientClass(string serverAddress, int port)
        {
            _serverAddress = serverAddress;
            _port = port;
        }

        public static async Task RunClient()
        {
            TcpClient client = new TcpClient();
            try
            {
                // Asynchronously connect to the server
                await client.ConnectAsync("127.0.0.1", 13000);
                Console.WriteLine("Connected to the server!");

                using (NetworkStream stream = client.GetStream())
                {
                    // Send data to the server asynchronously
                    string message = "Hello, Server!";
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);
                    Console.WriteLine("Sent: {0}", message);

                    // Receive response from the server asynchronously
                    data = new byte[256];
                    int bytesRead = await stream.ReadAsync(data, 0, data.Length);
                    string responseData = Encoding.ASCII.GetString(data, 0, bytesRead);
                    Console.WriteLine("Received: {0}", responseData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
            finally
            {
                client.Dispose(); // Ensure the client is disposed of
            }
        }

        public async Task<string> SendMessageAsync(string message)
        {
            using (var client = new TcpClient())
            {
                await client.ConnectAsync(_serverAddress, _port);

                using (var networkStream = client.GetStream())
                {
                    byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                    await networkStream.WriteAsync(messageBytes, 0, messageBytes.Length);

                    // Optionally read the response
                    byte[] responseBuffer = new byte[1024];
                    int bytesRead = await networkStream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                    return Encoding.ASCII.GetString(responseBuffer, 0, bytesRead);
                }
            }
        }
    }
}
