using System;
using log4net;
using System.Threading;
using System.Diagnostics;
using System.IO;
using LoggingProject.Models;

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
                if (ex != null)
                {
                    AbstractFactory factory = new ConcreteFactory();
                    Client clientElmahLogging = new Client(factory, ex);
                    clientElmahLogging.RunElmahLogging(ex);

                    Client clientFileStreamLogging = new Client(factory, ex);
                    clientFileStreamLogging.RunFileStreamLogging(ex);

                    Client clientFileLogging = new Client(factory, ex);
                    clientFileLogging.RunFileLogging(ex);

                    Client clientEventViewerLogging = new Client(factory, ex);
                    clientEventViewerLogging.RunEventViewerLogging(ex);

                }
            }
            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
    }
}