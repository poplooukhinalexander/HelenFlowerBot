using System.Collections.Generic;

namespace Model
{
	public class BotData
	{
		public string HelloText { get; set; }

		public IEnumerable<ProductItem> Products { get; set; }

		public string GetHelloText(string username) => string.Format(HelloText, username);
	}
}
