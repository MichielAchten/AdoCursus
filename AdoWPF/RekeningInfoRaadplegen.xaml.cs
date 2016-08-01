using AdoGemeenschap;
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
    /// Interaction logic for RekeningInfoRaadplegen.xaml
    /// </summary>
    public partial class RekeningInfoRaadplegen : Window
    {
        public RekeningInfoRaadplegen()
        {
            InitializeComponent();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new RekeningenManager();
                var info = manager.RekeningInfoRaadplegen(TextBoxRekeningNr.Text);
                LabelSaldo.Content = info.Saldo.ToString("N");
                LabelNaam.Content = info.KlantNaam;
                LabelStatus.Content = string.Empty;
            }
            catch (Exception ex)
            {
                LabelSaldo.Content = string.Empty;
                LabelNaam.Content = string.Empty;
                LabelStatus.Content = ex.Message;
            }
        }
    }
}
