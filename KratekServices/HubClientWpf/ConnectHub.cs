using KratekServices.HubClientWpf.Client;
using KratekServices.HubClientWpf.EventClient;
using KratekServices.HubConfig.ClientConnect;
using Microsoft.AspNetCore.SignalR.Client;

namespace KratekServices.HubClientWpf
{
    public class ConnectHub
    {
        public static HubConnection connection;
        ClientSignalR _clientSignalR;
        public ConnectSignalR ConnectSignalREvent = new();
        Action<string> _methodRefresh;

        public ConnectHub(Action<string> methodRefresh)
        {
            _methodRefresh = methodRefresh;
        }   

        public void ConnecntToServerSignalR(string login)
        {
            // var path = "Data/ActualPorts/portsClient.json";
            string validUrl = Convert.ToString(File.ReadAllText("DataServices/ActualPorts/portsClient.json"));
            //string validUrl = port;
            _clientSignalR = new ClientSignalR
            {
                NamePK = login,
                User = Environment.MachineName
            };

            CleintSignalR client = new CleintSignalR
            {
                Login = "Wpf Admin"
            };

            connection = new HubConnectionBuilder()
                 .WithUrl(validUrl)
                 .WithAutomaticReconnect(new[] { TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(20), TimeSpan.FromSeconds(30) })
                 .Build();

            connection.StartAsync().Wait(15_000);

            connection.ServerTimeout = TimeSpan.FromMinutes(3);
            connection.InvokeAsync("askServer", client);

            IDisposable disposable = null;

            using (disposable)
            {
                disposable = connection.On<string>("askServerResponce", (message) =>
                {
                    ConnectSignalREvent.InvokeEvent(message);
                });
            }

            IDisposable disposableRefreshWanTerminal = null;
            using (disposableRefreshWanTerminal)
            {
                disposable = connection.On<string>("RefreshWanTerminalResponce", (message) =>
                {
                    _methodRefresh.Invoke(message);
                    connection.InvokeAsync("RefreshWanTerminalReceive",3);
                });
            }

            connection.Closed += closedServer =>
            {
                ConnectSignalREvent.InvokeEvent("Сервер недоступен");
                return Task.CompletedTask;
            };

            connection.Reconnecting += reconnectServer =>
            {
                ConnectSignalREvent.InvokeEvent("Происходит переподключение к серверу!");

                return Task.CompletedTask;
            };

            connection.Reconnected += reconnectServer =>
            {
                ConnectSignalREvent.InvokeEvent("Вы успешно авторизовались на сервере!");
                return Task.CompletedTask;
            };
        }

        public async Task RefreshAllTerminals()
        {
           await connection.InvokeAsync("RefreshTerminals");
        }

        public async Task RefreshWanTerminal(int id)
        {
            await connection.InvokeAsync("RefreshWanTerminalReceive");
        }
    }
}
