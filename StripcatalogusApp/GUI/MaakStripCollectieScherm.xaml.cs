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
    public partial class MaakStripCollectieScherm : Window
    {
        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));

        private Dictionary<int, StripGUI> _selectedStrips = new Dictionary<int, StripGUI>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dit zet boeken icoontje links vanboven
            Uri iconUri = new Uri("../../../Images/book.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri); //zet icon linker bovenhoek van window
            
            //uitgeverijbox
            var allPublishers = generalManager.UitgeverijManager.GetAll().OrderBy(b => b.Naam);//alle uitgeverijen opvragen op alfabetisch volgorde
            TextBox_uitgeverij.ItemsSource = allPublishers;//uitgeverijen meegeven aan de combobox

            //strips
            var allstrips = ConvertToGUI.convertToStrips(generalManager.StripManager.GetAll()).OrderBy(b => b.StripTitel);//alle strips, we sorteren op naam
            TextBox_Strips.ItemsSource = allstrips;


        }
        public MaakStripCollectieScherm()
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
            string uitgeverij = TextBox_uitgeverij.Text;


            //  //foutcode eventueel teruggeven
            try
            {

                StripCollection strip = new StripCollection(generalManager.stripCollectionManager.GetAll().OrderBy(b => b.Id).Last().Id + 1, TextBox_titel.Text, Convert.ToInt32(TextBox_nr.Text), ConvertToBusinessLayer.ListStrips(_selectedStrips.Values.ToList()), TextBox_uitgeverij.SelectedItem as Uitgeverij);

                string messageBoxText = "Wilt u deze collectie aanmaken?";
                string caption = "Collectie Aanmaken?";
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

                        generalManager.stripCollectionManager.Add(strip);
                        break;

                    case MessageBoxResult.No:
                        // User pressed No button
                        // nothing happends
                        break;
                }


            }
            catch (Exception ex) { ExtraInfo_TextBox.Text = fouten + "\n" + ex.ToString(); }



        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        void OnChecked(object sender, RoutedEventArgs e)
        {
            var x = sender as CheckBox;
            StripGUI strip = (StripGUI)x.DataContext;
            if (strip != null)
            {
                bool succes = _selectedStrips.TryAdd(strip.ID, strip);
                if (!succes)
                {
                    _selectedStrips.Remove(strip.ID);

                }
            }
        }
    }
}
