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
using System.Windows.Controls;
using System.Collections;

namespace GUI
{

    //Voor de user interface wordt er gebruik gemaakt van WPF
    public partial class MainWindow : Window
    {
        List<Strip> stripsFromDb;
        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));
       public Strip selectedStrip;

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
            stripBewerken_button.Visibility = Visibility.Hidden;

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
             
            new EditStrip(selectedStrip).Show();

        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //("Strip id");
            if (SorteerBox.SelectedIndex == 0) {
                
                var smallList = stripsFromDb.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
               
                StripDataGrid.ItemsSource = smallList;
            }
           // ("Strip titel");
            else if (SorteerBox.SelectedIndex == 1) {
                
                var smallList = stripsFromDb.Select(c => new {  c.StripTitel, c.ID, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.StripTitel);
               
                StripDataGrid.ItemsSource = smallList;
            }
            // ("Reeks");
            else if (SorteerBox.SelectedIndex == 2) {
                
                var smallList = stripsFromDb.Select(c => new { Reeks = c.Reeks.Naam, c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs),  c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.Reeks);
               StripDataGrid.ItemsSource = smallList;
            }
            //("Uitgeverij");
            else if (SorteerBox.SelectedIndex == 3) {
                
                var smallList = stripsFromDb.Select(c => new { Uitgeverij = c.Uitgeverij.Naam, c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr }).OrderBy(s => s.Uitgeverij); ;
                StripDataGrid.ItemsSource = smallList;
            }


        }

        private void DataGridSelectie(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedStrip = null;
            String x = StripDataGrid.SelectedItem.ToString();
            string[] words = x.Split(',');
            
            x = words.Where(x => x.Contains("ID =")).FirstOrDefault();
            x = x.Replace("ID = ", "").Replace("{", "").Replace("}", "").Trim();
          
            //haalt de gekozen strip op en geeft die weer mee
            selectedStrip = stripsFromDb.Where(s => s.ID.ToString().Equals(x)).FirstOrDefault();
            if(selectedStrip != null) { 
            stripBewerken_button.Visibility = Visibility.Visible;
            }
        }

        private void Button_Zoek_Click(object sender, RoutedEventArgs e)
        {
            List<Strip> listStrip = new List<Strip>();

            if (RadioBtnStripid.IsChecked == true)
            {
                Strip helpstrip = generalManager.StripManager.GetById(Convert.ToInt32( SearchTextBox.Text));
                listStrip.Add(helpstrip);
                try
                {
                    if (helpstrip != null) {
                    var smallList = listStrip.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
                    StripDataGrid.ItemsSource = smallList;
                    }
                }
                catch (NullReferenceException ex) { } 
                }
            else if (RadioBtnStriptittel.IsChecked == true)
            {
                try { 
                List<Strip> strips = stripsFromDb.Where(b=> b.StripTitel.Equals(SearchTextBox.Text)).ToList();
                    
                    try
                    {
                        if (strips != null)
                        {
                            var smallList = strips.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
                            StripDataGrid.ItemsSource = smallList;
                        }
                    }
                    catch (NullReferenceException ex) { }

                }
                catch //als strip niet bestaat  
                { }
                   

            }
            else if (RadioBtnReeks.IsChecked == true)
            {
                try
                {
                    List<Strip> strips = stripsFromDb.Where(b => b.Reeks.Equals(SearchTextBox.Text)).ToList();

                    try
                    {
                        if (strips != null)
                        {
                            var smallList = strips.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
                            StripDataGrid.ItemsSource = smallList;
                        }
                    }
                    catch (NullReferenceException ex) { }

                }
                catch //als strip niet bestaat  
                { }

            }
            else if (RadioBtnAuteur.IsChecked == true)
            {
                try
                {

                    List<Strip> strips = stripsFromDb.Where(b => b.Auteurs.Equals(generalManager.AuteurManager.GetByName(SearchTextBox.Text))).ToList();

                    try
                    {
                        if (strips != null)
                        {
                            var smallList = strips.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
                            StripDataGrid.ItemsSource = smallList;
                        }
                    }
                    catch (NullReferenceException ex) { }

                }
                catch //als strip niet bestaat  
                { }

            }
            else if (RadioBtnUitgeverij.IsChecked == true)
            {
                try
                {
                    List<Strip> strips = generalManager.StripManager.GetAll().Where(b => b.Uitgeverij.Equals(SearchTextBox.Text)).ToList();

                    try
                    {
                        if (strips != null)
                        {
                            var smallList = strips.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
                            StripDataGrid.ItemsSource = smallList;
                        }
                    }
                    catch (NullReferenceException ex) { }

                }
                catch //als strip niet bestaat  
                { }
            }
        }

        private void Button_Reset_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
            RadioBtnStripid.IsChecked = true;
            selectedStrip = null;
            SorteerBox.SelectedIndex = 0;
            var smallList = stripsFromDb.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
            StripDataGrid.ItemsSource = smallList;

        }
    }
}
