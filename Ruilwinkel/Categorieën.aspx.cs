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
            GridViewRow gr = GridView2.SelectedRow;
            string selected = gr.Cells[1].Text;
            if (selected == "" || selected == null)
            {
                Label3.Text = "werkt niet";
            }
            else {
                Label3.Text = selected;
            }



        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}