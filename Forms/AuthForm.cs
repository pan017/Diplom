using Diplom.Forms;
using Diplom.Forms.Tests;
using Diplom.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            ViewModel db = new ViewModel();
         //   db.Group.Add(new Model.Lookups.Group { Name = "680961" });
          //  db.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox();
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
