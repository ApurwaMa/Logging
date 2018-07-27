using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingProject.Models
{
    public class ConcreteFactory : AbstractFactory
    {
        public override ElmahLogging ElmahLogging()
        {
            return new ElmahLogging();
        }

        public override EventViewerLogging EventViewerLogging()
        {
            return new EventViewerLogging();
        }

        public override FileLogging FileLogging()
        {
            return new FileLogging();
        }

        public override FileStreamLogging FileStreamLogging()
        {
            return new FileStreamLogging();
        }
    }
}
