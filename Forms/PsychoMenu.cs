using Diplom.Forms.Lookups;
using Diplom.Forms.Tests;
using Diplom.Model;
using Diplom.Service;
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
    public partial class PsychoMenu : Form
    {
        public PsychoMenu()
        {
            InitializeComponent();
        }
        void loadData()
        {
            dataGridView1.Rows.Clear();
            var list = db.TestPack.OrderBy(x => x.CreatonDate).ToList();
            foreach (var item in list)
            {
                dataGridView1.Rows.Add(
                    item.id,
                    item.Profile.ToString(),
                    item.Profile.Group,
                    "",
                    item.BeginTestDate.ToString(),
                    item.EndTestDate.ToString());
            }
        }
        ViewModel db = new ViewModel();
        private void PsychoMenu_Load(object sender, EventArgs e)
        {

            loadData();
            // var value = System.Configuration.ConfigurationManager.AppSettings["key"];
            //  System.Configuration.ConfigurationManager.AppSettings["key"] = "asdasd";

            // var a = Properties.Settings.Default.FirstTestTrys;
            //Properties.Settings.Default.FirstTestTrys = 15;
            // Properties.Settings.Default.Save();

            //    db.Profile.Add(new Model.Profile { BrithDate = DateTime.Now, Education = "B3F205A2-EF04-48AE-A9A8-6DAC1368DB85" });
            //   db.Education.Add(new Model.Lookups.Education { Name = "Среднее" });
            //  db.SaveChanges();
        }

        private void TesteeButton_Click(object sender, EventArgs e)
        {
            TesteeForm testeeForm = new TesteeForm();
            testeeForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReactionTimeForm distributionOfAttentionForm = new ReactionTimeForm();
             distributionOfAttentionForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void GroupsButton_Click(object sender, EventArgs e)
        {
            GroupsForm lookupsForm = new GroupsForm();
            lookupsForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TesteeEditForm testeeEditForm = new TesteeEditForm();
            testeeEditForm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void GroupsMenuStrip_Click(object sender, EventArgs e)
        {
            GroupsLookupForm groupsLookupForm = new GroupsLookupForm();
            groupsLookupForm.ShowDialog();
        }

        private void EducationsMenuStrip_Click(object sender, EventArgs e)
        {
            EducationLookupForm educationLookupForm = new EducationLookupForm();
            educationLookupForm.ShowDialog();
        }

        private void FamilyStateMenuStrip_Click(object sender, EventArgs e)
        {
            FamilyStateLookupForm familyStateLookupForm = new FamilyStateLookupForm();
            familyStateLookupForm.ShowDialog();
        }

        private void GenderMenuStrip_Click(object sender, EventArgs e)
        {
            GenderLookupForm genderLookupForm = new GenderLookupForm();
            genderLookupForm.ShowDialog();
        }

        private void CognitiveLoadMenuStrip_Click(object sender, EventArgs e)
        {
            CognitiveLoadLookupForm cognitiveLoadLookupForm = new CognitiveLoadLookupForm();
            cognitiveLoadLookupForm.ShowDialog();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void PsychoMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void PsychoMenu_Activated(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var a = (Guid)dataGridView1.Rows[0].Cells[0].Value;
            var selectedTestPack = db.TestPack.FirstOrDefault(x => x.id == a);
            var testResults = db.TestResult.Where(x => x.TestPack.id == selectedTestPack.id).ToList();
            ResultsChartForm resultsChartForm = new ResultsChartForm(testResults);
            resultsChartForm.ShowDialog();

        }

        private void ShowDiagramButton_Click(object sender, EventArgs e)
        {
            var a = (Guid)dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value;
            var selectedTestPack = db.TestPack.FirstOrDefault(x => x.id == a);
            var testResults = db.TestResult.Where(x => x.TestPack.id == selectedTestPack.id).ToList();
            ResultsChartForm resultsChartForm = new ResultsChartForm(testResults);
            resultsChartForm.ShowDialog();
        }
    }
}
