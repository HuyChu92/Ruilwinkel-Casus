using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ruilwinkel
{
    public class Product
    {
        public int CategorieID;

        public string ProductName;

        public string Description;

        public Product() { }

        public Product(int CategorieID, string ProductName, string Description)
        {
            this.CategorieID = CategorieID;
            this.ProductName = ProductName;
            this.Description = Description;
        }

    }
}