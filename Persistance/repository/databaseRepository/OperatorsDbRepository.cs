using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp_proiect_csharp.Model;
using System.Data;
using System.Data.SQLite;
using System.Configuration;
using log4net;

namespace mpp_proiect_csharp.Persistance
{
    public class OperatorsDbRepository : IOperatorsRepository
    {

        private static readonly ILog log = LogManager.GetLogger("OperatorsDbRepository");

        public OperatorsDbRepository(){
            log.InfoFormat("Creating OperatorsDbRepository");
        }


        public Operator Delete(int id)
        {

            log.InfoFormat("Entering Delete with value {0} ", id);
            IDbConnection  con = DbUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Operators where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();

                con.Close();
                if (dataR == 0)
                {
                    log.InfoFormat("Exiting Delete with value {0}", null);
                    throw new Exception("No Operator deleted!");    
                }
                    
                
            }
            log.InfoFormat("Exiting Delete with value {0}", id);
            return null;
        }

        public IEnumerable<Operator> FindAll()
        {
            log.InfoFormat("Entering findAll");
            IDbConnection con = DbUtils.getConnection();
            IList<Operator> operators = new List<Operator>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,firstName, lastName, username, password from Operators";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String firstName = dataR.GetString(1);
                        String lastName = dataR.GetString(2);
                        String username = dataR.GetString(3);
                        String password = dataR.GetString(4);
                        Operator op = new Operator(firstName, lastName);
                        op.Id = id;
                        op.Username = username;
                        op.Password = password;

                        operators.Add(op);
                    }
                }
            }
            con.Close();
            log.InfoFormat("Exiting findAll");
            return operators;
        }

        public Operator FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DbUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,firstName, lastName, username, password from Operators where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String firstName = dataR.GetString(1);
                        String lastName = dataR.GetString(2);
                        String username = dataR.GetString(3);
                        String password = dataR.GetString(4);
                        Operator op = new Operator(firstName, lastName);
                        op.Id = id;
                        op.Username = username;
                        op.Password = password;
                       
                        con.Close();
                        log.InfoFormat("Exiting findOne with value {0}", op);
                        return op;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            con.Close();
            return null;
        }

        public Operator Save(Operator entity)
        {
            var con = DbUtils.getConnection();
            log.InfoFormat("Entering save with value {0}", entity.Id);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Operators  values ( @firstName, @lastName, @username, @password)";
                /*var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);*/

                var paramFirstName = comm.CreateParameter();
                paramFirstName.ParameterName = "@firstName";
                paramFirstName.Value = entity.FirstName;
                comm.Parameters.Add(paramFirstName);

                var paramLastName = comm.CreateParameter();
                paramLastName.ParameterName = "@lastName";
                paramLastName.Value = entity.LastName;
                comm.Parameters.Add(paramLastName);

                IDbDataParameter paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = entity.Username;
                comm.Parameters.Add(paramUsername);

                IDbDataParameter paramPassword = comm.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = entity.Password;
                comm.Parameters.Add(paramPassword);

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

        public Operator Update(Operator entity)
        {
            log.InfoFormat("Entering save with value {0}", entity.Id);
            IDbConnection con = DbUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Operators set firstName=@firstName, lastName=@lastName, username=@username, password=@password where id=@id";

                var paramFirstName = comm.CreateParameter();
                paramFirstName.ParameterName = "@firstName";
                paramFirstName.Value = entity.FirstName;
                comm.Parameters.Add(paramFirstName);

                var paramLastName = comm.CreateParameter();
                paramLastName.ParameterName = "@lastName";
                paramLastName.Value = entity.LastName;
                comm.Parameters.Add(paramLastName);

                IDbDataParameter paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = entity.Username;
                comm.Parameters.Add(paramUsername);

                IDbDataParameter paramPassword = comm.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = entity.Password;
                comm.Parameters.Add(paramPassword);

                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

       
                var result = comm.ExecuteNonQuery();
                con.Close();
                if (result == 0)
                {
                    log.InfoFormat("Exiting update with value {0}", null);
                    throw new Exception("No Operator updated!");
                }
                   
               
            }
            log.InfoFormat("Exiting update with value {0}", entity.Id);
            return null;
        }

        public int FindIdByUsername(String username)
        {
            log.InfoFormat("Entering findIdByUsername with value {0}", username);
            IDbConnection con = DbUtils.getConnection();
            int id = -1;
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id from Operators where username=@username";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@username";
                paramId.Value = username;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                        id = dataR.GetInt32(0);                                                      
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", id);
            con.Close();
            return id;
        }
    }
}
