﻿using System;
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
        /*
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
        }*/


        [HttpGet]
        public Dictionary<string, List<AvailableArticles>> GetProductsSortedByCategory(SortedArticles articles)
        {
            Dictionary<string, List<AvailableArticles>> sortedArticles = new Dictionary<string, List<AvailableArticles>>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=productbeheerserver.database.windows.net;Initial Catalog=RuilwinkelDB;Persist Security Info=True;User ID=DevOps;Password=Zuyd2021";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            string basequery = "SELECT ARTICLE.ID, PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, CATEGORY.POINTS FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID WHERE STATUS = 1 AND ";
            string query = "CATEGORY.ID= ";
            cmd.Connection = con;

            if (articles.articles.Count() == 1)
            {
                int id = articles.articles.ElementAt(0);
                query += id.ToString();
                cmd.CommandText = basequery + query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                List <AvailableArticles> articles2 = new List<AvailableArticles>();
                while (dr.Read())
                {
                    int articleID = int.Parse(dr.GetValue(0).ToString());
                    string productname = dr.GetValue(1).ToString();
                    string description = dr.GetValue(2).ToString();
                    string categoryname = dr.GetValue(3).ToString();
                    int points = int.Parse(dr.GetValue(4).ToString());
                    articles2.Add(new AvailableArticles { productname = productname, points = points, description = description, 
                        articleID = articleID, categoryname = categoryname });

                    if (sortedArticles.ContainsKey(categoryname) == false)
                    {
                        sortedArticles.Add(categoryname, articles2);
                    }
                }

                con.Close();
            }
            
            
            else
            {
                foreach(int id in articles.articles)
                {
                    query += id.ToString() + ",";
                }
                string aangepast = query.Remove(query.Length - 1, 1);
                cmd.CommandText = basequery + aangepast;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                List<AvailableArticles> articles2 = new List<AvailableArticles>();
                while (dr.Read())
                {
                    int articleID = int.Parse(dr.GetValue(0).ToString());
                    string productname = dr.GetValue(1).ToString();
                    string description = dr.GetValue(2).ToString();
                    string categoryname = dr.GetValue(3).ToString();
                    int points = int.Parse(dr.GetValue(4).ToString());
                    articles2.Add(new AvailableArticles
                    {
                        productname = productname,
                        points = points,
                        description = description,
                        articleID = articleID,
                        categoryname = categoryname
                    });

                    if (sortedArticles.ContainsKey(categoryname) == false)
                    {
                        sortedArticles.Add(categoryname, articles2);
                    }
                }
                con.Close();
            }
            
            return sortedArticles;
        }    
    }
}