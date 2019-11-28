namespace Diplom.Forms.Tests
{
    partial class DistributionOfAttention
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributionOfAttention));
            this.BeginTestButton = new System.Windows.Forms.Button();
            this.TesteeLabel = new System.Windows.Forms.Label();
            this.TesteeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.cognitiveLoadWorker = new System.ComponentModel.BackgroundWorker();
            this.settingsButton = new System.Windows.Forms.Button();
            this.endTestButton = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // BeginTestButton
            // 
            this.BeginTestButton.Location = new System.Drawing.Point(314, 224);
            this.BeginTestButton.Name = "BeginTestButton";
            this.BeginTestButton.Size = new System.Drawing.Size(127, 23);
            this.BeginTestButton.TabIndex = 14;
            this.BeginTestButton.Text = "Начать тест";
            this.BeginTestButton.UseVisualStyleBackColor = true;
            this.BeginTestButton.Click += new System.EventHandler(this.BeginTestButton_Click);
            // 
            // TesteeLabel
            // 
            this.TesteeLabel.AutoSize = true;
            this.TesteeLabel.Location = new System.Drawing.Point(283, 163);
            this.TesteeLabel.Name = "TesteeLabel";
            this.TesteeLabel.Size = new System.Drawing.Size(73, 13);
            this.TesteeLabel.TabIndex = 13;
            this.TesteeLabel.Text = "Испытуемый";
            // 
            // TesteeComboBox
            // 
            this.TesteeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TesteeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TesteeComboBox.FormattingEnabled = true;
            this.TesteeComboBox.Location = new System.Drawing.Point(286, 179);
            this.TesteeComboBox.Name = "TesteeComboBox";
            this.TesteeComboBox.Size = new System.Drawing.Size(208, 21);
            this.TesteeComboBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Осталось попыток: 25";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(100, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(573, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Нажимайте \"Пробел\" каждый раз, когда изменится цвет круга";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(177, 224);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(23, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 24);
            this.label3.TabIndex = 15;
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(316, 272);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(127, 23);
            this.settingsButton.TabIndex = 17;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.UseVisualStyleBackColor = true;
            // 
            // endTestButton
            // 
            this.endTestButton.Location = new System.Drawing.Point(316, 224);
            this.endTestButton.Name = "endTestButton";
            this.endTestButton.Size = new System.Drawing.Size(127, 23);
            this.endTestButton.TabIndex = 16;
            this.endTestButton.Text = "Закончить тест";
            this.endTestButton.UseVisualStyleBackColor = true;
            this.endTestButton.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(485, 224);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // DistributionOfAttention
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.BeginTestButton);
            this.Controls.Add(this.TesteeLabel);
            this.Controls.Add(this.TesteeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.endTestButton);
            this.Name = "DistributionOfAttention";
            this.Text = "DistributionOfAttention";
            this.Load += new System.EventHandler(this.DistributionOfAttention_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DistributionOfAttention_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BeginTestButton;
        private System.Windows.Forms.Label TesteeLabel;
        private System.Windows.Forms.ComboBox TesteeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker cognitiveLoadWorker;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button endTestButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}