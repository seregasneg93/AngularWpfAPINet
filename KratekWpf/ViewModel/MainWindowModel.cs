using KratekData.Data.ConnectDB;
using KratekServices.HubClientWpf;
using KratekServices.WorkJobServerWPF.WorkRegistrationTerminals;
using KratekWpf.Commands;
using KratekWpf.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace KratekWpf.ViewModel
{
    internal class MainWindowModel : ViewModelBase
    {


        #region Свойства и поля

        readonly ConnectHub _connectHub;
        readonly ServerRegistrationTerminal _serverRegistrationTerminal = new();
        DispatcherTimer _dispatcherTimer = new(); // таймер опроса терминалов

        private string _title = string.Empty;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                Set(ref _title, value);
            }
        }

        private string _parametrWrite = string.Empty;
        public string ParametrWrite { get => _parametrWrite; set => Set(ref _parametrWrite, value); }

        private string _stateConnectServer = "Неопределено...";
        public string StateConnectServer { get => _stateConnectServer;  set { Set(ref _stateConnectServer, value); } }

        private string _textRefreshTimer = string.Empty; // свойство на форме на котором отображется время счетчика
        public string TextRefreshTimer { get => _textRefreshTimer; set => Set(ref _textRefreshTimer, value); }

        private DateTime _timeRefreshServer; // свойство счетчик, для повторных запросов на чтение терминала
        public DateTime TimeRefreshServer { get => _timeRefreshServer; set => Set(ref _timeRefreshServer, value); }

        #endregion

        #region Конструктор

        public MainWindowModel()
        {
             _connectHub = new(WriteParametrTerminal); // подключаемся к серверу SignalR

            _ = _serverRegistrationTerminal.StartServerRegistrationTerminalsAsync(); // старт сервера на подключения терминалов

            // старт таймера на регистрацию терминалов
            TimeRefreshServer = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 2, 30, 0);
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
             _dispatcherTimer.Tick += CountTimePoolTerminalsAsync;
            _dispatcherTimer.Start();

            Title = "Кратек Сервер";

            using (DataContext db = new())
            {
                var status = db.Database.CanConnect();

              //  var test = db.Terminals.ToList();
            }

            _ = StartResourcesApp();

            RefreshCommand = new LambdaCommand(OnRefreshCommand, CanRefreshCommand);
        }

        #endregion

        #region Команды

        public ICommand RefreshCommand { get; }
        private bool CanRefreshCommand(object p) => true;
        private async void OnRefreshCommand(object p)
        {
            await _connectHub.RefreshAllTerminals();
        }

        #endregion


        #region Методы

        private async void CountTimePoolTerminalsAsync(object? sender, EventArgs e)
        {
            TextRefreshTimer = $"До опроса терминалов : {TimeRefreshServer.Minute}m.- {TimeRefreshServer.Second}c.";

            TimeRefreshServer = TimeRefreshServer.AddSeconds(-1);

            // тут сервер опрашивает ровно в ноль секунд все котлы
            if (TimeRefreshServer.Minute == 0 && TimeRefreshServer.Second == 0)
            {
                await StartPollTerminalsAsync();
            }
            // тут метод ReceiveTime возвращает результат в какое время будет опрошен сл котлы. 00-30 : 1-00
            else if (ReceiveTime(TimeRefreshServer.Minute, TimeRefreshServer.Second))
            {
                // TODO
                await StartPollTerminalsAsync();
            }
        }

        async Task StartPollTerminalsAsync()
        {
            _dispatcherTimer.Stop();
            TextRefreshTimer = "Опрос терминалов ...";

            TimeRefreshServer = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 1, 30, 0);
            TextRefreshTimer = $"До обновления данных осталось : {TimeRefreshServer.Minute}m.- {TimeRefreshServer.Second}c. : идет опрос ошибок...";

            _dispatcherTimer.Start();
        }

        bool ReceiveTime(int minute, int sec)
        {
            if ((minute == 0 && sec == 30) || (minute == 1 && sec == 0)) // || (minute == 0 && sec == 30))
                return true;
            else
                return false;
        }

        async Task StartResourcesApp()
        {
            await Task.Run(() =>
            {
                  _connectHub.ConnecntToServerSignalR("Server");
            });

            //  _connectHub.ConnectSignalREvent.EventConnetToServer += EventToServer;
        }

        async void WriteParametrTerminal(string parametrTerminal)
        {
            ParametrWrite = parametrTerminal;

            // await Refresh();
        }

        private void EventToServer(string message)
        {
            StateConnectServer = message;
        }

        async Task Refresh()
        {
            // await _connectHub.RefreshWanTerminal(3);
        }

        #endregion

    }
}
