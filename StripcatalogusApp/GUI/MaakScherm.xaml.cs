using Datalaag.Repositories;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Datalaag;
using Businesslaag.Models;
using Businesslaag.Managers;
using System.Linq;
using System.Windows.Controls;
using GUI.Models;
using GUI.Mappers;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MaakScherm.xaml
    /// </summary>
    public partial class MaakScherm : Window
    {
        private Dictionary<int, AuteurGUI> _selectedAuteurs = new Dictionary<int, AuteurGUI>();

        GeneralManager generalManager;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dit zet boeken icoontje links vanboven
            Uri iconUri = new Uri("../../../Images/book.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri); //zet icon linker bovenhoek van window
            generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));
           
            List<Reeks> reeksList = generalManager.ReeksManager.GetAll().OrderBy(b=>b.Naam).ToList();
            List<Uitgeverij> uitgeverijList = generalManager.UitgeverijManager.GetAll().OrderBy(b => b.Naam).ToList();
            for (int i = 0; i < reeksList.Count; i++)
            {
                TextBox_reeks.Items.Add(reeksList[i].Naam);
            }

            
            for (int i = 0; i < uitgeverijList.Count; i++)
            {
                TextBox_uitgeverij.Items.Add(uitgeverijList[i].Naam);
            }

            //auteurs
            var allAuteurs = ConvertToGUI.ListAuteurs(generalManager.AuteurManager.GetAll()).OrderByDescending(b => b.Ischecked).ThenBy(b => b.Naam);//huidige strip auteurs geselecteerd zetten, we sorteren eerst op al geselecteerd en dan op naam
            TextBox_auteurs.ItemsSource = allAuteurs;

        }
        public MaakScherm()
        {
            InitializeComponent();


        }

        private void Button_Annuleren_Click(object sender, RoutedEventArgs e)
        {
            //Dit gebeurd als men op de button "annuleren" drukt
            string messageBoxText = "Wilt u zeker annuleren? \n gegevens worden dan niet opgeslaan.";
            string caption = "Annuleren";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;

            // Display message box
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button
                    this.DialogResult = true;

                    break;

                case MessageBoxResult.No:
                    // User pressed No button
                    // nothing happends
                    break;
            }
        }

        private void Button_Aanmaken_Click(object sender, RoutedEventArgs e)
        {
            ExtraInfo_TextBox.Text = "";
            string fouten = "";
           
            Reeks reeks1 = new Reeks();
            Uitgeverij uitgeverij1 = new Uitgeverij();
            List<Auteur> auteurLijst = new List<Auteur>();

            string titel = TextBox_titel.Text;
            string nr = TextBox_nr.Text;
            string reeks = TextBox_reeks.Text;
            string uitgeverij = TextBox_uitgeverij.Text;

            //Controleren of leeg
            if ( TextBox_titel.Text == "" || TextBox_nr.Text == "" || TextBox_reeks.Text == "" || TextBox_uitgeverij.Text == "" ) {
                fouten = fouten + "U heeft iets niet ingevuld.";
                ExtraInfo_TextBox.Text = fouten;

                
            }

            //  //foutcode eventueel teruggeven
            try
            {
              
                Strip newStrip = new Strip(generalManager.StripManager.GetAll().OrderBy(b => b.ID).Last().ID + 1, titel, Convert.ToInt32(nr), ConvertToBusinessLayer.ListAuteurs(_selectedAuteurs.Values.ToList()), reeks1, uitgeverij1);

                string messageBoxText = "Wilt u deze strip aanmaken: \n " + newStrip.ToString();
                string caption = "Strip Aanmaken?";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;

                // Display message box
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
               

                // Process message box results
                switch (result)
                {
                    case MessageBoxResult.Yes:
                      
                        // User pressed Yes button
                        this.DialogResult = true;

                            generalManager.StripManager.Add(newStrip);
                                break;
                    
                    case MessageBoxResult.No:
                        // User pressed No button
                        // nothing happends
                        break;
                }

              
            }
            catch(Exception ex) { ExtraInfo_TextBox.Text = fouten + "\n" + ex.ToString(); }
         

            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OnChecked(object sender, RoutedEventArgs e)
        {
            var x = sender as CheckBox;
            AuteurGUI auteur = (AuteurGUI)x.DataContext;
            if (auteur != null)
            {
                bool succes = _selectedAuteurs.TryAdd(auteur.ID, auteur);
                if (!succes)
                {
                    _selectedAuteurs.Remove(auteur.ID);

                }
            }
        }
    }
}
