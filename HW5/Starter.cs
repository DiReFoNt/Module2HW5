using Newtonsoft.Json;

namespace HW5
{
    internal static class Starter
    {
        public static void Run()
        {
            Actions actions = new Actions();
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    Random rand = new Random();
                    switch (rand.Next(1, 4))
                    {
                        case 1:
                            actions.Info();
                            break;
                        case 2:
                            throw actions.Warning();
                        case 3:
                            actions.Error();
                            break;
                        default:
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    Logger.Instance.NewLog(LogType.Warning, $"Action got this custom Exception:{ex.Text}");
                }
                catch (Exception ex)
                {
                    Logger.Instance.NewLog(LogType.Error, $"Action failed by reason:{ex.Message}");
                }
            }

            var data = Logger.GetWorkResult();
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"{data[i].Date} : {data[i].Type} : {data[i].Text}");
            }

            string configFile = string.Empty;
            try
            {
                configFile = File.ReadAllText($"config.json");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Config file does not exist");
            }

            var config = JsonConvert.DeserializeObject<Config>(configFile);
            if (config != null)
            {
                Console.WriteLine("Writing logs to file...");
                FileService.LogService(config);
            }
            else
            {
                Console.WriteLine("Can't write logs to file. Config file is empty or does not exist");
            }
        }
    }
}
