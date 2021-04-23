using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mpp_proiect_csharp.Model;

namespace mpp_proiect_csharp.Persistance
{
    public interface ICrudRepository<ID, Entity> where Entity : Entity<ID>
    {
        Entity FindOne(ID id);
        IEnumerable<Entity> FindAll();
        Entity Save(Entity entity);
        Entity Delete(ID id);
        Entity Update(Entity entity);
    }
}
