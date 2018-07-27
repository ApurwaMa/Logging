
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingProject.Models
{
    public class ElmahLogging : AbstractLogging
    {
        public override void Logging(Exception ex)
        {
            Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
        }
    }


}
