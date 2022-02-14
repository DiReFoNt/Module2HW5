using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    internal class LoggerConfig
    {
        public int LineSeparator { get; set; }
        public string TimeFormat { get; set; }
        public string DirectoryPath { get; set; }
        public string BackUpDirectoryPath { get; set; }
        public string FileNameFormat { get; set; }
        public string FileExtension { get; set; }
    }
}
