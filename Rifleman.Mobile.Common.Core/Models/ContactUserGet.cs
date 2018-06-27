using Rifleman.Mobile.Common.Core.Interfaces;
using Rifleman.Mobile.Common.Core.QueryParameters;

namespace Rifleman.Mobile.Common.Core.Models
{
	public class ContactUserGet : BaseQueryParameters
	{
		public string Email { get; set; }

		public ContactUserGet( string email, IRequestHelper requestHandler ) : base( requestHandler )
		{
			Email = email;
		}
	}
}
