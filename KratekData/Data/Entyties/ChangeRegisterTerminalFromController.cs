using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.Entyties
{
    public class ChangeRegisterTerminalFromController
    {
        [Key]
        public int Id { get; set; }

        public Terminal Terminal { get; set; }
        [MaxLength(300)]
        public string DescriptionRegisterTerminal { get; set; }
        public double OldValue { get; set; }
        public double NewValue { get; set; }
        public DateTime DateChange { get; set; }
    }
}
