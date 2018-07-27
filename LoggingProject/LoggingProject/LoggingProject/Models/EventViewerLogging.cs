using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoggingProject.Models
{
    public class EventViewerLogging : AbstractLogging
    {
        public override void Logging(Exception ex)
        {
            var message = ex.Message;
            EventLog m_EventLog = new EventLog("");
            m_EventLog.Source = "EventLogSource";
            m_EventLog.WriteEntry("Reading text file failed " + message,
                EventLogEntryType.FailureAudit);
        }
    }
}
