using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace KK
{
    class GameLogic
    {
        readonly char[] board = new char[9];
        readonly BitmapImage src = new BitmapImage();
        Boolean win;
        private int ai;
        private int counter;
        private readonly int network;
        public char tour = 'o';
        public char yoursTour;
        private readonly Image[] boxes;



        public GameLogic(Image[] boxes, int ai, int network)
        {
            this.ai = ai;
            this.boxes = boxes;

            this.network = network;
            if (network == 1)
            {
                yoursTour = 'o';
                MessageBox.Show("Jesteś kółkiem");
            }
            if (network == 2)
            {
                yoursTour = 'k';
                MessageBox.Show("Jesteś krzyżykiem");
            }

            Clear();



        }




        public void Clear()
        {
            win = false;
            if (ai == 0 || network == 0)
            {
                Random rand = new Random();
                if (rand.Next(0, 2) == 0)
                {
                    tour = 'o';
                }
                else
                    tour = 'k';
            }
            if (network == 1)
            {
                tour = 'o';
                yoursTour = 'o';
            }
            if (network == 2)
            {
                tour = 'o';
                yoursTour = 'k';
            }
            else
                tour = 'o';
            counter = 9;
            for (int j = 0; j < 9; j++)
            {
                Application.Current.Dispatcher.Invoke((Action)(() =>
                {
                    boxes[j].Source = new BitmapImage(new Uri(@"img/nic.bmp", UriKind.Relative));
                    boxes[j].Cursor = Cursors.Hand;
                    if (yoursTour != tour)
                    {
                        boxes[j].Cursor = null;
                    }
                }));
            }
            for (int i = 0; i < 9; i++)
            {
                board[i] = 'n';
            }

            if (tour == 'k')
            {
                SetX(boxes[9]);
            }
            else
            {
                SetO(boxes[9]);
            }

        }

        void Check()
        {

            if (
                    (board[0] == board[1] && board[1] == board[2] && board[0] != 'n') ||
                    (board[3] == board[4] && board[4] == board[5] && board[3] != 'n') ||
                    (board[6] == board[7] && board[7] == board[8] && board[6] != 'n') ||
                    (board[0] == board[3] && board[3] == board[6] && board[0] != 'n') ||
                    (board[1] == board[4] && board[4] == board[7] && board[1] != 'n') ||
                    (board[2] == board[5] && board[5] == board[8] && board[2] != 'n') ||
                    (board[0] == board[4] && board[4] == board[8] && board[0] != 'n') ||
                    (board[2] == board[4] && board[4] == board[6] && board[2] != 'n')
                )
            {

                string msg = "";
                if (tour == 'o')
                {
                    msg = "Wygrywa krzyżyk!";
                }
                if (tour == 'k')
                {
                    msg = "Wygrywa kółko!";
                }
                MessageBox.Show(msg);
                win = true;
                Clear();
            }

            else if (counter == 0)
            {
                MessageBox.Show("Remis");

                win = true;
                Clear();
            }
        }

        public void Move(int x)
        {

            if (board[x] == 'n')
            {


                --counter;

                if (tour == 'o')
                {
                    SetO(boxes[x]);
                    board[x] = 'o';
                    tour = 'k';
                    SetX(boxes[9]);

                }
                else
                {
                    SetX(boxes[x]);
                    board[x] = 'k';
                    tour = 'o';
                    SetO(boxes[9]);
                }
                Application.Current.Dispatcher.Invoke((Action)(() =>
                {
                    boxes[x].Cursor = null;
                }));
                Check();
                if (ai == 1 && win == false)
                {
                    Random randd = new Random();
                    int random = randd.Next(0, 9);
                    while (board[random] != 'n')
                    {
                        random = randd.Next(0, 9);
                    }
                    SetX(boxes[random]);
                    board[random] = 'k';
                    tour = 'o';
                    SetO(boxes[9]);
                    boxes[random].Cursor = null;
                    Check();
                    ai = 1;
                }
                if (yoursTour != tour)
                {
                    Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            boxes[j].Cursor = null;
                        }
                    }));
                }

                if (yoursTour == tour)
                {
                    Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (board[j] == 'n')
                            {
                                boxes[j].Cursor = Cursors.Hand;
                            }
                        }
                    }));
                }

            }

        }

        void SetX(Image image)
        {
            Application.Current.Dispatcher.Invoke((Action)(() =>
            {
                image.Source = new BitmapImage(new Uri(@"img/x.bmp", UriKind.Relative));
            }));
        }

        void SetO(Image image)
        {
            Application.Current.Dispatcher.Invoke((Action)(() =>
            {
                image.Source = new BitmapImage(new Uri(@"img/o.bmp", UriKind.Relative));
            }));


        }
    }
}
