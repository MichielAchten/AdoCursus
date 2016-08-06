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
        private CollectionViewSource brouwerViewSource;
        public OverzichtBrouwers()
        {
            InitializeComponent();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //System.Windows.Data.CollectionViewSource brouwerViewSource =
        //    //    ((System.Windows.Data.CollectionViewSource)(this.FindResource("brouwerViewSource")));

        //    CollectionViewSource brouwerViewSource =
        //        ((CollectionViewSource)(this.FindResource("brouwerViewSource")));
        //    var manager = new BrouwerManager();
        //    brouwerViewSource.Source = manager.GetBrouwersBeginNaam(textBoxZoeken.Text);


        //}

        //private void buttonZoeken_Click(object sender, RoutedEventArgs e)
        //{
        //    CollectionViewSource brouwerViewSource = ((CollectionViewSource)(this.FindResource("brouwerViewSource")));
        //    var manager = new BrouwerManager();
        //    brouwerViewSource.Source = manager.GetBrouwersBeginNaam(textBoxZoeken.Text);
        //}

        //private void goToFirstButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void VulDeGrid()
        {
            brouwerViewSource = (CollectionViewSource)(this.FindResource("brouwerViewSource"));
            var manager = new BrouwerManager();
            int totalRowsCount;
            List<Brouwer> brouwers = new List<Brouwer>();
            brouwers = manager.GetBrouwersBeginNaam(textBoxZoeken.Text);
            totalRowsCount = brouwers.Count();
            labelTotalRowCount.Content = totalRowsCount;
            brouwerViewSource.Source = brouwers;
            goUpdate();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulDeGrid();
            textBoxZoeken.Focus();

            var manager = new BrouwerManager();
            comboBoxPostcode.Items.Add("alles");
            List<string> pc = manager.GetPostCodes();
            foreach(var p in pc)
            {
                comboBoxPostcode.Items.Add(p);
            }
            comboBoxPostcode.SelectedIndex = 0;
        }

        private void buttonZoeken_Click(object sender, RoutedEventArgs e)
        {
            VulDeGrid();
        }

        private void textBoxZoeken_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VulDeGrid();
            }
        }

        private void goToFirstButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToFirst();
            goUpdate();
        }

        private void goToPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToPrevious();
            goUpdate();
        }

        private void goToNextButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToNext();
            goUpdate();
        }

        private void goToLastButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToLast();
            goUpdate();
        }

        private void goUpdate()
        {
            goToPreviousButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == 0);
            goToPreviousButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == 0);
            goToNextButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 1);
            goToLastButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 1);

            if (brouwerDataGrid.Items.Count !=0)
            {
                if (brouwerDataGrid.SelectedItem != null)
                {
                    brouwerDataGrid.ScrollIntoView(brouwerDataGrid.SelectedItem);
                }
            }
            textBoxGo.Text = (brouwerViewSource.View.CurrentPosition + 1).ToString();

            if (brouwerDataGrid.Items.Count != 0)
            {
                if (brouwerDataGrid.SelectedItem != null)
                {
                    brouwerDataGrid.ScrollIntoView(brouwerDataGrid.SelectedItem);
                    listBoxBrouwers.ScrollIntoView(brouwerDataGrid.SelectedItem);
                }
            }
        }

        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            int position;
            int.TryParse(textBoxGo.Text, out position);
            if (position > 0 && position <= brouwerDataGrid.Items.Count)
            {
                brouwerViewSource.View.MoveCurrentToPosition(position - 1);
            }
            else
            {
                MessageBox.Show("The input index is not valid.");
            }
            goUpdate();
        }

        private void brouwerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            goUpdate();
        }

        private void brouwerDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (CheckOpFouten())
            {
                e.Handled = true;
            }
        }

        private void brouwerDataGrid_PreviewMouseDown(object sender, MouseEventArgs e)
        {
            if (CheckOpFouten())
            {
                e.Handled = true;
            }
        }

        bool CheckOpFouten()
        {
            bool foutGevonden = false;
            foreach (var c in gridDetail.Children)
            {
                if (c is AdornerDecorator)
                {
                    if (Validation.GetHasError(((AdornerDecorator)c).Child))
                    {
                        foutGevonden = true;
                    }
                    else if (Validation.GetHasError((DependencyObject)c))
                    {
                        foutGevonden = true;
                    }
                }
            }
            return foutGevonden;
        }

        private void comboBoxPostcode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxPostcode.SelectedIndex == 0)
            {
                brouwerDataGrid.Items.Filter = null;
            }
            else
            {
                brouwerDataGrid.Items.Filter = new Predicate<object>(PostCodeFilter);
            }
        }

        public bool PostCodeFilter(object br)
        {
            Brouwer b = br as Brouwer;
            bool result = (b.Postcode == Convert.ToInt16(comboBoxPostcode.SelectedValue));
            return result;
        }
    }
}
