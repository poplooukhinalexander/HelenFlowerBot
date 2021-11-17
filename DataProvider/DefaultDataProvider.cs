using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DataProvider
{
	public class DefaultDataProvider : BaseDataProvider
	{						
		protected override async Task<string> LoadBotDataAsync(CancellationToken cancellationToken)
		{
			var botDataFilePath = Path.Combine(AppContext.BaseDirectory, "BotData.json");
			var botDataFileContent = await File.ReadAllTextAsync(botDataFilePath, cancellationToken);
			return botDataFileContent;
		}
	}
}
