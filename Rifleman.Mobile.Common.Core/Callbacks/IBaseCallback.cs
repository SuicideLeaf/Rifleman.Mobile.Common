using Rifleman.Mobile.Common.Core.Classes;

namespace Rifleman.Mobile.Common.Core.Callbacks
{
	public interface IBaseCallback
	{
		void OnDataError( Enums.DataError dataError );
	}
}
