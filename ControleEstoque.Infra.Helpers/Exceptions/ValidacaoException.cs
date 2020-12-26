using ControleEstoque.Infra.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace ControleEstoque.Infra.Helpers.Exceptions
{
    [StatusCode(HttpStatusCode.UnprocessableEntity)]
    public class ValidacaoException : Exception
    {
        public ValidacaoException() : base() { }
        public ValidacaoException(string message) : base(message) { }
        public ValidacaoException(string message, Exception inner) : base(message, inner) { }
        protected ValidacaoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
