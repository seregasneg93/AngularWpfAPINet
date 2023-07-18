using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.Entyties
{
    public class DataTerminal
    {
        [Key]
        public int Id { get; set; }
        public Terminal Terminal { get; set; }
        [MaxLength(300)]
        public string DescriptionsRegister { get; set; }
        public double ValueRegister { get; set; }
        [MaxLength(100)]
        public string Flags { get; set; }
        public DateTime DateAddValues { get; set; }
        public int NumberRegister { get; set; }
        public int GroupRegister { get; set; }
    }
}
