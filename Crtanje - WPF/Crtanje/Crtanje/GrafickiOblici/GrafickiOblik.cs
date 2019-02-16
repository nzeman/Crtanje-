using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Crtanje.GrafickiOblici
{
    public class GrafickiOblik
    {
        // oblik koji postavljamo
        protected Shape oblik;

        // krajnje tocke
        protected Point pocetak;
        protected Point kraj;

        // boja
        protected Brush boja;

        // linija
        protected double deblinaLinije;
        protected Brush bojaLinije;

        // kanvas na kojemu se nalazi
        protected Canvas kanvas;

        
        public virtual void Postavi(Canvas _kanvas, Point _pocetak, Point _kraj,
            Brush _boja, double _debljinaLinije, Brush _bojaLinije)
        {
            kanvas = _kanvas;
            pocetak = _pocetak;
            kraj = _kraj;
            boja = _boja;
            deblinaLinije = _debljinaLinije;
            bojaLinije = _bojaLinije;
            

        }

        // osvjezavanje oblika na kanvasu
        public virtual void Nacrtaj()
        {
            // ako ne postoji na kanvasu, dodaj!
            if (!kanvas.Children.Contains(oblik))
                    kanvas.Children.Add(oblik);

            // postavljanje linije i boja
            oblik.Stroke = bojaLinije;
            oblik.StrokeThickness = deblinaLinije;
            oblik.Fill = boja;
            
            
        }

        
  
    }
}
