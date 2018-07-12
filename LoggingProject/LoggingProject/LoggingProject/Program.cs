using System;
using log4net;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace LoggingProject
{
    class Program
    {
        private static readonly ILog Log =
                LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            var exceptionMessage = string.Empty;
            try
            {
                throw new System.ArgumentException("Parameter cannot be null", "original");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
                if (ex != null && !string.IsNullOrEmpty(exceptionMessage))
                {
                    ImplementLoggingFuntionToFile(exceptionMessage);
                    ImplementLoggingFuntionToEventViewer(exceptionMessage);
                    ErrorLogingUsingElmah(ex);
                    WriteLogUsingFileStream("LogUsingFileStream", exceptionMessage);
                }
            }
            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }

        private static void ErrorLogingUsingElmah(Exception ex)
        {
            Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
        }
        private static void ImplementLoggingFuntionToFile(string exceptionMessage)
        {
            var secs = 3;
            Log.Fatal("Start log FATAL...");
            Console.WriteLine("Start log FATAL...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Error(exceptionMessage);
            Console.WriteLine("Start log ERROR...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Warn("Start log WARN...");
            Console.WriteLine("Start log WARN...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Info("Start log INFO...");
            Console.WriteLine("Start log INFO...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Debug("Start log DEBUG...");
            Console.WriteLine("Start log DEBUG...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs
        }
        private static void ImplementLoggingFuntionToEventViewer(string message)
        {
            EventLog m_EventLog = new EventLog("");
            m_EventLog.Source = "EventLogSource";
            m_EventLog.WriteEntry("Reading text file failed " + message,
                EventLogEntryType.FailureAudit);
        }
        private static bool WriteLogUsingFileStream(string strFileName, string strMessage)
        {
            try
            {
                FileStream objFilestream = new FileStream(string.Format("{0}\\{1}", Path.GetTempPath(), strFileName), FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
                objStreamWriter.WriteLine(strMessage);
                objStreamWriter.Close();
                objFilestream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}