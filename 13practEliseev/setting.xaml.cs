using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для setting.xaml
    /// </summary>
    public partial class setting : Window
    {
        public setting()
        {
            InitializeComponent();
        }

        private void calculateTaskSetting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowCount = Int32.Parse(amountOfRow.Text);
                int columnCount = Int32.Parse(amountOfColumns.Text);

                StreamWriter streamWriter = new("config1.ini");
                using (streamWriter)
                {
                    streamWriter.WriteLine(rowCount);
                    streamWriter.WriteLine(columnCount);
                    Close();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Данные введены неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void countOfColumns_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void countOfRows_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
