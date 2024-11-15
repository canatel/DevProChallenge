using System;
using System.IO;

namespace LoggerApp
{
    public class LogHandler
    {

        public enum LOG_LEVEL
        {
            DEBUG,
            INFO,
            WARNING,
            ERROR
        }

        static void Main()
        {
        }

        public (String, String) Log_message(String file_name, String message, LOG_LEVEL log_level)
        {
            if (file_name == "" || file_name == null)
            {
                return ("Missing log file name", "");
            }else if(message == "" || message == null)
            {
                return ("Missing log message", "");
            }

            try
            {
                // Define folder to save file
                string folderPath = @"C:\LogFolder";
                string filePath = Path.Combine(folderPath, file_name);

                // Open stream writer to write logs
                StreamWriter writer = new StreamWriter(filePath, true);

                // Generate message to be logged                
                String log_message = CreateLogMessage(message, log_level);

                // Write log message
                writer.WriteLine(log_message);

                // Close writer
                writer.Close();

                return ("Log created successfully", log_message);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return ("Some error occurred while trying to create the log", "");
            }
            

        }

        public String CreateLogMessage(String message, LOG_LEVEL log_level)
        {
            String date = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            return $"[{date}] [{log_level}] {message}";
        }
    }
}
