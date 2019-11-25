using System.Collections.Generic;


namespace publicTransportMetroGrenobel
{
    public class StationModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public string zone { get; set; }
        public List<string> lines { get; set; }
    }
}


     //[
     //    {
     //    "id": "SEM:1986",
     //    "name": "GRENOBLE, CASERNE DE BONNE",
     //    "lon": 5.72533,
     //    "lat": 45.18506,
     //    "zone": "SEM_GENCASBONNE",
     //    "lines":
     //        [
     //        "SEM:16"
     //         ]
     //    },
     //]