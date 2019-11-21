using Diplom.Model;
using Diplom.Model.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.Forms.Tests
{
    public partial class ReactionTimeForm : Form
    {
        public ReactionTimeForm()
        {
            InitializeComponent();
            TesteeComboBox.Items.AddRange(db.Profile.ToArray());
        }
        Random random = new Random(DateTime.Now.Millisecond);
        Image blackImage = Image.FromFile(@"Resourses\blackPoint.png");
        Image redImage = Image.FromFile(@"Resourses\redPoint.png");
        List<ReactionTime> reactionTimes;
        TestPack testPack;
        Profile currentTestee;
        ViewModel db = new ViewModel();
        Stopwatch SW;
        int counterMaxValue = Properties.Settings.Default.FirstTestTrys;
        int counter = 0;
        int oldCounterValue = 0;
        List<double> actionTimes = new List<double>();
        List<double> clickTimes = new List<double>();

        bool cognitiveLoad = Properties.Settings.Default.FirtsTestCognitiveLoad;
        List<CognitiveLoadLookup> cognitiveLoadLookup;
        //   List<ReactionTimes> results;
        private void DistributionOfAttentionForm_Load(object sender, EventArgs e)
        {
            //   results = new List<ReactionTimes>();
            
        }
      

        //private async void label1_Click(object sender, EventArgs e)
        //{
        //    await Task.Run(() =>
        //    {
        //        //Stopwatch SW = new Stopwatch(); // Создаем объект
        //         // Запускаем


        //        for (; counter < 5; counter++)
        //        {
        //            label2.Invoke(new Action(() => label2.Text = (counterMaxValue - counter).ToString()));
        //            //label2.Text = (counterMaxValue - counter).ToString();
        //            Thread.Sleep(new Random().Next(1000, 5000));
        //            actionTimes.Add(SW.Elapsed.TotalMilliseconds);
        //            label1.ForeColor = System.Drawing.Color.FromArgb(new Random().Next(1, 255), new Random().Next(1, 255), new Random().Next(1, 255));

        //        }
        //        SW.Stop(); //Останавливаемхз
        //    });
        //}

        private async void DistributionOfAttentionForm_KeyDown(object sender, KeyEventArgs e)
        {
            await Task.Run(() =>
            {
                if (e.KeyCode == Keys.Space)
                {
                   
                    //if (reactionTimes.Count < counter)
                    //{
                        clickTimes.Add(SW.Elapsed.TotalMilliseconds);
                        TestResults testResults = new TestResults();
                        if (actionTimes.Count == 0)
                        reactionTimes.Add(new ReactionTime { BeginReactionTime = 0, EndReactionTime = (decimal)SW.Elapsed.TotalMilliseconds });
                        else
                    reactionTimes.Add(new ReactionTime { BeginReactionTime = (decimal)actionTimes.Last(), EndReactionTime = (decimal)SW.Elapsed.TotalMilliseconds });
                        //label2.Invoke(new Action(() => label2.Text = SW.Elapsed.TotalMilliseconds.ToString()));
                   // }
                    
                }
            });
        }

        private async void BeginTestButton_Click(object sender, EventArgs e)
        {
            cognitiveLoadLookup = db.CognitiveLoad.ToList();
            testPack = new TestPack();
            reactionTimes = new List<ReactionTime>();
            if (TesteeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Не выбран испытуемый", "Ошибка");
                return;
            }
            testPack.Profile = db.Profile.FirstOrDefault(x => x.id == ((Profile)TesteeComboBox.SelectedItem).id);
            MessageBox.Show("Нажимайте \"Пробел\" каждый раз, когда изменится цвет круга", "Инструкция");
            testPack.BeginTestDate = DateTime.Now;
            beginTest();
            SW = new Stopwatch();
            SW.Start();
            if (cognitiveLoad)
            {
                cognitiveLoadWorker.DoWork += cognitiveLoadWorker_DoWork;
                cognitiveLoadWorker.RunWorkerAsync();
            }
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerAsync();

        }
         void runTest()
        {

            for (; counter < counterMaxValue; counter++, oldCounterValue++)
            {
                label2.Invoke(new Action(() => label2.Text = "Осталось попыток:" + (counterMaxValue - counter).ToString()));
                Thread.Sleep(random.Next(2000, 5000));
                actionTimes.Add(SW.Elapsed.TotalMilliseconds);
                pictureBox1.Invoke(new Action(() => pictureBox1.Image = blackImage));
                Thread.Sleep(500);
                pictureBox1.Invoke(new Action(() => pictureBox1.Image = redImage));
                
            }
            Thread.Sleep(2000);
            testPack.EndTestDate = DateTime.Now;
            testPack.CognetiveLoad = cognitiveLoad;

                SW.Stop(); //Останавливаемхз

                db.TestPack.Add(testPack);
                db.SaveChanges();
                db.TestResult.Add(new TestResults { TestPack = testPack, ReactionTimes = reactionTimes });
                db.SaveChanges();

            label1.Invoke(new Action(() => label1.Visible = false ));
            label2.Invoke(new Action(() => label2.Visible = false));
            label3.Invoke(new Action(() => label3.Visible = false));
            pictureBox1.Invoke(new Action(() => pictureBox1.Visible = false));
            endTestButton.Invoke(new Action(() => endTestButton.Visible = true));

        }
        void beginTest()
        {
            BeginTestButton.Visible = false;
            TesteeComboBox.Visible = false;
            TesteeLabel.Visible = false;
            settingsButton.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            pictureBox1.Visible = true;
            this.Focus();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            runTest();
        }

        void showCognitiveLoad()
        {
            while (counter < counterMaxValue)
            {
                label3.Invoke(new Action(() => label3.Text = cognitiveLoadLookup[random.Next(0, cognitiveLoadLookup.Count)].Name));
                Thread.Sleep(random.Next(2000, 3000));
            }
        }

        private void cognitiveLoadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            showCognitiveLoad();
        }

        private void endTestButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void DistributionOfAttentionForm_Activated(object sender, EventArgs e)
        {
            counterMaxValue = Properties.Settings.Default.FirstTestTrys;
        }
    }
}
