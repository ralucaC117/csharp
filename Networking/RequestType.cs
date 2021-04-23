using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public enum  RequestType
    {
        LOGIN, LOGOUT, FIND_ALL_RIDES, FIND_ONE_OPERATOR, FIND_ALL_RESERVATIONS, ADD_ONE_RIDE, ADD_ONE_RESERVATION,
        UPDATE_RIDE, FIND_ONE_RIDE,
        FIND_RIDE_BY_DESTINATION_AND_DATE,
        FIND_RESERVATIONS_BY_RIDE_ID
    }
}
