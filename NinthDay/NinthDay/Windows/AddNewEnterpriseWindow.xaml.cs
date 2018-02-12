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
    /// Логика взаимодействия для AddNewEnterpriseWindow.xaml
    /// </summary>
    public partial class AddNewEnterpriseWindow : Window
    {
        DB.Entity db = HelpClasses.StaticClass.InicializateDateBase;
        DB.Enterprises Enterpise = new DB.Enterprises();

        public AddNewEnterpriseWindow()
        {
            InitializeComponent();
            this.DataContext = Enterpise;
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new AddNewTaxPaymentWindow().Show();
            this.Close();
        }

        private void click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((tbxName.Text.Length == 0) && (tbxINN.Text.Length == 0) && (tbxAddress.Text.Length == 0) && (tbxChief.Text.Length == 0) && (tbxPhone.Text.Length == 0))
                    throw new Exception();

                db.Enterprises.Add(Enterpise);
                db.SaveChanges();

                if (MessageBox.Show("Добавление новой организации прошло успешно! Желаете добавить ещё?", "Perfect", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    new AddNewEnterpriseWindow().Show();
                    this.Close();
                }
                else
                    click_Back(null,null);
            }
            catch
            {
                MessageBox.Show("Введите корректные данные!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
