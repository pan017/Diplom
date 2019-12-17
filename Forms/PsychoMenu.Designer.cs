namespace Diplom.Forms
{
    partial class PsychoMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TesteeButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingsMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupsMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.GenderMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.FamilyStateMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.EducationsMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ролиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыТестовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CognitiveLoadMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.тестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReactionTimeMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DistributionOfAttentionMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowDiagramButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.AlertnessTestMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TesteeButton
            // 
            this.TesteeButton.Location = new System.Drawing.Point(12, 27);
            this.TesteeButton.Name = "TesteeButton";
            this.TesteeButton.Size = new System.Drawing.Size(131, 23);
            this.TesteeButton.TabIndex = 2;
            this.TesteeButton.Text = "Испытуемые";
            this.TesteeButton.UseVisualStyleBackColor = true;
            this.TesteeButton.Click += new System.EventHandler(this.TesteeButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(756, 382);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenuStrip,
            this.справочникиToolStripMenuItem,
            this.тестыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(775, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "mainMenuStrip";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // SettingsMenuStrip
            // 
            this.SettingsMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.SettingsMenuStrip.Name = "SettingsMenuStrip";
            this.SettingsMenuStrip.Size = new System.Drawing.Size(53, 20);
            this.SettingsMenuStrip.Text = "Меню";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GroupsMenuStrip,
            this.GenderMenuStrip,
            this.FamilyStateMenuStrip,
            this.EducationsMenuStrip,
            this.ролиToolStripMenuItem,
            this.типыТестовToolStripMenuItem,
            this.CognitiveLoadMenuStrip});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // GroupsMenuStrip
            // 
            this.GroupsMenuStrip.Name = "GroupsMenuStrip";
            this.GroupsMenuStrip.Size = new System.Drawing.Size(250, 22);
            this.GroupsMenuStrip.Text = "Группы";
            this.GroupsMenuStrip.Click += new System.EventHandler(this.GroupsMenuStrip_Click);
            // 
            // GenderMenuStrip
            // 
            this.GenderMenuStrip.Name = "GenderMenuStrip";
            this.GenderMenuStrip.Size = new System.Drawing.Size(250, 22);
            this.GenderMenuStrip.Text = "Гендер";
            this.GenderMenuStrip.Click += new System.EventHandler(this.GenderMenuStrip_Click);
            // 
            // FamilyStateMenuStrip
            // 
            this.FamilyStateMenuStrip.Name = "FamilyStateMenuStrip";
            this.FamilyStateMenuStrip.Size = new System.Drawing.Size(250, 22);
            this.FamilyStateMenuStrip.Text = "Семейное положение";
            this.FamilyStateMenuStrip.Click += new System.EventHandler(this.FamilyStateMenuStrip_Click);
            // 
            // EducationsMenuStrip
            // 
            this.EducationsMenuStrip.Name = "EducationsMenuStrip";
            this.EducationsMenuStrip.Size = new System.Drawing.Size(250, 22);
            this.EducationsMenuStrip.Text = "Образование";
            this.EducationsMenuStrip.Click += new System.EventHandler(this.EducationsMenuStrip_Click);
            // 
            // ролиToolStripMenuItem
            // 
            this.ролиToolStripMenuItem.Name = "ролиToolStripMenuItem";
            this.ролиToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.ролиToolStripMenuItem.Text = "Роли";
            // 
            // типыТестовToolStripMenuItem
            // 
            this.типыТестовToolStripMenuItem.Name = "типыТестовToolStripMenuItem";
            this.типыТестовToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.типыТестовToolStripMenuItem.Text = "Типы тестов";
            this.типыТестовToolStripMenuItem.Click += new System.EventHandler(this.типыТестовToolStripMenuItem_Click);
            // 
            // CognitiveLoadMenuStrip
            // 
            this.CognitiveLoadMenuStrip.Name = "CognitiveLoadMenuStrip";
            this.CognitiveLoadMenuStrip.Size = new System.Drawing.Size(250, 22);
            this.CognitiveLoadMenuStrip.Text = "Вопросы когнитивной нагрузки";
            this.CognitiveLoadMenuStrip.Click += new System.EventHandler(this.CognitiveLoadMenuStrip_Click);
            // 
            // тестыToolStripMenuItem
            // 
            this.тестыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReactionTimeMenuStrip,
            this.DistributionOfAttentionMenuStrip,
            this.AlertnessTestMenuStrip});
            this.тестыToolStripMenuItem.Name = "тестыToolStripMenuItem";
            this.тестыToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.тестыToolStripMenuItem.Text = "Тесты";
            // 
            // ReactionTimeMenuStrip
            // 
            this.ReactionTimeMenuStrip.Name = "ReactionTimeMenuStrip";
            this.ReactionTimeMenuStrip.Size = new System.Drawing.Size(216, 22);
            this.ReactionTimeMenuStrip.Text = "Время реакции";
            this.ReactionTimeMenuStrip.Click += new System.EventHandler(this.времяРеакцииToolStripMenuItem_Click);
            // 
            // DistributionOfAttentionMenuStrip
            // 
            this.DistributionOfAttentionMenuStrip.Name = "DistributionOfAttentionMenuStrip";
            this.DistributionOfAttentionMenuStrip.Size = new System.Drawing.Size(216, 22);
            this.DistributionOfAttentionMenuStrip.Text = "Распределение внимания";
            this.DistributionOfAttentionMenuStrip.Click += new System.EventHandler(this.DistributionOfAttentionMenuStrip_Click);
            // 
            // ShowDiagramButton
            // 
            this.ShowDiagramButton.Location = new System.Drawing.Point(624, 27);
            this.ShowDiagramButton.Name = "ShowDiagramButton";
            this.ShowDiagramButton.Size = new System.Drawing.Size(144, 23);
            this.ShowDiagramButton.TabIndex = 11;
            this.ShowDiagramButton.Text = "Диаграмма";
            this.ShowDiagramButton.UseVisualStyleBackColor = true;
            this.ShowDiagramButton.Click += new System.EventHandler(this.ShowDiagramButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Общий отчет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xlsx";
            this.saveFileDialog1.Filter = "Excel files(*.xlsx)|*.xlsx|All files(*.*)|*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // AlertnessTestMenuStrip
            // 
            this.AlertnessTestMenuStrip.Name = "AlertnessTestMenuStrip";
            this.AlertnessTestMenuStrip.Size = new System.Drawing.Size(216, 22);
            this.AlertnessTestMenuStrip.Text = "Бдительность";
            this.AlertnessTestMenuStrip.Click += new System.EventHandler(this.AlertnessTestMenuStrip_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ФИО";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Группа";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Тест";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Дата начала";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Дата окончания";
            this.Column5.Name = "Column5";
            this.Column5.Width = 120;
            // 
            // PsychoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(775, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ShowDiagramButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TesteeButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PsychoMenu";
            this.Text = "Рабочее место психолога";
            this.Activated += new System.EventHandler(this.PsychoMenu_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PsychoMenu_FormClosing);
            this.Load += new System.EventHandler(this.PsychoMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button TesteeButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GroupsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem GenderMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FamilyStateMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EducationsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ролиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыТестовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CognitiveLoadMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.Button ShowDiagramButton;
        private System.Windows.Forms.ToolStripMenuItem тестыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReactionTimeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DistributionOfAttentionMenuStrip;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem AlertnessTestMenuStrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}