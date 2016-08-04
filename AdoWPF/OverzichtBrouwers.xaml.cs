﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AdoGemeenschap;

namespace AdoWPF
{
    /// <summary>
    /// Interaction logic for OverzichtBrouwers.xaml
    /// </summary>
    public partial class OverzichtBrouwers : Window
    {
        public OverzichtBrouwers()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //System.Windows.Data.CollectionViewSource brouwerViewSource =
            //    ((System.Windows.Data.CollectionViewSource)(this.FindResource("brouwerViewSource")));

            CollectionViewSource brouwerViewSource =
                ((CollectionViewSource)(this.FindResource("brouwerViewSource")));
            var manager = new BrouwerManager();
            brouwerViewSource.Source = manager.GetBrouwersBeginNaam(textBoxZoeken.Text);


        }

        private void buttonZoeken_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource brouwerViewSource = ((CollectionViewSource)(this.FindResource("brouwerViewSource")));
            var manager = new BrouwerManager();
            brouwerViewSource.Source = manager.GetBrouwersBeginNaam(textBoxZoeken.Text);
        }



        //private void VulDeGrid()
        //{
        //    CollectionViewSource brouwerViewSource = (CollectionViewSource)(this.FindResource("brouwerViewSource"));
        //    var manager = new BrouwerManager();
        //    brouwerViewSource.Source = manager.GetBrouwersBeginNaam(textBoxZoeken.Text);
        //}

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    VulDeGrid();
        //    textBoxZoeken.Focus();
        //}

        //private void buttonZoeken_Click(object sender, RoutedEventArgs e)
        //{
        //    VulDeGrid();
        //}

        //private void textBoxZoeken_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        VulDeGrid();
        //    }
        //}
    }
}
