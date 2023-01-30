using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ApiException : Exception
    {
        public override string Message { get; }
        public ApiException(string message, int status, string data, object headers, object foo)
        {
            this.Message = data;
        }
    }
}
