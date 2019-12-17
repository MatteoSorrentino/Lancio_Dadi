using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lancio_Dadi
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Random r = new Random();

        private void Btn_lancia_Click(object sender, RoutedEventArgs e)
        {
            var Dado1 = Task.Factory.StartNew(Lancio);

            var Dado2 = Task.Factory.StartNew(Lancio);

            Task.WaitAll(Dado1, Dado2);

            var Risultato = Dado1.Result + Dado2.Result;

            lbl_risultato.Content=$"{Risultato}";

        }

        public int Lancio()
        {
            return r.Next(1, 7);
        }
    }
}
