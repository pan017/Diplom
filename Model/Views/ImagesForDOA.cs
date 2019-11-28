using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Model.Views
{
    class ImagesForDOA
    {
        public Colors Color { get; set; }
        public Figure FigureType { get; set; }
        public Image Image { get; set; }

        public ImagesForDOA(string path)
        {
            Image = Image.FromFile(path);
            path = path.Replace(".png", "").Replace("Resourses\\1\\", "");
            Color = (Colors)int.Parse(path.Split('_')[1]);
            FigureType = (Figure)int.Parse(path.Split('_')[0]);
        }

    }
}
