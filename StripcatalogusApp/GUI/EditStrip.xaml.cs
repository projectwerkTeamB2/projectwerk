using Businesslaag.Models;
using System;
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
    /// Interaction logic for EditStrip.xaml
    /// </summary>
    public partial class EditStrip : Window
    {
        public EditStrip()
        {
            InitializeComponent();
            var x = (Application.Current.MainWindow as MainWindow).selectedStrip;
            TextBox_titel.Text = x.StripTitel;


        }



      
    }
}
