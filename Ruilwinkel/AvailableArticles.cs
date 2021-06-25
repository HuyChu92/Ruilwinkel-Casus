using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ruilwinkel
{
    public class AvailableArticles
    {
        public string productname;
        public string description;
        public string categoryname;
        public int articleID;
        public int points;
        public string image;

        public AvailableArticles() { }

        public AvailableArticles(string productname, string description, string categoryname, int articleID, int points, string image)
        {
            this.productname = productname;
            this.description = description;
            this.categoryname = categoryname;
            this.articleID = articleID;
            this.points = points;
            this.image = image;
        }

        //SELECT ARTICLE.ID, PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME, CATEGORY.POINTS FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN[USER] ON ARTICLE.RENTERID = [USER].ID WHERE STATUS = 1 ";
    }
}