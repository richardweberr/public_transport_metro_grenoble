using Newtonsoft.Json;
using System.Collections.Generic;

namespace publicTransportMetroGrenobel
{
    public class LinesData
    {
        private IRequestOnMetroApi _rawData;


        public LinesData(IRequestOnMetroApi rawData)
        {
            this._rawData = rawData;
        }


        public List<LineModel> GetLineData()
        {
            //convert json string to list of objects based on LineModel
            return  JsonConvert.DeserializeObject<List<LineModel>>(this._rawData.GetRawData());
        }
    }
}