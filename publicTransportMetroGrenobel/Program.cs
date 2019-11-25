using publicTransportMetroLibrary;
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

            //boucle 'exit'
            string input = "";
            while (input != "exit")
            {
                DataSelector dataselector = new DataSelector("5.727775", "45.185541", "1000", true);

                //sweep and print the dictionnary keys(== stations), and the list of each associated valueList (==lines)
                foreach (KeyValuePair<string, List<string>> station in dataselector._stations.GetSortedStationData())
                {
                    {
                        Console.WriteLine(station.Key);
                        foreach (string line in station.Value)
                        {
                            Console.WriteLine("\t" + line);
                            Dictionary<string, LineModel> y = dataselector._lines.GetLineData();
                            Console.WriteLine("\t\t" + y[line].longName);
                            Console.WriteLine("\t\t" + y[line].type);
                        }
                    }
                }
                Console.WriteLine("\n\n\n");
                input = Console.ReadLine();
            }
        }
    }
}

