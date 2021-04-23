using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp_proiect_csharp.Model;
using mpp_proiect_csharp.Persistance;

namespace mpp_proiect_csharp.Services
{
    public interface IService : IObservable

    {

        int login(String username, String password);

        List<Ride> FindAllRides();

        List<Reservation> FindAllReservations();


        Operator FindOneOperator(int id);


        void deleteOperator(int id);

        void addOperator(String firstName, String lastName, String username, String password);

        int findOperatorIdByUsername(String username);

        void addRide(String destination, DateTime dateTime);

        void addReservation(int idRide, int idOperator, String clientName, String clientPhoneNumber, int noOfSeats);

        void updateRide(Ride ride);

        Ride findOneRide(int id);

        void deleteReservation(int id);

       
    }
}
