using mpp_proiect_csharp.Model;
using mpp_proiect_csharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Networking
{
    public class ClientWorker : IObserver
    {
        private IService server;
        private TcpClient connection;
        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
     

        public ClientWorker(IService server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {

                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void run()
        {
            while (connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((Request)request);
                    if (response != null)
                    {
                        sendResponse((Response)response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }

        private Response handleRequest(Request request)
        {
            Response response = null;
            String handlerName = "handle" + request.GetRequestType();
            try
            {
                MethodInfo method = this.GetType().GetMethod(handlerName, BindingFlags.NonPublic | BindingFlags.Instance);
                //MethodInfo method = Type.GetType("ClientWorker").GetMethod(handlerName);
                lock (server)
                {
                    response = (Response)method.Invoke(this, new object[] { request });
                }
               
                Console.WriteLine("Method " + handlerName + " invoked");           
            }
            catch (TargetInvocationException exception)
            {
                Console.Write(exception.StackTrace);
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.Write(exception.StackTrace);
            } 

            return response;
        }

        private void sendResponse(Response response)
        {
            Console.WriteLine("sending response " + response);
            formatter.Serialize(stream, response);
            stream.Flush();

        }

        private Response handleLOGIN(Request request)
        {
            try
            {
                Operator _operator = (Operator)request.GetData();
                int id = -1;
                try
                {                 
                        id = server.login(_operator.Username, _operator.Password);
                        server.addObserver(this);
                    
                }
                catch( Exception exception)
                {
                    connected = false;
                    return new Response(ResponseType.ERROR, null);
                }

                        
                Response response = new Response(ResponseType.OK, id);
                return response;
            }
            catch (Exception exception)
            {
                return new Response(ResponseType.ERROR, exception.Message);
            }
        }

        private Response handleFIND_ALL_RIDES(Request request)
        {
            try
            {
                List<Ride> rides;
              
                try
                {
                    rides = server.FindAllRides();

                }
                catch (Exception exception)
                {
                    connected = false;
                    return new Response(ResponseType.ERROR, null);
                }


                Response response = new Response(ResponseType.OK, rides);
                return response;
            }
            catch (Exception exception)
            {
                return new Response(ResponseType.ERROR, exception.Message);
            }
        }

        private Response handleFIND_ALL_RESERVATIONS(Request request)
        {
            try
            {
                List<Reservation> reservations;

                try
                {
                    reservations = server.FindAllReservations();

                }
                catch (Exception exception)
                {
                    connected = false;
                    return new Response(ResponseType.ERROR, null);
                }


                Response response = new Response(ResponseType.OK, reservations);
                return response;
            }
            catch (Exception exception)
            {
                return new Response(ResponseType.ERROR, exception.Message);
            }
        }

        private Response handleFIND_ONE_OPERATOR(Request request)
        {
            try
            {
                Operator _operator;
                int id = (int)request.GetData();
                try
                {
                    _operator = server.FindOneOperator(id);

                }
                catch (Exception exception)
                {
                    connected = false;
                    return new Response(ResponseType.ERROR, null);
                }


                Response response = new Response(ResponseType.OK, _operator);
                return response;
            }
            catch (Exception exception)
            {
                return new Response(ResponseType.ERROR, exception.Message);
            }
        }

        private Response handleADD_ONE_RIDE(Request request)
        {
     
              try
              {
                    Ride ride = (Ride)request.GetData();

                    server.addRide(ride.Destination, ride.DateTime);
                    Response response = new Response(ResponseType.OK, null);
                    return response;
              }
                catch (Exception e)
                {
                    return new Response(ResponseType.ERROR, e.Message);
                }
        
        }
        private Response handleADD_ONE_RESERVATION(Request request)
        {

            try
            {
                Reservation reservation = (Reservation)request.GetData();
                server.addReservation(reservation.Ride, reservation.Operator, reservation.ClientName, reservation.ClientPhoneNumber, reservation.NoOfSeats);
                Response response = new Response(ResponseType.OK, null);
                return response;
            }
            catch (Exception e)
            {
                return new Response(ResponseType.ERROR, e.Message);
            }

        }

        private Response handleUPDATE_RIDE(Request request)
        {

            try
            {
                Ride ride = (Ride)request.GetData();
                server.updateRide(ride);
                Response response = new Response(ResponseType.OK, null);
                return response;
            }
            catch (Exception e)
            {
                return new Response(ResponseType.ERROR, e.Message);
            }

        }

        public void update()
        {
            Response response = new Response(ResponseType.UPDATE, null);
            sendResponse(response);
        }

    }
    
}
