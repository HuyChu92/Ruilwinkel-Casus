using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ruilwinkel
{
    public class CategoryInfo
    {
        public int categoryID;
        public string categorienaam;
        public int punten;

        public CategoryInfo() { }

        public CategoryInfo(int categoryID, string categorienaam, int punten)
        {
            this.categoryID = categoryID;
            this.categorienaam = categorienaam;
            this.punten = punten;
        }
    }
}