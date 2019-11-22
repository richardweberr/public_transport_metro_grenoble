using Newtonsoft.Json;
using System.Collections.Generic;


namespace publicTransportMetroGrenobel
{
    public class StationData
    {
        private IRequestOnMetroApi _rawData;


        public StationData(IRequestOnMetroApi rawData)
        {
            this._rawData = rawData;
        }


        public Dictionary<string, List<string>> GetStationData()
        {
            //convert json string to list of objects based on StationModel
            List<StationModel> deserializedStationData = JsonConvert.DeserializeObject<List<StationModel>>(this._rawData.GetRawData());

            //convert list of stationModels into dictionnary (name, list of lines)
            Dictionary<string, List<string>> stations = new Dictionary<string, List<string>>();
            foreach (StationModel station in deserializedStationData)
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


        public Dictionary<string, List<string>> GetStationDataLong()
        {
            //convert json string to list of objects based on StationModel
            List<StationModel> deserializedStationData = JsonConvert.DeserializeObject<List<StationModel>>(this._rawData.GetRawData());
            List<LineModel> deserializedLineData = JsonConvert.DeserializeObject<List<LineModel>>(this._rawData.GetRawData());
            //convert list of StationModels into dictionnary (name, list of lines)
            Dictionary<string, List<string>> stations = new Dictionary<string, List<string>>();
            foreach (StationModel station in deserializedStationData)
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
