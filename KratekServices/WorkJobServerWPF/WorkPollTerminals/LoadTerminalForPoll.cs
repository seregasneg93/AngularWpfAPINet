using KratekData.Data.ConnectDB;
using KratekData.Data.Entyties;
using KratekServices.WorkJobServerWPF.PassedTerminalRegistration;
using KratekServices.WorkJobServerWPF.WorkRegistrationTerminals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.WorkPollTerminals
{
    public class LoadTerminalForPoll
    {
       
        public async Task<List<PassedTerminal>> ReceiveValidColletionsForPollTerminalsAsync()
        {
            List<Terminal> collectionTerminalFromDB = new();
            List<RegistrastionTerminal> registrationTerminals = new();
            List<PassedTerminal> passedPollTerminals = new();

            object blockColletions = new();

            using (DataContext db = new())
            {
                 collectionTerminalFromDB = await db.Terminals
                                                    .Where(x=>x.SlaveId > 0)
                                                        .Include(x=>x.Frequencies.Where(x=>x.IsActive))
                                                    .ToListAsync()
                                                    .ConfigureAwait(false);
            }

            if(collectionTerminalFromDB.Count > 0)
            {
                lock(blockColletions)
                    registrationTerminals = new(ServerRegistrationTerminal.RegistrastionTerminals);

                passedPollTerminals = await ReceiveValidCollectionsAsync(collectionTerminalFromDB, registrationTerminals).ConfigureAwait(false);
            }

            return passedPollTerminals;
        }

        async Task<List<PassedTerminal>> ReceiveValidCollectionsAsync(List<Terminal> collectionTerminalFromDB, List<RegistrastionTerminal> registrationTerminals)
        {
            List<PassedTerminal> validRegistrations = new();

            await Task.Run(() =>
            {
                foreach (var registraion in registrationTerminals)
                {
                    List<Terminal> findTerminalCollections = collectionTerminalFromDB.Where(x => x.IMEI == registraion.IMEI).ToList();

                    if(findTerminalCollections.Count > 0)
                    {
                        PassedTerminal passedTerminal = new()
                        {
                            IMEI = registraion.IMEI,
                            TcpClient = registraion.Client,
                            PassedBoilers = new()
                        };

                        foreach (var findTerminal in findTerminalCollections)
                            passedTerminal.PassedBoilers.Add(new PassedBoiler(findTerminal));
                    }
                }
            }).ConfigureAwait(false);

            return validRegistrations;
        }
    }
}
