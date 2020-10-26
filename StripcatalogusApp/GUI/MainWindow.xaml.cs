using Datalaag;
using Datalaag.Models;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GUI
{

    //Voor de user interface wordt er gebruik gemaakt van WPF
    public partial class MainWindow : Window
    {
        IEnumerable<Strip> stripsFromDb;

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

            StripRepository sr = new StripRepository(DbFunctions.GetprojectwerkconnectionString()); //werkt
            #endregion
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            stripsFromDb = sr.GetAll(); // duurt heel lang...
            stopWatch.Stop();
            // Kijken hoelang het duurde
            // duurt 01min 49sec
            TimeSpan ts = stopWatch.Elapsed;



            string AuteursToString(List<Auteur> deze)
            {
                if (deze.Count > 1)
                { //als meerdere auteurs
                    var res = deze.Select(o => o.Naam.Trim()).Aggregate(
                     "", // start with empty string to handle empty list case.

                    (current, next) => current + ", " + next );
                    res = res.Remove(0, 2); //hij voegt ", " toe in de begin, ik verwijder die hier
                    return res;
                }
                else return deze.Select(o => o.Naam).FirstOrDefault();
            }

            // duurt 00.0004371 seconden
            var smallList = stripsFromDb.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam });
            



            StripDataGrid.ItemsSource = smallList;
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
