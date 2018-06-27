using System.Threading.Tasks;
using Refit;
using Rifleman.Mobile.Common.Core.Models;
using Rifleman.Mobile.Common.Core.QueryParameters;

namespace Rifleman.Mobile.Common.Core.Api
{
	[Headers( "Authorization : Bearer" )]
	public interface IBaseApi
	{
		[Post( "/api/token" )]
		Task<TokenRequestResponse> GetConsumerToken( [Body]BaseQueryParameters baseQueryParams );
	}
}
