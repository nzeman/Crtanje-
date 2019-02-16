using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Crtanje.GrafickiOblici
{
    public class Romb : GrafickiOblik
    {
        public Romb()
        {
            oblik = new Polygon();
            PointCollection points = new PointCollection();
            
        }

        public override void Nacrtaj()
        {
            base.Nacrtaj();

            /*
            // pravokutnik
            Point Point1 = new Point(pocetak.X, pocetak.Y);
            Point Point2 = new Point(pocetak.X, kraj.Y);
            Point Point3 = new Point(kraj.X, kraj.Y);
            Point Point4 = new Point(kraj.X, pocetak.Y);
           
            polygonPoints.Add(Point1);
            polygonPoints.Add(Point2);
            polygonPoints.Add(Point3);
            polygonPoints.Add(Point4);
            */


            // romb 
            Point Tocka1 = new Point(pocetak.X, pocetak.Y + ((kraj.Y - pocetak.Y)/2));
            Point Tocka2 = new Point(pocetak.X + ((kraj.X - pocetak.X) / 2), kraj.Y);
            Point Tocka3 = new Point(kraj.X, pocetak.Y + ((kraj.Y - pocetak.Y)/2));
            Point Tocka4 = new Point(pocetak.X +((kraj.X - pocetak.X) / 2), pocetak.Y);

            PointCollection polygonPoints = new PointCollection();
   
            polygonPoints.Add(Tocka1);
            polygonPoints.Add(Tocka2);
            polygonPoints.Add(Tocka3);
            polygonPoints.Add(Tocka4);
          
            ((Polygon)oblik).Points = polygonPoints;
            
        }
        public override string ToString()
        {
            return "Romb";
        }

    }
}
