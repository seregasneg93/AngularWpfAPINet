using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.Entyties
{
    public class ConsumptionCoalHourTerminal
    {
        [Key]
        public int Id { get; set; }
        public Terminal Terminal { get; set; }
        [MaxLength(300)]
        public string NameRegister { get; set; }
        public double ValueRegister { get; set; }
        public DateTime DateWrite { get; set; }
    }
}
