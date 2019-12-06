using Diplom.Forms;
using Diplom.Forms.Tests;
using Diplom.Model;
using Diplom.Model.Views;
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
           //
                this.Hide();
                PsychoMenu distributionOfAttentionForm = new PsychoMenu();
                distributionOfAttentionForm.ShowDialog();
          //  }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReactionTimeForm distributionOfAttentionForm = new ReactionTimeForm();
            distributionOfAttentionForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DistributionOfAttention distributionOfAttention = new DistributionOfAttention();
            distributionOfAttention.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AlertnessTestForm alertnessTestForm = new AlertnessTestForm();
            alertnessTestForm.ShowDialog();
        }
    }
}
