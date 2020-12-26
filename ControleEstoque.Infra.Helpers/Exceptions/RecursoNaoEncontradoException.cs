using ControleEstoque.Infra.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace ControleEstoque.Infra.Helpers.Exceptions
{
    [StatusCode(HttpStatusCode.NotFound)]
    public class RecursoNaoEncontradoException : Exception
    {
        public RecursoNaoEncontradoException() : base() { }
        public RecursoNaoEncontradoException(string message) : base(message) { }
        public RecursoNaoEncontradoException(string message, Exception inner) : base(message, inner) { }
        protected RecursoNaoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
