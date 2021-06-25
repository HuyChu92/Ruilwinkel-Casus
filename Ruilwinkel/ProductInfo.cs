using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ruilwinkel
{
    public class ProductInfo
    {
        public int ID;

        public int CategorieID;

        public string ProductName;

        public string Description;

        public ProductInfo() { }

        public ProductInfo(int ID, int CategorieID, string ProductName, string Description)
        {
            this.ID = ID;
            this.CategorieID = CategorieID;
            this.ProductName = ProductName;
            this.Description = Description;
        }
    }
}