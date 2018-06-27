using Rifleman.Mobile.Common.Core.Classes;

namespace Rifleman.Mobile.Common.Core.Models
{
	/// <summary>
	/// This class is used to check whether or not the API request was successful.
	/// Request exceptions will be caught and translated into a DataError as part of this class (e.g. connection issues, server side exceptions, etc).
	/// </summary>
	public class BaseResponse
	{
		public bool IsRequestSuccessful { get; set; }
		public Enums.DataError DataError { get; set; }
	}
}
