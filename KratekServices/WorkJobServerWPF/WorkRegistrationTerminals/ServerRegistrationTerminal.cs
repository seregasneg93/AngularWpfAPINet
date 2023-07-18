using KratekServices.Logger;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.WorkRegistrationTerminals
{
    public class ServerRegistrationTerminal
    {
        RegistrationClientTerminal _registreationClientTerminal = new();

        public static List<RegistrastionTerminal> RegistrastionTerminals = new();

        public async Task StartServerRegistrationTerminalsAsync()
        {

            try
            {
                TcpListener listenerTcp = new(IPAddress.Parse("192.168.0.168"), 11004);
                listenerTcp.Start();

                while (true)
                {
                    TcpClient newClient = await listenerTcp.AcceptTcpClientAsync();

                    _ = _registreationClientTerminal.RegisterClientAsync(newClient);
                }
            }
            catch (Exception e)
            {
                LoggerApp.LogErrorsInWorkTcpListener.Error($"Ошибка при работе сервера , ip 192.168.0.168 , port 11004 , \n Exception : {e}");

                throw;
            }


            #region Метода дял получения порта из папки в файле json

            //  var path = "Data/ActualPorts/portServer.json";
            // int port = Convert.ToInt32(File.ReadAllText(path));

            #endregion
        }
    }
}
