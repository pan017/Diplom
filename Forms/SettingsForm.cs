using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            FirstTestTrys.Value = Properties.Settings.Default.FirstTestTrys;
            CognitiveLoadComboBox.SelectedItem = Properties.Settings.Default.FirtsTestCognitiveLoad == true ? "Да" : "Нет"; 
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FirstTestTrys = (int)FirstTestTrys.Value;
            Properties.Settings.Default.FirtsTestCognitiveLoad = CognitiveLoadComboBox.SelectedItem.ToString() == "Да" ? true : false;
            Properties.Settings.Default.Save();
        }
    }
}
