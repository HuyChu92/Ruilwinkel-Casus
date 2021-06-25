using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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
            if (GridView2.SelectedRow == null)
            {
                Response.Write("<script>alert('Selecteer eerst een regel om te verwijderen.')</script>");
            }
            else
            {
                string selectedCategory = GridView2.SelectedRow.Cells[1].Text;
                string caterogyCheck = "SELECT PRODUCT.PRODUCTNAME FROM PRODUCT WHERE PRODUCT.CATEGORYID = (" + selectedCategory + ")";
                List<string> producten = new List<string>();
                //Label3.Text = selectedCategory;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=productbeheerserver.database.windows.net;Initial Catalog=RuilwinkelDB;Persist Security Info=True;User ID=DevOps;Password=Zuyd2021";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = caterogyCheck;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string productNaam = dr.GetValue(0).ToString();
                    producten.Add(productNaam);
                }
                con.Close();

                if (producten.Count == 0)
                {
                    string deleteString = "DELETE FROM CATEGORY WHERE ID = (" + selectedCategory + ")";
                    deleteCategory(deleteString);
                    Response.Redirect("Categorieën.aspx");
                }
                else
                {
                    Messagebox(producten);
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void deleteCategory(string command) {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=productbeheerserver.database.windows.net;Initial Catalog=RuilwinkelDB;Persist Security Info=True;User ID=DevOps;Password=Zuyd2021";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = command;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Messagebox(List<string> Message)
        {
            string test = "Verwijder volgende producten eerst:  ";
            foreach (string product in Message) {
                test += product.ToString() + ",  ";  
            }
            Response.Write("<script>alert('" + test + "')</script>");
        }
    }
}