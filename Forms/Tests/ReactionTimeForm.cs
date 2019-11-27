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
            random = new Random(DateTime.Now.Millisecond);
        }

        Random random;
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
        int currentTestIndex = 0;
        List<double> actionTimes = new List<double>();
        List<double> clickTimes = new List<double>();

        bool cognitiveLoad = Properties.Settings.Default.FirtsTestCognitiveLoad;
        List<CognitiveLoad> cognitiveLoadLookup;
        //   List<ReactionTimes> results;
        private void DistributionOfAttentionForm_Load(object sender, EventArgs e)
        {
            //   results = new List<ReactionTimes>();
            cognitiveLoadLookup = db.CognitiveLoad.ToList();
            testPack = new TestPack();
        }
      
        private async void DistributionOfAttentionForm_KeyDown(object sender, KeyEventArgs e)
        {
            await Task.Run(() =>
            {
                if (e.KeyCode == Keys.Space)
                {
                    clickTimes.Add(SW.Elapsed.TotalMilliseconds);
                    TestResults testResults = new TestResults();
                    if (actionTimes.Count == 0)
                        reactionTimes.Add(new ReactionTime { BeginReactionTime = 0, EndReactionTime = (decimal)SW.Elapsed.TotalMilliseconds });
                    else
                        reactionTimes.Add(new ReactionTime { BeginReactionTime = (decimal)actionTimes.Last(), EndReactionTime = (decimal)SW.Elapsed.TotalMilliseconds });

                }
            });
        }

        private async void BeginTestButton_Click(object sender, EventArgs e)
        {
            if (TesteeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Не выбран испытуемый", "Ошибка");
                return;
            }
            testPack.TestType = db.TestType.FirstOrDefault(x => x.TestTypeIndex == 0);          
            testPack.Profile = db.Profile.FirstOrDefault(x => x.id == ((Profile)TesteeComboBox.SelectedItem).id);
            testPack.BeginTestDate = DateTime.Now;
            testPack.EndTestDate = new DateTime(1900, 1, 1);
            db.TestPack.Add(testPack);
            db.SaveChanges();

            
            runTest(0);

        }
        void showInstruction()
        {
            showTestControls();
            reactionTimes = new List<ReactionTime>();
            MessageBox.Show("Нажимайте \"Пробел\" каждый раз, когда изменится цвет круга", "Инструкция");

            SW = new Stopwatch();
            SW.Start();
        }
        void runTest(int index)
        {
            counter = 0;
            endTestButton.Visible = false;
            this.Focus();
            switch (index)
            {
                case 0:
                    showInstruction();
                    backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                    backgroundWorker1.RunWorkerAsync(); break;
                case 1:
                    label3.Visible = true;
                    showInstruction();
                    cognitiveLoadWorker.DoWork += cognitiveLoadWorker_DoWork;
                    cognitiveLoadWorker.RunWorkerAsync();
                    backgroundWorker2.DoWork += backgroundWorker2_DoWork;
                    backgroundWorker2.RunWorkerAsync(); break;
                default:
                    this.Dispose();
                    this.Close(); break;
            }


            //if (cognitiveLoad)
            //{
            //    cognitiveLoadWorker.DoWork += cognitiveLoadWorker_DoWork;
            //    cognitiveLoadWorker.RunWorkerAsync();
            //}
            //backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            //backgroundWorker1.RunWorkerAsync();
            
        }
        void runSecondTest()
        {
            counter = 0;
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
            SW.Stop(); 
            db.TestResult.Add(new TestResults
            {
                TestPack = testPack,
                ReactionTimes = reactionTimes,
                TestStage = db.TestStage.FirstOrDefault(x => x.TestStageIndex == 1),
                EndTestDate = DateTime.Now,
                BeginTestDate = testPack.BeginTestDate
            });
            db.SaveChanges();

            label1.Invoke(new Action(() => label1.Visible = false));
            label2.Invoke(new Action(() => label2.Visible = false));
            label3.Invoke(new Action(() => label3.Visible = false));
            pictureBox1.Invoke(new Action(() => pictureBox1.Visible = false));
            endTestButton.Invoke(new Action(() => endTestButton.Visible = true));
        }
         void runFirtsTest()
        {
            counter = 0;
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
            SW.Stop(); //Останавливаемхз
            db.TestResult.Add(new TestResults {
                TestPack = testPack,
                ReactionTimes = reactionTimes,
                TestStage = db.TestStage.FirstOrDefault(x => x.TestStageIndex == 0),
                EndTestDate = DateTime.Now,
                BeginTestDate = testPack.BeginTestDate
            });
            db.SaveChanges();

            label1.Invoke(new Action(() => label1.Visible = false ));
            label2.Invoke(new Action(() => label2.Visible = false));
          //  label3.Invoke(new Action(() => label3.Visible = false));
            pictureBox1.Invoke(new Action(() => pictureBox1.Visible = false));
            endTestButton.Invoke(new Action(() => endTestButton.Visible = true));

        }
        void showTestControls()
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
            runFirtsTest();
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
            showTestControls();
            
            currentTestIndex += 1;
            SW = new Stopwatch();
            reactionTimes = new List<ReactionTime>();
            //MessageBox.Show("Нажимайте \"Пробел\" каждый раз, когда изменится цвет круга", "Инструкция");
            runTest(currentTestIndex);
       //     this.Close();
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

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            runSecondTest();
        }
    }
}
