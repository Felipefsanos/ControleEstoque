using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ControleEstoque.Infra.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class StatusCodeAttribute : Attribute
    {
        public HttpStatusCode StatusCode { get; set; }

        public StatusCodeAttribute(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
