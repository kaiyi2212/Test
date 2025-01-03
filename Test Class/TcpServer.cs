using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Test_Class
{
    public class TcpServer
    {
        private TcpListener _server;
        private bool _isRunning;

        public event EventHandler<DataReceivedEventArgs>? DataReceived; //Mark as non-nullable by adding ?

        public TcpServer(string ipAddress, int port)
        {
            _server = new TcpListener(IPAddress.Parse(ipAddress), port);
        }

        public async Task StartAsync()
        {
            _server.Start();
            _isRunning = true;
            Console.WriteLine("Server started...");

            while (_isRunning)
            {
                TcpClient client = await _server.AcceptTcpClientAsync();
                Console.WriteLine("Client connected!");

                _ = HandleClientAsync(client);
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = new byte[256];

                while (_isRunning)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;

                    string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received: " + data);

                    OnDataReceived(data);

                    string response = "Data received!";
                    byte[] responseData = Encoding.ASCII.GetBytes(response);
                    await stream.WriteAsync(responseData, 0, responseData.Length);
                }
            }

            client.Close();
            Console.WriteLine("Client disconnected.");
        }

        protected virtual void OnDataReceived(string data)
        {
            DataReceived?.Invoke(this, new DataReceivedEventArgs(data));
        }

        public void Stop()
        {
            _isRunning = false;
            _server.Stop();
            Console.WriteLine("Server stopped.");
        }
    }
}
