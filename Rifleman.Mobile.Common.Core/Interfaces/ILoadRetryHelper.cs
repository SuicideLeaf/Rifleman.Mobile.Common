namespace Rifleman.Mobile.Common.Core.Interfaces
{
	public interface ILoadRetryHelper
	{
		void ShowLoading( );

		void HideLoading( );

		void ShowRetry( string message );

		void HideRetry( );

		void HideLoadingAndRetry( );
	}
}
