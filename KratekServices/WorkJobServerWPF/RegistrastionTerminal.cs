using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF
{
    public class RegistrastionTerminal
    {
        public RegistrastionTerminal()
        {

        }
        public TcpClient Client { get; set; }
        public string IMEI { get; set; }
    }
}
