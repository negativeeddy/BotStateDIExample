using System;
using System.Threading;
using System.Threading.Tasks;
using BaseBot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BaseBot.Dialogs
{
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

            await context.PostAsync($"User data was: {_userData.CustomData}");
            _userData.CustomData = activity.Text;
            await context.PostAsync($"User data is now: \"{_userData.CustomData}\"");

            context.Wait(MessageReceivedAsync);
        }
    }
}