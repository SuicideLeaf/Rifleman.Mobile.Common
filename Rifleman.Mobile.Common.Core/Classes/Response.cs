using System.Net;

namespace Rifleman.Mobile.Common.Core.Classes
{
	public class Response<T>
	{
		public T Model { get; set; }
		public HttpStatusCode StatusCode { get; set; }
		public bool Success { get; set; }

        public Response( T model, HttpStatusCode statusCode, bool isSuccess )
        {
            Model = model;
            StatusCode = statusCode;
            Success = isSuccess;
        }

        public Response( ) { }
    }
}
