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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using AdoGemeenschap;

namespace AdoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonBieren_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new BierenDbManager();
                using (var conBieren = manager.GetConnection())
                {
                    conBieren.Open();
                    labelStatus.Content = "Bieren geopend";
                }
            }
            catch (Exception ex)
            {
                labelStatus.Content = ex.Message;
            }
            
            
            //try
            //{
            //    var conString = ConfigurationManager.ConnectionStrings["Bieren"];
            //    var factory = DbProviderFactories.GetFactory(conString.ProviderName);

            //    using (var conBieren = factory.CreateConnection())
            //    {
            //        conBieren.ConnectionString = conString.ConnectionString;
            //        conBieren.Open();
            //        labelStatus.Content = "Bieren geopend";
                    
            //        //conBieren.ConnectionString = Application.Current.Properties["Bieren2"].ToString();
            //        //conBieren.Open();
            //        //labelStatus.Content = "Bieren geopend";

            //        //ConnectionStringSettings conString = ConfigurationManager.ConnectionStrings["Bieren"];
            //        //conBieren.ConnectionString = conString.ConnectionString;
            //        //conBieren.Open();
            //        //labelStatus.Content = "Bieren geopend";
            //    }
                
            //    //using (var conBieren = new SqlConnection(@"server=.\sqlexpress;database=Bieren;integrated security=true"))
            //    //{
            //    //    //conBieren.ConnectionString = @"server=.\sqlexpress;database=Bieren;integrated security=true";
            //    //    conBieren.Open();
            //    //    labelStatus.Content = "Bieren geopend";
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    labelStatus.Content = ex.Message;
            //}
        }

        private void buttonBonus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new RekeningenManager();
                labelStatus.Content = manager.SaldoBonus() + " rekeningen aangepast";
            }
            catch(Exception ex)
            {
                labelStatus.Content = ex.Message;
            }
        }
    }
}
