using Businesslaag.Models;
using Businesslaag.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Businesslaag.Repositories;
using Datalaag.Repositories;
using Datalaag;

namespace GUI
{

    //Voor de user interface wordt er gebruik gemaakt van WPF
    public partial class MainWindow : Window
    {
        List<Strip> stripsFromDb;
        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));


        public MainWindow()
        {


            InitializeComponent();
        }

        private string AuteursToString(List<Auteur> deze)
        {
            if (deze.Count > 1)
            { //als meerdere auteurs
                var res = deze.Select(o => o.Naam.Trim()).Aggregate(
                 "", // start with empty string to handle empty list case.

                (current, next) => current + ", " + next);
                res = res.Remove(0, 2); //hij voegt ", " toe in de begin, ik verwijder die hier
                return res;
            }
            else return deze.Select(o => o.Naam).FirstOrDefault();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dit zet boeken icoontje links vanboven
            Uri iconUri = new Uri("../../../Images/book.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri); //zet icon linker bovenhoek van window

            stripsFromDb = generalManager.StripManager.GetAll();

            SorteerBox.Items.Add("Strip id");
            SorteerBox.Items.Add("Strip titel");
            SorteerBox.Items.Add("Reeks");
            SorteerBox.Items.Add("Uitgeverij");
            SorteerBox.SelectedIndex = 0;


        }

        private void Button_MaakStrip_Click(object sender, RoutedEventArgs e)
        {
            MaakScherm w2 = new MaakScherm(); //maak reservatie window openen
            w2.ShowDialog();

            // window reset// voor als er nieuwe reserveringen zijn gemaakt
            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            this.Close();
        }

      
        private void Button_Bijwerk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //("Strip id");
            if (SorteerBox.SelectedIndex == 0) {
                
                var smallList = stripsFromDb.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
               
                StripDataGrid.ItemsSource = smallList;
            }
           // ("Strip titel");
            if (SorteerBox.SelectedIndex == 1) {
                
                var smallList = stripsFromDb.Select(c => new {  c.StripTitel, c.ID, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.StripTitel);
               
                StripDataGrid.ItemsSource = smallList;
            }
           // ("Reeks");
            if (SorteerBox.SelectedIndex == 2) {
                
                var smallList = stripsFromDb.Select(c => new { Reeks = c.Reeks.Naam, c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs),  c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.Reeks);
               StripDataGrid.ItemsSource = smallList;
            }
            //("Uitgeverij");
            if (SorteerBox.SelectedIndex == 3) {
                
                var smallList = stripsFromDb.Select(c => new { Uitgeverij = c.Uitgeverij.Naam, c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr }).OrderBy(s => s.Uitgeverij); ;
                StripDataGrid.ItemsSource = smallList;
            }


        }
    }
}
