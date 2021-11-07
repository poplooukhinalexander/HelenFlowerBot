﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CommandBotParser
{
	public class CommandParser
	{				
		private readonly Func<BotData> botDataProvider;		

		public CommandParser(Func<BotData> botDataProvider)
		{						
			this.botDataProvider = botDataProvider ?? throw new ArgumentNullException(nameof(botDataProvider));			
;		}

		private IEnumerable<IEnumerable<InlineKeyboardButton>> GetProductUrlButtons()
		{
			return botDataProvider().Products.Select(_ => new[] { InlineKeyboardButton.WithUrl(_.Name, _.Link) });
		}

		public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
		{
			var ErrorMessage = exception switch
			{
				ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
				_ => exception.ToString()
			};

			Console.WriteLine(ErrorMessage);
			return Task.CompletedTask;
		}
		public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		{
			if (update.Type != UpdateType.Message)
			{
				await Task.CompletedTask;
				return;
			}						
			var chatId = update.Message.Chat.Id;
			var username = $"{update.Message.From.LastName} {update.Message.From.FirstName}";
			if (string.IsNullOrWhiteSpace(username))
				username = update.Message.From.Username;
			await DefaultCommandHandlerAsync(chatId, username, botClient, cancellationToken);
		}		

		/// <summary>
		/// Отправляет инлайн кнопки с ссылками на продукты.
		/// </summary>
		/// <param name="chatId"></param>		
		/// <param name="username"></param>
		/// <param name="botClient"></param>
		/// <param name="cancellationToken"></param>		
		/// <returns></returns>
		private async Task DefaultCommandHandlerAsync(long chatId, 			
			string username,
			ITelegramBotClient botClient, CancellationToken cancellationToken)
		{
			var productUrlBtns = GetProductUrlButtons();
			var productMarkup = new InlineKeyboardMarkup(productUrlBtns);

			await botClient.SendTextMessageAsync(chatId: chatId,
				text: botDataProvider().GetHelloText(username),
				parseMode: ParseMode.MarkdownV2,
				disableNotification: true,							
				replyMarkup: productMarkup,
				cancellationToken: cancellationToken);			
		}
	}
}
