namespace Diplom.Forms.Tests
{
    partial class BaseTestForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BeginTestButton = new System.Windows.Forms.Button();
            this.TesteeLabel = new System.Windows.Forms.Label();
            this.TesteeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.endTestButton = new System.Windows.Forms.Button();
            this.cognitiveLoadWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // BeginTestButton
            // 
            this.BeginTestButton.Location = new System.Drawing.Point(349, 239);
            this.BeginTestButton.Name = "BeginTestButton";
            this.BeginTestButton.Size = new System.Drawing.Size(127, 23);
            this.BeginTestButton.TabIndex = 24;
            this.BeginTestButton.Text = "Начать тест";
            this.BeginTestButton.UseVisualStyleBackColor = true;
            this.BeginTestButton.Click += new System.EventHandler(this.BeginTestButton_Click);
            // 
            // TesteeLabel
            // 
            this.TesteeLabel.AutoSize = true;
            this.TesteeLabel.Location = new System.Drawing.Point(307, 171);
            this.TesteeLabel.Name = "TesteeLabel";
            this.TesteeLabel.Size = new System.Drawing.Size(73, 13);
            this.TesteeLabel.TabIndex = 23;
            this.TesteeLabel.Text = "Испытуемый";
            // 
            // TesteeComboBox
            // 
            this.TesteeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TesteeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TesteeComboBox.FormattingEnabled = true;
            this.TesteeComboBox.Location = new System.Drawing.Point(307, 187);
            this.TesteeComboBox.Name = "TesteeComboBox";
            this.TesteeComboBox.Size = new System.Drawing.Size(208, 21);
            this.TesteeComboBox.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(69, 411);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(697, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Нажимайте \"Пробел\" каждый раз, когда цвет всех фигур будет одинаковый";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(257, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 24);
            this.label3.TabIndex = 25;
            // 
            // endTestButton
            // 
            this.endTestButton.Location = new System.Drawing.Point(349, 239);
            this.endTestButton.Name = "endTestButton";
            this.endTestButton.Size = new System.Drawing.Size(127, 23);
            this.endTestButton.TabIndex = 26;
            this.endTestButton.Text = "Закончить тест";
            this.endTestButton.UseVisualStyleBackColor = true;
            this.endTestButton.Visible = false;
            this.endTestButton.Click += new System.EventHandler(this.endTestButton_Click);
            // 
            // cognitiveLoadWorker
            // 
            this.cognitiveLoadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.cognitiveLoadWorker_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // BaseTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BeginTestButton);
            this.Controls.Add(this.TesteeLabel);
            this.Controls.Add(this.TesteeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endTestButton);
            this.Name = "BaseTestForm";
            this.Text = "BaseTestForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseTestForm_FormClosing);
            this.Load += new System.EventHandler(this.BaseTestForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseTestForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button BeginTestButton;
        private System.Windows.Forms.Label TesteeLabel;
        private System.Windows.Forms.ComboBox TesteeComboBox;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button endTestButton;
        private System.ComponentModel.BackgroundWorker cognitiveLoadWorker;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}