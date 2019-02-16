using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Crtanje
{
    /// <summary>
    /// Interaction logic for Upute.xaml
    /// </summary>
    public partial class Upute : Window
    {
        public Upute()
        {
            InitializeComponent();

       
        }



        private void izlazButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
