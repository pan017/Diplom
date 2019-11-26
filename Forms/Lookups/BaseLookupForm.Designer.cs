namespace Diplom.Forms.Lookups
{
    partial class BaseLookupForm
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
            this.components = new System.ComponentModel.Container();
            this.LookupDataGridView = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.LookupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LookupDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LookupDataGridView
            // 
            this.LookupDataGridView.AllowUserToAddRows = false;
            this.LookupDataGridView.AllowUserToDeleteRows = false;
            this.LookupDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LookupDataGridView.Location = new System.Drawing.Point(12, 12);
            this.LookupDataGridView.Name = "LookupDataGridView";
            this.LookupDataGridView.Size = new System.Drawing.Size(321, 350);
            this.LookupDataGridView.TabIndex = 1;
            this.LookupDataGridView.DataSourceChanged += new System.EventHandler(this.LookupDataGridView_DataSourceChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 369);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
          //  this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(93, 368);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(174, 368);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 4;
            this.RemoveButton.Text = "Удалить";
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // BaseLookupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 404);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.LookupDataGridView);
            this.Name = "BaseLookupForm";
            this.Text = "BaseLookupForm";
            this.Load += new System.EventHandler(this.BaseLookupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LookupDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookupBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.DataGridView LookupDataGridView;
        protected System.Windows.Forms.BindingSource LookupBindingSource;
        protected System.Windows.Forms.Button AddButton;
        protected System.Windows.Forms.Button EditButton;
        protected System.Windows.Forms.Button RemoveButton;
    }
}