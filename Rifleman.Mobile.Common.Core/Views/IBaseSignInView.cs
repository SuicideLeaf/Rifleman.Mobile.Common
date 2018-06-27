using System;

namespace Rifleman.Mobile.Common.Core.Views
{
	public interface IBaseSignInView : IApiView 
	{
		/// <summary>
		/// The email string that the user has entered
		/// </summary>
		string Email { get; }

		/// <summary>
		/// The password string that the user has entered.
		/// </summary> 
		string Password { get; }

		/// <summary>
		/// Property to indicate the current signing-in state of the application.
		/// </summary>
		bool IsSigningIn { get; set; }

		/// <summary>
		/// Checks that the entered email is in a valid email format
		/// </summary>
		bool ValidateEmailFormat( );

		/// <summary>
		/// Updates the UI of the sign in button to reflect whether or not the button is enabled/disabled
		/// </summary>
		void UpdateSignInButtonEnabledState( );

		/// <summary>
		/// Updates the UI to give the user feedback that the application is currently signing in.
		/// </summary>
		void ShowSigningIn( bool signingIn );

		/// <summary>
		/// Navigates to the home screen, usually after successfully signing in.
		/// </summary>
		void GoToHomeScreen( );

		/// <summary>
		/// Stores the instance url on the device for use in further requests.
		/// </summary>
		void SetInstanceUrl( string instanceUrl );

		/// <summary>
		/// Stores a bit on the device indicating that the user is signed in.
		/// </summary>
		void SetIsSignedIn( );

		/// <summary>
		/// Stores the email string on the device from the email text field.
		/// </summary>
		void SetLastUsedEmail( );

		/// <summary>
		/// Sets the email text field to the last used email stored on the device.
		/// </summary>
		void SetEmailToLastUsedEmail( );

		/// <summary>
		/// Stores the authentication token on the device for use in further requests.
		/// </summary>
		void StoreAuthenticationToken( Guid token );

		/// <summary>
		/// Sets the email and password of the login form for ease-of-use for development
		/// </summary>
		void SetMockEmailAndPassword( );

		/// <summary>
		/// Shows the instance url dialog for manual entry.
		/// </summary>
		void ShowInstanceUrlDialog( );
	}
}
