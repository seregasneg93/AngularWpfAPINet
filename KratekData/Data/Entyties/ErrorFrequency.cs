using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.Entyties
{
    public class ErrorFrequency
    {
        [Key]
        public int Id { get; set; }
        public Frequency Frequency { get; set; }
        [MaxLength(300)]
        public string NameError { get; set; }
        public DateTime DateError { get; set; }
    }
}
