using Businesslaag.Managers;
using Businesslaag.Models;
using Datalaag;
using Datalaag.Repositories;
using GUI.Mappers;
using GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GUI
{
    /// <summary>
    /// Interaction logic for EditStripCollection.xaml
    /// </summary>
    public partial class EditStripCollection : Window
    {      GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));
            private int StripCollection_id;



        public EditStripCollection(StripCollection stripcollection) //meegegeven stripcollection wordt bewerkt
        {
                this.StripCollection_id = stripcollection.Id; //weten welke stripcollection we bewerken

                InitializeComponent();
                TextBox_titel.Text = stripcollection.Titel;
                TextBox_nr.Text = stripcollection.Nummer.ToString();

                //reeksbox
                var allSeries = generalManager.ReeksManager.GetAll().OrderBy(b => b.Naam); //alle reeksen opvragen op alfabetisch volgorde
              
                //uitgeverijbox
                var allPublishers = generalManager.UitgeverijManager.GetAll().OrderBy(b => b.Naam);//alle uitgeverijen opvragen op alfabetisch volgorde
                TextBox_uitgeverij.ItemsSource = allPublishers;//uitgeverijen meegeven aan de combobox
                TextBox_uitgeverij.SelectedItem = allPublishers.Where(p => p.ID == stripcollection.Uitgeverij.ID).Single();//huidige strip uitgeverij geselecteerd zetten

                //strips
                var allstrips = ConvertToGUI.convertToStrips(generalManager.StripManager.GetAll()).OrderByDescending(b => b.Ischecked).ThenBy(b => b.StripTitel);//huidige strips geselecteerd zetten, we sorteren eerst op al geselecteerd en dan op naam
                foreach (var strip in stripcollection.Strips) // alle huidige auteurs van strip selecteren
                {
                    StripGUI selected = allstrips.Where(a => a.ID == strip.ID).Single();
                    selected.Ischecked = true;
                _selectedStrips.Add(selected.ID, selected);
                }
           
            TextBox_Strips.ItemsSource = allstrips;

         
            }
            private Dictionary<int, StripGUI> _selectedStrips = new Dictionary<int, StripGUI>();
            private void Button_update_confirmed_Click(object sender, RoutedEventArgs e)
            {
                var result = MessageBox.Show("Ben je zeker dat je deze wijziging wil doorvoeren", "bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    StripCollection strip = new StripCollection(StripCollection_id, TextBox_titel.Text, Convert.ToInt32(TextBox_nr.Text), ConvertToBusinessLayer.ListStrips(_selectedStrips.Values.ToList()), TextBox_uitgeverij.SelectedItem as Uitgeverij);
                    generalManager.stripCollectionManager.Update(strip);
                    this.Close();

                }


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

            private void cancel_update_Click(object sender, RoutedEventArgs e)
            {
                var result = MessageBox.Show("Bent u zeker dat u deze wijzigingen wil annuleren", "bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }

            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                //dit zet boeken icoontje links vanboven
                Uri iconUri = new Uri("../../../Images/book.ico", UriKind.RelativeOrAbsolute);
                this.Icon = BitmapFrame.Create(iconUri); //zet icon linker bovenhoek van window
            }
        }

    }

