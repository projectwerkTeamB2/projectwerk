
using Datalaag;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;
using Businesslaag.Models;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        StripRepository sr;
        List<Strip> stripsFromJson;
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
                jfr.locatieJson = openFileDlg.FileName;
                try
                {

                    stripsFromJson = jfr.leesJson_GeefAlleStripsTerug();
                }
                catch {
                    stripsFromJson = null;
                }
                if (stripsFromJson != null && stripsFromJson.Count != 0) { 
                TextBlock1.Text = "Gevonden strips in bestand: " + stripsFromJson.Count.ToString() + " strips.";

                NaarDBLabel.Visibility = Visibility.Visible;
                NaarDBButton.Visibility = Visibility.Visible;
                }
                else { TextBlock1.Text = "Ongeldige bestand, geen strips in gevonden."; }
            }
            else { TextBlock1.Text = "Ongeldige bestand, geen strips in gevonden."; }

        }

     
        private void NaarDBButton_Click(object sender, RoutedEventArgs e)
        {
            if (stripsFromJson != null) {
                try
                {
                //    sr.allesWegSchijvenNaarDataBank(stripsFromJson); //vladik zijn code is weg
                    TextBlock2.Text = "Gelukt!";
                }
                catch { TextBlock2.Text = "Er is iets fout gegaan"; }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            stripsFromJson = null;
            #region connectie db
            DbProviderFactories.RegisterFactory("sqlserver", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("sqlserver");

             sr = new StripRepository(DbFunctions.GetprojectwerkconnectionString());
            #endregion

            NaarDBLabel.Visibility = Visibility.Hidden;
            NaarDBButton.Visibility = Visibility.Hidden;
        }
    }
}
