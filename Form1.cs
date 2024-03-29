using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using ClosedXML.Excel;

namespace KitchenDB_EFCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //�������� ������� ����
            ToolStripMenuItem shoMore = new ToolStripMenuItem("���������");

            //���������� �������� ����
            contextMenuStrip1.Items.Add( shoMore );

            //����������� ����������� ���� � ������
            dataGridView2.ContextMenuStrip = contextMenuStrip1;

            //��������� ���������� ������� ��� ����
            shoMore.Click += shoMore_Click;



        }
        /*
         * ����� ��� �������� ���������� ��� �������� ����������: �� - ������


        */

        private void button1_Click(object sender, EventArgs e)//����� ���� ���� �� ���������
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products.Load();

                dataGridView1.DataSource = db.Products.ToList();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)// ��������
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

                db.Products.Load();
                dataGridView1.DataSource = db.Products.ToList();

            }

            MessageBox.Show("������� ��������!");

        }

        private void ���������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ���� ����� �������� ��� ����� ����� �������.
            // � ������ ����� ����������� sql ������ �� �������, ����� ��� ����

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();

            }

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

        private void button4_Click(object sender, EventArgs e)//�������������
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
                    MessageBox.Show("������ �������!");

                }

            }

        }

        private void button5_Click(object sender, EventArgs e)//����� ���� ���� �� ��������
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Recipes.Load();
                dataGridView2.DataSource= db.Recipes.ToList();

            }

        }

        private void button8_Click(object sender, EventArgs e) //��������
        {
            RecipeForm recipeForm = new RecipeForm();

            DialogResult result = recipeForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            //Recipe recipe = new Recipe();
            using (ApplicationContext db = new ApplicationContext())
            {
                Recipe recipe = new Recipe();
                /*
                //�������� �� ��������� ���� "1" - ������
                Product product = db.Products.FirstOrDefault(product => product.Id == 1);
                // ����� ��������  (product => product.Id == 1); �� (y => y.Id == 1); ,��� �������
                // �� ��� ����� ��������� ,���  ���� 
                recipe.Products.Add(product);
                */
               
                int x = int.Parse(recipeForm.textBox7.Text);
                Product product = db.Products.FirstOrDefault(product => product.Id == x);
                recipe.Products.Add(product);
                

                recipe.NameRecipe = recipeForm.textBox1.Text;
                recipe.�ookingtime = recipeForm.textBox2.Text;

                recipe.TypeRecipeTimesOfDay = recipeForm.comboBox1.SelectedItem.ToString();
                //����� �� ��������� ��� 3 ��������
                try
                {
                    recipe.TotalEnergyValue = Convert.ToInt32(recipeForm.textBox3.Text);
                }
                catch { }
                try
                {
                    recipe.ProteinsEnergyValue = Convert.ToInt32(recipeForm.textBox4.Text);
                }
                catch { }
                try
                {
                    recipe.�arbohydratesEnergyValue = Convert.ToInt32(recipeForm.textBox5.Text);
                }
                catch { }
                try
                {
                    recipe.FatsEnergyValue = Convert.ToInt32(recipeForm.textBox6.Text);
                }
                catch { }

                db.Recipes.Add(recipe);
                db.SaveChanges();

                db.Recipes.Load();
                dataGridView2.DataSource = db.Recipes.ToList();
            }

            MessageBox.Show("������� ��������!");
            
        }

        private void button7_Click(object sender, EventArgs e)// ��������
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int index = dataGridView2.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Recipe recipe = db.Recipes.Find(id);
                    db.Recipes.Remove(recipe);
                    db.SaveChanges();

                    MessageBox.Show("������ ������");
                }
                //�������������� ������ dataGridView1
                db.Recipes.Load();
                dataGridView2.DataSource = db.Recipes.ToList();
            }

        }
        private void button6_Click(object sender, EventArgs e)//�������������
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int index = dataGridView2.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Recipe recipe = db.Recipes.Find(id);
                    RecipeForm recipeForm = new RecipeForm();

                    recipeForm.textBox1.Text = recipe.NameRecipe;
                    recipeForm.textBox2.Text = recipe.�ookingtime;
                    recipeForm.comboBox1.Text = recipe.TypeRecipeTimesOfDay;
                    recipeForm.textBox3.Text = recipe.TotalEnergyValue.ToString();
                    recipeForm.textBox4.Text = recipe.ProteinsEnergyValue.ToString();
                    recipeForm.textBox5.Text = recipe.�arbohydratesEnergyValue.ToString();
                    recipeForm.textBox6.Text = recipe.FatsEnergyValue.ToString();


                    DialogResult result = recipeForm.ShowDialog(this);
                    if (result == DialogResult.Cancel)
                        return;

                    int x = int.Parse(recipeForm.textBox7.Text);
                    Product product = db.Products.FirstOrDefault(product => product.Id == x);
                    recipe.Products.Add(product);


                    recipe.NameRecipe = recipeForm.textBox1.Text;
                    recipe.�ookingtime = recipeForm.textBox2.Text;// ����� ���� null
                                                                  //player.Position = plForm.comboBox1.SelectedItem.ToString();
                    recipe.TypeRecipeTimesOfDay = recipeForm.comboBox1.SelectedItem.ToString();
                    //����� �� ��������� ��� 3 ��������
                    try
                    {
                        recipe.TotalEnergyValue = Convert.ToInt32(recipeForm.textBox3.Text);
                    }
                    catch { }
                    try
                    {
                        recipe.ProteinsEnergyValue = Convert.ToInt32(recipeForm.textBox4.Text);
                    }
                    catch { }
                    try
                    {
                        recipe.�arbohydratesEnergyValue = Convert.ToInt32(recipeForm.textBox5.Text);
                    }
                    catch { }
                    try
                    {
                        recipe.FatsEnergyValue = Convert.ToInt32(recipeForm.textBox6.Text);
                    }
                    catch { }

                    db.SaveChanges();
                    //dataGridView1.Refresh(); // �� ��������
                    db.Recipes.Load();// ����� �� �����.... �� ����� �����,
                                       // ��� ��� �������� � ��������/ ������� ��� 
                    dataGridView2.DataSource = db.Recipes.ToList();
                    MessageBox.Show("������ �������!");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)// ������� ���� � ���������
        {
            try
            {
                ProcessStartInfo procInfo = new ProcessStartInfo();
                // ����������� ���� ��������� - ������� ����
                procInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome";
                // ��������� ������� - ����� ��������-�������
                procInfo.Arguments = "https://1000.menu/";
                Process.Start(procInfo);
            }
            catch
            {
                MessageBox.Show("�� ������ ������� Google Chrome �� ������� " +
                    "C:\\Program Files\\Google\\Chrome\\Application\\chrome");
            }

        }

        void shoMore_Click(object sender, EventArgs e)// ��� - �� ������ - ��������� � �������
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());

                    //�� ���������������� id
                    Recipe recipe = db.Recipes.Include(r => r.Products).FirstOrDefault(x => x.Id == id);

                    RecipeInfo recipeInfo = new RecipeInfo();//���� � �������� ��� ����� 

                    recipeInfo.textBox1.Text = recipe.NameRecipe;
                    recipeInfo.Show();

                    try
                    {
                        recipeInfo.listBox1.DataSource = recipe.Products;
                        //recipeInfo.listBox1.ValueMember = "Id";
                        recipeInfo.listBox1.DisplayMember = "NameProduct";
                    }
                    catch
                    {
                        MessageBox.Show("������");
                    }


                }
            }
        }

        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Export", "export.xlsx");

            using (ApplicationContext db = new ApplicationContext())
            {
                // ��� �� ��������, ������� ,�� �������� 
                /*
                var products = db.Products.ToList();
                var workBook = new XLWorkbook();
                //workBook.Worksheets.Add(products);

                var sheet = workBook.Worksheets.Add("Products");
                //������ https://github.com/ClosedXML/ClosedXML/wiki
                // ������� ����, �� �������� �����... ������ ������ �������
                //                                      �� ������ ������
                sheet.Cell("A1").InsertTable(products);
                workBook.SaveAs(path);
                */
                //2 ����� ������ ������
                /*
                var products = db.Products.ToList();
                
                var workBook = new XLWorkbook();
                workBook.Worksheets.Add(products);// ��� ������ ������??

                workBook.SaveAs(path);
                */


                // ��� �� ��������, ������� ,�� �������� 
                var products = db.Products.ToList();
                var workBook = new XLWorkbook();

                var sheet = workBook.Worksheets.Add("Products");
                var startRow = 1;
                int startCol = 1;

                foreach(var item in products)
                {
                    sheet.Cell(startRow, startCol++).Value = item.Id;
                    sheet.Cell(startRow, startCol++).Value = item.NameProduct;
                    sheet.Cell(startRow, startCol++).Value = item.AmountInGramm;
                    sheet.Cell(startRow, startCol++).Value = item.AmountInPieces;
                    sheet.Cell(startRow, startCol).Value = item.Note;

                    //startCol = 0; !! ��-�� ����� ������ :
                    //Column number must be between 1 and 16384 Arg_ParamName_Name"
                    startCol = 1;
                    startRow++;

                }
                
                workBook.SaveAs(path);



            }


            

        }
    }
}