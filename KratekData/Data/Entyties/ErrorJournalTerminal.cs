using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.Entyties
{
    public class ErrorJournalTerminal
    {
        [Key]
        public int Id { get; set; }
        public Terminal Terminal { get; set; }
        [MaxLength(200)]
        public string NameDescription { get; set; }
        public DateTime DateError { get; set; }
        public bool Status { get; set; }
    }
}
