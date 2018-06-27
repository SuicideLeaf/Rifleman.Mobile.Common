using System.Threading.Tasks;

namespace Rifleman.Mobile.Common.Core.DataSources
{
	public class BaseMockDataSource
	{
		public async Task Delay( )
		{
			await Task.Delay( 1000 );
		}
	}
}
