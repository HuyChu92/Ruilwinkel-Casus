using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            CheckBoxList checkbox = CheckBoxList2;
            string selected = checkbox.SelectedValue;
            BTNOK.Text = selected;


        }
    }
}