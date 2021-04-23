using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp_proiect_csharp.Services;
using mpp_proiect_csharp.Model;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace Networking
{
    public class ServerProxy : IService
    {
        private string host;
        private int port;

        private IObserver client;

        private NetworkStream stream;

        private IFormatter formatter;
        private TcpClient connection;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;
        public ServerProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();
        }


        public void addOperator(string firstName, string lastName, string username, string password)
        {
            throw new NotImplementedException();
        }

        public void addReservation(int idRide, int idOperator, string clientName, string clientPhoneNumber, int noOfSeats)
        {
            Reservation reservation = new Reservation(idOperator, idRide, clientName, clientPhoneNumber, noOfSeats);

            Request request = new Request(RequestType.ADD_ONE_RESERVATION, reservation);
            try
            {
                sendRequest(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Response response = null;
            try
            {
                response = readResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            if (response.GetResponseType() == ResponseType.ERROR)
                throw new Exception((String)response.GetData());
        }

        public void addRide(string destination, DateTime dateTime)
        {
            Ride ride = new Ride(destination, dateTime);

            Request request = new Request(RequestType.ADD_ONE_RIDE, ride);
            try
            {
                sendRequest(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Response response = null;
            try
            {
                response = readResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            if (response.GetResponseType() == ResponseType.ERROR)
                throw new Exception((String)response.GetData());
        }

        public void deleteOperator(int id)
        {
            throw new NotImplementedException();
        }

        public void deleteReservation(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> FindAllReservations()
        {
            Request request = new Request(RequestType.FIND_ALL_RESERVATIONS, null);
            try
            {
                sendRequest(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Response response = null;
            try
            {
                response = readResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            if (response.GetResponseType() == ResponseType.OK)
            {
                List<Reservation> reservations = (List<Reservation>)response.GetData();
                return reservations;
            }
            return null;
        }

        public List<Ride> FindAllRides()
        {
            Request request = new Request(RequestType.FIND_ALL_RIDES, null);
            try
            {
                sendRequest(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Response response = null;
            try
            {
                response = readResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            if (response.GetResponseType() == ResponseType.OK)
            {
                List<Ride> rides = (List<Ride>)response.GetData();
                return rides;
            }
            return null;
        }

        public Operator FindOneOperator(int id)
        {
            Request request = new Request(RequestType.FIND_ONE_OPERATOR, id);
            try
            {
                sendRequest(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Response response = null;
            try
            {
                response = readResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            if (response.GetResponseType() == ResponseType.OK)
            {
                 Operator op = (Operator)response.GetData();
                return op;
            }
            return null;
            
        }

        public Ride findOneRide(int id)
        {
            throw new NotImplementedException();
        }

        public int findOperatorIdByUsername(string username)
        {
            Request request = new Request(RequestType.FIND_ONE_OPERATOR, username);
            try
            {
                sendRequest(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Response response = null;
            try
            {
                response = readResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            if (response.GetResponseType() == ResponseType.OK)
            {
                int id = (int)response.GetData();
                return id;
            }
            return -1;
        }

        public int login(string username, string password)
        {
            initializeConnection();
            Console.WriteLine("S-a stabilit conexiunea!");
            int id = -1;
            Operator _operator = new Operator();
            _operator.Username = username;
            _operator.Password = password;         
            try
            {
                sendRequest(new Request(RequestType.LOGIN, _operator));
                Console.WriteLine("S-a trimis request-ul!");
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Response response = null;
            try
            {
                response = readResponse();
                if (response.GetResponseType() is ResponseType.OK)
                    id = (int)response.GetData();
                return id;
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            closeConnection();
            throw new Exception(response.GetData().ToString());
        }

        public void updateRide(Ride ride)
        {
           
            Request request = new Request(RequestType.UPDATE_RIDE, ride);
            try
            {
                sendRequest(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Response response = null;
            try
            {
                response = readResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            if (response.GetResponseType() == ResponseType.ERROR)
                throw new Exception((String)response.GetData());
        }


        private void closeConnection()
        {
            finished = true;
            try
            {
                stream.Close();
                //output.close();
                connection.Close();
                _waitHandle.Close();
                client = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new Exception("Error sending object " + e);
            }

        }

        private Response readResponse()
        {
            Response response = null;
            try
            {
                _waitHandle.WaitOne();
                lock (responses)
                {
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }
        private void initializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void startReader()
        {
            Thread tw = new Thread(run);
            tw.Start();
        }

        private Boolean isUpdate(Response response)
        {
            return response.GetResponseType() == ResponseType.UPDATE;
        }
        private void handleUpdate(Response update)
        {
            client.update();
        }
        public virtual void run()
        {
            while (!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received " + response);
                    if (isUpdate((Response)response))
                    {
                        handleUpdate((Response)response);
                    }
                    else
                    {
                        lock (responses)
                        {
                            responses.Enqueue((Response)response);

                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error " + e);
                }

            }
        }

        public void addObserver(IObserver o)
        {
            client = o;
        }

        public void removeObserver(IObserver o)
        {
            sendRequest(new Request(RequestType.LOGOUT, null));
            closeConnection();
        }
    }
}
