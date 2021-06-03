using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Ruilwinkel
{
    public partial class AllProductsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BTNOK_Click(object sender, EventArgs e)
        {
            string geselecteerd = "";
            CheckBoxList checkbox = CheckBoxList2;
            foreach (ListItem item in checkbox.Items)
            {
                if (item.Selected)
                {

                    geselecteerd += "'" + item.Value + "',";
                }
            }

            if (geselecteerd.Length > 0) {
                string nieuw = geselecteerd.Remove(geselecteerd.Length - 1);
                string sqlquery = "SELECT PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN [USER] ON ARTICLE.PROVIDERID = [USER].ID AND ARTICLE.RENTERID = [USER].ID WHERE CATEGORYNAME in (" + nieuw + ")";
                SqlDataSource1.SelectCommand = sqlquery;
            }

        }

        protected void DropDownListStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}