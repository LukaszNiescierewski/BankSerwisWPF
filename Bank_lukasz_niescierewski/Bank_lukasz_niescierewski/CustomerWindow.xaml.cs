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

namespace Bank_lukasz_niescierewski
{
    /// <summary>
    /// Interaction logic for NowyKlient.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
            TB_surname.Focus();
        }

        private void B_ok_customer_Click(object sender, RoutedEventArgs e)
        {
            double err = 0;
            if (TB_surname.Text.Length < 3 || TB_name.Text.Length < 3 || 
                double.TryParse(TB_surname.Text, out err) == true || double.TryParse(TB_name.Text, out err) == true)
            {
                MessageBox.Show("Sprawdź poprawnośc wprowadzenia danych", "Nieprawidłowo wypełnione pola Imie i Nazwisko.",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                DialogResult = true;
        }

        private void B_cancel_customer_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
