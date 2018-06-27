using System.Threading.Tasks;
using Rifleman.Mobile.Common.Core.Models;

namespace Rifleman.Mobile.Common.Core.Repositories.Interfaces
{
	public interface ITokenRepository
	{
		Task<TokenRequestResponse> GetConsumerToken( );
	}
}
