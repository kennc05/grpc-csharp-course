using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;

namespace server
{
    internal class Program
    {
        const int PORT = 50051;

        static void Main(string[] args)
        {
            Server server = null;

            try
            {
                server = new Server()
                {
                    Ports = { new ServerPort("localhost", PORT, ServerCredentials.Insecure) }
                };

                server.Start();
                Console.WriteLine($"Server listening on port {PORT}");
                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine($"Server failed to start: {e.Message}");
                throw;
            }
            finally
            {
                if (server != null)
                    server.ShutdownAsync().Wait();
            }
        }
    }
}
