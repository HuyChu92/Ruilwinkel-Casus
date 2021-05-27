using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Ruilwinkel
{
    public static class Logger
    {
        public static void WriteLog(string message)
        {
            string path = HttpContext.Current.Server.MapPath("~/logFile.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Now} : {message}");
            }
        }
    }
}