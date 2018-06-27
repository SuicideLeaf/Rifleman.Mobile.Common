using System.Threading.Tasks;
using Rifleman.Mobile.Common.Core.Api;
using Rifleman.Mobile.Common.Core.Classes;
using Rifleman.Mobile.Common.Core.DataSources;
using Rifleman.Mobile.Common.Core.Interfaces;
using Rifleman.Mobile.Common.Core.Models;
using Rifleman.Mobile.Common.Core.Repositories.Interfaces;

namespace Rifleman.Mobile.Common.Core.Repositories
{
	public class GlobalSignInRepository : BaseApiDataSource, IGlobalSignInRepository
	{
		private readonly IGlobalSignInApi _globalSignInApi;

		public GlobalSignInRepository( IGlobalSignInApi globalSignInApi, IRequestHelper requestHandler, IInjectionHandler injectionHandler  ) : base( requestHandler,globalSignInApi, injectionHandler )
		{
			_globalSignInApi = globalSignInApi;
		}

		public async Task<ContactUserGetResponse> GetContactUserInstance( ContactUserGet request )
		{
			return await SafeCallApi( async delegate
			{
				return await Task.Run( async ( ) =>
				{
					ContactUserGetResponse response = await _globalSignInApi.GetContactUserInstance( request );

					if ( !response.IsRequestSuccessful )
					{
						response.DataError = Enums.DataError.BadRequest;
					}

					return response;
				} );
			} );
		}
	}
}
