using KratekData.Data.Entyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.PassedTerminalRegistration
{
    public class PassedFrequencies
    {
        public PassedFrequencies()
        {

        }

        public PassedFrequencies(Frequency freq)
        {
            NameFrequencies = freq.TypeFrequency;
            Modbuss = freq.Modbuss;
            ArrayRegistersFrequencies = new();
        }

        public string NameFrequencies { get; set; }
        public int Modbuss { get; set; }
        public List<byte> ArrayRegistersFrequencies { get; set; }
    }
}
