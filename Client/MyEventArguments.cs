using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public enum MyEvent
    {
       ADD_RIDE, ADD_RESERVATION
    };
    public class MyEventArguments : EventArgs
    {
        private readonly MyEvent myEvent;
        private readonly Object data;

        public MyEventArguments(MyEvent myEvent, object data)
        {
            this.myEvent = myEvent;
            this.data = data;
        }

        public MyEvent UserEventType
        {
            get { return myEvent; }
        }

        public object Data
        {
            get { return data; }
        }
    }
}
