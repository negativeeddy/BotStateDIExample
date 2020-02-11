# BotState Dependency Injection Example

## **NOTE:** This example is for BotFramework SDK v3. If you are using v4, see [the v4 documentation](https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-concept-state?view=azure-bot-service-4.0) instead.

This project is an example of how to set up a .NET [Bot Framework](https://dev.botframework.com/) project with the following goals
- configure the bot to [use custom state storage](https://docs.microsoft.com/en-us/bot-framework/dotnet/bot-builder-dotnet-state)
- use dependency injection to load the dialogs & services
- access the bot state interfaces from the dialogs & services without needing to pass around the IDialogContext or using the deprecated [StateClient](https://docs.microsoft.com/en-us/dotnet/api/microsoft.bot.connector.stateclient) class

The sample is configured to use your local [Cosmos DB Storage Emulator](https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator) to store the bot's state. You must either install the emulator or change the web.config file to point to an active Azure Cosmos DB  location.
