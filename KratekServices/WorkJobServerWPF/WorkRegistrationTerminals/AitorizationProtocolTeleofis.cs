using KratekServices.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.WorkRegistrationTerminals
{
    internal class AitorizationProtocolTeleofis
    {
        public async Task<string> ReceiveResultAytirazationJobShannelAsync(TcpClient tcpClient)
        {
            CancellationTokenSource cancellationToken = new();
            string validimei = string.Empty;
            //byte[] _arrayByteFromTerminal = new byte[28];
            //ArraySegment<byte> arrayServices = new();
            NetworkStream? stream = tcpClient.GetStream();
            try
            {
                // регистрация проходит по рабочему каналу по принципу, терминал к анм постучался, шлем ему привет, он в ответ шлет посылку, мы шлем подтверждение регистрации
                // по служебному каналу, точно все так же , только идет послыка дял подтверждения что мы регистрируем служебный канал

                ReadOnlyMemory<byte> arrayHello = ArrayRegistrationHello(); // приветствие
                Memory<byte> _recTerminalArray = new();

                cancellationToken.CancelAfter(10_000);

                await stream.WriteAsync(arrayHello, cancellationToken.Token).ConfigureAwait(false);// отправка приветствия
                await stream.ReadAsync(_recTerminalArray, cancellationToken.Token).ConfigureAwait(false);// ответ от терминала
                                                                                                        
                validimei = ReceiveIMEI(_recTerminalArray); // узнаем IMEI  _arrayByteFromTerminal // Tcp _recTerminalArray

                ReadOnlyMemory<byte> arrayJobAndServicesCahnnel = ArrayRegistrationAffirmative(); // подтсверждение регистрации

                Memory<byte> _recTerminalAut = new();

                await stream.WriteAsync(arrayJobAndServicesCahnnel, cancellationToken.Token).ConfigureAwait(false);// шлем подтваерждение регистрации
                await stream.ReadAsync(_recTerminalAut, cancellationToken.Token).ConfigureAwait(false);// ответ, пустой


            }
            catch (OperationCanceledException ex)
            {
                //  socket.Shutdown(SocketShutdown.Both);
                tcpClient.Dispose();
                tcpClient.Close();
                LoggerApp.LogErrorsRegistrationTerminals.Error($" Ошибка регистрации терминала - {validimei} - \n OperationCanceledException {ex}");
            }
            catch (IOException e)
            {
                tcpClient.Dispose();
                tcpClient.Close();
                LoggerApp.LogErrorsRegistrationTerminals.Error($"Ошибка регистрации терминала - {validimei} - \n IOException {e}");
            }
            catch (Exception e)
            {
                // socket.Shutdown(SocketShutdown.Both);
                tcpClient.Dispose();
                tcpClient.Close();
                LoggerApp.LogErrorsRegistrationTerminals.Error($" Ошибка регистрации терминала - {validimei} - \n Exception {e}");
            }
            finally
            {
                await stream.FlushAsync(cancellationToken.Token).ConfigureAwait(false); // чистим трубы
            }

            return validimei;

            #region Реализация с сервисным каналом связи а так же работа с socket напрямую

            //// if (typeChannel.Equals("Services"))
            // {
            //     // arrayServices = AutorizationServicesChannel();

            //     byte[] _recTerminalAutAgree = new byte[255];

            //     // await stream.WriteAsync(arrayServices).ConfigureAwait(false);
            //     // await stream.ReadAsync(_recTerminalAutAgree).ConfigureAwait(false);
            //     // await stream.FlushAsync().ConfigureAwait(false);

            //     //socket.SendAsync(arrayServices, SocketFlags.None); // шлем подтваерждение регистрации

            //     //socket.Receive(_arrayByteFromTerminal);
            // }

            //await socket.SendAsync(arrayJobAndServicesCahnnel, SocketFlags.None, cancellationToken.Token); // шлем подтваерждение регистрации

            //await socket.ReceiveAsync(_arrayByteFromTerminal, SocketFlags.None, cancellationToken.Token); // ответ, пустой

            // else if (typeChannel.Equals("Services"))
            //  imei = ReceiveIMEIServices(_arrayByteFromTerminal); // узнаем IMEI

            // await stream.FlushAsync(cancellationToken.Token).ConfigureAwait(false);
            // await socket.SendAsync(array, SocketFlags.None,cancellationToken.Token); // отправка приветствия

            // ArrayRegistration(ref _arrayByteFromTerminal);

            #endregion
        }

        public byte[] ArrayRegistrationHello() // массив приветствия по протоколу Teleofis
        {
            byte[] arrayHello = new byte[28];

            arrayHello[0] = 0xC0; //1
            arrayHello[1] = 0x00; //2
            arrayHello[2] = 0x06; //3
            arrayHello[3] = 0x00; //4
            arrayHello[4] = 0x14;//5
            arrayHello[5] = 0x00;//6
            arrayHello[6] = 0x00;//7
            arrayHello[7] = 0x00; //8
            arrayHello[8] = 0x00; //9
            arrayHello[9] = 0x00; //10
            arrayHello[10] = 0x00; //11
            arrayHello[11] = 0x00;// 12
            arrayHello[12] = 0x00;//13
            arrayHello[13] = 0x00;//14
            arrayHello[14] = 0x00;//15
            arrayHello[15] = 0x00;//16
            arrayHello[16] = 0x00;//17
            arrayHello[17] = 0x00;//18
            arrayHello[18] = 0x00;//19
            arrayHello[19] = 0x00;//20
            arrayHello[20] = 0x00;//21
            arrayHello[21] = 0x00;//22
            arrayHello[22] = 0x00;//23
            arrayHello[23] = 0x00;//24
            arrayHello[24] = 0x00;//25
            arrayHello[25] = 0xE7;//26
            arrayHello[26] = 0x48;//27
            arrayHello[27] = 0xC2;//28

            return arrayHello;
        }

        string ReceiveIMEI(Memory<byte> replyTerminal) // возвращаем IMEI дял рабочего канала
        {
            List<string> listIMEI = new();

            int index = 0;

            string IMEI = string.Empty;

            foreach (var byteMemory in replyTerminal.ToArray())
            {
                if (index <= 20)
                {
                    string str16 = Convert.ToString(byteMemory, 16);

                    str16 = str16.Substring(1, 1);

                    listIMEI.Add(str16);
                    index++;
                }
            }

            foreach (var item in listIMEI)
            {
                IMEI += item;
            }

            return IMEI.Length == 11 ? IMEI : string.Empty;
        }

        public string ReceiveIMEIServices(byte[] replyTerminal)
        {
            List<string> listIMEI = new List<string>();

            int index = 0;

            string IMEI = "";

            for (int i = 6; i <= replyTerminal.Length; i++)
            {
                if (i <= 20)
                {
                    string str16 = Convert.ToString(replyTerminal[i], 16);
                    // if (!str16.Equals("0"))
                    str16 = str16.Substring(1, 1);

                    listIMEI.Add(str16);
                    index++;
                }
            }

            foreach (var item in listIMEI)
            {
                IMEI = IMEI + item;
            }

            return IMEI;
        }

        byte[] ArrayRegistrationAffirmative() // Массив подтвержедния регистрации по протоколу Teleofis
        {
            byte[] arrayReg = new byte[28];

            arrayReg[0] = 0xC0; //1
            arrayReg[1] = 0x00; //2
            arrayReg[2] = 0x06; //3
            arrayReg[3] = 0x01; //4
            arrayReg[4] = 0x14;//5
            arrayReg[5] = 0x00;//6
            arrayReg[6] = 0x00;//7
            arrayReg[7] = 0x00; //8
            arrayReg[8] = 0x00; //9
            arrayReg[9] = 0x00; //10
            arrayReg[10] = 0x00; //11
            arrayReg[11] = 0x00;// 12
            arrayReg[12] = 0x00;//13
            arrayReg[13] = 0x00;//14
            arrayReg[14] = 0x00;//15
            arrayReg[15] = 0x00;//16
            arrayReg[16] = 0x00;//17
            arrayReg[17] = 0x00;//18
            arrayReg[18] = 0x00;//19
            arrayReg[19] = 0x00;//20
            arrayReg[20] = 0x00;//21
            arrayReg[21] = 0x00;//22
            arrayReg[22] = 0x00;//23
            arrayReg[23] = 0x00;//24
            arrayReg[24] = 0x00;//25
            arrayReg[25] = 0x3F;//26
            arrayReg[26] = 0x25;//27
            arrayReg[27] = 0xC2;//28

            return arrayReg;
        }

        byte[] AutorizationServicesChannel() // массив авторизации сервера в устройстве
        {
            byte[] autorization = new byte[12];

            autorization[0] = 0xC0;
            autorization[1] = 0x00;
            autorization[2] = 0x04;
            autorization[3] = 0x4E;
            autorization[4] = 0x04;
            autorization[5] = 0x30;
            autorization[6] = 0x30;
            autorization[7] = 0x30;
            autorization[8] = 0x30;

            autorization[9] = 0xC7; // C3 76 - C749
            autorization[10] = 0x49;

            autorization[11] = 0xC2;

            return autorization;
        }
    }
}
