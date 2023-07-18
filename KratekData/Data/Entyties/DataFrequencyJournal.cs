using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.Entyties
{
    public class DataFrequencyJournal
    {
        [Key]
        public int Id { get; set; }
        public Frequency Frequency { get; set; }
        [MaxLength(300)]
        public string NameRegister { get; set; }
        [MaxLength(100)]
        public string ValueRegister { get; set; }
        public DateTime DatePoll { get; set; }
    }
}
