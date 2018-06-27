using System.Threading.Tasks;
using Rifleman.Mobile.Common.Core.Api;
using Rifleman.Mobile.Common.Core.Classes;
using Rifleman.Mobile.Common.Core.DataSources;
using Rifleman.Mobile.Common.Core.Interfaces;
using Rifleman.Mobile.Common.Core.Models;
using Rifleman.Mobile.Common.Core.QueryParameters;
using Rifleman.Mobile.Common.Core.Repositories.Interfaces;

namespace Rifleman.Mobile.Common.Core.Repositories
{
	public class TokenRepository : BaseApiDataSource, ITokenRepository
	{
		private readonly IBaseApi _api;

		public TokenRepository( IBaseApi api, IRequestHelper requestHandler, IGlobalSignInApi globalSignInApi, IInjectionHandler injectionHandler ) : base( requestHandler, globalSignInApi, injectionHandler )
		{
			_api = api;
		}

		public async Task<TokenRequestResponse> GetConsumerToken( )
		{
			return await SafeCallApi( async delegate
			{
				return await Task.Run( async ( ) =>
				{
					BaseQueryParameters queryParams = new BaseQueryParameters( RequestHandler );
					TokenRequestResponse response = await _api.GetConsumerToken( queryParams );

					if ( !response.IsRequestSuccessful )
					{
						response.DataError = Enums.DataError.Unauthorized;
					}

					return response;
				} );
			} );
		}
	}
}
