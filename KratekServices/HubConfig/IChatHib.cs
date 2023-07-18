using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.HubConfig
{
    public interface IChatHib
    {
        Task askServerResponce(string message);
        Task RefreshTerminalsResponce(string message);
        Task RefreshWanTerminalResponce(string parametrTerminal);
        Task RefreshWanResponce(int id);
    }
}
