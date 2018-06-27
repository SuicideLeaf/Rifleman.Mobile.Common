using System;

namespace Rifleman.Mobile.Common.Core.Classes
{
	public static class CoreConfig
	{
		private const string GlobalApiInstanceUrl = "https://signin.re-leased.com/";
		//private const string GlobalApiInstanceUrlStaging = "https://globalsigninstaging.azurewebsites.net/";
		private const string GlobalApiInstanceUrlStaging = "http://192.168.1.66:50533/";

		public const string StagingEndPoint = "https://staging.re-leased.com/";

		public static Guid TestConsumerKey => Guid.Parse( "3dea58d5-a453-4924-98f8-b3af64c97be5" );
		public static Guid TestConsumerSecret => Guid.Parse( "1825c037-6e43-4cf2-9cdf-ad120c639874" );

		public static string GetGlobalAdminInstanceUrl( )
		{
#if DEBUG || STAGING
			return GlobalApiInstanceUrlStaging;
#else
			return GlobalApiInstanceUrl;
#endif
		}
	}
}
