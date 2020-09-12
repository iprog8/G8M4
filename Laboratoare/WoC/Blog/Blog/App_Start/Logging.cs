using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Blog.App_Start
{

    public class Logging
    {
        const string folderName = @"C:\logs\";
        const string fileName = "file.log";
        string fullName = string.Empty;

        public Logging()
        {
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);
            fullName = Path.Combine(folderName, fileName);
        }

        public void Start()
        {
            using (StreamWriter w = File.AppendText(fullName))
            {
                w.Write("\r\nBlog app start: ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            }
        }

        public void Error(string message, Exception exception = null)
        {
            Log(MessageType.Error, message, exception);
        }

        public void Warning(string message)
        {
            Log(MessageType.Warning, message, null);
        }

        public void Info(string message)
        {
            Log(MessageType.Info, message, null);
        }

        private void Log(MessageType messageType, string message, Exception exception = null)
        {
            string toLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss FFF");
            switch (messageType)
            {
                case MessageType.Error:
                    toLog += " ERR: ";
                    break;
                case MessageType.Warning:
                    toLog += " WRN: ";
                    break;
                case MessageType.Info:
                    toLog += " INF: ";
                    break;
                default:
                    break;
            }
            toLog += message;
            if (exception != null)
            {
                toLog += Environment.NewLine;
                toLog += exception.Message;
                toLog += Environment.NewLine;
                toLog += exception.StackTrace;
            }

            try
            {
                using (StreamWriter streamWriter = File.AppendText(fullName))
                {
                    streamWriter.WriteLine(toLog);
                }
            }
            catch
            {
            }
        }
    }

    public enum MessageType
    {
        Error = 1,
        Warning = 2,
        Info = 3
    }

}