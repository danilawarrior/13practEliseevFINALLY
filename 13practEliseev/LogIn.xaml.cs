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
using System.Windows.Shapes;

namespace _13practEliseev
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }
        
        private void Window_Activated(object sender, RoutedEventArgs e)
        {
            txtpassword.Focus();
        }

        private void enterIn(object sender, RoutedEventArgs e)
        {
            if (txtpassword.Password == "123") Close();
            else
            {
                MessageBox.Show("Пароль неверен, попробуй еще раз");
                txtpassword.Focus();
            }
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();
        }
    }
}
