using System.IO;

namespace DevPro_Tech_Assesment
{

    public class LogHandler
    {

        public static void Main() { 
            
            bool log_result = Log_message("application.log", "siuuu2", LOG_LEVEL.INFO);
            Console.WriteLine("Message logged successfully?: " + log_result);

        }

        public enum LOG_LEVEL
        {
            DEBUG,
            INFO,
            WARNING,
            ERROR
        }

        public static Boolean Log_message(String file_name, String message, LOG_LEVEL log_level) {

            try
            {
                // Define folder to save file
                string folderPath = @"C:\LogFolder";
                string filePath = Path.Combine(folderPath, file_name);

                // Open stream writer to write logs
                StreamWriter writer = new(filePath, true);

                // Generate message to be logged
                String date = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                String log_message = CreateLogMessage(date, message, log_level);

                // Write log message
                writer.WriteLine(log_message);

                // Close writer
                writer.Close();

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;    
            }

        }

        public static String CreateLogMessage(String date, String message, LOG_LEVEL log_level) {
            return $"[{date}] [{log_level}] {message}";
        }

    }


}