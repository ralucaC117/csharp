using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    [Serializable]
    public class Response
    {
        private ResponseType responseType;
        private Object data;

        public Response(ResponseType responseType, Object data)
        {
            this.responseType = responseType;
            this.data = data;

        }

        public ResponseType GetResponseType()
        {
            return this.responseType;
        }

        public Object GetData()
        {
            return this.data;
        }


        public void SetResponseType(ResponseType type)
        {
            this.responseType = type;
        }

        private void SetData(Object data)
        {
            this.data = data;
        }

      


       
    }
}
