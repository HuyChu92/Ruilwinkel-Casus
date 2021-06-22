using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;



namespace Ruilwinkel
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        public IEnumerable<Categorie> GetAllCategoriesWithPoints()
        {
            List<Categorie> categories = new List<Categorie>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=productbeheerserver.database.windows.net;Initial Catalog=RuilwinkelDB;Persist Security Info=True;User ID=DevOps;Password=Zuyd2021";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT CATEGORY.CATEGORYNAME, CATEGORY.POINTS FROM CATEGORY";
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string categorieNaam = dr.GetValue(0).ToString();
                int points = int.Parse(dr.GetValue(1).ToString());
                categories.Add(new Categorie { categorienaam = categorieNaam, punten = points});
            }
            con.Close();

            return categories;
        }

        /*
        [HttpGet]
        public void GetProductsSortedByCategory()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=productbeheerserver.database.windows.net;Initial Catalog=RuilwinkelDB;Persist Security Info=True;User ID=DevOps;Password=Zuyd2021";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ARTICLE.ID, PRODUCT.PRODUCTNAME, CATEGORY.CATEGORYNAME FROM ARTICLE INNER JOIN CATEGORY ON ARTICLE.ID = CATEGORY.ID INNER JOIN PRODUCT ON ARTICLE.PRODUCTID = PRODUCT.ID AND CATEGORY.ID = PRODUCT.CATEGORYID ORDER BY CATEGORY.CATEGORYNAME";
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            
        }
        */
        
    }
}