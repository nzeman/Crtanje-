using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Crtanje.SpremiOtvori
{
    public class Otvori
    {
        public static void OtvoriKanvas(Canvas PlocaCanvas)
        {
            Microsoft.Win32.OpenFileDialog d1 = new Microsoft.Win32.OpenFileDialog();

            d1.DefaultExt = ".png";
            d1.Filter = "Portable Network Graphics (.png)|*.png";
            Nullable<bool> result = d1.ShowDialog();

            if (result == true)
            {
                string filename = d1.FileName;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(@filename, UriKind.Relative));
                PlocaCanvas.Background = brush;
            }
        }
    }
}
