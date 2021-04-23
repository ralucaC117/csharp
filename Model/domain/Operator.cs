using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_csharp.Model
{
       [Serializable]
       public  class Operator : Entity<int>
       {

        public Operator()
        {
        
        }
        public Operator(String firstName, String lastName) 
        {
            
            this.FirstName = firstName;
            this.LastName = lastName;
           

        }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public override string ToString()
        {
            return "{" +base.ToString() +  " " + FirstName + " " + LastName + "}"; 
        }



    }
}
