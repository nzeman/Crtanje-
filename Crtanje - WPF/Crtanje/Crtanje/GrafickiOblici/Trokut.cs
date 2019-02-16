using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Crtanje.GrafickiOblici
{
    public class Trokut : GrafickiOblik
    {
        public Trokut()
        {
            oblik = new Polygon();
            PointCollection points = new PointCollection();
        }

        public override void Nacrtaj()
        {
            base.Nacrtaj();

            Point Point1 = new Point(pocetak.X, pocetak.Y);
            Point Point2 = new Point(pocetak.X, kraj.Y );
            Point Point3 = new Point(kraj.X, kraj.Y);

            PointCollection polygonPoints = new PointCollection();
            polygonPoints.Add(Point1);
            polygonPoints.Add(Point2);
            polygonPoints.Add(Point3);

            ((Polygon)oblik).Points = polygonPoints;                
        
        }

        public override string ToString()
        {
            return "Trokut";
        }


    }
}
