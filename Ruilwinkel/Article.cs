using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ruilwinkel
{
    public class Article
    {
        public int productID;
        public string commantary;
        public string image;

        public Article() { }

        public Article(int productID, string commantary, string image)
        {
            this.productID = productID;
            this.commantary = commantary;
            this.image = image;

        }
    }
}