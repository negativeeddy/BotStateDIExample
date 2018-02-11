using System;
using System.Threading;
using System.Threading.Tasks;
using BaseBot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BaseBot.Dialogs
{
    /// <summary>
    /// Uses dependency injection to access the IUserData component and sets
    /// the CustomData property to demonstrate reading/writing from bot state
    /// </summary>
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private readonly IUserData _userData;

        public RootDialog(IUserData userData)
        {
            _userData = userData;
        }

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync($"User data starts as: {_userData.CustomData}");
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // display the current value
            await context.PostAsync($"User data was: {_userData.CustomData}");

            // set the new value to the user's text entry
            _userData.CustomData = activity.Text;
            await context.PostAsync($"User data is now: \"{_userData.CustomData}\"");

            context.Wait(MessageReceivedAsync);
        }
    }
}