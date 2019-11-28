using Newtonsoft.Json;
using System.Collections.Generic;


namespace publicTransportMetroGrenobel
{
    public class Stations
    {
        private List<StationModel> _deserializedStations;


        public Stations(IConnectMetroAPI rawData)
        {
            //convert json string to list of objects based on StationModel
            _deserializedStations = JsonConvert.DeserializeObject<List<StationModel>>(rawData.GetRawData());
        }


        public Dictionary<string, List<string>> GetSortedStationData()
        {
            //convert list of stationModels into dictionnary (name, list of lines)
            Dictionary<string, List<string>> stations = new Dictionary<string, List<string>>();
            foreach (StationModel station in _deserializedStations)
            {
                if (!stations.ContainsKey(station.name))
                {
                    stations.Add(station.name, station.lines);
                }
                else
                {
                    foreach (string line in station.lines)
                    {
                        if (!stations[station.name].Contains(line))
                        {
                            stations[station.name].Add(line);
                        }
                    }
                }
            }
            return stations;
        }
    }
}
