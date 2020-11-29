﻿using Datalaag;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;
using Businesslaag.Models;
using Businesslaag.Managers;
using System.ComponentModel;
using JSON;
using Datalaag.Models;
using Datalaag.Mappers;

namespace WpfApp2
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        #region progressbar
        public int _x;
        public int x //nodig voor progressbar -> % weergeven
        {
            get { return _x; } //geeft opgeslagen percentage terug
            set
            {
                _x = value; //bij verandering, set je de percentage
                if (PropertyChanged != null) //PropertyChanged occurs when a property value changes.
                    // parameter "x", causes the property name of the caller to be substituted as an argument.
                    PropertyChanged(this, new PropertyChangedEventArgs("x"));
            }
        }
        //The BackgroundWorker class allows you to run an operation on a separate, dedicated thread
        private BackgroundWorker _bgWWorker = new BackgroundWorker();
        #endregion

        //nodig? V
        GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));

        List<Strip> stripsFromJson; //list die alle strips van json bestad gaat bevatten
        List<StripDB> stripsFromDB; //list die alle strips van db gaat bevatten
        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
         
            InitializeComponent();

            
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "";
            TextBlock2.Text = "";

            NaarDBLabel.Visibility = Visibility.Hidden;
            NaarDBButton.Visibility = Visibility.Hidden;
            stripsFromJson = null;

            if (Hoofdlabel.Content.Equals("Laad uw Json in en wij updaten uw databank.")) {
                // Create OpenFileDialog
                Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
                openFileDlg.DefaultExt = ".json";// Set filter for file extension and default file extension  
                openFileDlg.Filter = "Json files (*.json)|*.json";

                openFileDlg.Multiselect = false;// Multiple selection with all file types  
                                                // Launch OpenFileDialog by calling ShowDialog method
                Nullable<bool> result = openFileDlg.ShowDialog();
                // Get the selected file name and display in a TextBox.
                // Load content of file in a TextBlock
                if (result == true)
                {
                    FileNameTextBox.Text = openFileDlg.FileName;


                    //Leest de Json bestand in en maakt er objecten van
                    JsonFileReader_ToObjects jfr = new JsonFileReader_ToObjects();
                    //     jfr.locatieJson = openFileDlg.FileName;
                    try
                    {

                    //    stripsFromDB = jfr.leesJson_GeefAlleStripsTerug(FileNameTextBox.Text);
                    }
                    catch
                    {
                        stripsFromDB = null;
                    }
                    if (stripsFromDB != null && stripsFromDB.Count != 0)
                    {
                        TextBlock1.Text = "Gevonden strips in bestand: " + stripsFromDB.Count.ToString() + " strips.";

                        NaarDBLabel.Visibility = Visibility.Visible;
                        NaarDBButton.Visibility = Visibility.Visible;
                    }
                    else { TextBlock1.Text = "Ongeldige bestand, geen strips in gevonden."; }
                }
                else { TextBlock1.Text = "Ongeldige bestand, geen strips in gevonden."; }
            }
            else if (Hoofdlabel.Content.Equals("Kies een locatie waar je het wil schrijven.")) { }

        }

        public void Bewerk(List<Strip> strips) {
            if (stripsFromDB != null)
            {
                NaarDBButton.Visibility = Visibility.Hidden; //verberg knop, zodat je geen nieuwe thread start

                pbStatus.Maximum = stripsFromDB.Count; //min 0 tot X(aantal strips) ipv o tot 100% zodat je " x strips bewerkt" toont
                SchrijfwegnaarDB schrijfwegnaarDB = new SchrijfwegnaarDB();
                pbStatus.Value = 0; //progresbar start bij 0

                // Using the DataContext property is like setting the basis of all bindings down through the hierarchy of controls.
                //nodig voor progres value en tekst te binden aan deze context
                DataContext = this;
                _bgWWorker.DoWork += (s, e) => //start separate, dedicated thread
                {
                   
                    for (int i = 0; i <= strips.Count; i++)//alle strips overlopen
                    {
                        try //try, zodat fouten kunnen worden opgevangen
                        { 
                            schrijfwegnaarDB.stripWegSchijvenNaarDataBank(strips[i]); //huidige strip wegschrijven naar db
                        }
                        catch { TextBlock2.Text = "Er is iets fout gelopen"; }//error opvangen?
                        finally //klaar? verander dan percentage van progresbar -> die x
                        {
                            System.Threading.Thread.Sleep(100);
                            x = i;
                        }
                       
                    }
                };
                _bgWWorker.RunWorkerAsync(); //Starts execution of a background operation.


            }

        }

        private void NaarDBButton_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Bewerk(ConvertToBusinesslaag.convertToStrips(stripsFromDB)); //voer uit, schijf strips weg naar db
            });
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            stripsFromJson = null; //start met lege strip collectie
       
            NaarDBLabel.Visibility = Visibility.Hidden; //hidden tot je aantal strips hebt
            NaarDBButton.Visibility = Visibility.Hidden;
        }


        //nodig, zonder update hij de textblok niet
        private void pbStatus_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            pbStatus.Value = x;
        }

        //Databank naar text bestand zetten? -> geklikt
        private void VanDBButtonn_Click(object sender, RoutedEventArgs e)
        {
            NaarDBButtonKeuze.Visibility = Visibility.Visible; //toon button om terug naar andere scherm te gaan
            NaarJSONButton.Visibility = Visibility.Visible;
            NaarDBLabel.Visibility = Visibility.Collapsed;
            FileNameTextBox.Text = "";
          //  allesWegSchrijvenNaarJSONFile()

            Hoofdlabel.Content = "Kies een locatie waar je het wil schrijven.";


        }
        //Json naar Databank versturen? -> geklikt
        private void NaarDBButtonKeuze_Click(object sender, RoutedEventArgs e)
        {
            NaarJSONButton.Visibility = Visibility.Collapsed;
            NaarDBButtonKeuze.Visibility = Visibility.Collapsed;
            VanDBButton.Visibility = Visibility.Visible;
            FileNameTextBox.Text = "";
            TextBlock1.Text = "";

            Hoofdlabel.Content = "Laad uw Json in en wij updaten uw databank.";
        }

        private void NaarJSONButton_Click(object sender, RoutedEventArgs e)
        {
            SchrijfwegnaarJSON swj = new SchrijfwegnaarJSON();
            string time = DateTime.Now.ToString();
         //   swj.allesWegSchrijvenNaarJSONFileVanDataBank(FileNameTextBox.Text, "StripCatDB_" + time + ".txt");
        }
    }
}
