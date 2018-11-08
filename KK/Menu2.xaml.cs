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
    /// Logika interakcji dla klasy menu2.xaml
    /// </summary>
    public partial class Menu2 : Page
    {
        public Menu2()
        {
            InitializeComponent();
        }

        void Host_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Gamepage(0, 1));
            //AsynchronousSocketListener Host = new AsynchronousSocketListener();
        }

        void Client_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new Gamepage(0, 2));
            //AsynchronousClient Client = new AsynchronousClient();
        }
    }
}
