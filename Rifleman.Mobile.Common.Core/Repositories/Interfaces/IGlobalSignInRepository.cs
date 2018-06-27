using System.Threading.Tasks;
using Rifleman.Mobile.Common.Core.Models;

namespace Rifleman.Mobile.Common.Core.Repositories.Interfaces
{
	public interface IGlobalSignInRepository
	{
		Task<ContactUserGetResponse> GetContactUserInstance( ContactUserGet request );
	}
}
