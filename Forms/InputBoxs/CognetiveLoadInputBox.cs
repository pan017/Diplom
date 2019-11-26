using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.Forms.InputBoxs
{
    class CognetiveLoadInputBox: InputBox
    {
        public CognetiveLoadInputBox(List<Diplom.Model.Lookups.CognetiveLoadType> cognetiveLoadTypeLookups):base()
        {
            buttonOK.Location = new Point(105, 135);
            buttonCancel.Location = new Point(190, 135);

            ComboBox cb = new ComboBox();
            cb.Size = new Size(150, 25);
            cb.Location = new Point(20, 100);
            cb.DataSource = cognetiveLoadTypeLookups;
            this.Controls.Add(cb);
            this.Size = new Size(300, 220);

            Label label2 = new Label();
            label2.AutoSize = false;
            label2.Size = new Size(250, 25);
            label2.Font = new Font(label2.Font, FontStyle.Regular);
            label2.Location = new Point(20, 75);
            label2.Text = "Выберите тип: ";

            this.Controls.Add(label2);
        }

    }
}
