using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Diplom.Model;

namespace Diplom.Forms
{
    public partial class ResultsChartForm : DevExpress.XtraEditors.XtraForm
    {
        public ResultsChartForm()
        {
            db = new ViewModel();
            InitializeComponent();
        }
        public ResultsChartForm(List<TestResults> testPack)
        {       
            db = new ViewModel();
            this.testResults = testPack;
            InitializeComponent();
        }
        ViewModel db;
        List<TestResults> testResults;

        private void ResultsChartForm_Load(object sender, EventArgs e)
        {
            labelControl1.Text = String.Format("Ипытуемый: {0}", testResults[0].TestPack.Profile.ToString());
            this.Text = String.Format("Ипытуемый: {0}", testResults[0].TestPack.Profile.ToString());
            int errorsCount = 0;
            foreach (var item in testResults)
            {
                if (item.ReactionTimes == null || item.ReactionTimes.Count == 0)
                    continue;
                var series = new DevExpress.XtraCharts.Series();
                int reactions = 0;
                List<Model.Lookups.ReactionTime> reactionList = item.ReactionTimes.OrderBy(x => x.CreatonDate).ToList();
                foreach (var reaction in reactionList)
                {
                    if (reaction.isTrue)
                    {
                        series.Points.Add(new DevExpress.XtraCharts.SeriesPoint(reactions.ToString(), reaction.EndReactionTime - reaction.BeginReactionTime));
                        reactions++;
                    }
                    else
                        errorsCount++;
                }
                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                series.Visible = true;
                series.Name = item.TestStage.Name;
                if (chartControl1.Series.Count == 0) 
                    series.View.Color = System.Drawing.Color.FromArgb(0, 145, 234);
               
                else             
                    series.View.Color = System.Drawing.Color.FromArgb(255, 112, 67);

                chartControl1.Series.Add(series);
            }
            labelControl2.Text = String.Format("Количетсво ошибок: {0}", errorsCount.ToString());
            chartControl1.Titles.Add(new DevExpress.XtraCharts.ChartTitle()
            {
                Alignment = StringAlignment.Center,
                Visibility = DevExpress.Utils.DefaultBoolean.True,
                Text = testResults[0].TestPack.TestType.Name
            });
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }
    }
}