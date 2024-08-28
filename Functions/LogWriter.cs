using System.Formats.Asn1;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace kayahome_backend.Functions
{
    public static class LogWriter
    {
        private static string m_exePath = string.Empty;
        public static void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = m_exePath + "\\" + "Logs";
            string fullpath = path + "\\" + "log.csv";

            CreateDir(path);

            if (File.Exists(fullpath))
            {
                using (StreamWriter w = File.AppendText(fullpath))
                {
                    AppendLog(logMessage, w);
                }

                //File.Delete(fullpath);
            }
            else
            {
                try
                {
                    FileStream fs = new FileStream(fullpath, FileMode.OpenOrCreate);
                    using (StreamWriter w = new StreamWriter(fs))
                        Log(w);
                }
                catch (Exception ex)
                {
                    Log();
                }
            }

            // File.Create(fullpath);
        }

        private static void AppendLog(string logMessage, TextWriter csvWriter = null)
        {
            try
            {
                string first = DateTime.Now.ToString();
                string second = logMessage;
                string csvRow = string.Format("{0};{1}", first, second);

                csvWriter.WriteLine(csvRow);
            }
            catch (Exception ex)
            {
                csvWriter.Write(ex.Message);
            }
        }

        private static void Log(TextWriter csvWriter = null)
        {
            try
            {
                string first = "DATE";
                string second = "MESSAGE";
                string csvRow = string.Format("{0};{1}", first, second);
                
                csvWriter.WriteLine(csvRow);
            }
            catch (Exception ex)
            {
                csvWriter.Write(ex.Message);
            }
        }

        private static void CreateDir(string dir)
        {
            bool folderExists = Directory.Exists(dir);
            if (!folderExists)
                Directory.CreateDirectory(dir);
        }
    }
}
