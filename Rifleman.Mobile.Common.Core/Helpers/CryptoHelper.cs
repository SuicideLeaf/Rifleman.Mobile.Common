using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Rifleman.Mobile.Common.Core.Classes.Constants;

namespace Rifleman.Mobile.Common.Core.Helpers
{
    public static class CryptoHelper
    {
        public static string GenerateApiSignedHash( Guid requestId, string deviceId, Guid consumerSecret )
        {
            string input = string.Concat( requestId.ToString( FormattingConstants.Dashes ), deviceId );
            string key = consumerSecret.ToString( FormattingConstants.Dashes );

            byte[ ] inputAsBytes = Encoding.UTF8.GetBytes( input );
            byte[ ] keyAsBytes = Encoding.UTF8.GetBytes( key );

            using( HMACSHA1 sha1 = new HMACSHA1( keyAsBytes ) )
            {
                byte[ ] saltedHash = sha1.ComputeHash( inputAsBytes );

                string hashAsString = Convert.ToBase64String( saltedHash );

                return WebUtility.UrlEncode( hashAsString );
            }
        }
    }
}
