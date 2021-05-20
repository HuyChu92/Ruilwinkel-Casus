using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ruilwinkel
{
    public class Categorie
    {
        public string categorienaam;
        public int punten;
        public Categorie(string categorienaam, int punten)
        {
            this.categorienaam = categorienaam;
            this.punten = punten;
        }

        public void Toevoegen(Categorie categorie)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=ruilwinkelserver.database.windows.net;Initial Catalog=ruilwinkel;Persist Security Info=True;User ID=devops;Password=Zuyd2021";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into [CATEGORY] values(@CATEGORYNAME, @POINTS)";
            cmd.Parameters.AddWithValue("@CATEGORYNAME", categorie.categorienaam);
            cmd.Parameters.AddWithValue("@POINTS", categorie.punten);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}