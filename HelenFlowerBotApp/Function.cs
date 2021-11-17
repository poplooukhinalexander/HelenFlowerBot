using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using CommandBotParser;
using DataProvider;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace HelenFlowerBotApp
{   
    public class Function
    {        

        /// <summary>
        /// A simple function that takes a string and returns both the upper and lower case version of the string.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task FunctionHandler(Update request, ILambdaContext context)
        {           
            try
			{               
                var botClient = new TelegramBotClient("2056284575:AAHqPrdkhCMtpMoK6m5KVtyKTrSGY-Mr8eI");
                using var cts = new CancellationTokenSource();
                var dataProvider = GetDataProvider();
                var dataObject = await dataProvider.GetBotDataAsync(cts.Token);                
                var cmdParser = new CommandParser(dataObject);                                                        
                await cmdParser.HandleUpdateAsync(botClient, request, cts.Token);                
            }
            catch (Exception ex)
			{
                context.Logger.Log($"Error: {ex}");
			}
        }

        private static BaseDataProvider GetDataProvider() => new AwsS3DataProvider();
    }

    public record Casing(string Lower, string Upper);
}
