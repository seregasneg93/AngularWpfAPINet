using KratekServices.WorkJobServerWPF.ControllerCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.WorkPollTerminals
{
    internal class ReadRewgistersFrequencies
    {
        public async Task<List<byte>> ReadRegistersFrequenciesAsync(TcpClient tcpClient,int modbuss,string typeFreq)
        {
            CommandController commandController = new();
            List<byte> arrayValidDataRegisters = new();

            byte[] arrayCommandReadFreq = commandController.ReceiveValidArrayByteChastotnick(modbuss,typeFreq);

            byte[] validArrayPollFreq = commandController.PreparationCommandForReadPollFreq(arrayCommandReadFreq);

            await ReceiveResultPollRegistersFreqAsync(tcpClient,validArrayPollFreq,modbuss,arrayValidDataRegisters).ConfigureAwait(false);

            return arrayValidDataRegisters;
        }

        async Task ReceiveResultPollRegistersFreqAsync(TcpClient tcpClient, byte[] commandFromController, int modbuss, List<byte> arrayValidDataRegisters)
        {
            int countHearBeather = 0;

            while (countHearBeather != 3)
            {
                if (!tcpClient.Connected)
                    break;

                Memory<byte> resultPoll = await PollRegistersFreqAsync(tcpClient, commandFromController).ConfigureAwait(false);

                if (resultPoll.Span[0] != 0)
                {
                    arrayValidDataRegisters = resultPoll.ToArray().ToList();

                    break;
                }
                else
                    countHearBeather++;
            }
        }

        async Task<Memory<byte>> PollRegistersFreqAsync(TcpClient tcpClient, byte[] commandFromController)
        {
            CancellationTokenSource cts = new();
            cts.CancelAfter(12_000);
            ReadOnlyMemory<byte> arrayCommandOnread = commandFromController;
            Memory<byte> arrayReceiveTerminal = new();
            NetworkStream stream = tcpClient.GetStream();

            try
            {
                await stream.WriteAsync(arrayCommandOnread, cts.Token).ConfigureAwait(false);
                await stream.ReadAsync(arrayReceiveTerminal, cts.Token).ConfigureAwait(false);

                if (arrayReceiveTerminal.Span[0] == commandFromController[0] && arrayReceiveTerminal.Span[1] == commandFromController[1])
                    return arrayReceiveTerminal;
                else
                {
                    arrayReceiveTerminal.Span[0] = 0;
                    return arrayReceiveTerminal;
                }
            }
            catch (OperationCanceledException op)
            {
                tcpClient.Dispose();
                tcpClient.Close();
                arrayReceiveTerminal.Span[0] = 0;
                throw;
            }
            catch (Exception e)
            {
                tcpClient.Dispose();
                tcpClient.Close();
                arrayReceiveTerminal.Span[0] = 0;
                throw;
            }
            finally
            {
                await stream.FlushAsync(cts.Token).ConfigureAwait(false);
            }
        }
    }
}
