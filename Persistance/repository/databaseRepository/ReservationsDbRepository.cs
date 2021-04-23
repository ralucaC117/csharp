using log4net;
using mpp_proiect_csharp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_csharp.Persistance
{
    public class ReservationsDbRepository : IReservationsRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ReservationsDbRepository");

        public ReservationsDbRepository()
        {
            log.Info("Creating ReservationsDbRepository");
        }


        public Reservation Delete(int id)
        {

            log.InfoFormat("Entering Delete with value {0} ", id);
            IDbConnection con = DbUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Reservations where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();

                con.Close();
                if (dataR == 0)
                {
                    log.InfoFormat("Exiting Delete with value {0}", null);
                    throw new Exception("No Reservation deleted!");
                }


            }
            log.InfoFormat("Exiting Delete with value {0}", id);
            return null;
        }

        public IEnumerable<Reservation> FindAll()
        {
            log.InfoFormat("Entering findAll");
            IDbConnection con = DbUtils.getConnection();
            IList<Reservation> Reservations = new List<Reservation>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, idOperator, idRide, clientName, clientPhoneNumber, noOfSeats from Reservations";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        int idOperator = dataR.GetInt32(1);
                        int idRide = dataR.GetInt32(2);
                        String clientName = dataR.GetString(3);
                        String clientPhoneNumber = dataR.GetString(4);
                        int noOfSeats = dataR.GetInt32(5);
                        Reservation r = new Reservation(idOperator, idRide, clientName, clientPhoneNumber, noOfSeats);
                        r.Id = id;
                        Reservations.Add(r);
                    }
                }
            }
            con.Close();
            log.InfoFormat("Exiting findAll");
            return Reservations;
        }

        public Reservation FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DbUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, idOperator, idRide, clientName, clientPhoneNumber, noOfSeats from Reservations where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        id = dataR.GetInt32(0);
                        int idOperator = dataR.GetInt32(1);
                        int idRide = dataR.GetInt32(2);
                        String clientName = dataR.GetString(3);
                        String clientPhoneNumber = dataR.GetString(4);
                        int noOfSeats = dataR.GetInt32(5);
                        Reservation r = new Reservation(idOperator, idRide, clientName, clientPhoneNumber, noOfSeats);
                        r.Id = id;

                        con.Close();
                        log.InfoFormat("Exiting findOne with value {0}", id);
                        return r;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            con.Close();
            return null;
        }

        public Reservation Save(Reservation entity)
        {
            var con = DbUtils.getConnection();
            log.InfoFormat("Entering save with value {0}", entity.Id);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Reservations(idOperator, idRide, clientName, clientPhoneNumber, noOfSeats)  values (@idOperator, @idRide, @clientName, @clientPhoneNumber, @noOfSeats)";
                /*var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);*/

                var paramidOperator = comm.CreateParameter();
                paramidOperator.ParameterName = "@idOperator";
                paramidOperator.Value = entity.Operator;
                comm.Parameters.Add(paramidOperator);

                var paramIdRide = comm.CreateParameter();
                paramIdRide.ParameterName = "@idRide";
                paramIdRide.Value = entity.Ride;
                comm.Parameters.Add(paramIdRide);

                IDbDataParameter paramClientName = comm.CreateParameter();
                paramClientName.ParameterName = "@clientName";
                paramClientName.Value = entity.ClientName;
                comm.Parameters.Add(paramClientName);

                IDbDataParameter paramClientPhoneNumber = comm.CreateParameter();
                paramClientPhoneNumber.ParameterName = "@clientPhoneNumber";
                paramClientPhoneNumber.Value = entity.ClientPhoneNumber;
                comm.Parameters.Add(paramClientPhoneNumber);

                IDbDataParameter paramNoOfSeats = comm.CreateParameter();
                paramNoOfSeats.ParameterName = "@noOfSeats";
                paramNoOfSeats.Value = entity.NoOfSeats;
                comm.Parameters.Add(paramNoOfSeats);


                var result = comm.ExecuteNonQuery();
                con.Close();
                if (result == 0)
                {
                    log.InfoFormat("Exiting save with value {0} ", null);
                    throw new Exception("No task added !");
                }


            }
            log.InfoFormat("Exiting save with value {0} ", entity.Id);
            return null;
        }

        public Reservation Update(Reservation entity)
        {
            log.InfoFormat("Entering save with value {0}", entity.Id);
            IDbConnection con = DbUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Reservations set idOperator=@idOperator, idRide=@idRide, clientName=@clientName, clientPhoneNumber=@clientPhoneNumber, noOfSeats=@noOfSeats where id=@id";

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramidOperator = comm.CreateParameter();
                paramidOperator.ParameterName = "@idOperator";
                paramidOperator.Value = entity.Operator;
                comm.Parameters.Add(paramidOperator);

                var paramIdRide = comm.CreateParameter();
                paramIdRide.ParameterName = "@idRide";
                paramIdRide.Value = entity.Ride;
                comm.Parameters.Add(paramIdRide);

                IDbDataParameter paramClientName = comm.CreateParameter();
                paramClientName.ParameterName = "@clientName";
                paramClientName.Value = entity.ClientName;
                comm.Parameters.Add(paramClientName);

                IDbDataParameter paramClientPhoneNumber = comm.CreateParameter();
                paramClientPhoneNumber.ParameterName = "@clientPhoneNumber";
                paramClientPhoneNumber.Value = entity.ClientPhoneNumber;
                comm.Parameters.Add(paramClientPhoneNumber);

                IDbDataParameter paramNoOfSeats = comm.CreateParameter();
                paramNoOfSeats.ParameterName = "@noOfSeats";
                paramNoOfSeats.Value = entity.NoOfSeats;
                comm.Parameters.Add(paramNoOfSeats);


                var result = comm.ExecuteNonQuery();
                con.Close();
                if (result == 0)
                {
                    log.InfoFormat("Exiting update with value {0}", null);
                    throw new Exception("No Reservation updated!");
                }


            }
            log.InfoFormat("Exiting update with value {0}", entity.Id);
            return null;
        }
    }
}

