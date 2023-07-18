using KratekData.Data.Entyties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.ConnectDB
{
    public class DataContext : DbContext
    {
         private GetConnectionString _getConnectionString;
        public DataContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            _getConnectionString = new();
           // Database.MigrateAsync();
        }

        public void TestCreareConnection()
        {
           _getConnectionString = new GetConnectionString();        
        }

        public DataContext()
        {
            _getConnectionString = new();
        }

        public DbSet<User> Users { get; set; } = null;
        public DbSet<UserChange> UserChanges { get; set; } = null;
        public DbSet<Terminal> Terminals { get; set; } = null;
        public DbSet<TerminalSetting> TerminalSettings { get; set; } = null;
        public DbSet<TelegramUser> TelegramUsers { get; set; } = null;
        public DbSet<DataTerminal> DataTerminals { get; set; } = null;
        public DbSet<DataTerminalJournal> DataTerminalJournals { get; set; } = null;
        public DbSet<ErrorTerminal> ErrorTerminals { get; set; } = null;
        public DbSet<ErrorJournalTerminal> ErrorJournalTerminals { get; set; } = null;
        public DbSet<SensorTerminal> SensorTerminals { get; set; } = null;
        public DbSet<ConsumptionCoalHourTerminal> ConsumptionCoalHourTerminals { get; set; } = null;
        public DbSet<ChangeRegisterTerminalFromController> ChangeRegisterTerminalFromControllers { get; set; } = null;
        public DbSet<Frequency> Frequencies { get; set; } = null;
        public DbSet<DataFrequency> DataFrequencies { get; set; } = null;
        public DbSet<DataFrequencyJournal> DataFrequencyJournals { get; set; } = null;
        public DbSet<ErrorFrequency> ErrorFrequencies { get; set; } = null;
        public DbSet<ErrorJournalFrequency> ErrorJournalFrequencies { get; set; } = null;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Data Source=WIN-ARCTJA5L0P5\\SQLEXPRESS;Initial Catalog=KratecDBCore;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
            var connectionString = _getConnectionString.GetConnectionStrings("KratekAPIConnection");
            optionsBuilder.UseSqlServer(connectionString); ///
        }
    }
}
