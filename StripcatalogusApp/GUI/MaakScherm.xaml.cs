﻿using System;
using System.Collections.Generic;
using System.Text;
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
            int inteVullenGeg = 4; //voor elke correcte ingevulde vakje -1. dus op 0 is alles correct
            string titel = TextBox_titel.Text;
            string nr = TextBox_nr.Text;
            string reeks = TextBox_reeks.Text;
            string uitgeverij = TextBox_uitgeverij.Text;
            //Controleren of leeg
            //controleren of er fouten zijn
            //controleren of er duplicaten zijn
            //foutcode eventueel teruggeven
            //aanmaken en naar databank sturen
        }
    }
}
