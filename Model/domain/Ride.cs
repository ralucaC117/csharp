using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_csharp.Model
{
    [Serializable]
    public class Ride : Entity<int>
    {
        public Ride(String destination, DateTime dateTime)
        {
            
            this.Destination = destination;
            this.AvailableSeats = 18;
            this.DateTime = dateTime;
        }
        public String Destination { get; set; }
        public DateTime DateTime { get; set; }
        public int AvailableSeats { get; set; }

        public override string ToString()
        {
            return "{" + base.ToString() + Destination + " " + DateTime.ToString() + "}";
        }
    }
}
