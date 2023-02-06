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

        private void button1_Click(object sender, EventArgs e)//����� ���� ���� �� ���������
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

        private void ��������������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                Product grechka = new Product
                {
                    NameProduct = "������",
                    AmountInGramm = 2000,
                    Note = "������ ���������",
                    //Recipes = { r1, r2 }
                };
                Product svinina = new Product
                {
                    NameProduct = "�������",
                    AmountInGramm = 4000,
                    Note = "���������� ��������� ������������"
                };
                Product luk = new Product
                {
                    NameProduct = "���",
                    AmountInPieces = 20
                };
                Product morkov = new Product
                {
                    NameProduct = "�������",
                    AmountInPieces = 20
                };
                Product tomatPasta = new Product
                {
                    NameProduct = "����� ��������",
                    AmountInPieces = 2,
                    Note = "100 �� � �����"
                };
                Product sosiski = new Product
                {
                    NameProduct = "�������",
                    AmountInPieces = 10
                };


                db.Products.AddRange(grechka, svinina, luk, morkov, tomatPasta, sosiski);

                Recipe r1 = new Recipe
                {
                    NameRecipe = "������ �� ��������� �� �������� �� ���������",
                    �ookingtime = "40 �����",
                    TypeRecipeTimesOfDay = "������",
                    TotalEnergyValue = 156,
                    ProteinsEnergyValue = 8,
                    �arbohydratesEnergyValue = 9,
                    FatsEnergyValue = 12,
                    Products = { grechka, svinina, luk, morkov, tomatPasta }
                };
                Recipe r2 = new Recipe
                {
                    NameRecipe = "������ � ���������",
                    �ookingtime = "30 �����",
                    TypeRecipeTimesOfDay = "������",
                    TotalEnergyValue = 175,
                    ProteinsEnergyValue = 6,
                    �arbohydratesEnergyValue = 11,
                    FatsEnergyValue = 15,
                    Products = { grechka, sosiski }
                };

                db.Recipes.AddRange(r1, r2);

                db.SaveChanges();
            }
        }





    }
}