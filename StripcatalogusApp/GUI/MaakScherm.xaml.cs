using Datalaag.Repositories;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Datalaag;
using Businesslaag.Models;

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

            StripRepository sr = new StripRepository(DbFunctions.GetprojectwerkconnectionString());
            #endregion
            List<AuteurRepository> auteursList = new List<AuteurRepository>();
            Reeks reeks1 = new Reeks();
            Uitgeverij uitgeverij1 = new Uitgeverij();
           
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
           
          //  //foutcode eventueel teruggeven
          //  //aanmaken en naar databank sturen
          
          //  int LastStripID = sr.latestStripId();

          //  if (!ietsLeeg) {

          ////      Strip newStrip = new Strip(LastStripID + 1, titel, auteursList, reeks1,Convert.ToInt32( nr), uitgeverij1);
          // //     sr.AddStrip(newStrip);
          //  }

            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
