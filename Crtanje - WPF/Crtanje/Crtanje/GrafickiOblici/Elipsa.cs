using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Crtanje.GrafickiOblici
{
    public class Elipsa : GrafickiOblik
    {
        
        public Elipsa()
        {
            oblik = new Ellipse();
        }

        public override void Nacrtaj()
        {
            base.Nacrtaj();
            oblik.Width = Math.Abs(pocetak.X - kraj.X);
            oblik.Height = Math.Abs(pocetak.Y - kraj.Y);
            Canvas.SetTop(oblik, Math.Min(pocetak.Y, kraj.Y));
            Canvas.SetLeft(oblik, Math.Min(pocetak.X, kraj.X));
        }

        public override string ToString()
        {
            return "Elipsa";
        }

    }
}
