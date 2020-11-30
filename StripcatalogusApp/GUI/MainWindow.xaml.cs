using Businesslaag.Models;
using Businesslaag.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Datalaag.Repositories;
using Datalaag;

namespace GUI
{

    //Voor de user interface wordt er gebruik gemaakt van WPF
    public partial class MainWindow : Window
    {
        List<Strip> stripsFromDb;
        List<Strip> showingStrips;
        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));
       public Strip selectedStrip;

        public MainWindow()
        {


            InitializeComponent();
        }

        private string AuteursToString(List<Auteur> deze) //om de auteurs van stripboeken duidelijk te tonen in datagrid
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
            showingStrips = stripsFromDb;
            stripBewerken_button.Visibility = Visibility.Hidden;
            bin_image.Visibility = Visibility.Collapsed;

            SorteerBox.Items.Add("Strip id");
            SorteerBox.Items.Add("Strip titel");
            SorteerBox.Items.Add("Reeks");
            SorteerBox.Items.Add("Uitgeverij");
            SorteerBox.SelectedIndex = 0;


        }

        private void Button_MaakStrip_Click(object sender, RoutedEventArgs e)
        {
            MaakScherm w2 = new MaakScherm(); //maak window openen
            w2.ShowDialog();

            // window reset// voor als er nieuwe strips zijn gemaakt
            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            this.Close();
            newWindow.Show();
        }

      
        private void Button_Bijwerk_Click(object sender, RoutedEventArgs e)
        {

            // new EditStrip(selectedStrip).Show();
            EditStrip w2 = new EditStrip(selectedStrip); //maak window openen
            w2.ShowDialog();

            // window reset// 
            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            this.Close();
            newWindow.Show();
            
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            //("Strip id");
            if (SorteerBox.SelectedIndex == 0) {
                
                var smallList = showingStrips.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
               
                StripDataGrid.ItemsSource = smallList;
            }
           // ("Strip titel");
            else if (SorteerBox.SelectedIndex == 1) {
                
                var smallList = showingStrips.Select(c => new {  c.StripTitel, c.ID, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.StripTitel);
               
                StripDataGrid.ItemsSource = smallList;
            }
            // ("Reeks");
            else if (SorteerBox.SelectedIndex == 2) {
                
                var smallList = showingStrips.Select(c => new { Reeks = c.Reeks.Naam, c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs),  c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.Reeks);
               StripDataGrid.ItemsSource = smallList;
            }
            //("Uitgeverij");
            else if (SorteerBox.SelectedIndex == 3) {
                
                var smallList = showingStrips.Select(c => new { Uitgeverij = c.Uitgeverij.Naam, c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr }).OrderBy(s => s.Uitgeverij); ;
                StripDataGrid.ItemsSource = smallList;
            }


        }

        private void DataGridSelectie(object sender, System.Windows.Controls.SelectionChangedEventArgs e) //als er een strip geselecteerd is
        {  
            if(StripDataGrid.SelectedItem != null) { 
             selectedStrip = null;
            String x = StripDataGrid.SelectedItem.ToString();
            string[] words = x.Split(',');
            
            x = words.Where(x => x.Contains("ID =")).FirstOrDefault();
            x = x.Replace("ID = ", "").Replace("{", "").Replace("}", "").Trim();
          
            //haalt de gekozen strip op en geeft die weer mee
            selectedStrip = stripsFromDb.Where(s => s.ID.ToString().Equals(x)).FirstOrDefault();
                if (selectedStrip != null)
                {
                    stripBewerken_button.Visibility = Visibility.Visible;
                    bin_image.Visibility = Visibility.Visible;
                }
                else { stripBewerken_button.Visibility = Visibility.Collapsed; 
                    bin_image.Visibility = Visibility.Collapsed; }
            }
        }

        private void Button_Zoek_Click(object sender, RoutedEventArgs e)
        {
            List<Strip> listStrip = new List<Strip>();

            if (RadioBtnStripid.IsChecked == true)
            {


                if (SearchTextBox.Text.All(Char.IsDigit))
                {  //als een getal dan
                    Strip helpstrip = generalManager.StripManager.GetById(Convert.ToInt32(SearchTextBox.Text));
                    showingStrips.Clear();
                    showingStrips.Add(helpstrip);

                    listStrip.Add(helpstrip);
                    try
                    {
                        if (helpstrip != null)
                        {
                            var smallList = listStrip.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
                            
                            StripDataGrid.ItemsSource = smallList;
                        }
                    }
                    catch (NullReferenceException ex) { }
                }
                else { StripDataGrid.ItemsSource = null; } //niet geldige ingave
            }
            else if (RadioBtnStriptittel.IsChecked == true)
            {
                try { 
                List<Strip> strips = stripsFromDb.Where(b=> b.StripTitel.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
                    showingStrips.Clear();
                    showingStrips.AddRange(strips);

                    try
                    {
                        if (strips != null)
                        {
                            var smallList = strips.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
                            StripDataGrid.ItemsSource = smallList;

                        }
                    }
                    catch (NullReferenceException ex) { StripDataGrid.ItemsSource = null; }

                }
                catch (Exception ex) { StripDataGrid.ItemsSource = null; }


            }
            else if (RadioBtnReeks.IsChecked == true)
            {
                try { 
                    List<Strip> strips = stripsFromDb.Where(b => b.Reeks.Naam.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
                    showingStrips.Clear();
                    showingStrips.AddRange(strips);

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

                    List<Strip> strips = stripsFromDb.Where(b => b.Auteurs.Any(c=>c.Naam.ToUpper().Contains(SearchTextBox.Text.ToUpper()))).ToList();
                    showingStrips.Clear();
                    showingStrips.AddRange(strips);

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
                    List<Strip> strips = stripsFromDb.Where(b => b.Uitgeverij.Naam.ToUpper().Contains(SearchTextBox.Text.ToUpper())).ToList();
                    showingStrips.Clear();
                    showingStrips.AddRange(strips);

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
            showingStrips = generalManager.StripManager.GetAll();
            stripsFromDb = generalManager.StripManager.GetAll();
            var smallList = stripsFromDb.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam }).OrderBy(s => s.ID);
           
            StripDataGrid.ItemsSource = smallList;

        }

        private void BinClicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Ben je zeker dat je deze strip wil verwijderen?: \n" + selectedStrip.ToString(), "bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    generalManager.StripManager.Delete(selectedStrip);

                    MainWindow newWindow = new MainWindow(); //herstart de scherm, zodat het laad zonder verwijderde
                    Application.Current.MainWindow = newWindow;
                    this.Close();
                    newWindow.Show();
                }
            }
            catch (Exception ex) { }
        }

        private void Button_plusReeks_Click(object sender, RoutedEventArgs e) //nieuwe reeks toevoegen
        {
            AddReeksOrUitgeverij inputDialog = new AddReeksOrUitgeverij("Schrijf de naam van de nieuwe reeks: ", "");
            if (inputDialog.ShowDialog() == true) { 
                string Answer = inputDialog.Answer;
                try
                {
                    generalManager.ReeksManager.Add(new Reeks(generalManager.ReeksManager.GetAll().OrderBy(b => b.ID).Last().ID + 1, Answer.ToString().Trim()));
                    MessageBox.Show("Gelukt!");
                }
                catch (Exception ex) { MessageBox.Show("Er is iets fout gegaan, mogelijks bestaat deze reeks al.\n\nDetails: " + ex); }

            }
        }

        private void Button_plusUitgeverij_Click(object sender, RoutedEventArgs e) //nieuwe Uitgeverij toevoegen
        {
            AddReeksOrUitgeverij inputDialog = new AddReeksOrUitgeverij("Schrijf de naam van de nieuwe uitgeverij: ", "");
            if (inputDialog.ShowDialog() == true)
            {
                string Answer = inputDialog.Answer;
                try
                {
                    generalManager.UitgeverijManager.Add(new Uitgeverij(generalManager.UitgeverijManager.GetAll().OrderBy(b => b.ID).Last().ID + 1,Answer.ToString().Trim()));
                    MessageBox.Show("Gelukt!");
                }
                catch (Exception ex) { MessageBox.Show("Er is iets fout gegaan, mogelijks bestaat deze uitgeverij al.\n\nDetails: " + ex); }

            }
        }

        private void Button_plusAuteur_Click(object sender, RoutedEventArgs e) //nieuwe auteur toevoegen
        {
            AddReeksOrUitgeverij inputDialog = new AddReeksOrUitgeverij("Schrijf de naam van de nieuwe Auteur: ", "");
            if (inputDialog.ShowDialog() == true)
            {
                string Answer = inputDialog.Answer;
                try
                {
                    generalManager.AuteurManager.Add(new Auteur(generalManager.AuteurManager.GetAll().OrderBy(b => b.ID).Last().ID + 1, Answer.ToString().Trim()));
                    MessageBox.Show("Gelukt!");
                }
                catch (Exception ex) { MessageBox.Show("Er is iets fout gegaan, mogelijks bestaat deze Auteur al.\n\nDetails: " + ex); }

            }
        }
    }
}
