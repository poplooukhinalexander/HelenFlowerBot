using DataProvider;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace S3Demo
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var dataProvider = new AwsS3DataProvider();
			var cts = new CancellationTokenSource();
			var data = await dataProvider.GetBotDataAsync(cts.Token);
			Console.WriteLine(data.HelloText);
			Console.ReadLine();
			cts.Cancel();
		}
	}
}
