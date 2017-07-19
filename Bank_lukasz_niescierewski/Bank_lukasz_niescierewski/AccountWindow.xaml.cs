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
    /// Interaction logic for NoweKonto.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        ListAccount lk = new ListAccount();
       
        public AccountWindow()
        {
            InitializeComponent(); 
        }

        private void B_ok_account_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void B_cancel_account_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

            //MainWindow mw = ((MainWindow)this.Owner); // odwołanie z okna podrzędnego do obiektów, parametrów  itp. okna głównego
                  
    }
}
