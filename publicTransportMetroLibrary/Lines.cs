using Newtonsoft.Json;
using System.Collections.Generic;

namespace publicTransportMetroGrenobel
{
    public class Lines
    {
        public List<LineModel> _deserializedLines { get; set; }

        public Lines(IConnectMetroAPI rawData)
        {
            //convert json string to list of objects based on LineModel
            _deserializedLines = JsonConvert.DeserializeObject<List<LineModel>>(rawData.GetRawData());
        }


        
        public Dictionary<string, LineModel> GetLineData()
        {
            //build new dictionary with line id as key and other lineModel properties as list of line values
            Dictionary<string, LineModel> lines = new Dictionary<string, LineModel>();
            foreach (LineModel line in _deserializedLines)
            {
                if (!lines.ContainsKey(line.id))
                {
                    lines.Add(line.id, line);
                }
            }
            return lines;
        }
    }
}