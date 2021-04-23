using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_csharp.Model
{
    [Serializable]
    public class Reservation : Entity<int>
    {
        public int Operator { get; set; }
        public int Ride { get; set; }
        public String ClientName { get; set; }
        public String ClientPhoneNumber { get; set; }
        public int NoOfSeats { get; set; }

        public Reservation(int Operator, int Ride, String clientName, String ClientPhoneNumber, int noOfSeats)
        {
            
            this.Operator = Operator;
            this.Ride = Ride;
            this.ClientName = clientName;
            this.ClientPhoneNumber = ClientPhoneNumber;
            this.NoOfSeats = noOfSeats;
        }
        public override string ToString()
        {
            return "{" + base.ToString() + " " + ClientName + " " + ClientPhoneNumber + " " + Ride + " " + Operator + "}";
        }





    }
}
