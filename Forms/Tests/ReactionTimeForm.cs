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

        ViewModel db = new ViewModel();
        Stopwatch SW;
        int counterMaxValue = Properties.Settings.Default.TestTime;
        int counter = 0;

        int currentTestIndex = 0;
        List<double> actionTimes = new List<double>();
        List<double> clickTimes = new List<double>();
        bool isRunning;
        
        List<CognitiveLoad> cognitiveLoadLookup;

        private void DistributionOfAttentionForm_Load(object sender, EventArgs e)
        {
            cognitiveLoadLookup = db.CognitiveLoad.ToList();
            testPack = new TestPack();
            isRunning = false;
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
                    {
                        bool isTrue = reactionTimes.Count == 0 ? false : reactionTimes[reactionTimes.Count-1].BeginReactionTime == (decimal)actionTimes.Last();
                        reactionTimes.Add(new ReactionTime { BeginReactionTime = (decimal)actionTimes.Last(), EndReactionTime = (decimal)SW.Elapsed.TotalMilliseconds, isTrue = !isTrue});
                    }
                }
            });
        }

        private void BeginTestButton_Click(object sender, EventArgs e)
        {
            if (TesteeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Не выбран испытуемый", "Ошибка");
                return;
            }
            testPack.TestType = db.TestType.FirstOrDefault(x => x.TestTypeIndex == 1);          
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
            MessageBox.Show("Нажимайте \"Пробел\" каждый раз, когда круг станет черного цвета", "Инструкция");
            SW = new Stopwatch();
            SW.Start();
        }
        void runTest(int index)
        {
            counter = 0;
            reactionTimes = new List<ReactionTime>();
            endTestButton.Visible = false;
            this.Focus();
            //backgroundWorker1.CancelAsync();
            switch (index)
            {
                case 0:
                    showInstruction();
                    isRunning = true;
                    backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                    backgroundWorker1.WorkerSupportsCancellation = true;
                    backgroundWorker1.RunWorkerAsync(); break;
                case 1:
                    label3.Visible = true;
                    showInstruction();
                    isRunning = true;
                    cognitiveLoadWorker.DoWork += cognitiveLoadWorker_DoWork;
                    cognitiveLoadWorker.WorkerSupportsCancellation = true;
                    cognitiveLoadWorker.RunWorkerAsync();
                    backgroundWorker2.DoWork += backgroundWorker2_DoWork;
                    backgroundWorker2.WorkerSupportsCancellation = true;
                    backgroundWorker2.RunWorkerAsync(); break;
                default:
                    this.Dispose();
                    this.Close(); break;
            }         
        }
        void runSecondTest()
        {
            counter = 0;
            while(SW.ElapsedMilliseconds < Properties.Settings.Default.TestTime * 1000)
            {
                // label2.Invoke(new Action(() => label2.Text = "Осталось попыток:" + (counterMaxValue - counter).ToString()));
                
                Thread.Sleep(random.Next(2000, 5000));
                actionTimes.Add(SW.Elapsed.TotalMilliseconds);
                pictureBox1.Invoke(new Action(() => pictureBox1.Image = blackImage));
                Thread.Sleep(500);
                pictureBox1.Invoke(new Action(() => pictureBox1.Image = redImage));
                counter++;
            }

            //for (counter = 0; counter < counterMaxValue; counter++, oldCounterValue++)
            //{
            //    label2.Invoke(new Action(() => label2.Text = "Осталось попыток:" + (counterMaxValue - counter).ToString()));
            //    Thread.Sleep(random.Next(2000, 5000));
            //    actionTimes.Add(SW.Elapsed.TotalMilliseconds);
            //    pictureBox1.Invoke(new Action(() => pictureBox1.Image = blackImage));
            //    Thread.Sleep(500);
            //    pictureBox1.Invoke(new Action(() => pictureBox1.Image = redImage));

            //}
            Thread.Sleep(2000);
            SW.Stop();
            testPack.EndTestDate = DateTime.Now;
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
            backgroundWorker2.CancelAsync();
            cognitiveLoadWorker.CancelAsync();
        }
         void runFirtsTest()
        {
            counter = 0;
            while (SW.ElapsedMilliseconds < Properties.Settings.Default.TestTime * 1000)
            {
                // label2.Invoke(new Action(() => label2.Text = "Осталось попыток:" + (counterMaxValue - counter).ToString()));

                Thread.Sleep(random.Next(2000, 5000));
                actionTimes.Add(SW.Elapsed.TotalMilliseconds);
                pictureBox1.Invoke(new Action(() => pictureBox1.Image = blackImage));
                Thread.Sleep(500);
                pictureBox1.Invoke(new Action(() => pictureBox1.Image = redImage));
                counter++;
            }
            Thread.Sleep(2000);
            SW.Stop(); //Останавливаемхз
            testPack.EndTestDate = DateTime.Now;
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
            backgroundWorker1.CancelAsync();
        }
        void showTestControls()
        {
            BeginTestButton.Visible = false;
            TesteeComboBox.Visible = false;
            TesteeLabel.Visible = false;
          //  settingsButton.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label2.Text = "Осталось попыток:" + counterMaxValue.ToString();
            pictureBox1.Visible = true;
            this.Focus();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                isRunning = false;
                return;
            }
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
            if (this.cognitiveLoadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
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
            counterMaxValue = Properties.Settings.Default.TestTime;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.backgroundWorker2.CancellationPending)
            {
                e.Cancel = true;
                isRunning = false;
                return;
            }
            runSecondTest();
        }

        private void ReactionTimeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRunning && db.TestResult.Where(x => x.TestPack.id == testPack.id).Count() == 0)
            {
                db.TestPack.Remove(testPack);
                db.SaveChanges();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
