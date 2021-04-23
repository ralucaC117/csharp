using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp_proiect_csharp.Model;
using mpp_proiect_csharp.Services;

namespace Client
{
    public class Controller : IObserver
    {
        public event EventHandler<MyEventArguments>updateEvent; //ctrl calls it when it has received an update
        private readonly IService server;
        private int id;
        public Controller(IService server)
        {
            this.server = server;
            id = -1;
        }

        protected virtual void OnUserEvent(MyEventArguments e)
        {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Update Event called");
        }
        public void update()
        {
           OnUserEvent(new MyEventArguments(MyEvent.ADD_RIDE, null));
           OnUserEvent(new MyEventArguments(MyEvent.ADD_RESERVATION, null));
        }

        public int login(String username, String password)
        {
           
            id = server.login(username, password);
            server.addObserver(this);
            Console.WriteLine("Login succeeded ....");
            Console.WriteLine("Current user {0}", username);
            return id;
        }

        public List<Ride> findAllRides()
        {
            List<Ride> allRides = server.FindAllRides();
            Console.WriteLine("Find all rides succeeded ....");
            return allRides;
        }

        public List<Reservation> findAllReservations()
        {
            List<Reservation> allReservations = server.FindAllReservations();
            Console.WriteLine("Find all reservations succeeded ....");
            return allReservations;
        }

        public void addRide(String destination, DateTime dateTime)
        {
            server.addRide(destination, dateTime);

        }
        public void addReservation(int idRide, int idOperator, String clientName, String clientPhoneNumber, int noOfSeats)
        {
            server.addReservation(idRide, idOperator, clientName, clientPhoneNumber, noOfSeats);

        }

        public void updateRide(Ride ride)
        {
            server.updateRide(ride);
        }


    }
}
