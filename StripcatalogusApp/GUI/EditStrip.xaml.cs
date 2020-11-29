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
    /// Interaction logic for EditStrip.xaml
    /// </summary>
    public partial class EditStrip : Window
    {
     GeneralManager  generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));
        private int Strip_id;
        public EditStrip(Strip strip) //meegegeven strip wordt bewerkt
        {
            this.Strip_id = strip.ID; //weten welke strip we bewerken

            InitializeComponent();
            TextBox_titel.Text = strip.StripTitel;
            TextBox_nr.Text = strip.StripNr.ToString();

            //reeksbox
            var allSeries = generalManager.ReeksManager.GetAll().OrderBy(b=>b.Naam); //alle reeksen opvragen op alfabetisch volgorde
            TextBox_reeks.ItemsSource = allSeries;//reeksen meegeven aan de combobox
            TextBox_reeks.SelectedItem = allSeries.Where(s => s.ID == strip.Reeks.ID).Single(); //huidige strip reeks geselecteerd zetten
           
            //uitgeverijbox
             var allPublishers = generalManager.UitgeverijManager.GetAll().OrderBy(b=>b.Naam);//alle uitgeverijen opvragen op alfabetisch volgorde
            TextBox_uitgeverij.ItemsSource = allPublishers;//uitgeverijen meegeven aan de combobox
            TextBox_uitgeverij.SelectedItem = allPublishers.Where(p => p.ID == strip.Uitgeverij.ID).Single();//huidige strip uitgeverij geselecteerd zetten
            
            //auteurs
            var allAuteurs   = ConvertToGUI.ListAuteurs(generalManager.AuteurManager.GetAll()).OrderBy(b=>b.Ischecked).ThenBy(b => b.Naam);//huidige strip auteurs geselecteerd zetten, we sorteren eerst op al geselecteerd en dan op naam
            foreach (var aut in strip.Auteurs) // alle huidige auteurs van strip selecteren
            {
                AuteurGUI selected = allAuteurs.Where(a => a.ID == aut.ID).Single();
                   selected.Ischecked = true;
                _selectedAuteurs.Add(selected.ID, selected);
            }
            TextBox_auteurs.ItemsSource = allAuteurs;


        }
        private Dictionary<int,AuteurGUI> _selectedAuteurs = new Dictionary<int, AuteurGUI>();
        private void Button_update_confirmed_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Ben je zeker dat je deze wijziging wil doorvoeren","bevestiging",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                Strip strip = new Strip(Strip_id, TextBox_titel.Text, Convert.ToInt32(TextBox_nr.Text), ConvertToBusinessLayer.ListAuteurs(_selectedAuteurs.Values.ToList()), TextBox_reeks.SelectedItem as Reeks, TextBox_uitgeverij.SelectedItem as Uitgeverij);
                generalManager.StripManager.Update(strip);
                this.Close();
               
            }
            
           
        }


        void OnChecked(object sender, RoutedEventArgs e)
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

        private void cancel_update_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Ben je zeker dat je deze wijziging wil doorvoeren", "bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
