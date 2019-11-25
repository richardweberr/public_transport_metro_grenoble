using publicTransportMetroGrenobel;

namespace publicTransportMetroLibrary
{
    public class DataSelector
    {
        private string _longX;
        private string _latY;
        private string _dist;

        private IConnectMetroAPI _connectMetroAPIStations;
        private IConnectMetroAPI _connectMetroAPILines;

        public Stations _stations { get; set; }
        public Lines _lines { get; set; }


        public DataSelector(string x = "5.727775", string y = "45.185541", string d = "1000", bool fakedata = true)
        {
            _longX = x;
            _latY = y;
            _dist = d;

            if (fakedata)
            {
                _connectMetroAPIStations = new ConnectMetroAPIFake_StationsCCI600();
                _connectMetroAPILines = new ConnectMetroAPIFake_AllLines();
            }
            else
            {
                _connectMetroAPIStations = new ConnectMetroAPI("https://data.metromobilite.fr/api/linesNear/json?x=" + _longX + "&y=" + _latY + "45.185541&dist=" + _dist + "&details=true");
                _connectMetroAPILines = new ConnectMetroAPI("https://data.metromobilite.fr/api/routers/default/index/routes");
            }

            _stations = new Stations(_connectMetroAPIStations);
            _lines = new Lines(_connectMetroAPILines);
        }
    }
}
