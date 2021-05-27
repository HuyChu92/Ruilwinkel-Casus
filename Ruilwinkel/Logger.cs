using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public static void Logging(string naam)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=ruilwinkelserver.database.windows.net;Initial Catalog=ruilwinkel;Persist Security Info=True;User ID=devops;Password=Zuyd2021";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into [Logging] values(@LoggingVoor, @LoggingNa, @Naam)";
            cmd.Parameters.AddWithValue("@LoggingVoor", DateTime.Now);
            cmd.Parameters.AddWithValue("@LoggingNa", DateTime.Now);
            cmd.Parameters.AddWithValue("@Naam", naam);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            //Logger.WriteLog(categorie.categorienaam + " is aangemaakt.");
        }
    }
}