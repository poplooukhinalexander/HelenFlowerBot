# Telegram Bot of Helen Poploukhina
This bot (@lenatheflower_bot) helps subscribers to recieve promo-materials.

Parts of project:
* CommandBotParser - Handler of bot's commands.
* DataProvider - Promo-materials provider (used json).
* Model - Model of data.
* HelenFlowerBotApp - AWS Lambda function that handles bot's commands and returns data using DataProvider. AWS Lambda is called by AWS REST API Gateway. AWS REST API Gateway is called by Telegram's webhook.
* HelloWorldBot - Demo application for using Telegram's API.
