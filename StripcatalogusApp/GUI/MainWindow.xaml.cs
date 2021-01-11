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
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace GUI
{

    //Voor de user interface wordt er gebruik gemaakt van WPF
    public partial class MainWindow : Window
    {
        List<Strip> stripsFromDb; //houd stri^ps van databank bij
        List<Strip> showingStrips; //houd de huidig getoonde strips bij
        List<StripCollection> stripCollectionsFromDb; //houd de strip collecties van de databank bij

        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));
       public Strip selectedStrip; //huidig geselecteerde strip van de datagrid
        public StripCollection selectedStripCollection; //huidig geselecteerde strip collection van de datagrid

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
        private string StripsToString(List<Strip> deze) //om de auteurs van stripboeken duidelijk te tonen in datagrid
        {
            if (deze.Count > 1)
            { //als meerdere auteurs
                var res = deze.Select(o => o.StripTitel.Trim()).Aggregate(
                 "", // start with empty string to handle empty list case.

                (current, next) => current + ", " + next);
                res = res.Remove(0, 2); //hij voegt ", " toe in de begin, ik verwijder die hier
                return res;
            }
            else return deze.Select(o => o.StripTitel).FirstOrDefault();
        }
        private string StripCollToString(List<StripCollection> deze) //om de auteurs van stripboeken duidelijk te tonen in datagrid
        
        {
            if (deze.Count > 1)
            { //als meerdere auteurs
                var res = deze.Select(o => o.Titel.Trim()).Aggregate(
                 "", // start with empty string to handle empty list case.

                (current, next) => current + ", " + next);
                res = res.Remove(0, 2); //hij voegt ", " toe in de begin, ik verwijder die hier
                return res;
            }
            else return deze.Select(o => o.Titel).FirstOrDefault();
        }

        private void SetDataGridColumnsWidth() {
         
                StripDataGrid.Columns[0].Width = 40;
                StripDataGrid.Columns[1].Width = 200;
                StripDataGrid.Columns[2].Width = 210;
                StripDataGrid.Columns[4].Width = 30;
                StripDataGrid.Columns[5].Width = 150;
                StripDataGrid.Columns[6].Width = 120;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dit zet boeken icoontje links vanboven
            Uri iconUri = new Uri("../../../Images/book.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri); //zet icon linker bovenhoek van window

            stripsFromDb = generalManager.StripManager.GetAll();//strips ophalen
            showingStrips = stripsFromDb;

            
            stripCollectionsFromDb = generalManager.stripCollectionManager.GetAll(); //strip collections ophalen 

            if (stripCollectionsFromDb != null ) //als er collecties zij,
            {
                var smallList = stripsFromDb.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam
                    , Collectie = StripCollToString(stripCollectionsFromDb.Where(s => s.Strips.Any(b=>b.ID.Equals(c.ID))).ToList()) }).OrderBy(s => s.ID);
                StripDataGrid.ItemsSource = smallList;
                SetDataGridColumnsWidth();
            }
            else
            {   //als er geen collectie zijn
                var smallList = stripsFromDb.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam, Collectie = "" }).OrderBy(s => s.ID);
                StripDataGrid.ItemsSource = smallList; SetDataGridColumnsWidth();
            }

            stripBewerken_button.Visibility = Visibility.Hidden;
            bin_image.Visibility = Visibility.Collapsed;


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
            string stringx = stripBewerken_button.Content.ToString();
            Boolean xxx = stringx.Contains("Geselecteerde strip bijwerken ?");

            if (xxx) //om strip te bewerken
            {
                EditStrip w2 = new EditStrip(selectedStrip); //maak window openen
                w2.ShowDialog();

                // window reset// 
                MainWindow newWindow = new MainWindow();
                Application.Current.MainWindow = newWindow;
                this.Close();
                newWindow.Show();
            }
            else //om strip COLLECTIE te bewerken
            {

                EditStripCollection w2 = new EditStripCollection(selectedStripCollection); //maak window openen
                w2.ShowDialog();

                // window reset// 
                MainWindow newWindow = new MainWindow();
                Application.Current.MainWindow = newWindow;
                this.Close();
                newWindow.Show();

                //PRETEND "NaarStrip_button" IS CLICKED, zodat we in juiste scherm komen
                ButtonAutomationPeer peer = new ButtonAutomationPeer(NaarStripCollections_button);
                IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                invokeProv.Invoke();
            }
        }


        private void DataGridSelectie(object sender, System.Windows.Controls.SelectionChangedEventArgs e) //als er een strip geselecteerd is
        {
            string stringx = stripBewerken_button.Content.ToString();
            Boolean xxx = stringx.Contains("Geselecteerde strip bijwerken ?");

            if (xxx) //om strip te bewerken
            {
                if (StripDataGrid.SelectedItem != null)
                {
                    stripBewerken_button.Visibility = Visibility.Visible;
                    bin_image.Visibility = Visibility.Visible;

                    selectedStrip = null;
                    selectedStripCollection = null;
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
                    else
                    {
                        stripBewerken_button.Visibility = Visibility.Collapsed;
                        bin_image.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    stripBewerken_button.Visibility = Visibility.Collapsed;
                    bin_image.Visibility = Visibility.Collapsed;
                    selectedStripCollection = null;
                    selectedStrip = null;
                }
            }
            else {
                if (StripDataGrid.SelectedItem != null)
                {
                    selectedStrip = null;
                    selectedStripCollection = null;
                    String x = StripDataGrid.SelectedItem.ToString();
                    string[] words = x.Split(',');

                    x = words[1];
                    x = x.Replace("Titel = ", "").Replace("{", "").Replace("}", "").Trim();

                    //haalt de gekozen strip op en geeft die weer mee
                    selectedStripCollection = stripCollectionsFromDb.Where(s => s.Titel.ToString().Equals(x)).FirstOrDefault();
                    if (selectedStripCollection != null)
                    {
                        //collectiebewerken button zichtbaar
                        stripBewerken_button.Visibility = Visibility.Visible;
                        //vuilbakje zichtbaar
                        bin_image.Visibility = Visibility.Visible;
                    }
                    else
                    {   //als niet gevonden dan mag vuilbak en bewerk knop ontzichtbaar blijven
                        stripBewerken_button.Visibility = Visibility.Collapsed;
                        bin_image.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {//als niet gevonden dan mag vuilbak en bewerk knop ontzichtbaar blijven
                    stripBewerken_button.Visibility = Visibility.Collapsed;
                    bin_image.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Button_Zoek_Click(object sender, RoutedEventArgs e) //rechts vanboven kan je op gui speciefiekere data zoeken in db
        {
            string stringx = stripBewerken_button.Content.ToString();
            Boolean xxx = stringx.Contains("Geselecteerde strip bijwerken ?");

            if (xxx) //om strip te bewerken
            {
                stripBewerken_button.Visibility = Visibility.Collapsed;
                bin_image.Visibility = Visibility.Collapsed;

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
                                if (stripCollectionsFromDb != null && stripCollectionsFromDb.Any(s => s.Strips.Contains(helpstrip))) //als het een collectie heeft
                                {
                                    List<StripCollection> liststripcoll = stripCollectionsFromDb.Where(s => s.Strips.Contains(helpstrip)).ToList();
                                    var smallList = listStrip.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam, Collectie = StripCollToString(stripCollectionsFromDb.Where(s => s.Strips.Any(b => b.ID.Equals(c.ID))).ToList()) }).OrderBy(s => s.ID);
                                    StripDataGrid.ItemsSource = smallList; SetDataGridColumnsWidth();
                                }
                                else
                                { //als het strip geen collectie heeft
                                    var smallList = listStrip.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam, Collectie = "" }).OrderBy(s => s.ID);
                                    StripDataGrid.ItemsSource = smallList; SetDataGridColumnsWidth();
                                }
                            }
                        }
                        catch (NullReferenceException ex) { }
                    }
                    else { StripDataGrid.ItemsSource = null; } //niet geldige ingave
                } //zoeken op strip id
                else if (RadioBtnStriptittel.IsChecked == true)
                {
                    try
                    {
                        List<Strip> strips = stripsFromDb.Where(b => b.StripTitel.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
                        showingStrips.Clear();
                        showingStrips.AddRange(strips);

                        try
                        {
                            if (strips != null)
                            {
                                var smallList = strips.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam, Collectie = StripCollToString(stripCollectionsFromDb.Where(s => s.Strips.Any(b => b.ID.Equals(c.ID))).ToList()) }).OrderBy(s => s.ID);
                                StripDataGrid.ItemsSource = smallList;

                            }
                        }
                        catch (NullReferenceException ex) { StripDataGrid.ItemsSource = null; }

                    }
                    catch (Exception ex) { StripDataGrid.ItemsSource = null; }


                }//zoeken op strip tittel
                else if (RadioBtnReeks.IsChecked == true)//zoeken op strip reeksen
                {
                    try
                    {
                        List<Strip> strips = stripsFromDb.Where(b => b.Reeks.Naam.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
                        showingStrips.Clear();
                        showingStrips.AddRange(strips);

                        try
                        {
                            if (strips != null)
                            {
                                var smallList = strips.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam, Collectie = StripCollToString(stripCollectionsFromDb.Where(s => s.Strips.Any(b => b.ID.Equals(c.ID))).ToList()) }).OrderBy(s => s.ID);
                                StripDataGrid.ItemsSource = smallList;
                            }
                        }
                        catch (NullReferenceException ex) { }

                    }
                    catch //als strip niet bestaat  
                    { }

                }//zoeken op strip reeksen
                else if (RadioBtnAuteur.IsChecked == true)
                {
                    try
                    {

                        List<Strip> strips = stripsFromDb.Where(b => b.Auteurs.Any(c => c.Naam.ToUpper().Contains(SearchTextBox.Text.ToUpper()))).ToList();
                        showingStrips.Clear();
                        showingStrips.AddRange(strips);

                        try
                        {
                            if (strips != null)
                            {
                                var smallList = strips.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam, Collectie = StripCollToString(stripCollectionsFromDb.Where(s => s.Strips.Any(b => b.ID.Equals(c.ID))).ToList()) }).OrderBy(s => s.ID);
                                StripDataGrid.ItemsSource = smallList;
                            }
                        }
                        catch (NullReferenceException ex) { }

                    }
                    catch //als strip niet bestaat  
                    { }

                }//zoeken op strip auteurs
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
                                var smallList = strips.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam, Collectie = StripCollToString(stripCollectionsFromDb.Where(s => s.Strips.Any(b => b.ID.Equals(c.ID))).ToList()) }).OrderBy(s => s.ID);
                                StripDataGrid.ItemsSource = smallList;
                            }
                        }
                        catch (NullReferenceException ex) { }

                    }
                    catch //als strip niet bestaat  
                    { }
                }//zoeken op strip uitgeverijen
                else if (RadioBtnColl.IsChecked == true)//zoeken op strip collecties
                {
                    try
                    {
                        List<StripCollection> collections = stripCollectionsFromDb.Where(b => b.Titel.ToUpper().Contains(SearchTextBox.Text.ToUpper())).ToList();

                        List<Strip> strips = stripsFromDb.Where(b => (collections.Any(c => c.Strips.Any(s => s.ID.Equals(b.ID))))).ToList();
                        showingStrips.Clear();
                        showingStrips.AddRange(strips);

                        try
                        {
                            if (strips != null)
                            {
                                var smallList = strips.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam, Collectie = StripCollToString(collections.Where(s => s.Strips.Any(b => b.ID.Equals(c.ID))).ToList()) }).OrderBy(s => s.ID);
                                StripDataGrid.ItemsSource = smallList;
                            }
                        }
                        catch (NullReferenceException ex) { }

                    }
                    catch //als strips niet bestaan geef niets terug 
                    { }
                }
            }
            else {
                stripBewerken_button.Visibility = Visibility.Collapsed;
                bin_image.Visibility = Visibility.Collapsed;

                List<StripCollection> listStrip = new List<StripCollection>();

                if (RadioBtnStripid.IsChecked == true)
                { if (SearchTextBox.Text.All(Char.IsDigit))
                    {  //als een getal dan
                        StripCollection helpstrip = generalManager.stripCollectionManager.GetById(Convert.ToInt32(SearchTextBox.Text));
                            listStrip.Add(helpstrip);

                        try
                        {

                            if (helpstrip != null)
                            {
                                if (stripCollectionsFromDb != null ) //als het een collectie heeft
                                {

                                    var smallList = listStrip.Select(c => new { c.Id, c.Titel, c.Nummer, c.Uitgeverij.Naam, Strips = StripsToString(c.Strips) }).OrderBy(s => s.Id);
                                    StripDataGrid.ItemsSource = smallList;
                                }
                                else
                                {   //als er geen collecties zijn
                                    StripDataGrid.ItemsSource = null;
                                }
                            }
                        }
                        catch (NullReferenceException ex) { }
                    }
                    else { StripDataGrid.ItemsSource = null; } //niet geldige ingave
                } //zoeken op collectie id
                else if (RadioBtnStriptittel.IsChecked == true)
                {
                    try
                    {
                        listStrip = stripCollectionsFromDb.Where(b => b.Titel.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();

                        try
                        {
                            if (listStrip != null)
                            {
                                var smallList = listStrip.Select(c => new { c.Id, c.Titel, c.Nummer, c.Uitgeverij.Naam, Strips = StripsToString(c.Strips) }).OrderBy(s => s.Id);
                                StripDataGrid.ItemsSource = smallList;

                            }
                        }
                        catch (NullReferenceException ex) { StripDataGrid.ItemsSource = null; }

                    }
                    catch (Exception ex) { StripDataGrid.ItemsSource = null; }


                }//zoeken op collectie tittel
                else if (RadioBtnUitgeverij.IsChecked == true)
                {
                    try
                    {
                        listStrip = stripCollectionsFromDb.Where(b => b.Uitgeverij.Naam.ToUpper().Contains(SearchTextBox.Text.ToUpper())).ToList();
                        

                        try
                        {
                            if (listStrip != null)
                            {
                                var smallList = listStrip.Select(c => new { c.Id, c.Titel, c.Nummer, c.Uitgeverij.Naam, Strips = StripsToString(c.Strips) }).OrderBy(s => s.Id);
                                StripDataGrid.ItemsSource = smallList;
                            }
                        }
                        catch (NullReferenceException ex) { }

                    }
                    catch //als strip niet bestaat  
                    { }
                }//zoeken op collectie uitgeverijen
                else if (RadioBtnColl.IsChecked == true)//zoeken op strip collecties
                {
                    try
                    {
                        
                        List<Strip> strips = stripsFromDb.Where(b => b.StripTitel.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
                        List<StripCollection> listStrip2 = new List<StripCollection>();
                        for (int i = 0; i < strips.Count; i++)
                        {
                            listStrip2.AddRange(stripCollectionsFromDb.Where(s => s.Strips.Any(b => b.ID.Equals(strips[i].ID))));
                        }
                        for (int i = 0; i < listStrip2.Count; i++)
                        {
                            if (!listStrip.Contains(listStrip2[i]))
                            {
                                listStrip.Add(listStrip2[i]);
                            }
                        }
                       
                        try
                        {
                            if (listStrip != null)
                            {
                                var smallList = listStrip.Select(c => new { c.Id, c.Titel, c.Nummer, c.Uitgeverij.Naam, Strips = StripsToString(c.Strips) }).OrderBy(s => s.Id);
                                StripDataGrid.ItemsSource = smallList;
                            }
                        }
                        catch (NullReferenceException ex) { }

                    }
                    catch //als strips niet bestaan geef niets terug 
                    { }
                }

            }
        }


        private void BinClicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string stringx = stripBewerken_button.Content.ToString();
            Boolean xxx = stringx.Contains("Geselecteerde strip bijwerken ?");

            if (xxx) //om strip te bewerken
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
            else {
                try
                {
                    var result = MessageBox.Show("Ben je zeker dat je deze strip collectie wil verwijderen?: \n" + selectedStripCollection.ToString(), "bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        generalManager.stripCollectionManager.Delete(selectedStripCollection);

                        MainWindow newWindow = new MainWindow(); //herstart de scherm, zodat het laad zonder verwijderde
                        Application.Current.MainWindow = newWindow;
                        this.Close();
                        newWindow.Show();
                    }
                }
                catch (Exception ex) { }

            }
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

        private void Button_MaakStripCollectie_Click(object sender, RoutedEventArgs e)
        {
            MaakStripCollectieScherm w3 = new MaakStripCollectieScherm(); //maak window openen
            w3.ShowDialog();

            // window reset// voor als er nieuwe strips zijn gemaakt
            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            this.Close();
            newWindow.Show();

        }


        private void Button_Reset_Click(object sender, RoutedEventArgs e)
        {
            string stringx = stripBewerken_button.Content.ToString();
            Boolean xxx = stringx.Contains("Geselecteerde strip bijwerken ?");
            stripsFromDb = generalManager.StripManager.GetAll();
            if (xxx) //om strip te bewerken
            {
                SearchTextBox.Text = "";
                RadioBtnStripid.IsChecked = true;
                selectedStrip = null;
               // stripsFromDb = generalManager.StripManager.GetAll();
               // showingStrips = stripsFromDb;
                //var smallList = stripsFromDb.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam, Collectie = StripCollToString(stripCollectionsFromDb.Where(s => s.Strips.Any(b => b.ID.Equals(c.ID))).ToList()) }).OrderBy(s => s.ID);
                
                var smallList = stripsFromDb.Select(c => new {
                    c.ID,
                    c.StripTitel,
                    Auteurs = AuteursToString(c.Auteurs),
                    Reeks = c.Reeks.Naam,
                    c.StripNr,
                    Uitgeverij = c.Uitgeverij.Naam
                ,
                    Collectie = StripCollToString(stripCollectionsFromDb.Where(s => s.Strips.Any(b => b.ID.Equals(c.ID))).ToList())
                }).OrderBy(s => s.ID);
                StripDataGrid.ItemsSource = smallList;
                SetDataGridColumnsWidth();
                StripDataGrid.ItemsSource = smallList;
            }
            else {
                SearchTextBox.Text = "";
                selectedStripCollection = null;
                stripBewerken_button.Visibility = Visibility.Collapsed;
                bin_image.Visibility = Visibility.Collapsed;

                if (stripCollectionsFromDb != null) //als er collecties zij,
                {
                    var smallList = stripCollectionsFromDb.Select(c => new { c.Id, c.Titel, c.Nummer, c.Uitgeverij.Naam, Strips = StripsToString(c.Strips) }).OrderBy(s => s.Id);
                    StripDataGrid.ItemsSource = smallList;
                }
                else
                {   //als er geen collectie zijn
                    StripDataGrid.ItemsSource = null;
                }
            }
        }

        private void Button_StripCo_Click(object sender, RoutedEventArgs e) //overschakeling naar bekijk stripcollecties
        {
            //DEZE GEBRUIKTE KNOP DAN VERBERGEN
            NaarStripCollections_button.Visibility = Visibility.Collapsed;
            //KNOP OM TERUG TE GAAN NAAR TOON STRIPS
            NaarStrip_button.Visibility = Visibility.Visible;
            //BUTTONS VERBERGEN
            plusreeks.Visibility = Visibility.Collapsed;
            plusuitgeverij.Visibility = Visibility.Collapsed;
            plusauteur.Visibility = Visibility.Collapsed;
            plusstrip.Visibility = Visibility.Collapsed;

            //ZOEK TERMEN HIDDEN OF VERANDEREN VAN NAAM (RECHTSVANBOVEN APP)
            RadioBtnStripid.Content = "Collectie id";
            RadioBtnStriptittel.Content = "Collectie tittel";
            RadioBtnReeks.Visibility = Visibility.Collapsed; //HIDE
            RadioBtnAuteur.Visibility = Visibility.Collapsed; //HIDE
            RadioBtnUitgeverij.Content = "Collectie uitgeverij";
            RadioBtnColl.Content = "Strip tittel";

            RadioBtnColl.Margin = new Thickness(969, 45, 0, 0);
            RadioBtnUitgeverij.Margin = new Thickness(970, 67, 10, 10);


            //BUTTON AANPASSEN VAN NAAM
            stripBewerken_button.Content = "Geselecteerde strip collectie bijwerken ?";
            //DATAGRID RESET
            showingStrips = stripsFromDb;

            if (stripCollectionsFromDb != null) //als er collecties zij,
            {
                var smallList = stripCollectionsFromDb.Select(c => new { c.Id,c.Titel,c.Nummer,c.Uitgeverij.Naam, Strips = StripsToString(c.Strips)}).OrderBy(s => s.Id);
                StripDataGrid.ItemsSource = smallList;
            }
            else
            {   //als er geen collectie zijn
                StripDataGrid.ItemsSource = null;
            }

            stripBewerken_button.Visibility = Visibility.Collapsed;
            stripBewerken_button.Width = 350;
            bin_image.Visibility = Visibility.Collapsed;

        }

        private void Button_Strip_Click(object sender, RoutedEventArgs e)
        {
            //DEZE GEBRUIKTE KNOP DAN VERBERGEN
            NaarStrip_button.Visibility = Visibility.Collapsed;
            //KNOP OM TERUG TE GAAN NAAR TOON STRIPS
            NaarStripCollections_button.Visibility = Visibility.Visible;

            //BUTTON AANPASSEN VAN NAAM
            stripBewerken_button.Content = "Geselecteerde strip bijwerken ?";

            //WEER ZICHTBAAR MAKEN 
            plusreeks.Visibility = Visibility.Visible;
            plusuitgeverij.Visibility = Visibility.Visible;
            plusauteur.Visibility = Visibility.Visible;
            plusstrip.Visibility = Visibility.Visible;

            stripsFromDb = generalManager.StripManager.GetAll();//strips ophalen
            showingStrips = stripsFromDb;

            //ZOEK TERMEN TONEN OF VERANDEREN VAN NAAM (RECHTSVANBOVEN APP)
            RadioBtnStripid.Content = "Strip id";
            RadioBtnStriptittel.Content = "Strip tittel";
            RadioBtnReeks.Visibility = Visibility.Visible; // UNHIDE
            RadioBtnAuteur.Visibility = Visibility.Visible; // UNHIDE
            RadioBtnUitgeverij.Content = "Uitgeverij";
            RadioBtnColl.Content = "Collectie tittel";
            RadioBtnColl.Margin = new Thickness(989, 45, 0, 0);
            RadioBtnUitgeverij.Margin = new Thickness(990, 67, 10, 10);

            //DATAGRID RESET
            showingStrips = stripsFromDb;

            if (stripCollectionsFromDb != null) //als er collecties zij,
            {
                var smallList = stripsFromDb.Select(c => new {
                    c.ID,
                    c.StripTitel,
                    Auteurs = AuteursToString(c.Auteurs),
                    Reeks = c.Reeks.Naam,
                    c.StripNr,
                    Uitgeverij = c.Uitgeverij.Naam
                    ,
                    Collectie = StripCollToString(stripCollectionsFromDb.Where(s => s.Strips.Any(b => b.ID.Equals(c.ID))).ToList())
                }).OrderBy(s => s.ID);
                StripDataGrid.ItemsSource = smallList;
            }
            else
            {   //als er geen collectie zijn
                var smallList = stripsFromDb.Select(c => new { c.ID, c.StripTitel, Auteurs = AuteursToString(c.Auteurs), Reeks = c.Reeks.Naam, c.StripNr, Uitgeverij = c.Uitgeverij.Naam, Collectie = "" }).OrderBy(s => s.ID);
                StripDataGrid.ItemsSource = smallList;
            }

            stripBewerken_button.Width = 220;
            stripBewerken_button.Visibility = Visibility.Hidden;
            bin_image.Visibility = Visibility.Collapsed;
        }
    }
}
