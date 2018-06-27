using Rifleman.Mobile.Common.Core.Classes;
using Rifleman.Mobile.Common.Core.Interfaces;

namespace Rifleman.Mobile.Common.Core.Models
{
	public class ApiTokenRequest : RequestData
	{
		public ApiTokenRequest( IRequestHelper requestHandler ) : base( requestHandler )
		{
			SetBaseEndPoint( "Token" );
		}
	}
}
