using Model;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DataProvider
{
	public abstract class BaseDataProvider
	{
		public virtual async Task<BotData> GetBotDataAsync(CancellationToken cancellationToken)
		{
			var rawData = await LoadBotDataAsync(cancellationToken);
			var botData = JsonConvert.DeserializeObject<BotData>(rawData);
			return botData;
		}

		protected abstract Task<string> LoadBotDataAsync(CancellationToken cancellationToken);		
	}
}
