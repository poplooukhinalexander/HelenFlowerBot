using Amazon.S3;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DataProvider
{
	public class AwsS3DataProvider : BaseDataProvider
	{
		private readonly AmazonS3Client s3Client = new AmazonS3Client();
		protected override async Task<string> LoadBotDataAsync(CancellationToken cancellationToken)
		{
			using var s3Object = await s3Client.GetObjectAsync("helen-bot-data", "BotData.json", cancellationToken);
			using var sr = new StreamReader(s3Object.ResponseStream);
			var botRawData = await sr.ReadToEndAsync();
			return botRawData;
		}
	}
}
