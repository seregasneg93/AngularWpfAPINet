using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.Entyties
{
    public class UserChange
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        [MaxLength(100)]
        public string TypeChange { get; set; }
        [MaxLength(500)]
        public string DescParametr { get; set; }
        public int OldValue { get; set; }
        public int NewValue { get; set; }
        public DateTime DateChange { get; set; }
        [MaxLength(500)]
        public string ResultWriteClient { get; set; }
        [MaxLength(100)]
        public string Client { get; set; }
        [MaxLength(100)]
        public string NamePK { get; set; }
    }
}
