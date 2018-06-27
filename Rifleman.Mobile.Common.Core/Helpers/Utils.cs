using System.Text.RegularExpressions;

namespace Rifleman.Mobile.Common.Core.Helpers
{
	public static class Utils
	{
		public static string TryGetPluralS( int number )
		{
			if ( number == 1 )
			{
				return string.Empty;
			}

			return "s";
		}

		public static Regex GetReplaceExceptNumericRegex( )
		{
			return new Regex( @"[^\+0-9]" );
		}

		public static Regex GetPhoneNumberRegex( )
		{
			return new Regex( @"^[\-?\+?\s?\d]+$" );
		}
	}
}
