using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BaseBot.Services
{
    public class UserData : IUserData
    {
        private readonly IBotData _botData;
        private readonly IStateClient _stateClient;

        public UserData(IBotData botData, IStateClient client)
        {
            _botData = botData;
        }

        public string CustomData
        {
            get
            {
                try
                {
                    if (_botData.PrivateConversationData.TryGetValue(nameof(CustomData), out string val))
                    {
                        return val;
                    }
                }
                catch
                {
                }

                return "<empty value>";
            }

            set
            {
                _botData.PrivateConversationData.SetValue(nameof(CustomData), value);
            }
        }
    }
}