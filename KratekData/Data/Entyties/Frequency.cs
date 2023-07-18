using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.Entyties
{
    public class Frequency
    {
        [Key]
        public int Id { get; set; }
        public Terminal Terminal { get; set; }
        [MaxLength(100)]
        public string TypeEngine { get; set; } // тип двигателя
        [MaxLength(100)]
        public string TypeFrequency { get; set; }  // тип частотника
        public int Modbuss { get; set; }
        public double Current { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastPoll { get; set; }
        public ICollection<DataFrequency> DataFrequencies { get; set; }
        public ICollection<DataFrequencyJournal> DataFrequencyJournals { get; set; }
        public ICollection<ErrorFrequency> ErrorFrequencies { get; set; }
        public ICollection<ErrorJournalFrequency> ErrorJournalFrequencies { get; set; }
    }
}
