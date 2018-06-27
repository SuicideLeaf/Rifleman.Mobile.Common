namespace Rifleman.Mobile.Common.Core.Interfaces
{
	public interface IInjectionHandler
	{
		T Resolve<T>( );
		T Resolve<T>( string name );
		void InjectTokenRepository( );
		void InjectGlobalSignInRepository( );
		void InjectGlobalSignInApi( );
		void InjectApi( );
		void InjectRequestHandler( );
	}
}
