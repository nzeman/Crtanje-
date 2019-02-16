using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crtanje.GrafickiOblici
{
    public class TvornicaOblika
    {
        public static GrafickiOblik StvoriOblik(VrstaOblika vrsta)
        {
            if (vrsta == VrstaOblika.Linija)
            {
                return new Linija();
            }
            else if (vrsta == VrstaOblika.Pravokutnik)
            {
                return new Pravokutnik();
            }
            else if (vrsta == VrstaOblika.Kvadrat)
            {
                return new Kvadrat();
            }
            else if (vrsta == VrstaOblika.Elipsa)
            {
                return new Elipsa();
            }
            else if(vrsta == VrstaOblika.Trokut)
            {
                return new Trokut();
            }
            else if (vrsta == VrstaOblika.Romb)
            {
                return new Romb();
            }
            else if (vrsta == VrstaOblika.Test)
            {
                return new Test();
            }
            else
            {
                return new GrafickiOblik();
            }
        }
    }
}
