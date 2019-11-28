namespace Diplom.Forms.Lookups
{
    partial class CognetiveLoadTypeLookupForm
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
            ((System.ComponentModel.ISupportInitialize)(this.LookupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RemoveButton
            // 
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // CognetiveLoadTypeLookupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 405);
            this.Name = "CognetiveLoadTypeLookupForm";
            this.Text = "Справочник видов когнетивной нагрузки";
            this.Load += new System.EventHandler(this.CognetiveLoadTypeLookupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LookupBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}