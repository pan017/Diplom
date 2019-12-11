using Diplom.Forms.Lookups;
using Diplom.Forms.Tests;
using Diplom.Model;
using Diplom.Service;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                    item.TestType.Name,
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
            

        }

        private void ShowDiagramButton_Click(object sender, EventArgs e)
        {
            var a = (Guid)dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value;
            var selectedTestPack = db.TestPack.FirstOrDefault(x => x.id == a);
            var testResults = db.TestResult.Where(x => x.TestPack.id == selectedTestPack.id).ToList();
            if(testResults.Count == 0)
            {
                db.TestPack.Remove(selectedTestPack);
                db.SaveChanges();
                MessageBox.Show("Данный тест не был пройден до конца. Просмотр результатов не возможен. Он будет удален.", "Ошибка");
                return;
            }
            if (testResults[0].ReactionTimes == null || testResults[0].ReactionTimes.Count == 0)
            {
               
                db.TestResult.Remove(testResults[0]);
                db.SaveChanges();
                MessageBox.Show("Данный тест не был пройден до конца. Просмотр результатов не возможен. Он будет удален.", "Ошибка");
                return;
            }
            ResultsChartForm resultsChartForm = new ResultsChartForm(testResults);
            resultsChartForm.ShowDialog();
        }

        private void времяРеакцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReactionTimeForm reactionTimeForm = new ReactionTimeForm();
            reactionTimeForm.ShowDialog();
        }

        private void DistributionOfAttentionMenuStrip_Click(object sender, EventArgs e)
        {
            DistributionOfAttention distributionOfAttention = new DistributionOfAttention();
            distributionOfAttention.ShowDialog();
        }

        private void типыТестовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestTypesLookupForm testTypesLookupForm = new TestTypesLookupForm();
            testTypesLookupForm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = String.Format("Общий отчет_{0}", DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss"));
            saveFileDialog1.ShowDialog();
        }

        byte[] GenetrateExcelReport()
        {


            using (MemoryStream mem = new MemoryStream())
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(mem, SpreadsheetDocumentType.Workbook))
                {

                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();

                    FileVersion fv = new FileVersion();
                    fv.ApplicationName = "Microsoft Office Excel";
                    worksheetPart.Worksheet = new Worksheet(new SheetData());
                    WorkbookStylesPart wbsp = workbookPart.AddNewPart<WorkbookStylesPart>();

                    // Добавляем в документ набор стилей
                    wbsp.Stylesheet = ExcelHelper.GenerateStyleSheet();
                    wbsp.Stylesheet.Save();



                    // Задаем колонки и их ширину
                    Columns lstColumns = worksheetPart.Worksheet.GetFirstChild<Columns>();
                    Boolean needToInsertColumns = false;
                    if (lstColumns == null)
                    {
                        lstColumns = new Columns();
                        needToInsertColumns = true;
                    }
                    lstColumns.Append(new Column() { Min = 1, Max = 1, Width = 25, CustomWidth = true });
                    for (int i = 0; i < 50; i++)
                    {
                        lstColumns.Append(new Column() { Min = 2, Max = 53, Width = 14, CustomWidth = true });
                    }


                    if (needToInsertColumns)
                        worksheetPart.Worksheet.InsertAt(lstColumns, 0);


                    //Создаем лист в книге
                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "asdasd" };
                    sheets.Append(sheet);

                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                    //Добавим заголовки в первую строку
                    Row row = new Row() { RowIndex = 1 };
                    sheetData.Append(row);

                    InsertCell(row, 1, "ФИО респондентов", CellValues.String, 5);
                    InsertCell(row, 2, "Группа", CellValues.String, 5);
                    InsertCell(row, 3, "Стаж вождения", CellValues.String, 5);
                    InsertCell(row, 4, "Распределение внимания (РВ)", CellValues.String, 5);
                    ExcelHelper.InsertEmptyCell(row, 5, 9, CellValues.String, 5);
                    InsertCell(row, 10, "Время реакции", CellValues.String, 5);
                    ExcelHelper.InsertEmptyCell(row, 11, 15, CellValues.String, 5);
                    InsertCell(row, 16, "Бдительность", CellValues.String, 5);


                    row = new Row() { RowIndex = 2 };
                    sheetData.Append(row);

                    InsertCell(row, 1, "", CellValues.String, 5);
                    InsertCell(row, 2, "", CellValues.String, 5);
                    InsertCell(row, 3, "", CellValues.String, 5);
                    InsertCell(row, 4, "Среднее время реагирования в задании №1 (с)", CellValues.String, 5);
                    InsertCell(row, 5, "Количество правильных ответов на зрительные стимулы в задании №1", CellValues.String, 5);
                    InsertCell(row, 6, "Разница средних времен реагирования между заданием №2 и заданием №1 (с)", CellValues.String, 5);
                    InsertCell(row, 7, "Среднее время реагирования в задании №2 на зрительные стимулы (с)", CellValues.String, 5);
                    InsertCell(row, 8, "Количество правильных реагирований на зрительные стимулы в задании № 2", CellValues.String, 5);
                    InsertCell(row, 9, "Разница количества правильных ответов  на зрительные стимулы между заданием № 1 и заданием №2:", CellValues.String, 5);
                    InsertCell(row, 10, "Среднее время реагирования в задании №1 (с)", CellValues.String, 5);
                    InsertCell(row, 11, "Количество правильных ответов на зрительные стимулы в задании №1", CellValues.String, 5);
                    InsertCell(row, 12, "Разница средних времен реагирования между заданием №2 и заданием №1 (с)", CellValues.String, 5);
                    InsertCell(row, 13, "Среднее время реагирования в задании №2 на зрительные стимулы (с)", CellValues.String, 5);
                    InsertCell(row, 14, "Количество правильных реагирований на зрительные стимулы в задании № 2", CellValues.String, 5);
                    InsertCell(row, 15, "Разница количества правильных ответов  на зрительные стимулы между заданием № 1 и заданием №2:", CellValues.String, 5);
                    InsertCell(row, 16, "Среднее время реагирования (с)", CellValues.String, 5);
                    InsertCell(row, 17, "Количество правильных ответов на зрительные стимулы", CellValues.String, 5);


                    row.CustomHeight = true;
                    row.Height = new DoubleValue(){ Value = 240 };
                    

                    UInt32Value rowIndex = 3;
                    foreach (var item in db.TestPack.ToList())
                    {
                        row = new Row() { RowIndex = rowIndex };
                        sheetData.Append(row);

                        InsertCell(row, 1, item.Profile.ToString(), CellValues.String, 5);
                        InsertCell(row, 2, item.Profile.Group.Name, CellValues.String, 5);
                        InsertCell(row, 3, item.Profile.DriversLicense == null ? "0" : ((DateTime.Now - item.Profile.DriversLicense.GettingDate).TotalDays /365).ToString("N1"), CellValues.String, 5);

                        var currentTestResultsList = db.TestResult.Where(x => x.TestPack.id == item.id && x.TestPack.TestType.TestTypeIndex == 0).OrderBy(x => x.CreatonDate).ToList();
                        if (currentTestResultsList.Count() != 0)
                        {
                            if (currentTestResultsList.First(x => x.TestStage.TestStageIndex == 0).ReactionTimes.Count != 0)
                            {
                                var reactions = currentTestResultsList
                                  .First(x => x.TestStage.TestStageIndex == 0)
                                  .ReactionTimes;
                                List<decimal> reactionList = new List<decimal>();
                                reactions.ForEach(x => reactionList.Add(x.EndReactionTime - x.BeginReactionTime));
                                InsertCell(row, 4, (reactionList.Average() / 1000).ToString("N3"), CellValues.String, 5);
                                InsertCell(row, 5, reactions.Count(x => x.isTrue == true).ToString(), CellValues.String, 5);

                                if (currentTestResultsList.FirstOrDefault(x => x.TestStage.TestStageIndex == 1) != null && currentTestResultsList.First(x => x.TestStage.TestStageIndex == 1).ReactionTimes.Count != 0)

                                   
                                {
                                  var reactions2 = currentTestResultsList.First(x => x.TestStage.TestStageIndex == 1).ReactionTimes;
                                    List<decimal> reactionList2 = new List<decimal>();
                                    reactions.ForEach(x => reactionList2.Add(x.EndReactionTime - x.BeginReactionTime));
                                    if (reactionList2.Count() != 0)
                                    {
                                        InsertCell(row, 6, ((reactionList.Average() / 1000) - (reactionList2.Average() / 1000)).ToString("N3"), CellValues.String, 5);
                                        InsertCell(row, 7, (reactionList2.Average() / 1000).ToString("N3"), CellValues.String, 5);
                                        InsertCell(row, 8, reactions2.Count(x => x.isTrue == true).ToString(), CellValues.String, 5);
                                        InsertCell(row, 9, (reactions.Count(x => x.isTrue == true) - reactions2.Count(x => x.isTrue == true)).ToString(), CellValues.String, 5);
                                    }
                                    else
                                    {
                                        InsertCell(row, 6, "", CellValues.String, 5);
                                        InsertCell(row, 7, "", CellValues.String, 5);
                                        InsertCell(row, 8, "", CellValues.String, 5);
                                        InsertCell(row, 9, "", CellValues.String, 5);
                                    }
                                }
                                else
                                {
                                    InsertCell(row, 6, "", CellValues.String, 5);
                                    InsertCell(row, 7, "", CellValues.String, 5);
                                    InsertCell(row, 8, "", CellValues.String, 5);
                                    InsertCell(row, 9, "", CellValues.String, 5);
                                }

                            }
                            else
                            {
                                InsertCell(row, 4, "", CellValues.String, 5);
                                InsertCell(row, 5, "", CellValues.String, 5);
                                InsertCell(row, 6, "", CellValues.String, 5);
                                InsertCell(row, 7, "", CellValues.String, 5);
                                InsertCell(row, 8, "", CellValues.String, 5);
                                InsertCell(row, 9, "", CellValues.String, 5);
                            }


                        }
                        else
                        {
                          //  InsertCell(row, 2, "", CellValues.String, 5);
                          //  InsertCell(row, 3, "", CellValues.String, 5);
                            InsertCell(row, 4, "", CellValues.String, 5);
                            InsertCell(row, 5, "", CellValues.String, 5);
                            InsertCell(row, 6, "", CellValues.String, 5);
                            InsertCell(row, 7, "", CellValues.String, 5);
                            InsertCell(row, 8, "", CellValues.String, 5);
                            InsertCell(row, 9, "", CellValues.String, 5);
                        }
                        currentTestResultsList = db.TestResult.Where(x => x.TestPack.id == item.id && x.TestPack.TestType.TestTypeIndex == 1).OrderBy(x => x.CreatonDate).ToList();
                        if (currentTestResultsList.Count() != 0)
                        {
                            if (currentTestResultsList.First(x => x.TestStage.TestStageIndex == 0).ReactionTimes.Count != 0)
                            {
                                var reactions = currentTestResultsList
                                  .First(x => x.TestStage.TestStageIndex == 0)
                                  .ReactionTimes;
                                List<decimal> reactionList = new List<decimal>();
                                reactions.ForEach(x => reactionList.Add(x.EndReactionTime - x.BeginReactionTime));
                                InsertCell(row, 10, (reactionList.Average() / 1000).ToString("N3"), CellValues.String, 5);
                                InsertCell(row, 11, reactions.Count(x => x.isTrue == true).ToString(), CellValues.String, 5);

                                if (currentTestResultsList.FirstOrDefault(x => x.TestStage.TestStageIndex == 1) != null && currentTestResultsList.First(x => x.TestStage.TestStageIndex == 1).ReactionTimes.Count != 0)


                                {
                                    var reactions2 = currentTestResultsList.First(x => x.TestStage.TestStageIndex == 1).ReactionTimes;
                                    List<decimal> reactionList2 = new List<decimal>();
                                    reactions2.ForEach(x => reactionList2.Add(x.EndReactionTime - x.BeginReactionTime));
                                    if (reactionList2.Count() != 0)
                                    {
                                        InsertCell(row, 12, ((reactionList.Average() / 1000) - (reactionList2.Average() / 1000)).ToString("N3"), CellValues.String, 5);
                                        InsertCell(row, 13, (reactionList2.Average() / 1000).ToString("N3"), CellValues.String, 5);
                                        InsertCell(row, 14, reactions2.Count(x => x.isTrue == true).ToString(), CellValues.String, 5);
                                        InsertCell(row, 15, (reactions.Count(x => x.isTrue == true) - reactions2.Count(x => x.isTrue == true)).ToString(), CellValues.String, 5);
                                    }
                                    else
                                    {
                                        InsertCell(row, 12, "", CellValues.String, 5);
                                        InsertCell(row, 13, "", CellValues.String, 5);
                                        InsertCell(row, 14, "", CellValues.String, 5);
                                        InsertCell(row, 15, "", CellValues.String, 5);
                                    }
                                }
                                else
                                {
                                    InsertCell(row, 12, "", CellValues.String, 5);
                                    InsertCell(row, 13, "", CellValues.String, 5);
                                    InsertCell(row, 14, "", CellValues.String, 5);
                                    InsertCell(row, 15, "", CellValues.String, 5);
                                }

                            }
                            else
                            {
                                InsertCell(row, 10, "", CellValues.String, 5);
                                InsertCell(row, 11, "", CellValues.String, 5);
                                InsertCell(row, 12, "", CellValues.String, 5);
                                InsertCell(row, 13, "", CellValues.String, 5);
                                InsertCell(row, 14, "", CellValues.String, 5);
                                InsertCell(row, 15, "", CellValues.String, 5);
                            }


                        }
                        else
                        {
                            //  InsertCell(row, 2, "", CellValues.String, 5);
                            //InsertCell(row, 3, "", CellValues.String, 5);
                            InsertCell(row, 10, "", CellValues.String, 5);
                            InsertCell(row, 11, "", CellValues.String, 5);
                            InsertCell(row, 12, "", CellValues.String, 5);
                            InsertCell(row, 13, "", CellValues.String, 5);
                            InsertCell(row, 14, "", CellValues.String, 5);
                            InsertCell(row, 15, "", CellValues.String, 5);
                        }
                        currentTestResultsList = db.TestResult.Where(x => x.TestPack.id == item.id && x.TestPack.TestType.TestTypeIndex == 2).OrderBy(x => x.CreatonDate).ToList();
                        if (currentTestResultsList.Count() != 0)
                        {
                            if (currentTestResultsList.First().ReactionTimes.Count != 0)
                            {
                                var reactions = currentTestResultsList.First().ReactionTimes;
                                List<decimal> reactionList = new List<decimal>();
                                reactions.ForEach(x => reactionList.Add(x.EndReactionTime - x.BeginReactionTime));
                                InsertCell(row, 16, (reactionList.Average() / 1000).ToString("N3"), CellValues.String, 5);
                                InsertCell(row, 17, reactions.Count(x => x.isTrue == true).ToString(), CellValues.String, 5);
                            }
                            else
                            {
                                InsertCell(row, 16, "", CellValues.String, 5);
                                InsertCell(row, 17, "", CellValues.String, 5);
                            }
                        }
                        else
                        {
                            InsertCell(row, 16, "", CellValues.String, 5);
                            InsertCell(row, 17, "", CellValues.String, 5);
                        }
                        rowIndex++;
                    }
                    //  row = new Row() { RowIndex = rowIndex + 1 };
                    // sheetData.Append(row);
                    workbookPart.Workbook.Save();
                    document.Close();
                }
                return mem.ToArray();
            }

        }
        void InsertCell(Row row, int cell_num, string val, CellValues type, uint styleIndex)
        {
            Cell refCell = null;
            Cell newCell = new Cell() { CellReference = cell_num.ToString() + ":" + row.RowIndex.ToString(), StyleIndex = styleIndex };
            row.InsertBefore(newCell, refCell);

            // Устанавливает тип значения.
            newCell.CellValue = new CellValue(val);
            newCell.DataType = new EnumValue<CellValues>(type);

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            byte[] reportData = GenetrateExcelReport();
            try
            {
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(reportData, 0, reportData.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка доступа к файлу. Возможно он занят другим процессом", "Ошибка");
            }
        }
    }
}
