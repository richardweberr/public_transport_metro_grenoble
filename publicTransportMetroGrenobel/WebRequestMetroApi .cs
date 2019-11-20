using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace publicTransportMetroGrenobel
{
    public class WebRequestMetroApi
    {
        private string _URL;
        private WebRequest _request;

        public WebRequestMetroApi(string URL = "https://data.metromobilite.fr/api/linesNear/json?x=5.727775&y=45.185541&dist=600&details=true")
        {
            this._URL = URL;
        }

        public string getRawData()
        {
            _request = WebRequest.Create(_URL);
            HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            
            return responseFromServer;
        }

        public List<StationModel> getStationData()
        {
            return JsonConvert.DeserializeObject<List<StationModel>>(getRawData());
        }

        public List<StationModel> getUniqueStationData()
        {
            return JsonConvert.DeserializeObject<List<StationModel>>(getRawData());
        }
    }
}
