using KratekServices.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.WorkRegistrationTerminals
{
    internal class RegistrationClientTerminal
    {

        public async Task RegisterClientAsync(TcpClient tcpClient)
        {
            // регистрируем по протоколу и получаем результат

            AitorizationProtocolTeleofis _autorizationProtocolTeleofis = new();

            string imei = await _autorizationProtocolTeleofis.ReceiveResultAytirazationJobShannelAsync(tcpClient).ConfigureAwait(false);

            if(imei != string.Empty)
                  await AddClientInCollectionAsync(tcpClient, imei).ConfigureAwait(false);

        }

        async Task AddClientInCollectionAsync(TcpClient tcpClient, string imei)
        {
            string lengthIMEI = imei[..2];
            object lockCollection = new();

            if (lengthIMEI == "35")
            {
                await Task.Run(() =>
                {
                    lock(lockCollection)
                    {
                        RegistrastionTerminal findTerminal = ServerRegistrationTerminal.RegistrastionTerminals.FirstOrDefault(x => x.IMEI == imei);

                        if(findTerminal is null)
                        {
                            RegistrastionTerminal newRegistrastionTerminal = new()
                            {
                                IMEI = imei,
                                Client =tcpClient
                            };

                            ServerRegistrationTerminal.RegistrastionTerminals.Add(newRegistrastionTerminal);
                            LoggerApp.LogRegistraionTerminalsInColletions.Information($"Терминал был добавлен , imei - {imei}");
                        }             
                        else
                        {
                            findTerminal.Client = tcpClient;
                            LoggerApp.LogRegistraionTerminalsInColletions.Information($"Терминал был обновлен , imei - {imei}");
                        }  
                    }
                });
            }
        }

        #region Реализация через потокобезопасную коллекцию

    //    RegistrastionTerminal? outRegistrastionTerminal;

    //    bool resultPeek = ServerRegistrationTerminal.RegistrastionTerminals.TryPeek(out outRegistrastionTerminal);

    //                if(resultPeek)
    //                {
    //                    RegistrastionTerminal registrastionTerminal = new RegistrastionTerminal
    //                    {
    //                        IMEI = imei,
    //                        Client = socket
    //                    };

    //    bool resultTryTake = ServerRegistrationTerminal.RegistrastionTerminals.TryTake(out outRegistrastionTerminal);

    //                    if (resultTryTake)
    //                        ServerRegistrationTerminal.RegistrastionTerminals.Add(registrastionTerminal);
    //                    else
    //                        LoggerApp.LogErrorsAddCuncurentBag.Error($" \n Ошибка при добавлении нового терминала в коллекцию , imei {imei} , результат нахождения - {resultPeek}" +
    //                            $", результат удаления {resultTryTake}");
    //                }
    //                else
    //                {
    //                    RegistrastionTerminal registrastionTerminal = new RegistrastionTerminal
    //                    {
    //                        IMEI = imei,
    //                        Client = socket
    //                    };

    //ServerRegistrationTerminal.RegistrastionTerminals.Add(registrastionTerminal);
    //                }

        #endregion
    }
}
