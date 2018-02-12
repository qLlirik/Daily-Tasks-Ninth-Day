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

namespace NinthDay
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DB.Entity db = HelpClasses.StaticClass.InicializateDateBase;

        public MainWindow()
        {
            InitializeComponent();

            click_Search(null,null);
        }

        private void click_AddNewPaymentWindowOpen(object sender, RoutedEventArgs e)
        {
            new Windows.AddNewTaxPaymentWindow().Show();
            this.Close();
        }

        private void click_Search(object sender, RoutedEventArgs e)
        {
            var qwery = db.TaxPayment.Where(w => w.ID != null);
            if (cbxSearch.Text.Length != 0)
                qwery = qwery.Where(w => w.Taxpayers.LastName.Contains(cbxSearch.Text) || w.Taxpayers.FirstName.Contains(cbxSearch.Text) ||w.Taxpayers.Patronymic.Contains(cbxSearch.Text));
            if (qwery.Count() != 0)
                lv.ItemsSource = qwery.ToList();
            else
                MessageBox.Show("Поиск недал результатов!","Error",MessageBoxButton.OK,MessageBoxImage.Warning);
        }

        private void keydown_cbxSearch(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                click_Search(null,null);
        }

        private void click_Info(object sender, RoutedEventArgs e)
        {
            HelpClasses.StaticClass.SelectTaxPayment = (DB.TaxPayment)((Button)sender).DataContext;
            new Windows.TaxPaymentInfoWindow().Show();
            this.Close();
        }
    }
}
