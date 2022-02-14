using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    internal class Logger
    {
        private static readonly Logger _instance = new Logger();
        private static List<LogItem> _logWorkResult = new List<LogItem>();
        static Logger()
        {
        }

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                return _instance;
            }
        }

        public void NewLog(LogType type, string message)
        {
            _logWorkResult.Add(new LogItem(type, message));
        }

        public static List<LogItem> GetWorkResult()
        {
            return _logWorkResult;
        }
    }
}
