using System;
using System.IO;
using Rifleman.Mobile.Common.Core.Helpers;
using Rifleman.Mobile.Common.Core.Interfaces;

namespace Rifleman.Mobile.Common.Core.Classes
{
	public class RequestData
	{
		public string CheckSum { get; set; }
		public Guid ConsumerKey { get; set; }
		public string DeviceIdentifier { get; set; }
		public string EndPoint { get; set; }
		public string InstanceUrl { get; set; }
		public Guid RequestIdentifier { get; set; }
		public Guid Secret { get; set; }
		public Guid Token { get; set; }

		public RequestData( ) { }

		public RequestData( IRequestHelper requestHandler )
		{
			Token = requestHandler.GetAuthToken( ) ?? Guid.Empty;
			DeviceIdentifier = requestHandler.GetDeviceId( );
			ConsumerKey = requestHandler.GetConsumerKey( );
			InstanceUrl = requestHandler.GetInstanceUrl( );
			Secret = requestHandler.GetSecret( );
			RequestIdentifier = Guid.NewGuid( );

			CheckSum = CryptoHelper.GenerateApiSignedHash( RequestIdentifier, DeviceIdentifier, Secret );
		}

		public void SetBaseEndPoint( string controller, bool hasInstanceUrl = true )
		{
			// If we do not have an instance url yet, use the global api instance url.
			string instanceUrl = hasInstanceUrl ? InstanceUrl : CoreConfig.GetGlobalAdminInstanceUrl( );

			EndPoint = Path.Combine( instanceUrl, "api", controller );
		}

		public void SetEndPoint( string controller, string extraParams, bool hasInstanceUrl = true )
		{
			SetBaseEndPoint( controller, hasInstanceUrl );

			EndPoint += $"?token={Token}" +
				 $"&requestIdentifier={RequestIdentifier}" +
				 $"&deviceIdentifier={DeviceIdentifier}" +
				 $"&checksum={CheckSum}" + extraParams;
		}
	}
}
