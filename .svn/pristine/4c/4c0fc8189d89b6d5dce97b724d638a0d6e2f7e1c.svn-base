using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();//启用日志
            ILog log = LogManager.GetLogger("RollingLogFileAppender");
            log.Debug("this is a debug error--");

        }
    }
}
