using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KitchenDB_EFCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //var products = (from product in db.Products select product).ToList();

                //dataGridView1.Rows.Add(products);

                db.Products.Load();
                dataGridView1.DataSource = db.Products.ToList();

                // или так?...  dataGridView1.DataSource = db.Products.Local.ToBindingList();


                //foreach (string[] stringView in products)
                //{
                //   dataGridView1.Rows.Add(stringView);
                //}





            }



        }


    }
}