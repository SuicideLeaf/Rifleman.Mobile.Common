using System;
using System.Threading.Tasks;
using Rifleman.Mobile.Common.Core.Models;

namespace Rifleman.Mobile.Common.Core.Presenters
{
	public interface ISignInPresenter : IBasePresenter
	{
		Task SignIn( Guid token );
		Task<ContactUserGetResponse> GetContactUserInstance( );
		Task<TokenRequestResponse> GetTemporaryValidationToken( );
	}
}
