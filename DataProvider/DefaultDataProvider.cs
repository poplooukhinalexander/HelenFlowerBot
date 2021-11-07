using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataProvider
{
	public class DefaultDataProvider
	{				
		public BotData GetData()
		{
			var botDataFilePath = Path.Combine(AppContext.BaseDirectory, "BotData.json");
			var botDataFileContent = File.ReadAllText(botDataFilePath);
			var botData = JsonConvert.DeserializeObject<BotData>(botDataFileContent);
			return botData;
		}		
	}
}
