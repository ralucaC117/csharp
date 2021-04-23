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
    public class RidesDbRepository : IRidesRepository
    {
        private static readonly ILog log = LogManager.GetLogger("RidesDbRepository");

        public RidesDbRepository()
        {
            log.Info("Creating RidesDbRepository");
        }


        public IEnumerable<Ride> FindRidesByDateAndDestination(DateTime date, String destination)
        {
            log.InfoFormat("Entering findAll filtered by Date and Destination");
            IDbConnection con = DbUtils.getConnection();
            IList<Ride> Rides = new List<Ride>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Rides where date==@date and destination==@destination";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        destination = dataR.GetString(1);
                        int noOfAvailableSeats = dataR.GetInt32(2);
                        DateTime dateTime = dataR.GetDateTime(3);

                        Ride r = new Ride(destination,dateTime);
                        r.Id = id;

                        Rides.Add(r);
                    }
                }
            }
            con.Close();
            log.InfoFormat("Exiting findAll");
            return Rides;
        }
        public Ride Delete(int id)
        {

            log.InfoFormat("Entering Delete with value {0} ", id);
            IDbConnection con = DbUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Rides where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();

                con.Close();
                if (dataR == 0)
                {
                    log.InfoFormat("Exiting Delete with value {0}", null);
                    throw new Exception("No Ride deleted!");
                }


            }
            log.InfoFormat("Exiting Delete with value {0}", id);
            return null;
        }

        public IEnumerable<Ride> FindAll()
        {
            log.InfoFormat("Entering findAll");
            IDbConnection con = DbUtils.getConnection();
            IList<Ride> Rides = new List<Ride>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Rides";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String destination = dataR.GetString(1);
                        int noOfAvailableSeats = dataR.GetInt32(2);
                        DateTime dateTime = dataR.GetDateTime(3);

                        Ride r = new Ride(destination, dateTime);
                        r.Id = id;
                        r.AvailableSeats = noOfAvailableSeats;

                        Rides.Add(r);
                    }
                }
            }
            con.Close();
            log.InfoFormat("Exiting findAll");
            return Rides;
        }

        public Ride FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DbUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Rides where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                     
                        String destination = dataR.GetString(1);
                        int noOfAvailableSeats = dataR.GetInt32(2);
                        DateTime dateTime = dataR.GetDateTime(3);

                        Ride r = new Ride(destination,dateTime);
                        r.Id = id;
                        r.AvailableSeats = noOfAvailableSeats;

                        con.Close();
                        log.InfoFormat("Exiting findOne with value {0}", r);
                        return r;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            con.Close();
            return null;
        }

        public Ride Save(Ride entity)
        {
            var con = DbUtils.getConnection();
            log.InfoFormat("Entering save with value {0}", entity);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Rides(destination, noOfAvailableSeats, dateTime) values (@destination, @noOfAvailableSeats, @dateTime)";
               /* var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);*/

                var paramDestination = comm.CreateParameter();
                paramDestination.ParameterName = "@destination";
                paramDestination.Value = entity.Destination;
                comm.Parameters.Add(paramDestination);

                var paramNoOfAvailableSeats = comm.CreateParameter();
                paramNoOfAvailableSeats.ParameterName = "@noOfAvailableSeats";
                paramNoOfAvailableSeats.Value = entity.AvailableSeats;
                comm.Parameters.Add(paramNoOfAvailableSeats);

                IDbDataParameter paramDateTime = comm.CreateParameter();
                paramDateTime.ParameterName = "@dateTime";
                paramDateTime.Value = entity.DateTime;
                comm.Parameters.Add(paramDateTime);


                var result = comm.ExecuteNonQuery();
                con.Close();
                if (result == 0)
                {
                    log.InfoFormat("Exiting save with value {0} ", null);
                    throw new Exception("No task added !");
                }


            }
            log.InfoFormat("Exiting save with value {0} ", entity);
            return null;
        }

        public Ride Update(Ride entity)
        {
            log.InfoFormat("Entering save with value {0}", entity.Id);
            IDbConnection con = DbUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Rides set destination=@destination, noOfAvailableSeats=@noOfAvailableSeats, dateTime=@dateTime where id=@id";

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramDestination = comm.CreateParameter();
                paramDestination.ParameterName = "@destination";
                paramDestination.Value = entity.Destination;
                comm.Parameters.Add(paramDestination);

                var paramNoOfAvailableSeats = comm.CreateParameter();
                paramNoOfAvailableSeats.ParameterName = "@noOfAvailableSeats";
                paramNoOfAvailableSeats.Value = entity.AvailableSeats;
                comm.Parameters.Add(paramNoOfAvailableSeats);

                IDbDataParameter paramDateTime = comm.CreateParameter();
                paramDateTime.ParameterName = "@dateTime";
                paramDateTime.Value = entity.DateTime;
                comm.Parameters.Add(paramDateTime);


                var result = comm.ExecuteNonQuery();
                con.Close();
                if (result == 0)
                {
                    log.InfoFormat("Exiting update with value {0}", null);
                    throw new Exception("No Ride updated!");
                }


            }
            log.InfoFormat("Exiting update with value {0}", entity.Id);
            return null;
        }
    }
}
