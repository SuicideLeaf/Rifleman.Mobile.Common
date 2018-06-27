namespace Rifleman.Mobile.Common.Core.Classes
{
	public static class CoreConstants
	{
		public static class Colours
		{
			// Basic
			public const string Black = "#000000";
			public const string White = "#FFFFFF";

			public const string Green = "#4ac06b";
			public const string LightGrey = "#eeeeee";
			public const string Grey = "#bdbdbd";
			public const string Slate = "#414c50";
			public const string Charcoal = "#262e31";
			public const string Purple = "#745f82";
			public const string Red = "#ce4837";
			public const string Orange = "#eb8f45";
			public const string Blue = "#0cb6ea";
		}

		public static class FormattingConstants
		{
			public const string Currency = "C";
			public const string Dashes = "D";
			public const string Date = "dd MMMM yyyy";
			public const string DateWithoutYear = "dd MMMM";
			public const string Time = "hh:mm tt";
			public const string TwoDecimalPlace = "N2";
		}

		public static class TimeoutConstants
		{
			public const int FileUploadSeconds = 180;
			public const int ConnectionSeconds = 45;
		}

		public static class MissingData
		{
			public const string NoRentAvailable = "No rent data found";
			public const string NotAvailable = "";
		}

		public static class ErrorMessages
		{
			public const string AccountLocked = "This user account is locked due to a large number of failed sign-in attempts. Please contact support to have your account activated again.";
			public const string AccountLockedTitle = "Account Locked";
			public const string ConnectionError = "Could not connect to Re-Leased";
			public const string ConnectionErrorTitle = "Connection Error";
			public const string CredentialsIncorrect = "The entered email or password is incorrect, please try again";
			public const string CredentialsIncorrectTitle = "Invalid Credentials";
			public const string Unauthorized = "Please try sign in again, or contact support if the problem persists.";
			public const string UnauthorizedTitle = "Access Denied";
		}

		public static class Messages
		{
			public const string Ok = "OK";
		}

		public static class Mock
		{
			public const string ValidEmail = "mock@re-leased.com";
			public const string ValidPassword = "password";
		}

		public static class Links
		{
			public const string Icons8 = "https://icons8.com";
		}

		public static class PreferenceKeys
		{
			public const string InstanceUrlKey = "EndPoint";
		}
	}
}
