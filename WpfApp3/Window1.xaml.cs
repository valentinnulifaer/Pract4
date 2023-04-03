using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp3._c_DataSetTableAdapters;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        GameTableAdapter game = new GameTableAdapter();
        public Window1()
        {
            InitializeComponent();
            Game.ItemsSource = game.GetData();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string test = NameTxc.Text;
            int Test = Convert.ToInt32(test);
            game.InsertQuery(NameTcx.Text, NameTbx.Text, Test);
            Game.ItemsSource = game.GetData();
        }

        private void NameTvx_Click(object sender, RoutedEventArgs e)
        {
            if (Game.SelectedItem != null)
            {
                object gel = (Game.SelectedItem as DataRowView).Row[0];
                game.DeleteQuery(Convert.ToInt32(gel));
                Game.ItemsSource = game.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string test = NameTxc.Text;
            int Test = Convert.ToInt32(test);
            object sel = (Game.SelectedItem as DataRowView).Row[0];
            game.UpdateQuery(NameTcx.Text, NameTbx.Text, Test, Convert.ToInt32(sel));
            Game.ItemsSource = game.GetData();
        }
    }
}
