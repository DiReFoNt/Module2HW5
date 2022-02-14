using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    internal class LogItem
    {
        public LogItem(LogType type, string message)
        {
            Date = DateTime.Now;
            Type = type;
            Text = message;
        }

        public DateTime Date { get; private set; }
        public LogType Type { get; private set; }
        public string Text { get; private set; }
    }
}
