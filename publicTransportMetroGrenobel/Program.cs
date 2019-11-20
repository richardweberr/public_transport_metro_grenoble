using System;
using System.Net;

namespace publicTransportMetroGrenobel
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            string input = "";
            WebRequestMetroApi webRequestMetroApi = new WebRequestMetroApi();

            while (input != "exit")
            {
                foreach (StationModel station in webRequestMetroApi.getStationData())
                Console.WriteLine(station);
                input = Console.ReadLine();
            }
        }
    }
}
