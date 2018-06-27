using System;
using System.Threading.Tasks;
using Rifleman.Mobile.Common.Core.Callbacks;
using Rifleman.Mobile.Common.Core.Interfaces;
using Rifleman.Mobile.Common.Core.Models;
using Rifleman.Mobile.Common.Core.Repositories.Interfaces;
using Rifleman.Mobile.Common.Core.Views;

namespace Rifleman.Mobile.Common.Core.Presenters
{
	public abstract class BaseSignInPresenter : BasePresenter<IBaseSignInView>, ISignInPresenter
	{
		private readonly IGlobalSignInRepository _globalRepository;
		private readonly IBaseCallback _callback;

		public readonly IRequestHelper RequestHandler;
		public readonly IInjectionHandler InjectionHandler;

		protected BaseSignInPresenter( IGlobalSignInRepository globalRepository, IRequestHelper requestHandler, 
		                              IInjectionHandler injectionHandler, IBaseSignInView view, IBaseCallback callback )
			: base( view )
		{
			RequestHandler = requestHandler;
			InjectionHandler = injectionHandler;

			_globalRepository = globalRepository;
			_callback = callback;
		}

		public abstract Task SignIn( Guid token );

		public override async Task Start( )
		{
			await StartSignInProcess( );
		}

		public async Task StartSignInProcess( )
		{
			View.ShowSigningIn( true );

#if DEBUG   // Sign in instantly, the local user instance url should already be set.

			await GetTokenAndSignIn( );

#else       // Call the global api for getting the user instance url.

			ContactUserGetResponse contactUserGetResponse = await GetContactUserInstance( );

			if ( contactUserGetResponse.IsRequestSuccessful )
			{
				View.SetInstanceUrl( contactUserGetResponse.InstanceUrl );
				await GetTokenAndSignIn( );
			}
			else
			{
				_callback.OnDataError( contactUserGetResponse.DataError );
			}

#endif
		}

		private async Task GetTokenAndSignIn( )
		{
			InjectionHandler.InjectApi( );

			TokenRequestResponse tokenResponse = await GetTemporaryValidationToken( );

			if ( tokenResponse.IsRequestSuccessful )
			{
				await SignIn( tokenResponse.Token );
			}
			else
			{
				_callback.OnDataError( tokenResponse.DataError );
			}
		}

		public async Task<ContactUserGetResponse> GetContactUserInstance( )
		{
			ContactUserGet request = new ContactUserGet( View.Email, RequestHandler );

			return await _globalRepository.GetContactUserInstance( request );
		}

		public async Task<TokenRequestResponse> GetTemporaryValidationToken( )
		{
			ITokenRepository tokenRepository = InjectionHandler.Resolve<ITokenRepository>( );

			return await tokenRepository.GetConsumerToken( );
		}
	}
}
