using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;

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
                db.Products.Load();

                dataGridView1.DataSource = db.Products.ToList();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductForm productForm= new ProductForm();

            DialogResult result= productForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            Product product = new Product();
            product.NameProduct = productForm.textBox1.Text;
            //����� �� ��������� ��� 3 ��������
            try
            {
                product.AmountInGramm = Convert.ToInt32(productForm.textBox2.Text);
            }
            catch{}
            try
            {
                product.AmountInPieces = Convert.ToInt32(productForm.textBox3.Text);
            }
            catch { }
            try
            {
                product.Note = productForm.textBox4.Text;
            }
            catch { }

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products.Add(product);
                db.SaveChanges();

            }
            MessageBox.Show("������� ��������!");

            //�������������� ������ dataGridView1
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products.Load();// ����� �� �����.... �� ����� �����,
                                   // ��� ��� �������� � ��������/ ������� ��� 
                dataGridView1.DataSource = db.Products.ToList();

            }

        }


        private void ���������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ���� ����� �������� ��� ����� ����� �������.
            
            using (ApplicationContext db = new ApplicationContext())
            {

                Product grechka = new Product
                {
                    NameProduct = "������",
                    AmountInGramm = 2000,
                    Note = "������ ���������",
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

        private void button3_Click(object sender, EventArgs e)//��������
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Product product = db.Products.Find(id);
                    db.Products.Remove(product);
                    db.SaveChanges();

                    MessageBox.Show("������ ������");
                }
                //�������������� ������ dataGridView1
                db.Products.Load();// ����� �� �����.... �� ����� �����,
                                   // ��� ��� �������� � ��������/ �������� ��� 

                dataGridView1.DataSource = db.Products.ToList();

            }

        }

        private void button4_Click(object sender, EventArgs e)// �������������
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Product product = db.Products.Find(id);
                    ProductForm productForm = new ProductForm();

                    productForm.textBox1.Text = product.NameProduct;
                    productForm.textBox2.Text = product.AmountInGramm.ToString();
                    productForm.textBox3.Text = product.AmountInPieces.ToString();
                    productForm.textBox4.Text = product.Note;

                    
                    DialogResult result = productForm.ShowDialog(this);

                    if (result == DialogResult.Cancel)
                        return;

                    product.NameProduct = productForm.textBox1.Text;
                    //����� �� ��������� ��� 3 ��������
                    try
                    {
                        product.AmountInGramm = Convert.ToInt32(productForm.textBox2.Text);
                    }
                    catch { }
                    try
                    {
                        product.AmountInPieces = Convert.ToInt32(productForm.textBox3.Text);
                    }
                    catch { }
                    try
                    {
                        product.Note = productForm.textBox4.Text;
                    }
                    catch { }

                    db.SaveChanges();
                    //dataGridView1.Refresh(); // �� ��������
                    db.Products.Load();// ����� �� �����.... �� ����� �����,
                                       // ��� ��� �������� � ��������/ �������� ��� 
                    dataGridView1.DataSource = db.Products.ToList();
                    MessageBox.Show("������ ������!");

                }

            }

        }
    }
}