using KratekServices.WorkJobServerWPF.PassedTerminalRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.WorkJobServerWPF.WorkPollTerminals
{
    public class PollTerminal
    {
        LoadTerminalForPoll _loadTerminalForPoll;
        ReadTerminal _readTerminal = new();
        private List<PassedTerminal> _passedTerminalsCollectionsReset = new();

        public async Task PollTerminalsAsync()
        {
            _passedTerminalsCollectionsReset.Clear();

            _loadTerminalForPoll = new();
            List<PassedTerminal> passedTerminalsCollections = new();
            List<Task> tasks = new();

            passedTerminalsCollections = await _loadTerminalForPoll.ReceiveValidColletionsForPollTerminalsAsync().ConfigureAwait(false);

            if(passedTerminalsCollections.Count > 0)
            {
                foreach (var terminal in passedTerminalsCollections)
                    tasks.Add(_readTerminal.ReadTerminalAsync(terminal));

                await Task.WhenAll(tasks).ConfigureAwait(false);
            }

            foreach (var terminal in passedTerminalsCollections)
            {
                List<PassedBoiler> findPollTerminalFalse = terminal.PassedBoilers.Where(x => !x.IsPoll).ToList();

                if (findPollTerminalFalse.Count > 0)
                {
                    PassedTerminal passedTerminal = new()
                    {
                        IMEI = terminal.IMEI,
                        TcpClient = terminal.TcpClient,
                        PassedBoilers = findPollTerminalFalse
                    };

                    _passedTerminalsCollectionsReset.Add(passedTerminal);
                }               
            }

            // TODO Work is DB ///

            foreach (var terminal in passedTerminalsCollections)
            {
                //
            }
        }
    }
}
