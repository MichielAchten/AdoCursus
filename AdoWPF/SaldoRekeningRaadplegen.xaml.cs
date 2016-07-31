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
    /// Interaction logic for SaldoRekeningRaadplegen.xaml
    /// </summary>
    public partial class SaldoRekeningRaadplegen : Window
    {
        public SaldoRekeningRaadplegen()
        {
            InitializeComponent();
        }

        private void SaldoButto_Click(object sender, RoutedEventArgs e)
        {
            var manager = new RekeningenManager();
            try
            {
                LabelStatus.Content = manager.SaldoRekeningRaadplegen(TextBoxRekeningNr.Text).ToString("N");
            }
            catch (Exception ex)
            {
                LabelStatus.Content = ex.Message;
            }
        }
    }
}
