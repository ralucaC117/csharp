using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using mpp_proiect_csharp.Model;
using mpp_proiect_csharp.Persistance;

namespace mpp_proiect_csharp.Services
{
    public class RidesAndReservationsServices : IService
    {
        public IOperatorsRepository OperatorRepository { set; get; }
        public IRidesRepository RidesRepository { set; get; }
        public IReservationsRepository ReservationsRepository { set; get; }
        private List<IObserver> observers = new List<IObserver>();

        private static readonly ILog log = LogManager.GetLogger("Service");

        public RidesAndReservationsServices(IOperatorsRepository operatorsRepository, IRidesRepository ridesRepository, IReservationsRepository reservationsRepository)
        {
            log.InfoFormat("Creating the service");
            this.OperatorRepository = operatorsRepository;
            this.RidesRepository = ridesRepository;
            this.ReservationsRepository = reservationsRepository;
            
        }

        public int login(String username, String password)
        {

            int id = OperatorRepository.FindIdByUsername(username);
            Operator op = OperatorRepository.FindOne(id);
            if (op.Password == password)
                return id;
            else
            {
               throw new Exception("Invalid password!");
            }       
        }

        public List<Ride> FindAllRides()
        {
            log.InfoFormat("Entering FindAllRides()");
            return RidesRepository.FindAll().ToList();
        }
        public List<Reservation> FindAllReservations()
        {
            log.InfoFormat("Entering FindAllReservations()");
            return ReservationsRepository.FindAll().ToList();
        }

        public Operator FindOneOperator(int id)
        {
            return OperatorRepository.FindOne(id);
        }

        public void deleteOperator(int id)
        {
            OperatorRepository.Delete(id);
        }

        public void addOperator(String firstName, String lastName, String username, String password)
        {
            Operator op = new Operator(firstName, lastName);
            op.Username = username;
            op.Password = password;
            OperatorRepository.Save(op);
        }

        public int findOperatorIdByUsername(String username)
        {
            return OperatorRepository.FindIdByUsername(username);
        }

        public void addRide(String destination, DateTime dateTime)
        {
            Ride ride = new Ride(destination, dateTime);
            RidesRepository.Save(ride);

            foreach (var o in observers)
            {
                o.update();
            }
        }

        public void addReservation(int idRide, int idOperator, String clientName, String clientPhoneNumber, int noOfSeats)
        {
            Reservation reservation = new Reservation(idRide, idOperator, clientName, clientPhoneNumber, noOfSeats);
            ReservationsRepository.Save(reservation);
            foreach (var o in observers)
            {
                o.update();
            }

        }

        public void updateRide(Ride ride)
        {
            RidesRepository.Update(ride);
            foreach (var o in observers)
            {
                o.update();
            }
        }

        public Ride findOneRide(int id)
        {
            return RidesRepository.FindOne(id);
        }

        public void deleteReservation(int id)
        {
            ReservationsRepository.Delete(id);

        }

        public void addObserver(IObserver o)
        {
            if (o != null) observers.Add(o);
        }

        public void removeObserver(IObserver o)
        {
            if (o != null) observers.Remove(o);
        }
    }
}
