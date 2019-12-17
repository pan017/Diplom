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
    public partial class BaseTestForm : Form
    {
        List<ReactionTime> reactionTimes;
        TestPack testPack;
        ViewModel db;
        protected Stopwatch SW;
        int counterMaxValue = Properties.Settings.Default.TestTime;
        public int counter = 0;
        int currentTestIndex = 0;
       
        List<double> actionTimes = new List<double>();
        List<double> clickTimes = new List<double>();
        bool isRunning;       
        List<CognitiveLoad> cognitiveLoadLookup;
        protected Random random;

        public string instruction = "";
        public int testTypeIndex;
        public virtual void hidePictures()
        {

        }
        public virtual void action()
        {

        }
        public virtual void showTestControls()
        {

        }
        public virtual void endTestButton_Click(object sender, EventArgs e)
        {
            showBaseControls();
            currentTestIndex += 1;
            SW = new Stopwatch();
            runTest(currentTestIndex);
        }
        public virtual async void BaseTestForm_KeyDown(object sender, KeyEventArgs e)
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
                        bool isTrue = reactionTimes.Count == 0 ? false : reactionTimes[reactionTimes.Count - 1].BeginReactionTime == (decimal)actionTimes.Last();
                        reactionTimes.Add(new ReactionTime { BeginReactionTime = (decimal)actionTimes.Last(), EndReactionTime = (decimal)SW.Elapsed.TotalMilliseconds, isTrue = !isTrue });
                    }
                }
            });
        }
        public virtual void runTest(int index)
        {
            endTestButton.Visible = false;
            this.Focus();
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
        public void addActionTime()
        {
            actionTimes.Add(SW.Elapsed.TotalMilliseconds);
        }
        public BaseTestForm()
        {
            
            InitializeComponent();
            db = new ViewModel();
            cognitiveLoadLookup = db.CognitiveLoad.ToList();
            testPack = new TestPack();
            isRunning = false;
            random = new Random(DateTime.Now.Millisecond);
            reactionTimes = new List<ReactionTime>();
            TesteeComboBox.Items.AddRange(db.Profile.OrderBy(x => x.Name).ToArray());
        }

        private void BaseTestForm_Load(object sender, EventArgs e)
        {

        }

       
        void showInstruction()
        {
            showTestControls();
            reactionTimes = new List<ReactionTime>();
            MessageBox.Show(instruction, "Инструкция");
            SW = new Stopwatch();
            SW.Start();
        }
      
        public void hideTestContorls()
        {
            label1.Invoke(new Action(() => label1.Visible = false));
            endTestButton.Invoke(new Action(() => endTestButton.Visible = true));
            hidePictures();           
        }
       
        public void showBaseControls()
        {
            BeginTestButton.Visible = false;
            TesteeComboBox.Visible = false;
            TesteeLabel.Visible = false;
            label1.Visible = true;
            this.Focus();
            showTestControls();
        }

        void testActions()
        {
            counter = 0;
            action();
            Thread.Sleep(2000);
            SW.Stop();
            testPack.EndTestDate = DateTime.Now;
            db.TestResult.Add(new TestResults
            {
                TestPack = testPack,
                ReactionTimes = reactionTimes,
                TestStage = db.TestStage.FirstOrDefault(x => x.TestStageIndex == 0),
                EndTestDate = DateTime.Now,
                BeginTestDate = testPack.BeginTestDate
            });
            db.SaveChanges();
        }
        public void runFirstTest()
        {
            testActions();
            hideTestContorls();
            backgroundWorker1.CancelAsync();
        }
        public void runSecondTest()
        {
            testActions();
            hideTestContorls();
            cognitiveLoadWorker.CancelAsync();
            cognitiveLoadWorker.CancelAsync();
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
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                isRunning = false;
                return;
            }
            runFirstTest();
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

        private void BaseTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRunning && db.TestResult.Where(x => x.TestPack.id == testPack.id).Count() == 0)
            {
                db.TestPack.Remove(testPack);
                db.SaveChanges();
            }
        }

        private void BeginTestButton_Click(object sender, EventArgs e)
        {
            if (TesteeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Не выбран испытуемый", "Ошибка");
                return;
            }
            showBaseControls();
            testPack.TestType = db.TestType.FirstOrDefault(x => x.TestTypeIndex == testTypeIndex);
            testPack.Profile = db.Profile.FirstOrDefault(x => x.id == ((Profile)TesteeComboBox.SelectedItem).id);
            testPack.BeginTestDate = DateTime.Now;
            testPack.EndTestDate = new DateTime(1900, 1, 1);
            db.TestPack.Add(testPack);
            db.SaveChanges();
            runTest(0);
        }
    }
}
