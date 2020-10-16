using businesslaag;
using Businesslaag;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MaakScherm.xaml
    /// </summary>
    public partial class MaakScherm : Window
    {

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dit zet boeken icoontje links vanboven
            Uri iconUri = new Uri("../../../Images/book.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri); //zet icon linker bovenhoek van window


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
            string fouten = "";
            #region connectie db
            DbProviderFactories.RegisterFactory("sqlserver", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("sqlserver");

            StripRepository sr = new StripRepository(sqlFactory);
            #endregion
            List<Auteur> auteursList = new List<Auteur>();
            Reeks reeks1 = new Reeks();
            Uitgeverij uitgeverij1 = new Uitgeverij();
            int inteVullenGeg = 5; //voor elke correcte ingevulde vakje -1. dus op 0 is alles correct
            string titel = TextBox_titel.Text;
            string nr = TextBox_nr.Text;
            string reeks = TextBox_reeks.Text;
            string uitgeverij = TextBox_uitgeverij.Text;
            string auteurs = TextBox_auteurs.Text;

            //Controleren of leeg
            Boolean ietsLeeg = false;
            if (TextBox_auteurs.Text =="" || TextBox_titel.Text == "" || TextBox_nr.Text == "" || TextBox_reeks.Text == "" || TextBox_uitgeverij.Text == "" ) {
                fouten = fouten + "U heeft iets niet ingevuld.";
                ietsLeeg = true;
            }
            //controleren of er fouten zijn
            //TITEL
            if ( TextBox_titel.Text != "" || TextBox_titel.Text.Length > 1)
            { inteVullenGeg = inteVullenGeg - 1; }
            //NUMMER
            if (TextBox_nr.Text != "" )
            { inteVullenGeg = inteVullenGeg - 1; }
            //REEKS
            if (TextBox_reeks.Text != "" || TextBox_reeks.Text.Length > 1)
            {
                Reeks reeksX = sr.GetReeks_fromName(reeks);
                if (reeksX == null)// als reeks niet bestaat -> maak aan
                {
                    reeks1 = new Reeks(sr.latestReeksId() + 1, reeks);
                }
                else { reeks1 = reeksX; }
                inteVullenGeg = inteVullenGeg - 1; }
            //UITGEVERIJ
            if (TextBox_uitgeverij.Text != "" || TextBox_uitgeverij.Text.Length > 1)
            {
                Uitgeverij uitgeverijX = sr.GetUitgeverij_fromName(uitgeverij);
                if (uitgeverijX == null)// als reeks niet bestaat -> maak aan
                {
                    uitgeverij1 = new Uitgeverij(sr.latestReeksId() + 1, uitgeverij);
                }
                else { uitgeverij1 = uitgeverijX; }
                inteVullenGeg = inteVullenGeg - 1; }
            //AUTEURS
            if (TextBox_auteurs.Text != "" || TextBox_auteurs.Text.Length > 1)
            {
                
                //meedere auteurs
                if (TextBox_auteurs.Text.Contains(',')) { 
                
                }
                //maar 1 auteur
                else {
                    Auteur bestaandeAuteur = sr.GetAuteur_fromName(auteurs);

                    if (bestaandeAuteur == null) {
                        auteursList.Add(new Auteur(sr.latestAuteurId() +1, auteurs));
                    }
                    else { auteursList.Add(bestaandeAuteur); }
                }
                inteVullenGeg = inteVullenGeg - 1; }
            //controleren of er duplicaten zijn
            //foutcode eventueel teruggeven
            //aanmaken en naar databank sturen
          
            int LastStripID = sr.latestStripId();

            if (!ietsLeeg) {

                Strip newStrip = new Strip(LastStripID + 1, titel, auteursList, reeks1,Convert.ToInt32( nr), uitgeverij1);
                sr.AddStrip(newStrip);
            }

            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
