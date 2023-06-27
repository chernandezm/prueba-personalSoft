using System.Collections.Generic;
using System.Net;

namespace Prueba.Api.Model.DTO.ResponseServices
{
    public class ResponseServices<T>
    {
        public IEnumerable<string> Errors { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}
