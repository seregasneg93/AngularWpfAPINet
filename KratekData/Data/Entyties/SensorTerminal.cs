using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.Entyties
{
    public class SensorTerminal
    {
        [Key]
        public int Id { get; set; }
        public Terminal Terminal { get; set; }
        [MaxLength(300)]
        public string NameSensor { get; set; }
        public bool AcessSensor { get; set; }
    }
}
