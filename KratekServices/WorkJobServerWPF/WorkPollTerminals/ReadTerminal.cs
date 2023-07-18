using KratekServices.WorkJobServerWPF.PassedTerminalRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.WorkPollTerminals
{
    public class ReadTerminal
    {
        public async Task ReadTerminalAsync(PassedTerminal passedTerminal)
        {
            ReadRegiustersTerminal readRegiustersTerminal = new();
            ReadRewgistersFrequencies readRewgistersFrequencies = new();
            List<byte> arrayValidDataRegisters = new();
            List<byte> arrayValidDataRegistersFreq = new();

            foreach (var terminal in passedTerminal.PassedBoilers)
            {
                arrayValidDataRegisters.Clear();

                if (passedTerminal.TcpClient.Connected)
                {
                    terminal.IsPoll = true;

                    arrayValidDataRegisters = await readRegiustersTerminal.ReadRegistersTerinalAsync(passedTerminal.TcpClient,terminal.Modbuss);

                    if (arrayValidDataRegisters.Count > 0)
                        terminal.ArrayRegistersTerminal.AddRange(arrayValidDataRegisters);
                }

                foreach (var freq in terminal.PassedFrequencies)
                {
                    arrayValidDataRegistersFreq.Clear();

                    if (passedTerminal.TcpClient.Connected)
                    {
                        arrayValidDataRegistersFreq = await readRewgistersFrequencies.ReadRegistersFrequenciesAsync(passedTerminal.TcpClient, terminal.Modbuss,
                                                                                                                        freq.NameFrequencies);

                        if (arrayValidDataRegistersFreq.Count > 0)
                            arrayValidDataRegistersFreq.AddRange(arrayValidDataRegistersFreq);
                    }
                }
            }
        }
    }
}
