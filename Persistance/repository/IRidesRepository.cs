using mpp_proiect_csharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_csharp.Persistance
{
    public interface IRidesRepository : ICrudRepository<int, Ride>
    {
        IEnumerable<Ride> FindRidesByDateAndDestination(DateTime date, String destination);

     

    }
}
