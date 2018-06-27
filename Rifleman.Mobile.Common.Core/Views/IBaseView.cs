using Rifleman.Mobile.Common.Core.Classes;
using Rifleman.Mobile.Common.Core.Interfaces;
using Unity;

namespace Rifleman.Mobile.Common.Core.Views
{
	public interface IBaseView
	{
		void SetPresenter( IUnityContainer container );

		void ShowDataError( Enums.DataError error );

		ILoadRetryHelper LoadRetryHelper { get; set; }
	}
}
