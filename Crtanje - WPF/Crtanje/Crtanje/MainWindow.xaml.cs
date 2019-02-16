using Crtanje.GrafickiOblici;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;



namespace Crtanje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // pocetna tocka objekta
        private Point startPoint;

        // zavrsna tocka objekta
        private Point endPoint;
        
        // oblik koji se trenutno crta (pokazivac na njega)
        private GrafickiOblik trenutniOblik;

        // vrsta oblika
        private VrstaOblika vrsta;

        // Liste za Redo i Undo (pamćenje)
        private List<GrafickiOblik> RedoObliciLista = new List<GrafickiOblik>();
        private List<Point> startPointLista = new List<Point>();
        private List<Point> endPointLista = new List<Point>();
        private List<VrstaOblika> VrstaOblikaLista = new List<VrstaOblika>();
        private List<Brush> BojaOblikaLista = new List<Brush>();
        private List<double> LinijaComboBoxLista = new List<double>();
        private List<Brush> BojaLinijeLista = new List<Brush>();

        private int undoCounter = 0;

        private List<int> VratiBroj(int odBroj, int doBroj)
        {
            // trebam samo za ComboBox
            List<int> lista = new List<int>();
            for (int i = odBroj; i <= doBroj; i++)
            {
                lista.Add(i);
            }
            return lista;
        }


        public MainWindow()
        {
            InitializeComponent();
            
            vrsta = VrstaOblika.Linija;
            LinijaComboBox.ItemsSource = VratiBroj(0, 30); // popunjava ComboBox za liniju
            LinijaComboBox.SelectedIndex = 5; // ComboBox defaultna vrijednost je postavljena na prvi index
            UndoButton.IsEnabled = false; // na pocetku je undo button nedostupan
            RedoButton.IsEnabled = false; // na pocetku je redo button nedostupan
            ObliciListBox.Items.Clear();
            KoordinateLabel.Foreground = Brushes.Blue;
            colorList.ItemsSource = typeof(Brushes).GetProperties();
            bojaLinijeListBox.ItemsSource = typeof(Brushes).GetProperties();
            
        }

        #region IzborniciBoja
        private void colorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

                Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
                rtlfill.Fill = selectedColor;
                Console.WriteLine("BOJA OBLIKA PROMJENJENA");
      
        }

        private void bojaLinijeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

                Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
                bojaLinijeRectangle.Fill = selectedColor;
                Console.WriteLine("BOJA LINIJE PROMJENJENA");

        }
        #endregion


        #region miš eventi
        // kod pritiska lijeve tipke misa na kanvasu
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            startPoint = e.GetPosition(PlocaCanvas);

      
                // ako ne postoji oblik svori novi oblik
                    if (trenutniOblik == null)
                    {
                    
                        trenutniOblik = TvornicaOblika.StvoriOblik(vrsta);
                        VrstaOblikaLista.Add(vrsta);
                        Console.WriteLine("MOUSE LEFT BUTTON DOWN");
                        
                    
                   }
            }
        
        // prilikom pomaka na kanvasu misa
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
                    
            // uzmi zavrsnu tocku
            endPoint = e.GetPosition(PlocaCanvas);

            // ispisivanje koordinata miša
            KoordinateTextBox.Text = "X = " + Math.Round(endPoint.X).ToString() + "    Y = " + Math.Round(endPoint.Y).ToString();

            // ako postoji trenutniOblik osvježi ga
            if (trenutniOblik != null)
            {
                 /*BojaTextBox.Background*/
                trenutniOblik.Postavi(PlocaCanvas, startPoint, endPoint, rtlfill.Fill , double.Parse(LinijaComboBox.Text), bojaLinijeRectangle.Fill);
                trenutniOblik.Nacrtaj();
            }

        }

        // kod pustanja lijeve tipke misa na kanvasu
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            if (!(startPoint.X == endPoint.X && startPoint.Y == endPoint.Y))
            {
                
                ObliciListBox.Items.Add(trenutniOblik); //  dodaj trenutni oblik u listbox za oblike
                
               
                Console.WriteLine("MOUSE LEFT BUTTON UP");

                startPointLista.Add(startPoint);//testerino
                endPointLista.Add(endPoint);//testerino
                RedoObliciLista.Add(trenutniOblik);//testerino
                BojaOblikaLista.Add(rtlfill.Fill);//testerino
                LinijaComboBoxLista.Add(double.Parse(LinijaComboBox.Text));
                BojaLinijeLista.Add(bojaLinijeRectangle.Fill); //testerino
                

                trenutniOblik = null; // zaboravi na trenutni oblik
                UndoButton.IsEnabled = true; // dok se stvori oblik onda enablaj undo button

            }
            
         }
            
        


        #endregion

        #region UndoRedo

        // UNDO
        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (PlocaCanvas.Children.Count > 0)
            {
                PlocaCanvas.Children.RemoveAt(PlocaCanvas.Children.Count - 1);
                RedoButton.IsEnabled = true;
                undoCounter++;
                ObliciListBox.Items.RemoveAt(ObliciListBox.Items.Count - 1);
               
            }
        
           
        }

        // REDO
        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
               
           if (undoCounter > 0)
                {   
                    trenutniOblik = TvornicaOblika.StvoriOblik(VrstaOblikaLista.ElementAt(VrstaOblikaLista.Count - undoCounter));
                    
                    trenutniOblik.Postavi(
                            PlocaCanvas, 
                            startPointLista.ElementAt(startPointLista.Count - undoCounter),
                            endPointLista.ElementAt(endPointLista.Count - undoCounter),
                            BojaOblikaLista.ElementAt(BojaOblikaLista.Count - undoCounter), 
                            LinijaComboBoxLista.ElementAt(LinijaComboBoxLista.Count - undoCounter), 
                            BojaLinijeLista.ElementAt(BojaLinijeLista.Count - undoCounter)
                        );
                 
                    trenutniOblik.Nacrtaj();
                    ObliciListBox.Items.Add(trenutniOblik);
                    trenutniOblik = null; // zaboravi na trenutni oblik
                    undoCounter--;
                }
                           
            if (undoCounter == 0) RedoButton.IsEnabled = false;  
        }
        #endregion

        #region VrsteOblika
        private void LinijaButton_Click(object sender, RoutedEventArgs e)
        {
            vrsta = VrstaOblika.Linija;
        }

        private void PravokutnikButton_Click(object sender, RoutedEventArgs e)
        {
            vrsta = VrstaOblika.Pravokutnik;
        }

        private void KvadratButton_Click(object sender, RoutedEventArgs e)
        {
            vrsta = VrstaOblika.Kvadrat;
        }

        private void ElipsaButton_Click(object sender, RoutedEventArgs e)
        {
            vrsta = VrstaOblika.Elipsa;
        }

        private void TrokutButton_Click(object sender, RoutedEventArgs e)
        {
            vrsta = VrstaOblika.Trokut;
        }

        private void RombButton_Click(object sender, RoutedEventArgs e)
        {
            vrsta = VrstaOblika.Romb;
        }

        private void TestButtonClick(object sender, RoutedEventArgs e)
        {
            vrsta = VrstaOblika.Test;
        }
        #endregion

        #region MenuItem Click
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Izlaz i messageBox prije kompletnog izlaza
            if (MessageBox.Show("Da li ste sigurni da želite izaći?", "Izlaz", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
             
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // Spremi kao...
            SpremiOtvori.Spremi.SpremiKanvas(PlocaCanvas);
           
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            // Otvori...
            SpremiOtvori.Otvori.OtvoriKanvas(PlocaCanvas);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Da li ste sigurni da želite čisti kanvas? (izgubit će te sve što ste nacrtali do sad!)", "Čisti kanvas", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                PlocaCanvas.Children.Clear();

                ObliciListBox.Items.Clear();

                RedoObliciLista.Clear();
                startPointLista.Clear();
                endPointLista.Clear();
                VrstaOblikaLista.Clear();
                BojaOblikaLista.Clear();
                LinijaComboBoxLista.Clear();
                BojaLinijeLista.Clear();

                UndoButton.IsEnabled = false;
                RedoButton.IsEnabled = false;

                undoCounter = 0;

            }
            else
            {
                
            }

        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
         // otvori o autoru
            MessageBox.Show("Nikola Zeman - student Međimurskog Veleučilišta u Čakovcu",
                "O autoru",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            string tekst = "The License and Services Agreement (LSA) provides the terms and conditions under which you can license software through the Education Community. Software provided without charge to Education Community members may be used solely for purposes directly related to learning, training, research or development. Such software shall not be used for commercial, professional or any other for-profit purposes.";
            MessageBox.Show(tekst,"Licenca",MessageBoxButton.OK, MessageBoxImage.Information);
                
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            Upute u1 = new Upute();
            u1.Show();
        }
        
        #endregion















    }
}
