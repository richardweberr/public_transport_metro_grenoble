using publicTransportMetroGrenobel;

namespace publicTransportMetroLibrary
{
    public class ConnectMetroAPIFake_AllLines : IConnectMetroAPI
    {
        public string GetRawData()
        {
            return System.IO.File.ReadAllText(@"C:\Users\richard.weber\source\mm_data_all_routes.txt");
        }
    }
}
