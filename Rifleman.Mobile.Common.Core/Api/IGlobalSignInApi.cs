using System.Threading.Tasks;
using Refit;
using Rifleman.Mobile.Common.Core.Models;

namespace Rifleman.Mobile.Common.Core.Api
{
	[Headers( "Authorization : Bearer" )]
	public interface IGlobalSignInApi
	{
		[Post( "/api/contactuserlookup" )]
		Task<ContactUserGetResponse> GetContactUserInstance( [Body]ContactUserGet request );
	}
}
