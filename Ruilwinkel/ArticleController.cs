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
            cmd.CommandText = "SELECT ARTICLE.ID, PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, CATEGORY.POINTS FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID WHERE STATUS = 1";
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int articleID = int.Parse(dr.GetValue(0).ToString());
                string productname = dr.GetValue(1).ToString();
                string description = dr.GetValue(2).ToString();
                string categoryname = dr.GetValue(3).ToString();
                int points = int.Parse(dr.GetValue(4).ToString());
                articleStatus.Add(new AvailableArticles { productname = productname, points = points, description = description, articleID = articleID, categoryname = categoryname });
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

        /*
        [HttpPost]
        public void InsertNewArticle(Article article)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=productbeheerserver.database.windows.net;Initial Catalog=RuilwinkelDB;Persist Security Info=True;User ID=DevOps;Password=Zuyd2021";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into ARTICLE values(@PRODUCTID, @COMMENTARY, @IMAGE)";
            cmd.Parameters.AddWithValue("@PRODUCTID", article.productID);
            cmd.Parameters.AddWithValue("@COMMENTARY", article.commantary);
            cmd.Parameters.AddWithValue("@IMAGE", article.image);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        */

        //[HttpGet]
        //public List<int> GetAvailableArticles()
        //{
        //    List<int> articleStatus = new List<int>();

        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = @"Data Source=productbeheerserver.database.windows.net;Initial Catalog=RuilwinkelDB;Persist Security Info=True;User ID=DevOps;Password=Zuyd2021";
        //    con.Open();

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SELECT ARTICLE.ID, PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME, CATEGORY.POINTS FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN[USER] ON ARTICLE.RENTERID = [USER].ID ";
        //    cmd.Connection = con;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        int articleID = int.Parse(dr.GetValue(0).ToString());
        //        articleStatus.Add(articleID);
        //    }
        //    con.Close();

        //    return articleStatus;

        //}
        
    }
}