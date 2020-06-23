using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApplication
{
    enum StatusCode
    {
        Success,
        Failure,
        Exception,
        Unknown
    }

    public class Status
    {
        private StatusCode code = StatusCode.Unknown;
        delegate void ExceptionDelegate();

        StatusCode GetStatusCode()
        {
            StatusCode s = StatusCode.Success;
            return s;
        }

        void SetStatusCode(StatusCode sc)
        {
            
        }

        void OnException()
        {

        }
    }
}
