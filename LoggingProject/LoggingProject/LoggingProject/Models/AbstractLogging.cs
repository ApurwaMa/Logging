using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingProject.Models
{
    public abstract class AbstractLogging
    {
        public abstract void Logging(Exception ex);
    }
}
