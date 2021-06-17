using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruilwinkel
{
    public partial class Categorieën : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddCategory_Click(object sender, EventArgs e)
        {
            DateTime loggingVoor = DateTime.Now;
            Categorie categorie = new Categorie(TextBoxCategorieNaam.Text, int.Parse(TextBoxCategoriePunten.Text));
            categorie.Toevoegen(categorie);
            DateTime loggingNa = DateTime.Now;
            categorie.Logging(TextBoxCategorieNaam.Text, loggingVoor, loggingNa);
            Response.Redirect("Categorieën.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string selectedCategory = GridView2.SelectedRow.Cells[2].Text;
            string caterogyCheck = "SELECT CATEGORY.CATEGORYNAME";
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label3.Text = GridView2.SelectedRow.Cells[2].Text;
        }
    }
}