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

namespace KK
{
    /// <summary>
    /// Logika interakcji dla klasy Page2.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void vs_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Gamepage(0, 0));
        }

        private void ai_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Gamepage(1, 0));
        }

        private void Online_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menu2());
        }
    }
}
