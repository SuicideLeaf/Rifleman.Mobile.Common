namespace Rifleman.Mobile.Common.Core.Interfaces
{
	public interface IAnalyticsProvider
	{
		void TrackEvent( string eventName );
		void TrackScreenHit( string screenName );
	}
}