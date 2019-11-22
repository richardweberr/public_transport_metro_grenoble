using System.IO;
using System.Net;


namespace publicTransportMetroGrenobel
{
    public class RequestOnMetroApi : IRequestOnMetroApi
    {
        private string _url;


        public RequestOnMetroApi(string url = "https://data.metromobilite.fr/api/linesNear/json?x=5.727775&y=45.185541&dist=1000&details=true")
        {
            this._url = url;
        }


        public string GetRawData()
        //connect to _URL and retrieve string data 
        {
            WebRequest request = WebRequest.Create(_url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}