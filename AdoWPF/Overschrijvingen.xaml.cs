﻿using AdoGemeenschap;
using System;
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

namespace AdoWPF
{
    /// <summary>
    /// Interaction logic for Overschrijvingen.xaml
    /// </summary>
    public partial class Overschrijvingen : Window
    {
        public Overschrijvingen()
        {
            InitializeComponent();
        }

        private void buttonOverschrijven_Click(object sender, RoutedEventArgs e)
        {
            Decimal bedrag;
            if (Decimal.TryParse(textBoxBedrag.Text, out bedrag))
            {
                try
                {
                    var manager = new RekeningenManager();
                    manager.Overschrijven(bedrag, textBoxVanRekNr.Text, textBoxNaarRekNr.Text);
                    labelStatus.Content = "OK";
                }
                catch (Exception ex)
                {
                    labelStatus.Content = ex.Message;
                }
            }
            else
            {
                labelStatus.Content = "Bedrag bevat geen getal";
            }
        }
    }
}
