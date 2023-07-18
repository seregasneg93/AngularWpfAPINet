using KratekServices.HubConfig.ClientConnect;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.HubConfig
{
    public class ChatHub : Hub<IChatHib>
    {
        public async Task askServer(CleintSignalR messageClient)
        {
            await Clients.All.askServerResponce($"Добро пожаловать, ваша роль сервера - {messageClient.Login}");
        }

        public async Task RefreshTerminals()
        {
            await Clients.All.RefreshTerminalsResponce("Произошло обновление клиентов");
        }

        public async Task RefreshWanTerminal(string parametrTerminal)
        {
            await Clients.All.RefreshWanTerminalResponce(parametrTerminal);
        }

        public async Task RefreshWanTerminalReceive(int Id)
        {
            await Clients.All.RefreshWanResponce(Id);
        }
    }
}
