using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Diplom.Forms
{
    public class InputBox : Form
    {
        TextBox textBox;
        protected Button buttonOK;
        protected Button buttonCancel;
        Control lastControl;


        public void AddControl(Control control)
        {
            buttonOK.Location = new Point(105, buttonOK.Location.Y + 35);
            buttonCancel.Location = new Point(190, buttonCancel.Location.Y + 35);
            control.Location = new Point(lastControl.Location.X, lastControl.Location.Y + 25);
            lastControl = control;
            this.Controls.Add(control);
        }
        public void addComboBox(object items, string caption = "Выберите тип: ") 
        {
            buttonOK.Location = new Point(105, buttonOK.Location.Y + 50);
            buttonCancel.Location = new Point(190, buttonCancel.Location.Y + 50);

            Label label2 = new Label();
            label2.AutoSize = false;
            label2.Size = new Size(250, 25);
            label2.Font = new Font(label2.Font, FontStyle.Regular);
            label2.Location = new Point(20, lastControl.Location.Y + 25);// new Point(20, 75);
            label2.Text = caption;
            lastControl = label2;
            this.Controls.Add(label2);

            ComboBox cb = new ComboBox();
            cb.Size = new Size(150, 25);
            cb.Location = new Point(20, lastControl.Location.Y + 25);//new Point(20, 100);
            cb.DataSource = items;
            this.Controls.Add(cb);


          
            this.Controls.Add(label2);
            lastControl = cb;
            this.Size = new Size(this.Size.Width, this.Size.Height + 50);
        }
        

        public InputBox()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Size = new Size(300, 150);
            this.Text = "Ввод значения";

            /* Создаем текстовое поле. -> */

            textBox = new TextBox();
            textBox.Size = new Size(250, 25);
            textBox.Font = new Font(TextBox.DefaultFont, FontStyle.Regular);
            textBox.Location = new Point(20, 50);
            textBox.Text = "";

            lastControl = textBox;
            this.Controls.Add(textBox);

            textBox.Show();

            textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);

            /* Создаем текстовое поле. <- */

            /* Создаем метку. -> */

            Label label = new Label();
            label.AutoSize = false;
            label.Size = new Size(250, 25);
            label.Font = new Font(label.Font, FontStyle.Regular);
            label.Location = new Point(20, 25);
            label.Text = "Введите название: ";

            this.Controls.Add(label);

            label.Show();

            /* Создаем метку. <- */

            /* Создаем кнопку "OK". -> */

            buttonOK = new Button();
            buttonOK.Size = new Size(80, 25);
            buttonOK.Location = new Point(105, 75);
            buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonOK.Text = "OK";

            this.Controls.Add(buttonOK);

            buttonOK.Show();

            /* Создаем кнопку "OK". <- */

            /* Создаем кнопку "Cancel". -> */

            buttonCancel = new Button();
            buttonCancel.Size = new Size(80, 25);
            buttonCancel.Location = new Point(190, 75);
            buttonCancel.Text = "Cancel";

            this.Controls.Add(buttonCancel);

            buttonCancel.Show();

            buttonCancel.Click += new EventHandler(buttonCancel_Click);
            
            /* Создаем кнопку "OK". <- */
        }

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
        }

        public void buttonCancel_Click(object sander, EventArgs e)
        {
            this.Close();
        }

        public string getString()
        {
            if (this.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return null;

            return textBox.Text;
        }
        public string getString(string inputString)
        {
            textBox.Text = inputString;
            if (this.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return null;

            return textBox.Text;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // InputBox
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "InputBox";
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.ResumeLayout(false);

        }

        private void InputBox_Load(object sender, EventArgs e)
        {

        }
    }
}
