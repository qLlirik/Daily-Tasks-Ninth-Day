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

namespace NinthDay.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewTaxPaymentWindow.xaml
    /// </summary>
    public partial class AddNewTaxPaymentWindow : Window
    {
        DB.Entity db = HelpClasses.StaticClass.InicializateDateBase;
        DB.TaxPayment TaxPayment = new DB.TaxPayment();

        public AddNewTaxPaymentWindow()
        {
            InitializeComponent();

            cbxTaxpayer.ItemsSource = db.Taxpayers.ToList();
            cbxTaxpayer.DisplayMemberPath = "FullName";

            cbxEnterprise.ItemsSource = db.Enterprises.ToList();
            cbxEnterprise.DisplayMemberPath = "Name";

            this.DataContext = TaxPayment;
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void click_AddNewEnterpriseWindowOpen(object sender, RoutedEventArgs e)
        {
            new AddNewEnterpriseWindow().Show();
            this.Close();
        }

        private void click_AddNewTaxpayerWindowOpen(object sender, RoutedEventArgs e)
        {
            new AddNewTaxpayerWindow().Show();
            this.Close();
        }

        private void click_Add(object sender, RoutedEventArgs e)
        {
            TaxPayment.DateTax = DateTime.Now;
            try
            {
                TaxPayment.NumberTax = int.Parse(db.TaxPayment.ToList().Last().NumberTax) + 1 + "";
            }
            catch 
            {
                TaxPayment.NumberTax = "1";
            }
            db.TaxPayment.Add(TaxPayment);
            db.SaveChanges();

            if (MessageBox.Show("Добавление декларации прошло успешно! Желаете добавить ещё?", "Perfect", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                new AddNewTaxPaymentWindow().Show();
                this.Close();
            }
            else
                click_Back(null,null);
        }
    }
}
