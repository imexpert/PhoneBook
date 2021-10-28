using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Utilities.Results
{
    public class ResponseMessage<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string DeveloperMessage { get; set; }
        public string Message { get; set; }
        public static ResponseMessage<T> Success(T data, int statusCode)
        {
            return new ResponseMessage<T>
            {
                Data = data,
                IsSuccess = true,
                StatusCode = statusCode
            };
        }
        public static ResponseMessage<T> Success(int statusCode)
        {
            return new ResponseMessage<T>
            {
                Data = default(T),
                IsSuccess = true,
                StatusCode = statusCode
            };
        }
        public static ResponseMessage<T> NoDataFound()
        {
            return new ResponseMessage<T>
            {
                Data = default(T),
                IsSuccess = false,
                StatusCode = ((int)HttpStatusCode.NotFound)
            };
        }
        public static ResponseMessage<T> Fail(string message,string developerMessage = null)
        {
            return new ResponseMessage<T>
            {
                Data = default(T),
                Message = message,
                DeveloperMessage = developerMessage ?? message,
                IsSuccess = false,
                StatusCode = ((int)HttpStatusCode.InternalServerError)
            };
        }
    }
}
