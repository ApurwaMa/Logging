using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingProject.Models
{
    public class Client
    {
        private ElmahLogging _abstractElmahLogging;
        private EventViewerLogging _abstractEventViewerLogging;
        private FileLogging _abstractFileLogging;
        private FileStreamLogging _abstractFileStreamLogging;
        private Exception message { get; set; }

        public Client(AbstractFactory factory, Exception exception)
        {
            _abstractElmahLogging = factory.ElmahLogging();
            _abstractEventViewerLogging = factory.EventViewerLogging();
            _abstractFileLogging = factory.FileLogging();
            _abstractFileStreamLogging = factory.FileStreamLogging();
            message = exception;
        }

        public void RunElmahLogging(Exception message)
        {
            _abstractElmahLogging.Logging(message);
        }

        public void RunEventViewerLogging(Exception message)
        {
            _abstractEventViewerLogging.Logging(message);
        }

        public void RunFileLogging(Exception message)
        {
            _abstractFileLogging.Logging(message);
        }

        public void RunFileStreamLogging(Exception message)
        {
            _abstractFileStreamLogging.Logging(message);
        }
    }
}
