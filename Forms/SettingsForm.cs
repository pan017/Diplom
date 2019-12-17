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
            FirstTestTrys.Value = Properties.Settings.Default.TestTime;
       //     CognitiveLoadComboBox.SelectedItem = Properties.Settings.Default.FirtsTestCognitiveLoad == true ? "Да" : "Нет"; 
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if ((int)FirstTestTrys.Value == 0 || FirstTestTrys.Value == null)
            {
                MessageBox.Show("Время теста не может быть равным 0!", "Ошибка!");
                return;
                
            }
            Properties.Settings.Default.TestTime = (int)FirstTestTrys.Value;
          //  Properties.Settings.Default.FirtsTestCognitiveLoad = CognitiveLoadComboBox.SelectedItem.ToString() == "Да" ? true : false;
            Properties.Settings.Default.Save();
            MessageBox.Show("Настройки успешно сохранены", "Сохранено");
        }
    }
}
