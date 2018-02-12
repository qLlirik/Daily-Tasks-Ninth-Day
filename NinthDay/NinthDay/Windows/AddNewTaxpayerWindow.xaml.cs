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
    /// Логика взаимодействия для AddNewTaxpayerWindow.xaml
    /// </summary>
    public partial class AddNewTaxpayerWindow : Window
    {
        DB.Entity db = HelpClasses.StaticClass.InicializateDateBase;
        DB.Taxpayers TaxPayer = new DB.Taxpayers();

        public AddNewTaxpayerWindow()
        {
            InitializeComponent();

            this.DataContext = TaxPayer;
            dpBorn.SelectedDate = DateTime.Now;
            dpDate.SelectedDate = DateTime.Now;
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new AddNewTaxPaymentWindow().Show();
            this.Close();
        }

        private byte[] ImageToByte(string uri)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(new BitmapImage(new Uri(uri,UriKind.Relative))));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            encoder.Save(ms);
            return ms.ToArray();
        }

        private void click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                TaxPayer.Picture = ImageToByte(tbxPath.Text);
                TaxPayer.LastName = tbxFIO.Text.Split(' ')[0];
                TaxPayer.FirstName = tbxFIO.Text.Split(' ')[1];
                TaxPayer.Patronymic = tbxFIO.Text.Split(' ')[2];

                db.Taxpayers.Add(TaxPayer);
                db.SaveChanges();

                if (MessageBox.Show("Добавление нового налогоплательшика прошло успешно! Желаете добавить ещё?","Perfect",MessageBoxButton.YesNo,MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    new AddNewTaxpayerWindow().Show();
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

        private void click_SelectImage(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "All Images|*.png;*.bmp;*.jpg;*.jpeg";
            if (ofd.ShowDialog() == true)
                tbxPath.Text = ofd.FileName;
        }
    }
}
