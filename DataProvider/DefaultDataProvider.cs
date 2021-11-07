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
		public string GetHelloText(string username)
		{
			return @$"{username}, здравствуйте\!

Вам пишет телеграм\-бот Елены Поплоухиной\. Я очень хочу принести пользу\. Пожалуйста, выберите продукт для скачивания\.";
		}	
		
		public IEnumerable<ProductItem> GetProducts()
		{
			return new ProductItem[] 
			{
				new ProductItem { Name = "Шпаргалка для беременных", Link = "https://drive.google.com/drive/folders/1oMHWRBEa86XNnW9M6k0ZKMk7ioG1BgMt?usp=sharing" },
				new ProductItem { Name = "Аптечка для новорожденного", Link = "https://drive.google.com/drive/folders/1cwtv0spylpX5nJxvdh9JYleJrzhEYVjh?usp=sharing" },
				new ProductItem { Name = "Товары для новорожденных ", Link = "https://www.lenatheflower.com/newborn" },
				new ProductItem { Name = "Instagram-блоги для мам", Link = "https://www.instagram.com/lenatheflower/guide/_/17872493435553673/" },
			};
		}
	}
}
