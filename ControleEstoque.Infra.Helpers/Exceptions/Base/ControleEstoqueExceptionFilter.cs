using ControleEstoque.Infra.Helpers.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Helpers.Exceptions.Base
{
    public class ControleEstoqueExceptionFilter: IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is null)
                return;

            var exception = context.Exception;

            context.Result = new ObjectResult(new ErroDetalhado(exception))
            {
                StatusCode = exception.GetType().GetCustomAttribute<StatusCodeAttribute>() is null 
                                ? 500 
                                : (int)exception.GetType().GetCustomAttribute<StatusCodeAttribute>().StatusCode,
            };

            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }

    public class ErroDetalhado 
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Mensagem { get; set; }
        public Exception InnerException { get; set; }
        public string StackTrace { get; set; }

        public ErroDetalhado(HttpStatusCode statusCode, string mensagem)
        {
            StatusCode = statusCode;
            Mensagem = mensagem;
        }

        public ErroDetalhado(Exception exception)
        {
            StatusCode = exception.GetType().GetCustomAttribute<StatusCodeAttribute>() is null
                                ? HttpStatusCode.InternalServerError
                                : exception.GetType().GetCustomAttribute<StatusCodeAttribute>().StatusCode;

            Mensagem = exception.Message;
            InnerException = exception.InnerException;
            StackTrace = exception.StackTrace;
        }
    }

}
