using Microsoft.Maps.MapControl.WPF;
using publicTransportMetroLibrary;
using publicTransportMetroMap.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace publicTransportMetroMap.ViewModel
{
    public class TransportViewModel : INotifyPropertyChanged
    {
        private string _longX;
        private string _latY;
        private string _dist;

        private ObservableCollection<TransportModel> _transports;

        public string LongX
        {
            get => _longX;
            set
            {
                if (_longX != value)
                {
                    _longX = value;
                    RaisePropertyChanged("LongX");
                }
            }
        }
        public string LatY
        {
            get => _latY;
            set
            {
                if (_latY != value)
                {
                    _latY = value;
                    RaisePropertyChanged("LatY");
                }
            }
        }
        public string Dist
        {
            get => _dist;
            set
            {
                if (_dist != value)
                {
                    _dist = value;
                    RaisePropertyChanged("Dist");
                }
            }
        }

        public ObservableCollection<TransportModel> Transports {
            get => _transports;
            set
            {
                if (_transports != value)
                {
                    _transports = value;
                    RaisePropertyChanged("Transports");
                }
            }
        }

        public ICommand RefreshData { get; set; }


        public TransportViewModel()
        {
            this.LongX = "5.727775";
            this.LatY = "45.185541";
            this.Dist = "600";

            RefreshData = new RelayCommand(ExecutuButtoni);
        }

        public void ExecutuButtoni()
        {
            Transports.Clear();
            LoadTransport();
        }


        public void LoadTransport()
        {
            //API Data
            DataSelector metroData = new DataSelector(_longX, _latY, _dist, true);

            //faked Data
            //DataSelector metroData = new DataSelector(_longX, _latY, _dist, false);

            List<string> listLocation = new List<string>();
            ObservableCollection<TransportModel> transports = new ObservableCollection<TransportModel>();
            Dictionary<string, List<string>> stationsDict = metroData._stations.GetSortedStationData();
            foreach (KeyValuePair<string, List<string>> station in stationsDict)
            {
                TransportModel transport = new TransportModel(station.Key, station.Value);
                transports.Add(transport);
            }

            Transports = transports;
        }


        public event PropertyChangedEventHandler PropertyChanged;


        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }


    }
}

