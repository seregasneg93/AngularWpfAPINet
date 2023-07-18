using KratekData.Data.Entyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.PassedTerminalRegistration
{
    public class PassedBoiler
    {
        public PassedBoiler()
        {

        }

        public PassedBoiler(Terminal terminal)
        {
            NameTerminal = terminal.NameTerminal;
            Modbuss = terminal.SlaveId;
            PassedFrequencies = new();
            ArrayRegistersTerminal = new();

            if (terminal.Frequencies != null && terminal.Frequencies.Count > 0)
            {
                foreach (var freq in terminal.Frequencies)
                {
                    // если больше 30 минут то добавляем и опрашиваем частотник
                    TimeSpan substrDate = DateTime.Now.Subtract(freq.LastPoll);

                    if(substrDate.Minutes > 30)
                        PassedFrequencies.Add(new PassedFrequencies(freq));
                }
                    
            }
        }

        public string NameTerminal { get; set; }
        public int Modbuss { get; set; }
        public bool IsPoll { get; set; } = false;
        public List<byte> ArrayRegistersTerminal { get; set; }
        public List<PassedFrequencies> PassedFrequencies { get; set; }
    }
}
