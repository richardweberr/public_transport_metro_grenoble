namespace publicTransportMetroGrenobel
{
    public class RequestOnMetroApiFake : IRequestOnMetroApi
    {
        public string GetRawData()
        {
            return System.IO.File.ReadAllText(@"C:\Users\richard.weber\source\mm_data_CCI_600m.txt");
        }
    }
}