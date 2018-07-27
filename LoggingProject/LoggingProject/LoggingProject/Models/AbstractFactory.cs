
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingProject.Models
{
    public abstract class AbstractFactory
    {
        public abstract ElmahLogging ElmahLogging();
        public abstract EventViewerLogging EventViewerLogging();
        public abstract FileLogging FileLogging();
        public abstract FileStreamLogging FileStreamLogging();
    }
}
