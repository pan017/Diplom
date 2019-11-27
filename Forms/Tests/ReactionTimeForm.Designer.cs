namespace Diplom.Forms.Tests
{
    partial class ReactionTimeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReactionTimeForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TesteeComboBox = new System.Windows.Forms.ComboBox();
            this.TesteeLabel = new System.Windows.Forms.Label();
            this.BeginTestButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.cognitiveLoadWorker = new System.ComponentModel.BackgroundWorker();
            this.endTestButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(342, 157);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(99, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(573, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Нажимайте \"Пробел\" каждый раз, когда изменится цвет круга";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Осталось попыток: 25";
            this.label2.Visible = false;
            // 
            // TesteeComboBox
            // 
            this.TesteeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TesteeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TesteeComboBox.FormattingEnabled = true;
            this.TesteeComboBox.Location = new System.Drawing.Point(285, 180);
            this.TesteeComboBox.Name = "TesteeComboBox";
            this.TesteeComboBox.Size = new System.Drawing.Size(208, 21);
            this.TesteeComboBox.TabIndex = 3;
            // 
            // TesteeLabel
            // 
            this.TesteeLabel.AutoSize = true;
            this.TesteeLabel.Location = new System.Drawing.Point(282, 164);
            this.TesteeLabel.Name = "TesteeLabel";
            this.TesteeLabel.Size = new System.Drawing.Size(73, 13);
            this.TesteeLabel.TabIndex = 4;
            this.TesteeLabel.Text = "Испытуемый";
            // 
            // BeginTestButton
            // 
            this.BeginTestButton.Location = new System.Drawing.Point(313, 225);
            this.BeginTestButton.Name = "BeginTestButton";
            this.BeginTestButton.Size = new System.Drawing.Size(127, 23);
            this.BeginTestButton.TabIndex = 5;
            this.BeginTestButton.Text = "Начать тест";
            this.BeginTestButton.UseVisualStyleBackColor = true;
            this.BeginTestButton.Click += new System.EventHandler(this.BeginTestButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(22, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 24);
            this.label3.TabIndex = 6;
            // 
            // cognitiveLoadWorker
            // 
            this.cognitiveLoadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.cognitiveLoadWorker_DoWork);
            // 
            // endTestButton
            // 
            this.endTestButton.Location = new System.Drawing.Point(315, 225);
            this.endTestButton.Name = "endTestButton";
            this.endTestButton.Size = new System.Drawing.Size(127, 23);
            this.endTestButton.TabIndex = 7;
            this.endTestButton.Text = "Закончить тест";
            this.endTestButton.UseVisualStyleBackColor = true;
            this.endTestButton.Visible = false;
            this.endTestButton.Click += new System.EventHandler(this.endTestButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(315, 273);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(127, 23);
            this.settingsButton.TabIndex = 8;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // ReactionTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.endTestButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BeginTestButton);
            this.Controls.Add(this.TesteeLabel);
            this.Controls.Add(this.TesteeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ReactionTimeForm";
            this.Text = "Распределение внимания";
            this.Activated += new System.EventHandler(this.DistributionOfAttentionForm_Activated);
            this.Load += new System.EventHandler(this.DistributionOfAttentionForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DistributionOfAttentionForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TesteeComboBox;
        private System.Windows.Forms.Label TesteeLabel;
        private System.Windows.Forms.Button BeginTestButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker cognitiveLoadWorker;
        private System.Windows.Forms.Button endTestButton;
        private System.Windows.Forms.Button settingsButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}