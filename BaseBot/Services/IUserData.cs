using System.Threading;
using System.Threading.Tasks;

namespace BaseBot.Services
{
    public interface IUserData
    {
        string CustomData { get; set; }
    }
}