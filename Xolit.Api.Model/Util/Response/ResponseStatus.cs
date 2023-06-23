using System.Collections.Generic;
using Xolit.Api.Model.DTO.ResponseServices;

namespace Xolit.Api.Model.Util.Response
{
    public class ResponseStatus
    {
        public static ResponseServices<T> ResponseSucessful<T>(T data)
        {
            return new ResponseServices<T>() { StatusCode = System.Net.HttpStatusCode.OK, Data = data };
        }

        public static ResponseServices<T> ResponseWithoutData<T>(string message)
        {
            return new ResponseServices<T>() { StatusCode = System.Net.HttpStatusCode.NotFound, Message = message };
        }

        public static ResponseServices<T> ResponseError<T>(string message)
        {
            return new ResponseServices<T>() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = message };
        }

        public static ResponseServices<T> ResponseErrors<T>(IEnumerable<string> errors)
        {
            return new ResponseServices<T>() { StatusCode = System.Net.HttpStatusCode.BadRequest, Errors = errors };
        }
    }
}
