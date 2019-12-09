﻿using System;
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
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using DocumentFormat.OpenXml.Packaging;

using Alignment = DocumentFormat.OpenXml.Spreadsheet.Alignment;
using Color = DocumentFormat.OpenXml.Spreadsheet.Color;
using Font = DocumentFormat.OpenXml.Spreadsheet.Font;

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
        
        static void InsertCell(Row row, int cell_num, string val, CellValues type, uint styleIndex)
        {
            Cell refCell = null;
            Cell newCell = new Cell() { CellReference = cell_num.ToString() + ":" + row.RowIndex.ToString(), StyleIndex = styleIndex };
            row.InsertBefore(newCell, refCell);

            // Устанавливает тип значения.
            newCell.CellValue = new CellValue(val);
            newCell.DataType = new EnumValue<CellValues>(type);

        }

        private void ExcelImportButton_Click(object sender, EventArgs e)
        {
           
            saveFileDialog1.ShowDialog();
        }
        static Stylesheet GenerateStyleSheet()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(                                                               // Стиль под номером 0 - Шрифт по умолчанию.
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Стиль под номером 1 - Жирный шрифт Times New Roman.
                        new Bold(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" }),
                    new Font(                                                               // Стиль под номером 2 - Обычный шрифт Times New Roman.
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" }),
                    new Font(                                                               // Стиль под номером 3 - Шрифт Times New Roman размером 14.
                        new FontSize() { Val = 14 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" })
                ),
                new Fills(
                    new Fill(                                                           // Стиль под номером 0 - Заполнение ячейки по умолчанию.
                        new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(                                                           // Стиль под номером 1 - Заполнение ячейки серым цветом
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFAAAAAA" } }
                            )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Стиль под номером 2 - Заполнение ячейки красным.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFFFAAAA" } }
                        )
                        { PatternType = PatternValues.Solid })
                )
                ,
                new Borders(
                    new Border(                                                         // Стиль под номером 0 - Грани.
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder()),
                    new Border(                                                         // Стиль под номером 1 - Грани
                        new LeftBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Medium },
                        new RightBorder(
                            new Color() { Indexed = (UInt32Value)64U }
                        )
                        { Style = BorderStyleValues.Medium },
                        new TopBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Medium },
                        new BottomBorder(
                            new Color() { Indexed = (UInt32Value)64U }
                        )
                        { Style = BorderStyleValues.Medium },
                        new DiagonalBorder()),
                    new Border(                                                         // Стиль под номером 2 - Грани.
                        new LeftBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new RightBorder(
                            new Color() { Indexed = (UInt32Value)64U }
                        )
                        { Style = BorderStyleValues.Thin },
                        new TopBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new BottomBorder(
                            new Color() { Indexed = (UInt32Value)64U }
                        )
                        { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                ),
                new CellFormats(
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 },                          // Стиль под номером 0 - The default cell style.  (по умолчанию)
                    new CellFormat(new DocumentFormat.OpenXml.Spreadsheet.Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }) { FontId = 1, FillId = 2, BorderId = 1, ApplyFont = true },       // Стиль под номером 1 - Bold 
                    new CellFormat(new DocumentFormat.OpenXml.Spreadsheet.Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }) { FontId = 2, FillId = 0, BorderId = 2, ApplyFont = true },       // Стиль под номером 2 - REgular
                    new CellFormat() { FontId = 3, FillId = 0, BorderId = 2, ApplyFont = true, NumberFormatId = 4 },       // Стиль под номером 3 - Times Roman
                    new CellFormat() { FontId = 0, FillId = 2, BorderId = 0, ApplyFill = true },       // Стиль под номером 4 - Yellow Fill
                    new CellFormat(                                                                   // Стиль под номером 5 - Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }
                    )
                    { FontId = 0, FillId = 0, BorderId = 0, ApplyAlignment = true },
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }) { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true },      // Стиль под номером 6 - Border
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Right, Vertical = VerticalAlignmentValues.Center, WrapText = true }) { FontId = 2, FillId = 0, BorderId = 2, ApplyFont = true, NumberFormatId = 4 }       // Стиль под номером 7 - Задает числовой формат полю.
                )
            ); // Выход
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
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
                    wbsp.Stylesheet = GenerateStyleSheet();
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
                    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "" };
                    sheets.Append(sheet);

                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                    //Добавим заголовки в первую строку
                    Row row = new Row() { RowIndex = 1 };
                    sheetData.Append(row);
                }
                using (FileStream output = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                {
                    mem.CopyTo(output);
                }
            }
            
        }
    }
}