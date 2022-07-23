using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Middlewares.ExceptionHandler
{
    public class RestException : Exception
    {
        public HttpStatusCode Code { get; }
        public RestException(string message, HttpStatusCode code, Exception inner = null) : base(message, inner)
        {
            Code = code;
        }
    }
}
