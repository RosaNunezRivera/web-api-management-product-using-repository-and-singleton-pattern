using System.Text;

namespace ENTITIES.Utility
{
    //Logging implementation using Singleton design pattern
    //1. Creating a sealed class
    public sealed class Log : ILog
    {
        //3. Declaring a statinc class instance 
        private static Log _loginstance;

        //2. Creating a private parameterless constructor 
        private Log()
        {

        }

        public static Log GetInstance()
        {
            if (_loginstance == null)
                _loginstance = new Log();
            return _loginstance;

        }

        //4. Declaring a public method 
        public void LogInformation(string message)
        {

            string filename = $"Information_log Web Api Prducts and Orders";
            string filepath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{filename}";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);

            using (StreamWriter sw = new StreamWriter(filepath, true))
            {
                sw.WriteLine(sb.ToString());
                sw.Flush();
            }
        }
    }
}
