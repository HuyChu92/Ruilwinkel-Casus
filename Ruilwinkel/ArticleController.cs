using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ruilwinkel
{
    public class ArticleController : ApiController
    {
        [HttpGet]
        public List<int> GetAvailableArticles()
        {
            List<int> articleStatus = new List<int>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=productbeheerserver.database.windows.net;Initial Catalog=RuilwinkelDB;Persist Security Info=True;User ID=DevOps;Password=Zuyd2021";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ARTICLE.ID FROM ARTICLE WHERE ARTICLE.STATUS=1";
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int articleID = int.Parse(dr.GetValue(0).ToString());
                articleStatus.Add(articleID);
            }
            con.Close();

            return articleStatus;

        }

        [HttpPatch]
        public string UpdateArticleStatus(ArticleStatus article)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=productbeheerserver.database.windows.net;Initial Catalog=RuilwinkelDB;Persist Security Info=True;User ID=DevOps;Password=Zuyd2021";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE ARTICLE SET STATUS = (" + article.status + ") WHERE ID = (" + article.ArticleID + ")";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();

            return "Status successfully updated";
        }
        
        
        [HttpPost]
        public string InsertNewArticle(Article article)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=productbeheerserver.database.windows.net;Initial Catalog=RuilwinkelDB;Persist Security Info=True;User ID=DevOps;Password=Zuyd2021";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into [ARTICLE] values(@PRODUCTID, @RENTERID, @COMMENTARY, @STATUS, @IMAGE)";
            cmd.Parameters.AddWithValue("@PRODUCTID", article.productID);
            cmd.Parameters.AddWithValue("@RENTERID", 6);
            cmd.Parameters.AddWithValue("@COMMENTARY", article.commantary);
            cmd.Parameters.AddWithValue("@STATUS", 1);
            cmd.Parameters.AddWithValue("@IMAGE", article.image);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();

            return "Article successfully inserted";
        }
        
    }
}