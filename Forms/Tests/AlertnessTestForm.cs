using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.Forms.Tests
{
    public partial class AlertnessTestForm : BaseTestForm
    {

        public AlertnessTestForm()
        {
            InitializeComponent();
            testTypeIndex = 2;
            instruction = "Перед Вами на экране монитора будет перемещаться по кругу, по фиксированным позициям," +
                " чёрное пятно. Оно будет двигаться, последовательно перемещаясь на одну позицию." +
                " Иногда чёрное пятно будет совершать перескок через одну позицию. " +
                "Ваша задача - внимательно следить за движением чёрного пятна.Если Вы заметите перескок пятна вперед" +
                " через одну позицию, то как можно быстрее нажмите на клавишу \"Пробел\"";
            label1.Visible = false;
            this.Name = "Тест на бдительность";
        }
        public override void hidePictures()
        {
            
            for (int i = 2; i < 52; i++)
            {
                ((PictureBox)Controls["pictureBox" + i]).Image = null;
            }
        }
        public override void showTestControls()
        {
            label1.Visible = false;
            for (int i = 2; i < 52; i++)
            {
                ((PictureBox)Controls["pictureBox" + i]).Image = Image.FromFile(@"Resourses\blackPoint.png");
                ((PictureBox)Controls["pictureBox" + i]).SizeMode = PictureBoxSizeMode.StretchImage;
                ((PictureBox)Controls["pictureBox" + i]).Visible = true;
            }

        }
        public override void action()
        {
            int pictureIndex = 2;

            while (SW.ElapsedMilliseconds < Properties.Settings.Default.TestTime * 1000)
            {
                if (random.Next(0, 100) % 5 == 0)
                {
                    pictureIndex++;
                    addActionTime();
                }

                if (pictureIndex == 52)
                    pictureIndex = 2;
                PictureBox picture = (PictureBox)Controls["pictureBox" + pictureIndex];
                picture.Image = Image.FromFile(@"Resourses\redPoint.png");
                Thread.Sleep(500);
                picture.Image = Image.FromFile(@"Resourses\blackPoint.png");
                Thread.Sleep(500);
                pictureIndex++;
            }
        }
        public override void endTestButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AlertnessTestForm_Load(object sender, EventArgs e)
        {

        }
    }
}
