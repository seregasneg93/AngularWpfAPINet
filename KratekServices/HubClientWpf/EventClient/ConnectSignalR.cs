using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.HubClientWpf.EventClient
{
    public delegate void EventConnectServer(string message); // событие на подключение к серверу
    public class ConnectSignalR
    {
        public event EventConnectServer EventConnetToServer = null;

        public void InvokeEvent(string message)
        {
            EventConnetToServer.Invoke(message);
        }
    }
}
