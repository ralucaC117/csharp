using mpp_proiect_csharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    [Serializable]
    public class Request
    {
        private RequestType requestType;
        private Object data;

        private Request()
        {

        }

        public Request(RequestType requestType, Object data)
        {
            this.requestType = requestType;
            this.data = data; 
        }


        public void SetRequestType(RequestType requestType)
        {
            this.requestType = requestType;
        }

        public void SetData(Object data)
        {
            this.data = data;
        }

        public RequestType GetRequestType()
        {
            return this.requestType;
        }

        public Object GetData()
        {
            return this.data;
        }


    }

}
