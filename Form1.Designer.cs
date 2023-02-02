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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётПоПродуктамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётПоРецептамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FatsEnergyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.СarbohydratesEnergyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProteinsEnergyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalEnergyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeRecipeTimesOfDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Сookingtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountInGramm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountInPieces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.создатьОтчётToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "Сервис";
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
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1012, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1012, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FatsEnergyValue
            // 
            this.FatsEnergyValue.HeaderText = "FatsEnergyValue";
            this.FatsEnergyValue.Name = "FatsEnergyValue";
            // 
            // СarbohydratesEnergyValue
            // 
            this.СarbohydratesEnergyValue.HeaderText = "СarbohydratesEnergyValue";
            this.СarbohydratesEnergyValue.Name = "СarbohydratesEnergyValue";
            // 
            // ProteinsEnergyValue
            // 
            this.ProteinsEnergyValue.HeaderText = "ProteinsEnergyValue";
            this.ProteinsEnergyValue.Name = "ProteinsEnergyValue";
            // 
            // TotalEnergyValue
            // 
            this.TotalEnergyValue.HeaderText = "TotalEnergyValue";
            this.TotalEnergyValue.Name = "TotalEnergyValue";
            // 
            // TypeRecipeTimesOfDay
            // 
            this.TypeRecipeTimesOfDay.HeaderText = "TypeRecipeTimesOfDay";
            this.TypeRecipeTimesOfDay.Name = "TypeRecipeTimesOfDay";
            // 
            // Сookingtime
            // 
            this.Сookingtime.HeaderText = "Сookingtime";
            this.Сookingtime.Name = "Сookingtime";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Сookingtime,
            this.TypeRecipeTimesOfDay,
            this.TotalEnergyValue,
            this.ProteinsEnergyValue,
            this.СarbohydratesEnergyValue,
            this.FatsEnergyValue});
            this.dataGridView2.Location = new System.Drawing.Point(19, 272);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(889, 160);
            this.dataGridView2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NameProduct,
            this.AmountInGramm,
            this.AmountInPieces,
            this.Note});
            this.dataGridView1.Location = new System.Drawing.Point(29, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(594, 197);
            this.dataGridView1.TabIndex = 5;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // NameProduct
            // 
            this.NameProduct.HeaderText = "NameProduct";
            this.NameProduct.Name = "NameProduct";
            // 
            // AmountInGramm
            // 
            this.AmountInGramm.HeaderText = "AmountInGramm";
            this.AmountInGramm.Name = "AmountInGramm";
            // 
            // AmountInPieces
            // 
            this.AmountInPieces.HeaderText = "AmountInPieces";
            this.AmountInPieces.Name = "AmountInPieces";
            // 
            // Note
            // 
            this.Note.HeaderText = "Note";
            this.Note.Name = "Note";
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Сookingtime;
        private DataGridViewTextBoxColumn TypeRecipeTimesOfDay;
        private DataGridViewTextBoxColumn TotalEnergyValue;
        private DataGridViewTextBoxColumn ProteinsEnergyValue;
        private DataGridViewTextBoxColumn СarbohydratesEnergyValue;
        private DataGridViewTextBoxColumn FatsEnergyValue;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn NameProduct;
        private DataGridViewTextBoxColumn AmountInGramm;
        private DataGridViewTextBoxColumn AmountInPieces;
        private DataGridViewTextBoxColumn Note;
    }
}