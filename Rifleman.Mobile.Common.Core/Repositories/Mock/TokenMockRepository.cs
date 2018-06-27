using System.Threading.Tasks;
using Rifleman.Mobile.Common.Core.Classes;
using Rifleman.Mobile.Common.Core.Models;
using Rifleman.Mobile.Common.Core.Repositories.Interfaces;

namespace Rifleman.Mobile.Common.Core.Repositories.Mock
{
	public class TokenMockRepository : ITokenRepository
	{
		public Task<TokenRequestResponse> GetConsumerToken( )
		{
			TokenRequestResponse response = new TokenRequestResponse
			{
				IsRequestSuccessful = true,
				DataError = Enums.DataError.Unauthorized
			};

			return Task.FromResult( response );
		}
	}
}