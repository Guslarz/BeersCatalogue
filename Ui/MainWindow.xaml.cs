using Kaczmarek.BeersCatalogue.BLC;
using Kaczmarek.BeersCatalogue.Interfaces;
using Kaczmarek.BeersCatalogue.Ui.Properties;
using System;
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

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Blc.Instance.Dispose();
        }

        private IDbParams LoadParams()
        {
            var settings = Settings.Default;
            return new DbParams(settings.DbName);
        }
    }
}
