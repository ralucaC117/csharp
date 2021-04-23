using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_csharp.Services
{
    public interface  IObservable
    {
        void addObserver(IObserver o);
        void removeObserver(IObserver o);
    }
}
