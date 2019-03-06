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

namespace Errr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public bool test(int n)
        {
            if (n < 1) throw new ArgumentException ("Число должно быть > 1");

                for (int i = 2; i < n; i++)
                    if (n % i == 0) return false;

            return true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool a = test(int.Parse(tb.Text));


                if (a == false) MessageBox.Show("Число не простое");//throw new ArgumentException("Число не простое");
                else inp.Items.Add(int.Parse(tb.Text));
                tb.Text = "";
            }

            catch (FormatException)
            {
                lb.Content = "не корректный ввод: вводится не число";
            }

            catch (ArgumentException ex) //реакция на неверный аргумент
            {
                lb.Content = ex.Message;
            }

        }


        private void load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            dlg.ShowDialog();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(dlg.FileName);

            while ((line = file.ReadLine()) != null)
            {

            }
            file.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.ShowDialog();


        }
    }
}
