namespace publicTransportMetroGrenobel
{
    public interface IConnectMetroAPI
    {
        string GetRawData();
    }
}

/*
interface documented on:
https://www.metromobilite.fr/pages/opendata/OpenDataApi.html

list of stations and lines close to (X, Y):
http://data.metromobilite.fr/api/linesNear/json?x={X}&y={Y}&dist={Z}&details={bool}

details on 1 line:
https://data.metromobilite.fr/api/routers/default/index/routes?codes=SEM:12
*/
