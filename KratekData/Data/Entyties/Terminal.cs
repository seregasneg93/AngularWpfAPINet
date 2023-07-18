using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.Entyties
{
    public class Terminal
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        public string NameTerminal { get; set; }
        [MaxLength(100)]
        public string IMEI { get; set; }
        public int SlaveId { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<DataTerminal> DataTerminals { get; set; }
        public ICollection<TerminalSetting> TerminalSettings { get; set; }
        public ICollection<ChangeRegisterTerminalFromController> ChangeRegisterTerminalFromControllers { get; set; }
        public ICollection<SensorTerminal> SensorTerminals { get; set; }
        public ICollection<Frequency> Frequencies { get; set; }
        public ICollection<ConsumptionCoalHourTerminal> ConsumptionCoalHourTerminals { get; set; }
        public ICollection<TelegramUser> TelegramUsers { get; set; }
        public ICollection<ErrorTerminal> ErrorTerminals { get; set; }
        public ICollection<ErrorJournalTerminal> ErrorJournalTerminals { get; set; }

    }
}
