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

            //создадим элемент меню
            ToolStripMenuItem shoMore = new ToolStripMenuItem("Подробнее");

            //Добавление элемента меню
            contextMenuStrip1.Items.Add( shoMore );

            //Ассоциируем контекстное меню с гридом
            dataGridView2.ContextMenuStrip = contextMenuStrip1;

            //Установим обработчик события для меню
            shoMore.Click += shoMore_Click;



        }
        /*
         * можно ещё добавить функционал при закритии приложения: Да - Отмена


        */

        private void button1_Click(object sender, EventArgs e)//Вывод всей инфы по продуктам
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products.Load();

                dataGridView1.DataSource = db.Products.ToList();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)// Добавить
        {
            ProductForm productForm= new ProductForm();

            DialogResult result= productForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            Product product = new Product();
            product.NameProduct = productForm.textBox1.Text;
            //можно не заполнять эти 3 свойства
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
            MessageBox.Show("Продукт добавлен!");

            //автообновление вывода dataGridView1
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products.Load();// вроде не нужен.... но пусть будет,
                                   // ещё раз загрузим в контекст/ обновим его 
                dataGridView1.DataSource = db.Products.ToList();

            }

        }


        private void сброситьБДПоумолчаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Надо будет доделать эту фишку Бдует полезно.
            // В начале будет выполеяться sql запрос на очистку, потом код ниже
            
            using (ApplicationContext db = new ApplicationContext())
            {

                Product grechka = new Product
                {
                    NameProduct = "Гречка",
                    AmountInGramm = 2000,
                    Note = "Гречка Минстраль",
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

        private void button3_Click(object sender, EventArgs e)//удаление
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

                    MessageBox.Show("Объект удален");
                }
                //автообновление вывода dataGridView1
                db.Products.Load();// вроде не нужен.... но пусть будет,
                                   // ещё раз загрузим в контекст/ обноввим его 

                dataGridView1.DataSource = db.Products.ToList();

            }

        }

        private void button4_Click(object sender, EventArgs e)// редактировать
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
                    //можно не заполнять эти 3 свойства
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
                    //dataGridView1.Refresh(); // не работает
                    db.Products.Load();// вроде не нужен.... но пусть будет,
                                       // ещё раз загрузим в контекст/ обноввим его 
                    dataGridView1.DataSource = db.Products.ToList();
                    MessageBox.Show("Объект изменён!");

                }

            }

        }

        private void button5_Click(object sender, EventArgs e)//Вывод всей инфы по Рецептам
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Recipes.Load();
                dataGridView2.DataSource= db.Recipes.ToList();

            }

        }

        private void button8_Click(object sender, EventArgs e) //Добавить
        {
            RecipeForm recipeForm = new RecipeForm();

            DialogResult result = recipeForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            Recipe recipe = new Recipe();
            recipe.NameRecipe = recipeForm.textBox1.Text;
            recipe.Сookingtime = recipeForm.textBox2.Text;// может имет null
            //player.Position = plForm.comboBox1.SelectedItem.ToString();
            recipe.TypeRecipeTimesOfDay = recipeForm.comboBox1.SelectedItem.ToString();
            //можно не заполнять эти 3 свойства
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
                recipe.СarbohydratesEnergyValue = Convert.ToInt32(recipeForm.textBox5.Text);
            }
            catch { }
            try
            {
                recipe.FatsEnergyValue = Convert.ToInt32(recipeForm.textBox6.Text);
            }
            catch { }


            //recipe.Products = new List<Product>();//будет содержать определённые продукты
            //Products = { grechka, svinina, luk, morkov, tomatPasta } ВОТ ТАК ПРАВИЛЬНО!!

            MessageBox.Show("Продукт добавлен!");

            //автообновление вывода dataGridView1
            using (ApplicationContext db = new ApplicationContext())
            {

                db.Recipes.Load();// вроде не нужен.... но пусть будет,
                                   // ещё раз загрузим в контекст/ обновим его 
                dataGridView2.DataSource = db.Recipes.ToList();

            }
        }

        private void button7_Click(object sender, EventArgs e)// Удаление
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

                    MessageBox.Show("Объект удален");
                }
                //автообновление вывода dataGridView1
                db.Recipes.Load();
                dataGridView2.DataSource = db.Recipes.ToList();
            }

        }
        private void button6_Click(object sender, EventArgs e)//Редактировать
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
                    recipeForm.textBox2.Text = recipe.Сookingtime;
                    recipeForm.comboBox1.Text = recipe.TypeRecipeTimesOfDay;
                    recipeForm.textBox3.Text = recipe.TotalEnergyValue.ToString();
                    recipeForm.textBox4.Text = recipe.ProteinsEnergyValue.ToString();
                    recipeForm.textBox5.Text = recipe.СarbohydratesEnergyValue.ToString();
                    recipeForm.textBox6.Text = recipe.FatsEnergyValue.ToString();


                    DialogResult result = recipeForm.ShowDialog(this);
                    if (result == DialogResult.Cancel)
                        return;

                    recipe.NameRecipe = recipeForm.textBox1.Text;
                    recipe.Сookingtime = recipeForm.textBox2.Text;// может имет null
                                                                  //player.Position = plForm.comboBox1.SelectedItem.ToString();
                    recipe.TypeRecipeTimesOfDay = recipeForm.comboBox1.SelectedItem.ToString();
                    //можно не заполнять эти 3 свойства
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
                        recipe.СarbohydratesEnergyValue = Convert.ToInt32(recipeForm.textBox5.Text);
                    }
                    catch { }
                    try
                    {
                        recipe.FatsEnergyValue = Convert.ToInt32(recipeForm.textBox6.Text);
                    }
                    catch { }

                    db.SaveChanges();
                    //dataGridView1.Refresh(); // не работает
                    db.Recipes.Load();// вроде не нужен.... но пусть будет,
                                       // ещё раз загрузим в контекст/ обноввим его 
                    dataGridView2.DataSource = db.Recipes.ToList();
                    MessageBox.Show("Объект изменён!");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)// Открыть Сайт с рецептами
        {
            try
            {
                ProcessStartInfo procInfo = new ProcessStartInfo();
                // исполняемый файл программы - браузер хром
                procInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome";
                // аргументы запуска - адрес интернет-ресурса
                procInfo.Arguments = "https://1000.menu/";
                Process.Start(procInfo);
            }
            catch
            {
                MessageBox.Show("Не найден браузер Google Chrome по адрессу " +
                    "C:\\Program Files\\Google\\Chrome\\Application\\chrome");
            }

        }

        void shoMore_Click(object sender, EventArgs e)// ПКМ - на строке - Подробнее о рецепте
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    
                    //по соответствующему id
                    Recipe recipe = db.Recipes.Find(id);
                    RecipeInfo recipeInfo = new RecipeInfo();//созд и показать экз формы 

                    recipeInfo.textBox1.Text = recipe.NameRecipe;
                    recipeInfo.Show();

                    //var recInfo = db.Recipes.Include(r => r.Products).ToList();

                    //int idFaind = 0;
                    //var recInfo = db.Recipes.Include(r => r.Products).Where(id).ToList();
                    // можно так, но это не совсем верно....
                    var value = string.Join(", ", db.Recipes.Include(r => r.Products));
                    recipeInfo.textBox2.Text = value.ToString();

                    
                    //List<Product> products = db.Products.Include(p => p.Recipes.Where(p => p.Recipes.Id = id));
                    //List<Product> products = db.Products.Include(p => p.Recipes).ToList();
                    //List<Product> products = new List<Product>();
                    //

                    try
                    {
                        //1) неверно..
                        //products = db.Products.Where(p => p.Recipes.Id == id).ToList();

                        var products = db.Products.Include(p => p.Recipes.Where(x => x.Id == id)).ToList();

                        //2) поробуем наш выбранный id рецепта засунуть в правильно типизирванную переменную
                        //List<Recipe> myIdRecipe = new List<Recipe>(id);
                        //products = db.Products.Where(p => p.Recipes == myIdRecipe).ToList();
                        // ! срабатывает catch..

                        recipeInfo.listBox1.DataSource = products;
                        //recipeInfo.listBox1.ValueMember = "Id";
                        recipeInfo.listBox1.DisplayMember = "NameProduct";
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка");
                    }
                    //!var products = db.Products.Include(p => p.Recipes.Where(x => x.Id == id)).ToList();
                    //!recipeInfo.listBox1.DataSource = products;
                    //recipeInfo.listBox1.ValueMember = "Id";
                    //!recipeInfo.listBox1.DisplayMember = "NameProduct";
                    /*
                    //List<Product> recipes = db.Recipes.Include(r => r.Products).ToList();
                    var rec = db.Products.Include(r => r.Recipes).ToList();//Продукты которые содерж в этом рецепте...НО выводит все продукты из БД
                   //db.Products.Include(p => p.Recipes.Where(p => p.Recipes.Id = id)); НЕ совсем верно...
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
                throw new ApplicationException("Ошибка загрузки данных.", ex);
            }
        }
        
        */

                    //var recipeConsistOf = db.Recipes.Include(r => r.Products).ToList();
                    //textBox2.Text = recipeConsistOf.ToList();
                    //textBox2.Text = db.Recipes.Include(r => r.Products).ToList();

                    //'nj hf,jnftn!
                    //textBox2.Text = Convert.ToString(db.Recipes.Include(r => r.Products).ToList());

                    /*работает но выводит все рецепты сука  
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
                throw new ApplicationException("Ошибка загрузки данных.", ex);
            }
        }
        
        */



    }
}