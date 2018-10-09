using System;
using Serilog;
using SerilogLab.Model;

namespace SerilogLab.LogHelper
{
    public class LogHelper
    {
        public static ILogger GetLogger()
        {
            return Log.Logger;
        }
        
        public static ILogger GetLogger<T>()
        {
            return Log.Logger.ForContext<T>();
        }

        public PFLogDetail CreatePFLogDetail(string remark)
        {
            return new PFLogDetail(){Remark = remark};
        }
    }
}