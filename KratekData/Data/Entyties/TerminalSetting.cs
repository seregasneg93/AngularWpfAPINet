using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.Entyties
{
    public class TerminalSetting
    {
        [Key]
        public int Id { get; set; }
        public Terminal Terminal { get; set; }
        [MaxLength(100)]
        public string NumberPhone { get; set; }
        public bool ConenctionsTerminalJobChannel { get; set; }
        public bool ConnectionsTerminalServicesChannel { get; set; }
        public bool AcessReadModbuss { get; set; }
        public string Descriptions { get; set; }
        [MaxLength(100)]
        public string AdressObject { get; set; }
        [MaxLength(100)]
        public string TypeServices { get; set; }
        [MaxLength(100)]
        public string Acess { get; set; }//
        [MaxLength(100)]//
        public string TypeAsphan { get; set; }
        public double PowerWanCoal { get; set; } // энергия на 1 кг угля
        public double NormaWater { get; set; } // норма протока воды
        public double CapasityBunker { get; set; } // вместимость бункера
        public double PowerBoiler { get; set; } // мощность котла
        public bool Ibr { get; set; }
        public bool PollFrequencies { get; set; }
        public double MyProperty { get; set; }
        public DateTime DateLastInterogation { get; set; } //дата последнего опроса терминала
        public DateTime DateLoadCoal { get; set; } // дата загрузки угля
        public DateTime DateChangeAsphan { get; set; } // дата замены зольника
        public DateTime VersionFirtware { get; set; } // версия прошивки
    }
}
