using KratekServices.WorkJobServerWPF.ControllerCommand;
using KratekServices.WorkJobServerWPF.PassedTerminalRegistration;
using KratekServices.WorkJobServerWPF.RegisterConvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.WorkDB
{
    public class WriteRewgisterDB
    {
        public async Task ReadFregistersInDbAsync(PassedTerminal passedTerminal)
        {
            CommandController commandController = new();
            ConvertRegister convertRegister = new();
            ConvertRegistersFrequencies convertRegistersFrequencies = new();
            List<PrepfrationFrequenciesDB> prepfrationFrequenciesDB = new();

            foreach (var passed in passedTerminal.PassedBoilers)
            {
                prepfrationFrequenciesDB.Clear();

                if (passed.ArrayRegistersTerminal.Count > 0)
                {
                    int resultCRC = commandController.ReceiveValidCRC(passed.ArrayRegistersTerminal.ToArray(),passed.NameTerminal);

                    if(resultCRC == 1)
                    {                      
                        Dictionary<string, double> preparationRegistersTerminal = convertRegister.ReceiveConvertRegisters(passed.ArrayRegistersTerminal.ToArray(),
                                                                                                                             passed.NameTerminal);

                        foreach (var passedFreq in passed.PassedFrequencies)
                            if(passedFreq.ArrayRegistersFrequencies.Count > 0)
                                prepfrationFrequenciesDB.Add(convertRegistersFrequencies.ReceiveValidFreqForBD(passedFreq));
                    }
                }
            }
        }
    }
}
