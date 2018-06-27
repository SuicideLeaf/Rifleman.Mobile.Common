using System;

namespace Rifleman.Mobile.Common.Core.Interfaces
{
	public interface IThreadHandler
	{
		void RunActionInBackgroundThread( Action<object> method );
		void RunActionInUiThread( Action method );
	}
}
