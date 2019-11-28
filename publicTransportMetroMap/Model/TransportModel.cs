using System.Collections.Generic;
using System.ComponentModel;

namespace publicTransportMetroMap.Model
{
    public class TransportModel : INotifyPropertyChanged
    {
        private string _station;
        private List<string> _lines;

        public string Station
        {
            get => _station;
            set
            {
                if (_station != value)
                {
                    _station = value;
                    RaisePropertyChanged("Station");
                }
            }
        }
        public List<string> Lines
        {
            get => _lines;
            set
            {
                if (_lines != value)
                {
                    _lines = value;
                    RaisePropertyChanged("Lines");
                }
            }
        }

        public TransportModel() { }
        public TransportModel(string station, List<string> lines)
        {
            _station = station;
            _lines = lines;
        }


        public event PropertyChangedEventHandler PropertyChanged;


        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
