using System;
using System.Net.Http;

namespace Rifleman.Mobile.Common.Core.Classes
{
	public static class ApiHelper
	{
		public static HttpClient GetHttpClient( string baseAddress, string consumerKey )
		{
			AuthenticatedHttpClientHandler authenticatedHttpClientHandler = new AuthenticatedHttpClientHandler( consumerKey );
			HttpClient httpClient = new HttpClient( authenticatedHttpClientHandler ) { BaseAddress = new Uri( baseAddress ) };


#if DEBUG
			httpClient.Timeout = TimeSpan.FromSeconds( 10 );
#endif


			return httpClient;
		}
	}
}
