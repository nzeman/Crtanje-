using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Crtanje.GrafickiOblici
{
    public class Kvadrat : Pravokutnik
    {
        public override void Nacrtaj()
        {
            base.Nacrtaj();


            if (oblik.Width > oblik.Height)
                oblik.Width = oblik.Height;
            else
                oblik.Height = oblik.Width;
        }

        public override string ToString()
        {
            return "Kvadrat";
        }
        


    }
}
