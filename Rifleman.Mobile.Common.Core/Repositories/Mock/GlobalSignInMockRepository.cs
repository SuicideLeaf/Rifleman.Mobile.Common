using System.Threading.Tasks;
using Rifleman.Mobile.Common.Core.Classes;
using Rifleman.Mobile.Common.Core.Models;
using Rifleman.Mobile.Common.Core.Repositories.Interfaces;

namespace Rifleman.Mobile.Common.Core.Repositories.Mock
{
	public class GlobalSignInMockRepository : IGlobalSignInRepository
	{
		public Task<ContactUserGetResponse> GetContactUserInstance( ContactUserGet request )
		{
			ContactUserGetResponse response = new ContactUserGetResponse
			{
				IsRequestSuccessful = request.Email == CoreConstants.Mock.ValidEmail,
				DataError = Enums.DataError.BadRequest,
				InstanceUrl = string.Empty
			};

			return Task.FromResult( response );
		}
	}
}