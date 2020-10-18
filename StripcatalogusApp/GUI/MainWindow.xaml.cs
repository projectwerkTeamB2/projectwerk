using businesslaag;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
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

namespace GUI
{

    //Voor de user interface wordt er gebruik gemaakt van WPF
    public partial class MainWindow : Window
    {


        public MainWindow()
        {


            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dit zet boeken icoontje links vanboven
            Uri iconUri = new Uri("../../../Images/book.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri); //zet icon linker bovenhoek van window

            #region connectie db
            DbProviderFactories.RegisterFactory("sqlserver", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("sqlserver");

            StripRepository sr = new StripRepository(sqlFactory);
            #endregion

            IEnumerable<Strip> stripsFromDb = sr.FindAll_strip();
            StripDataGrid.ItemsSource = stripsFromDb;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MaakScherm w2 = new MaakScherm(); //maak reservatie window openen
            w2.ShowDialog();

            // window reset// voor als er nieuwe reserveringen zijn gemaakt
            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            this.Close();
        }
    }
}
