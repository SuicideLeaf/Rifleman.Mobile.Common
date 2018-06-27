using System.Net;

namespace Rifleman.Mobile.Common.Core.Classes
{
	public static class Extensions
	{
		public static Enums.DataError ToDataError( this HttpStatusCode enumValue )
		{
			switch ( enumValue )
			{
				case HttpStatusCode.NotFound:
					return Enums.DataError.NotFound;
				case HttpStatusCode.BadRequest:
					return Enums.DataError.BadRequest;
				case HttpStatusCode.Unauthorized:
					return Enums.DataError.Unauthorized;
				case HttpStatusCode.Forbidden:
					return Enums.DataError.Forbidden;
				default:
					return Enums.DataError.Connection;
			}
		}
	}
}