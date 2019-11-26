using Diplom.Forms;
using Diplom.Forms.Tests;
using Diplom.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
            Service.DBInit.init();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewModel db = new ViewModel();
            var a = db.CognetiveLoadType.ToList();
            InputBox inputBox = new InputBox();

            inputBox.addComboBox(a);
            inputBox.addComboBox(a);
            inputBox.addComboBox(a);
            if (inputBox.getString() == "12345")
            {
                this.Hide();
                PsychoMenu distributionOfAttentionForm = new PsychoMenu();
                distributionOfAttentionForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReactionTimeForm distributionOfAttentionForm = new ReactionTimeForm();
            distributionOfAttentionForm.ShowDialog();
        }
    }
}
