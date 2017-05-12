using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace OnitamaFx
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Uri> move_card_path;

        public MainWindow()
        {
            InitializeComponent();
            init_assets();
            start_game();
        }

        public void init_assets()
        {
            move_card_path = new List<Uri>();

            DirectoryInfo d = new DirectoryInfo(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Ressource");
            FileInfo[] Files = d.GetFiles("*.png");
            foreach (FileInfo fi in Files)
            {
                var path = fi.FullName;
                move_card_path.Add(new Uri(path));
            }
        }

        public void createGrid(int width, int height)
        {
            for (int i =0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    game_grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(game_grid.Width / width) });
                    game_grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(game_grid.Height / height) });
                    Button butt = new Button();
                    butt.Height = 70;
                    butt.Width = 70;
                    butt.Tag = null;
                    butt.Click += case_click;
                    butt.IsEnabled = false;
                    Grid.SetColumn(butt, j);
                    Grid.SetRow(butt, i);
                    game_grid.Children.Add(butt);
                }
            }
        }

        private void case_click(object sender, RoutedEventArgs e)
        {
            Button butt = (sender as Button);
            if ((string)butt.Tag != null)
            {
                //Register this piece to be move
                removePiece(Grid.GetColumn(butt), Grid.GetRow(butt));
                denable_case(Grid.GetColumn(butt), Grid.GetRow(butt));
            }
            else
            {
                //Place the piece in this case
                placePiece(Grid.GetColumn(butt), Grid.GetRow(butt), "P");
            }
        }

        public void start_game()
        {
            game_grid.Children.Clear();
            createGrid(5, 5);

            placePiece(0, 0, "P");
            placePiece(1, 0, "P");
            placePiece(2, 0, "M");
            placePiece(3, 0, "P");
            placePiece(4, 0, "P");

            placePiece(0, 4, "P");
            placePiece(1, 4, "P");
            placePiece(2, 4, "M");
            placePiece(3, 4, "P");
            placePiece(4, 4, "P");

            place_move(1, 1);
            place_move(2, 2);
            place_move(3, 3);
            place_move(4, 4);
            place_move(5, 5);
        }

        public void placePiece(int x, int y, string piece)
        {
            var item = game_grid.Children.Cast<UIElement>().Where(i => Grid.GetRow(i) == y && Grid.GetColumn(i) == x);
            (item.First() as Button).Content = new Label() { Content = piece };
            (item.First() as Button).Tag = piece; // Peut etre n'importe lequel objet
        }

        public void removePiece(int x, int y)
        {
            var item = game_grid.Children.Cast<UIElement>().Where(i => Grid.GetRow(i) == y && Grid.GetColumn(i) == x);
            (item.First() as Button).Content = null;
            (item.First() as Button).Tag = null;
        }

        public void enable_case(int x, int y)
        {
            var item = game_grid.Children.Cast<UIElement>().Where(i => Grid.GetRow(i) == y && Grid.GetColumn(i) == x);
            (item.First() as Button).IsEnabled = true;
        }

        public void denable_case(int x, int y)
        {
            var item = game_grid.Children.Cast<UIElement>().Where(i => Grid.GetRow(i) == y && Grid.GetColumn(i) == x);
            (item.First() as Button).IsEnabled = false;
        }

        public void place_move(int pos, int id)
        {
            switch (pos)
            {
                case 1:
                    this.Move1.Tag = id;
                    (this.Move1.Content as Image).Source = new BitmapImage(move_card_path[id-1]);
                    break;
                case 2:
                    this.Move2.Tag = id;
                    (this.Move2.Content as Image).Source = new BitmapImage(move_card_path[id-1]);
                    break;
                case 3:
                    this.Move3.Tag = id;
                    (this.Move3.Content as Image).Source = new BitmapImage(move_card_path[id-1]);
                    break;
                case 4:
                    this.Move4.Tag = id;
                    (this.Move4.Content as Image).Source = new BitmapImage(move_card_path[id-1]);
                    break;
                case 5:
                    this.Move5.Tag = id;
                    this.Move5.Source = new BitmapImage(move_card_path[id - 1]);
                    break;
                default:
                    throw new ArithmeticException("Position not right");
            }
        }

        public int remove_move(int pos)
        {
            int id = 0;
            switch (pos)
            {
                case 1:
                    id = (int)this.Move1.Tag;
                    this.Move1.Tag = null;
                    break;
                case 2:
                    id = (int)this.Move2.Tag;
                    this.Move2.Tag = null;
                    break;
                case 3:
                    id = (int)this.Move3.Tag;
                    this.Move3.Tag = null;
                    break;
                case 4:
                    id = (int)this.Move4.Tag;
                    this.Move4.Tag = null;
                    break;
                case 5:
                    id = (int)this.Move5.Tag;
                    this.Move5.Tag = null;
                    break;
                default:
                    throw new ArithmeticException("Position not right");
            }
            return id;
        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)(sender as Button).Tag;
            //Activate case according to the id fetch

            //Change the move
            int pos = Int32.Parse((sender as Button).Name.Replace("Move", ""));
            int newId = remove_move(5);
            place_move(pos, newId);
            place_move(5, id);
        }
    }
}
