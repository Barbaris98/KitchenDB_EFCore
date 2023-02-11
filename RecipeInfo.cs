using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitchenDB_EFCore
{
    public partial class RecipeInfo : Form
    {
        public RecipeInfo()
        {
            InitializeComponent();
        }

        private void RecipeInfo_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //var recipeConsistOf = db.Recipes.Include(r => r.Products).ToList();
                //textBox2.Text = recipeConsistOf.ToList();
                //textBox2.Text = db.Recipes.Include(r => r.Products).ToList();

                //'nj hf,jnftn!
                //textBox2.Text = Convert.ToString(db.Recipes.Include(r => r.Products).ToList());
                /*
                var value = string.Join(", ", db.Recipes.Include(r => r.Products));
                textBox2.Text = value.ToString();

                
                //Product product = new Product();
                //recipe.Products = new List<Product>();
                List<Product> products = db.Products.ToList();
                listBox1.DataSource= products;
                listBox1.ValueMember = "Id";
                listBox1.DisplayMember = "NameProduct";
                */
                






            }



        }
    }
}
