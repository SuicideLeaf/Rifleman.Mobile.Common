using System.Threading.Tasks;
using Rifleman.Mobile.Common.Core.Views;

namespace Rifleman.Mobile.Common.Core.Presenters
{
	public abstract class BasePresenter : IBasePresenter
	{
		public IBaseView View { get; set; }
		public abstract Task Start( );

		public virtual void ShowLoading( )
		{
			View.LoadRetryHelper.ShowLoading( );
		}

		protected internal BasePresenter( IBaseView view )
		{
			View = view;
		}
	}

	public abstract class BasePresenter<TView> : BasePresenter
		where TView : IBaseView
	{
		protected internal BasePresenter( TView view ) : base( view ) { }

		public new TView View
		{
			get => ( TView )base.View;
			set => base.View = value;
		}
	}
}
