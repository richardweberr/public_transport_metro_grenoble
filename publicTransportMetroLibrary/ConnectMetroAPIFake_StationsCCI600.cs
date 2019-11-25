namespace publicTransportMetroGrenobel
{
    public class ConnectMetroAPIFake_StationsCCI600 : IConnectMetroAPI
    {
        public string GetRawData()
        {
            return System.IO.File.ReadAllText(@"C:\Users\richard.weber\source\mm_data_CCI_600m.txt");
        }
    }
}