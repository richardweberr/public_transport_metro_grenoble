using Microsoft.VisualStudio.TestTools.UnitTesting;
using publicTransportMetroGrenobel;
using System.Collections.Generic;

namespace publicTransportMetroGrenobelTest
{
    [TestClass]
    public class StationDataTest
    {
        [TestMethod]
        public void ValidReturnTypeOnConnectionTest()
        {
            //ce test n'a aucun sens
            IConnectMetroAPI target = new ConnectMetroAPI();
            string result = target.GetRawData();
            Assert.AreEqual(result.GetType(), typeof(string));
            Assert.AreSame(result.GetType(), typeof(string));
        }


        [TestMethod]
        public void ValuesTest()
        {
            //init
            IConnectMetroAPI fakeRequestOnMetroData = new ConnectMetroAPIFake_StationsCCI600();
            Stations target = new Stations(fakeRequestOnMetroData);
            //action
            Dictionary<string, List<string>> result = target.GetSortedStationData();
            //assertion
            //Assert.AreEqual(result, cci600);
            Assert.IsTrue(result.ContainsKey("GRENOBLE, CASERNE DE BONNE"));
            Assert.AreEqual(result["GRENOBLE, CASERNE DE BONNE"][0], "SEM:16");
            Assert.IsTrue(result.ContainsKey("GRENOBLE, DOCTEUR MARTIN"));
            Assert.AreEqual(result["GRENOBLE, DOCTEUR MARTIN"][0], "SEM:C1");
            Assert.AreEqual(result["GRENOBLE, DOCTEUR MARTIN"][1], "SEM:C4");
            Assert.AreEqual(result["GRENOBLE, DOCTEUR MARTIN"][2], "SEM:13");
            Assert.AreEqual(result["GRENOBLE, DOCTEUR MARTIN"][3], "SEM:16");
            Assert.AreEqual(result["GRENOBLE, DOCTEUR MARTIN"][4], "SEM:12");
            Assert.AreEqual(result["GRENOBLE, DOCTEUR MARTIN"][5], "C38:6020");
            Assert.IsTrue(result.ContainsKey("GRENOBLE, CHAVANT"));
            Assert.AreEqual(result["GRENOBLE, CHAVANT"][0], "SEM:C1");
            Assert.AreEqual(result["GRENOBLE, CHAVANT"][1], "C38:EXP2");
            Assert.AreEqual(result["GRENOBLE, CHAVANT"][2], "C38:EXP1");
            Assert.AreEqual(result["GRENOBLE, CHAVANT"][3], "C38:6200");
            Assert.AreEqual(result["GRENOBLE, CHAVANT"][4], "C38:6080");
            Assert.AreEqual(result["GRENOBLE, CHAVANT"][5], "C38:6060");
            Assert.IsTrue(result.ContainsKey("GRENOBLE, CHAMPOLLION"));
            Assert.AreEqual(result["GRENOBLE, CHAMPOLLION"][0], "SEM:16");
        }

        /*
        [TestMethod]
        public void ObjectsTest()
        {
            //init
            Dictionary<string, List<string>> cci600 = new Dictionary<string, List<string>> {
                {"GRENOBLE, CASERNE DE BONNE", new List<string>() {"SEM:16"}},
                {"GRENOBLE, DOCTEUR MARTIN", new List<string>() {"SEM:C1",  "SEM:C4",  "SEM:13",  "SEM:16",  "SEM:12",  "C38:6020"}},
                {"GRENOBLE, CHAVANT", new List<string>() {"SEM:C1",  "C38:EXP2",  "C38:EXP1",  "C38:6200",  "C38:6080",  "C38:6060"}},
                {"GRENOBLE, CHAMPOLLION", new List<string>() {"SEM:16"}}
             };
            IConnectMetroAPI fakeRequestOnMetroData = new ConnectMetroAPIFake_StationsCCI600();
            Stations target = new Stations(fakeRequestOnMetroData);
            //action
            Dictionary<string, List<string>> result = target.GetSortedStationData();
            //assertion
            Assert.AreEqual(result, cci600);
            Assert.Equals(result, cci600);
        }
        */
    }
}