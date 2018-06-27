using System;

namespace Rifleman.Mobile.Common.Core.Interfaces
{
	public interface IRequestHelper
	{
		string GetInstanceUrl( );
		string GetDeviceId( );
		string GetDeviceInfo( );
		string GetUserEmail( );
		bool IsDeviceConnectedToInternet( );
		void SetInstanceUrl( string instanceUrl );
		Guid GetConsumerKey( );
		Guid GetSecret( );
		Guid? GetAuthToken( );
	}
}
