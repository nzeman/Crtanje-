using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Crtanje.GrafickiOblici
{
    class Test : GrafickiOblik
    {
        public Test()
        {
            oblik = new Line();
           
            
        }

        public override void Nacrtaj()
        {
            base.Nacrtaj();
            ((Line)oblik).X1 = pocetak.X;
            ((Line)oblik).Y1 = pocetak.Y;
            ((Line)oblik).X2 = kraj.X;
            ((Line)oblik).Y2 = kraj.Y;

           
        
        }

        public override string ToString()
        {
            return "Test";
        }

    }
}
