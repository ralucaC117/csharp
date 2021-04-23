using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp_proiect_csharp.Persistance;
using mpp_proiect_csharp.Services;
using ServerTemplate;
using static ServerTemplate.ServerUtils;
using Networking;
using System.Threading;
using System.Net.Sockets;

namespace Server
{
    public class StartServer
    {       
            static void Main(string[] args)
            {
             log4net.Config.XmlConfigurator.Configure();
             IOperatorsRepository operatorsRepository = new OperatorsDbRepository();
             IRidesRepository ridesRepository = new RidesDbRepository();
             IReservationsRepository reservationsRepository = new ReservationsDbRepository();
             IService serviceImpl = new RidesAndReservationsServices(operatorsRepository, ridesRepository, reservationsRepository);
             SerialServer server = new SerialServer("127.0.0.1", 55555, serviceImpl);
             server.Start();
             Console.WriteLine("Server started ...");
      
             Console.ReadLine();
            }
    }

        public class SerialServer : ConcurrentServer
        {
            private IService server;
            private ClientWorker worker;
            public SerialServer(string host, int port, IService server) : base(host, port)
            {
                this.server = server;
                Console.WriteLine("SerialChatServer...");
            }
            protected override Thread createWorker(TcpClient client)
            {
                worker = new ClientWorker(server, client);
                return new Thread(new ThreadStart(worker.run));
            }
        }
    
}
