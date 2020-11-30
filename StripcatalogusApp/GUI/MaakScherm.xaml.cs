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
using Businesslaag.Managers;
using System.Linq;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MaakScherm.xaml
    /// </summary>
    public partial class MaakScherm : Window
    {
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
            string auteurs = TextBox_auteurs.Text;

            //Controleren of leeg
            Boolean ietsLeeg = false;
            if (TextBox_auteurs.Text =="" || TextBox_titel.Text == "" || TextBox_nr.Text == "" || TextBox_reeks.Text == "" || TextBox_uitgeverij.Text == "" ) {
                fouten = fouten + "U heeft iets niet ingevuld.";
                ietsLeeg = true;
                ExtraInfo_TextBox.Text = fouten;

                
            }

            //  //foutcode eventueel teruggeven
            try
            {
                String[] strlist = auteurs.Split(",", StringSplitOptions.RemoveEmptyEntries);
                reeks1 = new Reeks(reeks);
                uitgeverij1 = new Uitgeverij(uitgeverij);


                foreach (var item in strlist)
                {
                    auteurLijst.Add(new Auteur(item.Trim()));
                }

                Strip newStrip = new Strip(generalManager.StripManager.GetAll().OrderBy(b => b.ID).Last().ID + 1, titel, Convert.ToInt32(nr), auteurLijst, reeks1, uitgeverij1);

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
                        //try
                        //{
                            generalManager.StripManager.Add(newStrip);
                            //break;
                            //}
                            //catch (Exception ex) {

                            //    messageBoxText = fouten + "\n" + ex.ToString();
                            //     button = MessageBoxButton.OK;
                            //     icon = MessageBoxImage.Information;


                            //    // Display message box
                            //     result = MessageBox.Show(messageBoxText, caption, button, icon);

                            //    // Process message box results
                            //    switch (result)
                            //    {
                            //        case MessageBoxResult.OK:
                            //            // User pressed Yes button
                            //            this.DialogResult = true;

                            //            break;
                            //    }
                            break;
                        //}
                        //catch (Exception ex)
                        //{
                        //    throw new Exception(ex.ToString());
                        //    break;
                        //}

                        



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

    
    }
}
