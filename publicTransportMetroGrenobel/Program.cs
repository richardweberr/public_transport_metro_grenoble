using System;
using System.Collections.Generic;
using System.Net;


namespace publicTransportMetroGrenobel
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            IRequestOnMetroApi requestOnMetroDataStations;

            //boucle 'exit'
            string input = "";
            while (input != "exit")
            {
                //mode 'offline' par défaut
                if (input != "m")
                {
                    requestOnMetroDataStations = new RequestOnMetroApiFake();
                }
                else
                {
                    requestOnMetroDataStations = new RequestOnMetroApi();
                }

                StationData stationData = new StationData(requestOnMetroDataStations);

                //sweep and print the dictionnary keys(== stations), and the list of each associated valueList (==lines)
                foreach (KeyValuePair<string, List<string>> station in stationData.GetStationData())
                {
                    Console.WriteLine(station.Key);
                    foreach (string line in station.Value)
                    {
                        Console.WriteLine(line);
                    }
                }
                Console.WriteLine("\n\n\n");
                input = Console.ReadLine();
            }
        }
    }
}

