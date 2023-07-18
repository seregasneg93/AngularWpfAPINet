using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.PassedTerminalRegistration
{
    public class PrepfrationFrequenciesDB
    {
        public PrepfrationFrequenciesDB()
        {

        }

        public string NameFrequencies { get; set; }
        public int Modbuss { get; set; }
        public Dictionary<string, double> ArrayRegistersFrequencies { get; set; } = new();
    }
}
