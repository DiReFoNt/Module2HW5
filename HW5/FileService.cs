using Newtonsoft.Json;

namespace HW5
{
    [Serializable]
    internal class FileService
    {
        public static void LogService(Config config)
        {
            string directoryPath = config.Logger.DirectoryPath;
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            var files = directoryInfo.GetFiles();
            if (files.Length > 3)
            {
                var oldestFileDate = DateTime.Now;
                string oldestFilePath = string.Empty;
                foreach (var file in files)
                {
                    if (oldestFileDate > file.LastWriteTime)
                    {
                        oldestFileDate = file.LastWriteTime;
                        oldestFilePath = file.Name;
                    }
                }

                File.Delete($"{directoryPath}\\{oldestFilePath}");
            }

            string fileName = DateTime.Now.ToString(config.Logger.FileNameFormat);
            string fileExtension = config.Logger.FileExtension;
            string filePath = $"{directoryPath}\\{fileName}{fileExtension}";

            using StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);
            try
            {
                foreach (var log in Logger.GetWorkResult())
                {
                    sw.WriteLine($"{log.Date}: {log.Type}: {log.Text}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
