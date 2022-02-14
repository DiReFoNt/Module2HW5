using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    internal class Actions
    {
        public bool Info()
        {
            Logger.Instance.NewLog(LogType.Info, "Start method");
            return true;
        }

        public BusinessException Warning()
        {
            return new BusinessException("Skipped logic in method", false);
        }

        public void Error()
        {
            throw new Exception("I broke a logic");
        }
    }
}
