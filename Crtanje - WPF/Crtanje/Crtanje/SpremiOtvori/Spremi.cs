using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Crtanje.SpremiOtvori
{
    public class Spremi
    {
        public static void SpremiKanvas(Canvas PlocaCanvas)
        {
            Rect rect = new Rect(PlocaCanvas.RenderSize);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right,

            (int)rect.Bottom, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(PlocaCanvas);

            //enkodiranje kao PNG
            Microsoft.Win32.SaveFileDialog d1 = new Microsoft.Win32.SaveFileDialog();
            d1.FileName = "Slika";
            d1.DefaultExt = ".png";
            d1.Filter = "Portable Network Graphics (.png)|*.png";
            Nullable<bool> result = d1.ShowDialog();
            if (result == true)
            {
                string filename = d1.FileName;
                BitmapEncoder pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(rtb));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
        
     
               pngEncoder.Save(ms);
               ms.Close();
               System.IO.File.WriteAllBytes(filename, ms.ToArray());
               
            }
        }

    }
}
