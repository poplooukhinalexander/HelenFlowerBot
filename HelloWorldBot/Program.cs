using CommandBotParser;
using DataProvider;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace HelloWorldBot
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var myBot = new TelegramBotClient("2056284575:AAHqPrdkhCMtpMoK6m5KVtyKTrSGY-Mr8eI");
			var me = await myBot.GetMeAsync();
			Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

			using var cts = new CancellationTokenSource();			
			var dataProvider = new DefaultDataProvider();
			var cmdParser = new CommandParser(botDataProvider: dataProvider.GetData);
			myBot.StartReceiving(new DefaultUpdateHandler(cmdParser.HandleUpdateAsync, cmdParser.HandleErrorAsync));
			Console.WriteLine($"Start listening for @{me.Username}");
			Console.ReadLine();

			// Send cancellation request to stop bot
			cts.Cancel();		
		}
	}
}
