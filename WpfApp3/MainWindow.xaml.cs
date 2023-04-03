using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp3._c_DataSetTableAdapters;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CharactersTableAdapter characters = new CharactersTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            Characters.ItemsSource = characters.GetData();
        }
        private void Characters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Characters.SelectedItem != null)
            {
                var sel = Characters.SelectedItem as DataRowView;
                MessageBox.Show(sel.Row[1] + "" + sel.Row[2]);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            characters.InsertQuery(NameTcx.Text, NameTbx.Text);
            Characters.ItemsSource = characters.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Characters.SelectedItem != null) {
                object sel = (Characters.SelectedItem as DataRowView).Row[0];
                characters.DeleteQuery(Convert.ToInt32(sel));
                Characters.ItemsSource = characters.GetData();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            object sel = (Characters.SelectedItem as DataRowView).Row[0];
            characters.UpdateQuery(NameTcx.Text, NameTbx.Text, Convert.ToInt32(sel));
            Characters.ItemsSource = characters.GetData();
        }
    }
}
