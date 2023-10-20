using System.Collections.Generic;

namespace Xtramile.WeatherForecasts.Library.Responses
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Success = true;
            ErrorMessages = new List<string>();
        }

        public BaseResponse(T data) : this()
        {
            Data = data;
        }

        public BaseResponse(string error) : this()
        {
            Success = false;
            ErrorMessages.Add(error);
        }

        public BaseResponse(List<string> errors) : this()
        {
            Success = false;
            ErrorMessages.AddRange(errors);
        }
        public bool Success { get; set; }

        public T Data { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}
