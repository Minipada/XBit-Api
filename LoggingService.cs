using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBitApi.EF;

namespace XBitApi
{
    public class LoggingService
    {
        private XBitContext context;
        public LoggingService(XBitContext context)
        {
            this.context = context;
        }

        public void LogError()
        {

        }


        public void LogInfo()
        {

        }

        public void LogWarning()
        {

        }
    }
}
