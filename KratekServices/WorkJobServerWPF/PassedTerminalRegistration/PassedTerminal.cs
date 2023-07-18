using KratekData.Data.Entyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.PassedTerminalRegistration
{
    public class PassedTerminal
    {
        public PassedTerminal()
        {

        }

        public string IMEI { get; set; }
        public TcpClient TcpClient { get; set; }
        public List<PassedBoiler> PassedBoilers { get; set; }
    }
}
