using System;
using System.Threading.Tasks;
using Refit;
using Rifleman.Mobile.Common.Core.Api;
using Rifleman.Mobile.Common.Core.Callbacks;
using Rifleman.Mobile.Common.Core.Classes;
using Rifleman.Mobile.Common.Core.Interfaces;
using Rifleman.Mobile.Common.Core.Models;
using Rifleman.Mobile.Common.Core.Presenters;

namespace Rifleman.Mobile.Common.Core.DataSources
{
	public class BaseApiDataSource
	{
		public readonly IRequestHelper RequestHandler;

		private readonly IGlobalSignInApi _globalSignInApi;

		private readonly IInjectionHandler _injectionHandler;

		public BaseApiDataSource( IRequestHelper requestHandler, IGlobalSignInApi globalSignInApi, IInjectionHandler injectionHandler )
		{
			RequestHandler = requestHandler;
			_globalSignInApi = globalSignInApi;
			_injectionHandler = injectionHandler;
		}
		/// <summary>
		/// Catches any exceptions when making a request and returns an appropriate data error to return in the callback
		/// </summary>
		public static async Task SafeCallApi( Func<Task> action, IBaseCallback callback )
		{
			try
			{
				await action( );
			}
			catch ( ApiException e )
			{
				callback.OnDataError( e.StatusCode.ToDataError( ) );
			}
			catch ( Exception )
			{
				callback.OnDataError( Enums.DataError.Connection );
			}
		}

		/// <summary>
		/// Catches any exceptions when making a request and returns an appropriate data error to return in the callback
		/// </summary>
		/// <returns>Returns object of type <typeparamref name="T"/>. If the request failed this method will return an appropriate data error with it.</returns>
		public static async Task<T> SafeCallApi<T>( Func<Task<T>> action )
			where T : BaseResponse, new()
		{
			try
			{
				T response = await action( );

				response.IsRequestSuccessful = true;

				return response;
			}
			catch ( ApiException e )
			{
				return new T
				{
					DataError = e.StatusCode.ToDataError( )
				};
			}
			catch ( Exception )
			{
				return new T
				{
					DataError = Enums.DataError.Connection
				};
			}
		}

		public virtual void HandleResponseForSignIn( BaseResponse response, Action successAction, IBaseCallback callback )
		{
			if ( response.IsRequestSuccessful )
			{
				successAction( );
			}
			else
			{
				callback.OnDataError( response.DataError );
			}
		}

		public virtual async Task HandleResponse( BaseResponse response, Action successAction, IBaseCallback callback, IBasePresenter basePresenter )
		{
			if ( response.IsRequestSuccessful )
			{
				successAction( );
			}
			else if ( response.DataError == Enums.DataError.Connection && RequestHandler.IsDeviceConnectedToInternet( ) )
			{
				await CheckIsInstanceUrlChanged( callback, basePresenter );
			}
			else
			{
				callback.OnDataError( response.DataError );
			}
		}

		private async Task CheckIsInstanceUrlChanged( IBaseCallback callback, IBasePresenter basePresenter )
		{
			string storedInstanceUrl = RequestHandler.GetInstanceUrl( );

			ContactUserGet contactUser = new ContactUserGet( RequestHandler.GetUserEmail( ), RequestHandler );
			ContactUserGetResponse contactUserRespose = await SafeCallApi( ( ) => _globalSignInApi.GetContactUserInstance( contactUser ) );

			if ( contactUserRespose.IsRequestSuccessful && contactUserRespose.InstanceUrl != storedInstanceUrl )
			{
				//set new url and call injectapi method to use new url 
				//RequestHandler.SetInstanceUrl( "http://192.168.1.66:57204/" );
				RequestHandler.SetInstanceUrl( contactUserRespose.InstanceUrl );
				_injectionHandler.InjectApi( );
				await basePresenter.Start( );
			}
			else
			{
				callback.OnDataError( contactUserRespose.DataError );
			}
		}
	}
}
