using Kaczmarek.BeersCatalogue.BLC;
using Kaczmarek.BeersCatalogue.Interfaces;
using Kaczmarek.BeersCatalogue.Ui.Properties;
using System.Windows;

namespace Kaczmarek.BeersCatalogue.Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() : base()
        {
            Blc.Initialize(LoadParams());
            InitializeComponent();
        }

        private IDbParams LoadParams()
        {
            var settings = Settings.Default;
            return new DbParams(settings.DbName);
        }

        private void AddNewBeerButton_Click(object sender, RoutedEventArgs e)
        {
            //BeersList.SelectedItem = null;
        }

        private void AddNewBreweryButton_Click(object sender, RoutedEventArgs e)
        {
            //BreweriesList.SelectedItem = null;
        }
    }
}
