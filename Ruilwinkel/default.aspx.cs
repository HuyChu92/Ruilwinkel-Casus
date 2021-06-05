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
            show_checkboxlist(false);
        }

        protected void DropDownListStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string geselecteerddropdown = getSelectedDropdownValue();
            string geselecteerdcheckbox = getSelectedCheckboxlistValue();
            action1(geselecteerddropdown, geselecteerdcheckbox);
            //Label1.Text = geselecteerdcheckbox;
            show_checkboxlist(CheckBox2.Checked);
        }

        protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string geselecteerddropdown = getSelectedDropdownValue();           
            string geselecteerdcheckbox = getSelectedCheckboxlistValue();
            action1(geselecteerddropdown, geselecteerdcheckbox);
            //Label1.Text = geselecteerdcheckbox;
            show_checkboxlist(CheckBox2.Checked);

        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            show_checkboxlist(CheckBox2.Checked);
        }

        private void show_checkboxlist(bool value) {
            dvCategorie.Visible = value;
        }

        private void executeSqlquery( string nieuw, string geselecteerddropdown)
        {
            string baseQuery = "SELECT PRODUCT.PRODUCTNAME, PRODUCT.DESCRIPTION, CATEGORY.CATEGORYNAME, ARTICLE.STATUS, [USER].FIRSTNAME, [USER].LASTNAME, CATEGORY.POINTS FROM PRODUCT INNER JOIN ARTICLE ON PRODUCT.ID = ARTICLE.PRODUCTID INNER JOIN CATEGORY ON PRODUCT.CATEGORYID = CATEGORY.ID INNER JOIN [USER] ON ARTICLE.PROVIDERID = [USER].ID AND ARTICLE.RENTERID = [USER].ID ";
            string bothSelected = "WHERE CATEGORYNAME in (" + nieuw + ") AND STATUS in (" + geselecteerddropdown + ") ";
            string statusSelected = "WHERE STATUS in (" + geselecteerddropdown + ")";
            string categorySelected = "WHERE CATEGORYNAME in (" + nieuw + ")";
            string sqlQuery = "";
            if (!String.IsNullOrEmpty(nieuw))
            {
                sqlQuery = baseQuery + categorySelected;
            }
            else if (!String.IsNullOrEmpty(geselecteerddropdown))
            {
                sqlQuery = baseQuery + statusSelected;
            }
            else if (!String.IsNullOrEmpty(nieuw) && !String.IsNullOrEmpty(geselecteerddropdown))
            {
                sqlQuery = baseQuery + bothSelected;
            }
            else {
                sqlQuery = baseQuery;
            }
            SqlDataSource1.SelectCommand = sqlQuery;
        }

        private void action1(string geselecteerddropdown, string geselecteerdcheckbox) {
            if (String.IsNullOrEmpty(geselecteerddropdown) == false && String.IsNullOrEmpty(geselecteerdcheckbox) == false)
            {
                string nieuw = geselecteerdcheckbox.Remove(geselecteerdcheckbox.Length - 1);
                executeSqlquery(nieuw, geselecteerddropdown);
            }

            else if (String.IsNullOrEmpty(geselecteerddropdown) == false && String.IsNullOrEmpty(geselecteerdcheckbox) == true)
            {
                executeSqlquery("", geselecteerddropdown);
            }

            else if (String.IsNullOrEmpty(geselecteerddropdown) == true && String.IsNullOrEmpty(geselecteerdcheckbox) == false)
            {
                string nieuw = geselecteerdcheckbox.Remove(geselecteerdcheckbox.Length - 1);
                executeSqlquery(nieuw, "");
            }

            else
            {
                executeSqlquery("", "");
            }
        }

        private string getSelectedDropdownValue()
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

            return geselecteerddropdown;
        }

        private string getSelectedCheckboxlistValue() {
            string geselecteerdcheckbox = "";
            CheckBoxList checkbox = CheckBoxList2;
            foreach (ListItem item in checkbox.Items)
            {
                if (item.Selected)
                {

                    geselecteerdcheckbox += "'" + item.Value + "',";
                }
            }

            return geselecteerdcheckbox;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Label1.Text = TextBox1.Text;
        }
    }
}