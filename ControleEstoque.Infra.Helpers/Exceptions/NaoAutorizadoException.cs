using ControleEstoque.Infra.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Helpers.Exceptions
{
    [StatusCode(HttpStatusCode.Unauthorized)]
    public class NaoAutorizadoException : Exception
    {
        public NaoAutorizadoException() : base() { }
        public NaoAutorizadoException(string message) : base(message) { }
        public NaoAutorizadoException(string message, Exception inner) : base(message, inner) { }
        protected NaoAutorizadoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
