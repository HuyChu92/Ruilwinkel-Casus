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
        public List<AvailableArticles> GetAvailableArticles()
        {
            List<AvailableArticles> articleStatus = new List<AvailableArticles>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=productbeheerserver.database.windows.net;Initial Catalog=RuilwinkelDB;Persist Security Info=True;User ID=DevOps;Password=Zuyd2021";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ARTICLE.ID, PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, CATEGORY.POINTS, ARTICLE.IMAGE FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID WHERE STATUS = 1";
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int articleID = int.Parse(dr.GetValue(0).ToString());
                string productname = dr.GetValue(1).ToString();
                string description = dr.GetValue(2).ToString();
                string categoryname = dr.GetValue(3).ToString();
                int points = int.Parse(dr.GetValue(4).ToString());
                string image = dr.GetValue(5).ToString();
                articleStatus.Add(new AvailableArticles { productname = productname, points = points, description = description, articleID = articleID, categoryname = categoryname, image = image });
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
            cmd.CommandText = "UPDATE ARTICLE SET STATUS = (" + article.status + "), NAAM ='" + article.naam + "' WHERE ID = (" + article.ArticleID + ")";
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
            cmd.CommandText = "insert into [ARTICLE] values(@PRODUCTID, @NAAM, @COMMENTARY, @STATUS, @IMAGE)";
            cmd.Parameters.AddWithValue("@PRODUCTID", article.productID);
            cmd.Parameters.AddWithValue("@NAAM", "Ruilwinkel");
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