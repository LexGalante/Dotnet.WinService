using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.WinService.App
{
    public partial class LogService : ServiceBase
    {
        public const string EVENT_SOURCE_NAME = "Dotnet.WinService.LogService.Source";
        public const string EVENT_LOG_NAME = "Dotnet.WinService.LogService.Log";


        private readonly EventLog _log;

        public LogService()
        {
            InitializeComponent();

            _log = new EventLog();
            if (!EventLog.SourceExists(EVENT_SOURCE_NAME))
                EventLog.CreateEventSource(EVENT_SOURCE_NAME, EVENT_LOG_NAME);

            _log.Source = EVENT_SOURCE_NAME;
            _log.Log = EVENT_LOG_NAME;
        }

        protected override void OnStart(string[] args)
        {
            _log.WriteEntry($"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}] -> LogService starting...");

            OnExecute();
        }

        private void OnExecute()
        {
            while (true)
            {
                _log.WriteEntry($"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}] -> LogService running...");

                Task.Delay(TimeSpan.FromMinutes(1));
            }
        }

        protected override void OnStop()
        {
            _log.WriteEntry($"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}] -> LogService stopping...");
        }
    }
}
