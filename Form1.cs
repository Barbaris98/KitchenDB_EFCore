using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;


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
            // � ������ ����� ����������� sql ������ �� �������, ����� ��� ����
            
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

            Recipe recipe = new Recipe();
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


            //recipe.Products = new List<Product>();//����� ��������� ����������� ��������
            //Products = { grechka, svinina, luk, morkov, tomatPasta } ��� ��� ���������!!

            MessageBox.Show("������� ��������!");

            //�������������� ������ dataGridView1
            using (ApplicationContext db = new ApplicationContext())
            {

                db.Recipes.Load();// ����� �� �����.... �� ����� �����,
                                   // ��� ��� �������� � ��������/ ������� ��� 
                dataGridView2.DataSource = db.Recipes.ToList();

            }
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
                                       // ��� ��� �������� � ��������/ �������� ��� 
                    dataGridView2.DataSource = db.Recipes.ToList();
                    MessageBox.Show("������ ������!");
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
                    Recipe recipe = db.Recipes.Find(id);
                    RecipeInfo recipeInfo = new RecipeInfo();//���� � �������� ��� ����� 

                    recipeInfo.textBox1.Text = recipe.NameRecipe;
                    recipeInfo.Show();

                    //var recInfo = db.Recipes.Include(r => r.Products).ToList();

                    //int idFaind = 0;
                    //var recInfo = db.Recipes.Include(r => r.Products).Where(id).ToList();
                    // ����� ���, �� ��� �� ������ �����....
                    var value = string.Join(", ", db.Recipes.Include(r => r.Products));
                    recipeInfo.textBox2.Text = value.ToString();

                    
                    //List<Product> products = db.Products.Include(p => p.Recipes.Where(p => p.Recipes.Id = id));
                    //List<Product> products = db.Products.Include(p => p.Recipes).ToList();
                    //List<Product> products = new List<Product>();
                    //

                    try
                    {
                        //1) �������..
                        //products = db.Products.Where(p => p.Recipes.Id == id).ToList();

                        var products = db.Products.Include(p => p.Recipes.Where(x => x.Id == id)).ToList();

                        //2) �������� ��� ��������� id ������� �������� � ��������� ������������� ����������
                        //List<Recipe> myIdRecipe = new List<Recipe>(id);
                        //products = db.Products.Where(p => p.Recipes == myIdRecipe).ToList();
                        // ! ����������� catch..

                        recipeInfo.listBox1.DataSource = products;
                        //recipeInfo.listBox1.ValueMember = "Id";
                        recipeInfo.listBox1.DisplayMember = "NameProduct";
                    }
                    catch
                    {
                        MessageBox.Show("������");
                    }
                    //!var products = db.Products.Include(p => p.Recipes.Where(x => x.Id == id)).ToList();
                    //!recipeInfo.listBox1.DataSource = products;
                    //recipeInfo.listBox1.ValueMember = "Id";
                    //!recipeInfo.listBox1.DisplayMember = "NameProduct";
                    /*
                    //List<Product> recipes = db.Recipes.Include(r => r.Products).ToList();
                    var rec = db.Products.Include(r => r.Recipes).ToList();//�������� ������� ������ � ���� �������...�� ������� ��� �������� �� ��
                   //db.Products.Include(p => p.Recipes.Where(p => p.Recipes.Id = id)); �� ������ �����...
                    recipeInfo.listBox1.DataSource = rec;
                    recipeInfo.listBox1.DisplayMember = "NameProduct";
                    */
                    /*
        public async Task<List<DrawSpecification>> GetDrawSpecificationsAsync(DrawSystem drawSystem)
        {
            List<DrawSpecification> drawSpecifications = new List<DrawSpecification>();

            try
            {
                drawSpecifications = await _drawContext.DrawSpecifications
                    .Where(ds => ds.DrawSystemID == drawSystem.DrawSystemID)
                    .OrderBy(ds => ds.DSPositionNum)
                    .ToListAsync();

                return drawSpecifications;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("������ �������� ������.", ex);
            }
        }
        
        */

                    //var recipeConsistOf = db.Recipes.Include(r => r.Products).ToList();
                    //textBox2.Text = recipeConsistOf.ToList();
                    //textBox2.Text = db.Recipes.Include(r => r.Products).ToList();

                    //'nj hf,jnftn!
                    //textBox2.Text = Convert.ToString(db.Recipes.Include(r => r.Products).ToList());

                    /*�������� �� ������� ��� ������� ����  
                    var rec = db.Recipes.Include(r => r.Products).ToList();
                    recipeInfo.listBox1.DataSource = rec;
                    recipeInfo.listBox1.DisplayMember = "NameRecipe";

                    */
                }
            }
        }
        //
        //
        /*
        public async Task<List<DrawSpecification>> GetDrawSpecificationsAsync(DrawSystem drawSystem)
        {
            List<DrawSpecification> drawSpecifications = new List<DrawSpecification>();

            try
            {
                drawSpecifications = await _drawContext.DrawSpecifications
                    .Where(ds => ds.DrawSystemID == drawSystem.DrawSystemID)
                    .OrderBy(ds => ds.DSPositionNum)
                    .ToListAsync();

                return drawSpecifications;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("������ �������� ������.", ex);
            }
        }
        
        */



    }
}