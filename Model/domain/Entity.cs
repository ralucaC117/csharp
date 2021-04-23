using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_csharp.Model
{
    [Serializable]
    public class Entity<ID>
    {
     
        public ID Id { get; set; }

        public override string ToString()
        {
            return Id.ToString();

        }

    }
}
