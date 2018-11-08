using System;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net;
using System.Net.Sockets;

namespace KK
{
    /// <summary>
    /// Logika interakcji dla klasy Page1.xaml
    /// </summary>
    public partial class Gamepage : Page
    {
        private Image[] boxes;
        GameLogic Logic;
        int network;
        delegate void SetTextCallback(string text);
        TcpListener listener;
        TcpClient client;
        NetworkStream ns;
        Thread t = null;
        Thread tt = null;

        private void Initialize()
        {
            InitializeComponent();
            Image[] box = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p0 };
            boxes = (Image[])box.Clone();
        }

        public Gamepage(int ai=0, int networking = 0)
        {
            Initialize();
            network = networking;

            if (network == 1)
            {
                newgame.IsEnabled = false;
                SetupServer();
            }
            if (network == 2)
            {
                SetupClient();
                newgame.IsEnabled = false;
            }

            Logic = new GameLogic(boxes, ai, networking);
            
        }
        

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            Logic.Clear();
            this.NavigationService.Navigate(new Menu());
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            Logic.Clear();
        }

        

        private void p1_Click(object sender, MouseEventArgs e)
        {

            if (network == 1 && Logic.yoursTour==Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("0");
                ns.Write(byteTime, 0, byteTime.Length);

                Logic.Move(0);
            }
            if (network == 2 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("0");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(0);
            }
        }

        private void p2_Click(object sender, MouseEventArgs e)
        {
            if (network == 1 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("1");
                ns.Write(byteTime, 0, byteTime.Length);

                Logic.Move(1);
            }
            if (network == 2 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("1");
                ns.Write(byteTime, 0, byteTime.Length);

                Logic.Move(1);
            }
        }

        private void p3_Click(object sender, MouseEventArgs e)
        {
            if (network == 1 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("2");
                ns.Write(byteTime, 0, byteTime.Length);

                Logic.Move(2);
            }
            if (network == 2 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("2");
                ns.Write(byteTime, 0, byteTime.Length);

                Logic.Move(2);
            }
        }

        private void p4_Click(object sender, MouseEventArgs e)
        {
            if (network == 1 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("3");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(3);
            }
            if (network == 2 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("3");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(3);
            }
        }

        private void p5_Click(object sender, MouseEventArgs e)
        {
            if (network == 1 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("4");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(4);
            }
            if (network == 2 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("4");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(4);
            }
        }

        private void p6_Click(object sender, MouseEventArgs e)
        {
            if (network == 1 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("5");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(5);
            }
            if (network == 2 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("5");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(5);
            }
        }

        private void p7_Click(object sender, MouseEventArgs e)
        {
            if (network == 1 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("6");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(6);
            }
            if (network == 2 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("6");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(6);
            }
        }

        private void p8_Click(object sender, MouseEventArgs e)
        {
            if (network == 1 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("7");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(7);
            }
            if (network == 2 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("7");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(7);
            }
        }

        private void p9_Click(object sender, MouseEventArgs e)
        {
            if (network == 1 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("8");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(8);
            }
            if (network == 2 && Logic.yoursTour == Logic.tour)
            {
                byte[] byteTime = Encoding.ASCII.GetBytes("8");
                ns.Write(byteTime, 0, byteTime.Length);
                Logic.Move(8);
            }
        }

        private void SetupServer()
        {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 4545);
            listener.Start();
            client = listener.AcceptTcpClient();
            ns = client.GetStream();
            t = new Thread(DoWork);
            t.IsBackground = true;
            t.Start();
        }
        private void SetupClient()
        {
            client = new TcpClient("127.0.0.1", 4545);
            ns = client.GetStream();
            t = new Thread(DoWork);
            t.IsBackground = true;
            t.Start();
        }

        public void DoWork()
        {
            byte[] bytes = new byte[1024];
            while (true)
            {
                int bytesRead = ns.Read(bytes, 0, bytes.Length);
                //var str = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                //MessageBox.Show(str);
                SetText(Encoding.ASCII.GetString(bytes, 0, bytesRead));
                //MessageBox.Show(Encoding.ASCII.GetString(bytes, 0, bytesRead));
            }
        }

        private void SetText(string text)
        {
            int x = 0;

            Int32.TryParse(text, out x);
            object o = x;
            //MessageBox.Show(o.GetType().ToString());
            Logic.Move(x);
        }

    }
}
