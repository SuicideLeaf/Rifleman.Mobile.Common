using System;
using Refit;
using Rifleman.Mobile.Common.Core.Helpers;
using Rifleman.Mobile.Common.Core.Interfaces;

namespace Rifleman.Mobile.Common.Core.QueryParameters
{
	public class BaseQueryParameters
	{
		[AliasAs( "token" )]
		public string Token { get; set; }
		[AliasAs( "requestIdentifier" )]
		public string RequestIdentifier { get; set; }
		[AliasAs( "deviceIdentifier" )]
		public string DeviceIdentifier { get; set; }
		[AliasAs( "checksum" )]
		public string Checksum { get; set; }

		public BaseQueryParameters( IRequestHelper requestHandler )
		{
			Guid token = requestHandler.GetAuthToken( ) ?? Guid.Empty;
			Guid requestId = Guid.NewGuid( );
			string deviceId = requestHandler.GetDeviceId( );

			Token = token.ToString( );
			RequestIdentifier = requestId.ToString( );
			DeviceIdentifier = deviceId;
			Checksum = CryptoHelper.GenerateApiSignedHash( requestId, deviceId, requestHandler.GetSecret( ) );
		}
	}
}
