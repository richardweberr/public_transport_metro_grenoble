using publicTransportMetroMap.ViewModel;
using System.Windows;

namespace publicTransportMetroMap
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void MetroMapViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            TransportViewModel transportViewModelObject = new TransportViewModel();
            transportViewModelObject.LoadTransport();
            MetroMapViewControl.DataContext = transportViewModelObject;
        }
    }
}
