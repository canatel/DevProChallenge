using LoggerApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;


namespace TestCases
{
    [TestClass]
    public class LoggerTests
    {

        public static LogHandler logger = new LogHandler();

        [TestMethod]
        public void Log_Message_Successfully()
        {

            var result = logger.Log_message("application.log", "User logged in successfully", LogHandler.LOG_LEVEL.INFO);
            Assert.AreEqual("Log created successfully", result.Item1);

        }


        [TestMethod]
        public void Log_Message_Empty_File_Name()
        {

            var result = logger.Log_message("", "", LogHandler.LOG_LEVEL.INFO);
            Assert.AreEqual("Missing log file name", result.Item1);

        }

        [TestMethod]
        public void Log_Message_Null_File_Name()
        {
            
            var result = logger.Log_message(null, "", LogHandler.LOG_LEVEL.INFO);
            Assert.AreEqual("Missing log file name", result.Item1);

        }

        [TestMethod]
        public void Log_Message_Empty_Message()
        {

            var result = logger.Log_message("application.log", "", LogHandler.LOG_LEVEL.INFO);
            Assert.AreEqual("Missing log message", result.Item1);

        }

        [TestMethod]
        public void Log_Message_Null_Message()
        {

            var result = logger.Log_message("application.log", null, LogHandler.LOG_LEVEL.INFO);
            Assert.AreEqual("Missing log message", result.Item1);

        }

        [TestMethod]
        public void Log_Message_Validate_Message_Logged()
        {
            const string file_name = "application.log";
            const string message = "Test log message is correct";

            var result = logger.Log_message(file_name, message, LogHandler.LOG_LEVEL.INFO);
            Assert.AreEqual("Log created successfully", result.Item1);

            var lastMessageLogged = File.ReadLines(@"C:\LogFolder\"+file_name).Last();

            Assert.AreEqual(result.Item2, lastMessageLogged);
        }
    }
}
