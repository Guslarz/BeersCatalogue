using Kaczmarek.BeersCatalogue.BLC;
using Kaczmarek.BeersCatalogue.Interfaces;
using Kaczmarek.BeersCatalogue.Ui.Properties;
using Kaczmarek.BeersCatalogue.Ui.ViewModel;
using System.Linq;
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
            Blc.Initialize(loadParams());
            InitializeComponent();
        }

        private IDbParams loadParams()
        {
            var settings = Settings.Default;
            return new DbParams(settings.DbName);
        }
    }
}
