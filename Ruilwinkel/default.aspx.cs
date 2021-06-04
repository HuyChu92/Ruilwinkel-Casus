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

    

        protected void DropDownListStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string geselecteerddropdown = "";
            DropDownList dropdown = DropDownListStatus;
            foreach (ListItem item in dropdown.Items)
            {
                if (item.Selected)
                {

                    geselecteerddropdown += "'" + item.Value + "'";
                }
            }

            string geselecteerdcheckbox = "";
            CheckBoxList checkbox = CheckBoxList2;
            foreach (ListItem item in checkbox.Items)
            {
                if (item.Selected)
                {

                    geselecteerdcheckbox += "'" + item.Value + "',";
                }
            }

            if ((geselecteerddropdown.Length > 0) && (geselecteerdcheckbox.Length > 0))
            {
                string nieuw = geselecteerdcheckbox.Remove(geselecteerdcheckbox.Length - 1);
                string sqlquery = "SELECT PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN [USER] ON ARTICLE.PROVIDERID = [USER].ID AND ARTICLE.RENTERID = [USER].ID WHERE CATEGORYNAME in (" + nieuw + ") AND STATUS in (" + geselecteerddropdown + ") ";
                SqlDataSource1.SelectCommand = sqlquery;
            }

            else if ((geselecteerddropdown.Length > 0) && (geselecteerdcheckbox.Length == 0))
            {
                string sqlquery = "SELECT PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN [USER] ON ARTICLE.PROVIDERID = [USER].ID AND ARTICLE.RENTERID = [USER].ID WHERE STATUS in (" + geselecteerddropdown + ")";
                SqlDataSource1.SelectCommand = sqlquery;
            }

            else if ((geselecteerddropdown.Length == 0) && (geselecteerdcheckbox.Length > 0))
            {
                string nieuw = geselecteerdcheckbox.Remove(geselecteerdcheckbox.Length - 1);
                string sqlquery = "SELECT PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN [USER] ON ARTICLE.PROVIDERID = [USER].ID AND ARTICLE.RENTERID = [USER].ID WHERE CATEGORYNAME in (" + nieuw + ")";
                SqlDataSource1.SelectCommand = sqlquery;
            }

            else
            {
                
                string sqlquery = "SELECT PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN [USER] ON ARTICLE.PROVIDERID = [USER].ID AND ARTICLE.RENTERID = [USER].ID ";
                SqlDataSource1.SelectCommand = sqlquery;
            }

            Label1.Text = geselecteerdcheckbox;
        }

        protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string geselecteerddropdown = "";
            DropDownList dropdown = DropDownListStatus;
            foreach (ListItem item in dropdown.Items)
            {
                if (item.Selected)
                {

                    geselecteerddropdown += "'" + item.Value + "'";
                }
            }

            string geselecteerdcheckbox = "";
            CheckBoxList checkbox = CheckBoxList2;
            foreach (ListItem item in checkbox.Items)
            {
                if (item.Selected)
                {

                    geselecteerdcheckbox += "'" + item.Value + "',";
                }
            }

            if ((geselecteerddropdown.Length > 0) && (geselecteerdcheckbox.Length > 0))
            {
                string nieuw = geselecteerdcheckbox.Remove(geselecteerdcheckbox.Length - 1);
                string sqlquery = "SELECT PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN [USER] ON ARTICLE.PROVIDERID = [USER].ID AND ARTICLE.RENTERID = [USER].ID WHERE CATEGORYNAME in (" + nieuw + ") AND STATUS in (" + geselecteerddropdown + ") ";
                SqlDataSource1.SelectCommand = sqlquery;
            }

            else if ((geselecteerddropdown.Length > 0) && (geselecteerdcheckbox.Length == 0))
            {
                string sqlquery = "SELECT PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN [USER] ON ARTICLE.PROVIDERID = [USER].ID AND ARTICLE.RENTERID = [USER].ID WHERE STATUS in (" + geselecteerddropdown + ")";
                SqlDataSource1.SelectCommand = sqlquery;
            }

            else if ((geselecteerddropdown.Length == 0) && (geselecteerdcheckbox.Length > 0))
            {
                string nieuw = geselecteerdcheckbox.Remove(geselecteerdcheckbox.Length - 1);
                string sqlquery = "SELECT PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN [USER] ON ARTICLE.PROVIDERID = [USER].ID AND ARTICLE.RENTERID = [USER].ID WHERE CATEGORYNAME in (" + nieuw + ")";
                SqlDataSource1.SelectCommand = sqlquery;
            }

            else
            {
                
                string sqlquery = "SELECT PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN [USER] ON ARTICLE.PROVIDERID = [USER].ID AND ARTICLE.RENTERID = [USER].ID ";
                SqlDataSource1.SelectCommand = sqlquery;
            }

            Label1.Text = geselecteerdcheckbox;


        }
    }
}