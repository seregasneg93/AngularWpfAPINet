using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekServices.Logger
{
    public static class LoggerApp
    {
        // логгер для записи ошибок при регистрации терминалов
        private static ILogger _logErrorsRegistrationTerminals = LogErrorsRegistrationTerminalsInformation();
        public static ILogger LogErrorsRegistrationTerminals
        {
            get => _logErrorsRegistrationTerminals;
        }

        private static ILogger LogErrorsRegistrationTerminalsInformation()
        {
            var configuration = new LoggerConfiguration()
                .WriteTo.File(path: "LogsErrors\\ErrorsRegistrationTerminals.txt",
                retainedFileCountLimit: 31,
                shared: true,
                rollingInterval: RollingInterval.Day
                );

            return configuration.CreateLogger();
        }

        // логгер для записи регистрации терминалов в общей коллекции
        private static ILogger _logRegistraionTerminalsInColletions = LogRegistraionTerminalsInColletionsInformation();
        public static ILogger LogRegistraionTerminalsInColletions
        {
            get => _logRegistraionTerminalsInColletions;
        }

        private static ILogger LogRegistraionTerminalsInColletionsInformation()
        {
            var configuration = new LoggerConfiguration()
                .WriteTo.File(path: "LogsInformation\\LogRegistraionTerminalsInColletions.txt",
                retainedFileCountLimit: 31,
                shared: true,
                rollingInterval: RollingInterval.Day
                );

            return configuration.CreateLogger();
        }

        // логгер для записи ошбики при работе TcpListener
        private static ILogger _logErrorsInWorkTcpListener = LogLogErrorsInWorkTcpListener();
        public static ILogger LogErrorsInWorkTcpListener
        {
            get => _logErrorsInWorkTcpListener;
        }

        private static ILogger LogLogErrorsInWorkTcpListener()
        {
            var configuration = new LoggerConfiguration()
                .WriteTo.File(path: "LogsErrors\\LogErrorsInWorkTcpListener.txt",
                retainedFileCountLimit: 31,
                shared: true,
                rollingInterval: RollingInterval.Day
                );

            return configuration.CreateLogger();
        }


        // логгер для записи ошбики при работе TcpListener
        private static ILogger _logValidCRCTerminal = LogValidCRCTerminalInformation();
        public static ILogger LogValidCRCTerminal
        {
            get => _logValidCRCTerminal;
        }

        private static ILogger LogValidCRCTerminalInformation()
        {
            var configuration = new LoggerConfiguration()
                .WriteTo.File(path: "LogsErrors\\LogValidCRCTerminal.txt",
                retainedFileCountLimit: 31,
                shared: true,
                rollingInterval: RollingInterval.Day
                );

            return configuration.CreateLogger();
        }
    }
}
