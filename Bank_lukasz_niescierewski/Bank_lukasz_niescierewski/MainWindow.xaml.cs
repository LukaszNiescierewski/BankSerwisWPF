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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Bank_lukasz_niescierewski
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListCustomers lk = new ListCustomers();
        ListAccount kk = new ListAccount();


        public MainWindow()
        {
            InitializeComponent();

            Customer k1 = new Customer("Kowalski", "Jan");
            Customer k2 = new Customer("Nowak", "Andrzej");
            Customer k3 = new Customer("Bencławski", "Witalis");

            Account ror1 = new ROR(1234, 1500);
            Account ror2 = new ROR(4321, 2500);
            Account ror3 = new ROR(1111, 3200);

            Account lokata1 = new Investment(5678, 1000);
            Account lokata2 = new Investment(8765, 500);
            Account lokata3 = new Investment(2222, 200);

            Account karta1 = new CreditCard(3333, 1020);
            Account karta2 = new CreditCard(4444, 5000);
            Account karta3 = new CreditCard(5555, 2000);

            kk.Plus(ror1, k1);
            kk.Plus(ror2, k2);
            kk.Plus(ror3, k3);

            kk.Plus(lokata1, k1);
            kk.Plus(lokata2, k2);
            kk.Plus(lokata3, k3);

            kk.Plus(karta1, k1);
            kk.Plus(karta2, k2);
            kk.Plus(karta3, k3);

            lk.Plus(k2);
            lk.Plus(k3);
            lk.Plus(k1);

            UpdateComboBox();
        }

        private void B_add_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow nk = new CustomerWindow();
            nk.ShowDialog();

            if (nk.DialogResult == true)
            {
                Customer k = new Customer(nk.TB_surname.Text.ToString(), nk.TB_name.Text.ToString());
                lk.Plus(k);
                CB_list_customers.Items.Add(k);
            }
        }

        private void B_add_account_Click(object sender, RoutedEventArgs e)
        {
            //generowanie losowego numeru konta
            int nraccount = 0;
            Random rnd = new Random();
            nraccount = rnd.Next(10000, 99999);

            //sprawdzenie czy konto o wylosowanym numerze istnieje, jesli tak to generuj nowy nr
            foreach (KeyValuePair<Account, Customer> o in kk.List_Account)
            {
                if (o.Key.Number.Equals(nraccount) == true)
                    nraccount = rnd.Next(10000, 99999);
            }

            AccountWindow new_account = new AccountWindow();

            if (CB_list_customers.SelectedIndex >= 0)
            {
                Customer k = CB_list_customers.SelectedItem as Customer; // rzutowanie na klasę klient 
                new_account.TB_nraccount_generate.Text = nraccount.ToString();
                new_account.ShowDialog();

                //nkonto.Owner = this; // potrzebne by z okna podrzednego można było odwoalc się do zasobów MainWindow

                if (new_account.DialogResult == true)
                {
                    switch (new_account.CB_type_account.Text.ToString())
                    {
                        case "ROR":
                            Account NewKonto = new ROR(nraccount, 0);
                            kk.Plus(NewKonto, k);
                            break;
                        case "Lokata":
                            Account NewKonto1 = new Investment(nraccount, 0);
                            kk.Plus(NewKonto1, k);
                            break;
                        case "Karta kredytowa":
                            Account NewKonto2 = new CreditCard(nraccount, 0);
                            kk.Plus(NewKonto2, k);
                            break;
                    }
                }
            }
            UpdateListBox();
        }

        private void CB_list_customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListBox();
        }

        private void B_pay_Click(object sender, RoutedEventArgs e)
        {
            decimal payment;
            Account nk = LB_accounts.SelectedItem as Account;

            foreach (KeyValuePair<Account, Customer> o in kk.List_Account)
            {
                if (o.Key.Equals(nk) == true)
                {
                    if (decimal.TryParse(TB_pay_payoff.Text, out payment))
                    {
                        nk.Pay(payment);
                        LB_accounts.Items.Refresh();
                    }
                }
            }
        }

        private void B_payoff_Click(object sender, RoutedEventArgs e)
        {
            decimal payoff;
            Account nk = LB_accounts.SelectedItem as Account;

            foreach (KeyValuePair<Account, Customer> o in kk.List_Account)
            {
                if (o.Key.Equals(nk) == true)
                {
                    if (decimal.TryParse(TB_pay_payoff.Text, out payoff))
                    {
                        nk.Payoff(payoff);
                        LB_accounts.Items.Refresh();
                    }
                }
            }
        }

        private void B_remove_account_Click(object sender, RoutedEventArgs e)
        {
            if (LB_accounts.SelectedIndex >= 0)
            {
                Customer kl = CB_list_customers.SelectedItem as Customer; // rzutowanie na klase klient
                Account ko = LB_accounts.SelectedItem as Account; //rzutowanie na klase konto

                //przegladanie słownika w poszukiwaniu zaznaczonego konta
                foreach (KeyValuePair<Account, Customer> acc_search in kk.List_Account)
                {
                    if (acc_search.Key.Equals(ko) == true)
                    {
                        if (MessageBox.Show(
                            "Czy na pewno chesz usunąć wskazane konto?", "Usuwanie konta",
                            MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            foreach (KeyValuePair<Account, Customer> o in kk.List_Account) //usunięcie pozycji słownika <Konto, Klient>
                            {
                                if (o.Key.Equals(ko))
                                {
                                    kk.Remove(o.Key);
                                    break;
                                }
                            }
                            break;
                        }
                        else
                            break;
                    }
                }
                UpdateListBox();
            }
        }

        private void B_save_Click(object sender, RoutedEventArgs e)
        {
            // serializacja - zapis listy klientow do pliku txt
            ISerialization txtSave = new TxtSerialization();
            txtSave.Serialized("lista_klientow.txt", lk);

            // serializacja - zapis listy klientów i słownika do pliku bin
            ISerialization save = new BinSerialization();
            save.Serialized("lista_klinetow.bin", lk.Customers);

            ISerialization save2 = new BinSerialization();
            save2.Serialized("lista_kont.bin", kk.List_Account);

            // serializacja - zapis listy klientów i słownika do pliku XML
            ISerialization XmlSave = new XmlSerialization();
            XmlSave.Serialized("lista_klientow.xml", lk.Customers, typeof(List<Customer>));

            ISerialization XmlSave2 = new XmlSerialization();
            XmlSave2.Serialized("lista_kont.xml", kk.List_Account, typeof(Dictionary<Account, Customer>));

           /*
            XmlSerializer xs = new XmlSerializer(typeof(List<Customer>));
            TextWriter sw = null;
            try
            {
                sw = new StreamWriter("lista_klientow.xml");
                xs.Serialize(sw, lk.Customers);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
            */
        }

        private void B_read_Click(object sender, RoutedEventArgs e)
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("lista_klinetow.bin", FileMode.Open);
            List<Customer> customer_secondary = new List<Customer>();
            customer_secondary = (List<Customer>)bf.Deserialize(fs);
            fs.Close();
            lk.Clear();
            foreach (Object o in customer_secondary)
            {
                lk.Plus(o as Customer);
            }
            CB_list_customers.Items.Refresh();

            BinaryFormatter bin = new BinaryFormatter();
            fs = new FileStream("lista_kont.bin", FileMode.Open);
            Dictionary<Account, Customer> dictionary_secondary = new Dictionary<Account, Customer>();
            dictionary_secondary = (Dictionary<Account, Customer>)bin.Deserialize(fs);
            fs.Close();
            kk.Clear();
            foreach (KeyValuePair<Account, Customer> o in dictionary_secondary)
            {
                kk.Plus(o.Key as Account, o.Value as Customer);
            }
            LB_accounts.Items.Refresh();
            
            UpdateComboBox();

        }
        public void UpdateListBox()
        {
            LB_accounts.Items.Clear();
            Customer k = CB_list_customers.SelectedItem as Customer; // rzutowanie na klasę klient 
            foreach (KeyValuePair<Account, Customer> o in kk.List_Account)
            {
                if (o.Value.Equals(k) == true)
                {
                    LB_accounts.Items.Add(o.Key as Account);
                }
            }
        }
        public void UpdateComboBox()
        {
            CB_list_customers.Items.Clear();

            List<Customer> customer_secondary = new List<Customer>();
            bool bFirst = false;
            bool bDifrent = true;
            foreach (KeyValuePair<Account, Customer> o in kk.List_Account)
            {
                if (!bFirst)
                {
                    CB_list_customers.Items.Add(o.Value as Customer);
                    customer_secondary.Add(o.Value as Customer);
                    bFirst = true;
                }
                foreach (Object pom_k in customer_secondary)
                {
                    if (o.Value.Equals(pom_k))
                        bDifrent = false;
                }
                if (bDifrent)
                {
                    CB_list_customers.Items.Add(o.Value as Customer);
                    customer_secondary.Add(o.Value as Customer);
                }
                bDifrent = true;
            }
        }
    }
}

