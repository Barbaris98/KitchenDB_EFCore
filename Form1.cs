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

        private void button1_Click(object sender, EventArgs e)//Вывод всей инфы по продуктам
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //var products = (from product in db.Products select product).ToList();
                //dataGridView1.Rows.Add(products);

                db.Products.Load();

                dataGridView1.DataSource = db.Products.ToList();
                //dataGridView2.DataSource = db.Recipes.ToList();
                //dataGridView1.DataSource = db.Products.Local.ToBindingList();

                //foreach (string[] stringView in products)
                //{
                //   dataGridView1.Rows.Add(stringView);
                //}


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void инициализироватьНачДаннымиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                Product grechka = new Product
                {
                    NameProduct = "Гречка",
                    AmountInGramm = 2000,
                    Note = "Гречка Минстраль",
                    //Recipes = { r1, r2 }
                };
                Product svinina = new Product
                {
                    NameProduct = "Свинина",
                    AmountInGramm = 4000,
                    Note = "Нарезанная кусочками замороженная"
                };
                Product luk = new Product
                {
                    NameProduct = "Лук",
                    AmountInPieces = 20
                };
                Product morkov = new Product
                {
                    NameProduct = "Морковь",
                    AmountInPieces = 20
                };
                Product tomatPasta = new Product
                {
                    NameProduct = "Паста томатная",
                    AmountInPieces = 2,
                    Note = "100 гр в банке"
                };
                Product sosiski = new Product
                {
                    NameProduct = "Сосиски",
                    AmountInPieces = 10
                };


                db.Products.AddRange(grechka, svinina, luk, morkov, tomatPasta, sosiski);

                Recipe r1 = new Recipe
                {
                    NameRecipe = "Гречка по купечески со свининой на сковороде",
                    Сookingtime = "40 минут",
                    TypeRecipeTimesOfDay = "Второе",
                    TotalEnergyValue = 156,
                    ProteinsEnergyValue = 8,
                    СarbohydratesEnergyValue = 9,
                    FatsEnergyValue = 12,
                    Products = { grechka, svinina, luk, morkov, tomatPasta }
                };
                Recipe r2 = new Recipe
                {
                    NameRecipe = "Гречка с сосисками",
                    Сookingtime = "30 минут",
                    TypeRecipeTimesOfDay = "Второе",
                    TotalEnergyValue = 175,
                    ProteinsEnergyValue = 6,
                    СarbohydratesEnergyValue = 11,
                    FatsEnergyValue = 15,
                    Products = { grechka, sosiski }
                };

                db.Recipes.AddRange(r1, r2);

                db.SaveChanges();
            }
        }





    }
}