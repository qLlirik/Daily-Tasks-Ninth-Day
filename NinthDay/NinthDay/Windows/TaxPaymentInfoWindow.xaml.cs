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
    /// Логика взаимодействия для TaxPaymentInfoWindow.xaml
    /// </summary>
    public partial class TaxPaymentInfoWindow : Window
    {
        public TaxPaymentInfoWindow()
        {
            InitializeComponent();

            spTaxPayer.DataContext = HelpClasses.StaticClass.SelectTaxPayment.Taxpayers;
            spEnterprises.DataContext = HelpClasses.StaticClass.SelectTaxPayment.Enterprises;
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
