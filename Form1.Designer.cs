namespace KitchenDB_EFCore
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётПоПродуктамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётПоРецептамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инициализироватьНачДаннымиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.applicationContextBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationContextBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.сервисToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1044, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьОтчётToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьОтчётToolStripMenuItem
            // 
            this.создатьОтчётToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчётПоПродуктамToolStripMenuItem,
            this.отчётПоРецептамToolStripMenuItem});
            this.создатьОтчётToolStripMenuItem.Name = "создатьОтчётToolStripMenuItem";
            this.создатьОтчётToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.создатьОтчётToolStripMenuItem.Text = "Создать отчёт";
            // 
            // отчётПоПродуктамToolStripMenuItem
            // 
            this.отчётПоПродуктамToolStripMenuItem.Name = "отчётПоПродуктамToolStripMenuItem";
            this.отчётПоПродуктамToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.отчётПоПродуктамToolStripMenuItem.Text = "Отчёт по продуктам";
            // 
            // отчётПоРецептамToolStripMenuItem
            // 
            this.отчётПоРецептамToolStripMenuItem.Name = "отчётПоРецептамToolStripMenuItem";
            this.отчётПоРецептамToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.отчётПоРецептамToolStripMenuItem.Text = "Отчёт по рецептам";
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.инициализироватьНачДаннымиToolStripMenuItem,
            this.очиститьБДToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // инициализироватьНачДаннымиToolStripMenuItem
            // 
            this.инициализироватьНачДаннымиToolStripMenuItem.Name = "инициализироватьНачДаннымиToolStripMenuItem";
            this.инициализироватьНачДаннымиToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.инициализироватьНачДаннымиToolStripMenuItem.Text = "Инициализировать нач данными";
            this.инициализироватьНачДаннымиToolStripMenuItem.Click += new System.EventHandler(this.инициализироватьНачДаннымиToolStripMenuItem_Click);
            // 
            // очиститьБДToolStripMenuItem
            // 
            this.очиститьБДToolStripMenuItem.Name = "очиститьБДToolStripMenuItem";
            this.очиститьБДToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.очиститьБДToolStripMenuItem.Text = "Очистить БД";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1020, 482);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1012, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(480, 346);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 50);
            this.button4.TabIndex = 10;
            this.button4.Text = "Редактировать";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(300, 346);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 50);
            this.button3.TabIndex = 9;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(738, 311);
            this.dataGridView1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(120, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 50);
            this.button2.TabIndex = 7;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(792, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 67);
            this.button1.TabIndex = 6;
            this.button1.Text = "Показать БД";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1012, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(734, 205);
            this.dataGridView2.TabIndex = 10;
            // 
            // applicationContextBindingSource
            // 
            this.applicationContextBindingSource.DataSource = typeof(KitchenDB_EFCore.ApplicationContext);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(764, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "ПОСМОТРТЕЬ ЕЩЁ РЕЦЕПТЫЭ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 551);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationContextBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem создатьОтчётToolStripMenuItem;
        private ToolStripMenuItem отчётПоПродуктамToolStripMenuItem;
        private ToolStripMenuItem отчётПоРецептамToolStripMenuItem;
        private ToolStripMenuItem сервисToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private BindingSource applicationContextBindingSource;
        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem инициализироватьНачДаннымиToolStripMenuItem;
        private ToolStripMenuItem очиститьБДToolStripMenuItem;
        private Button button4;
        private Button button3;
        private Label label1;
    }
}