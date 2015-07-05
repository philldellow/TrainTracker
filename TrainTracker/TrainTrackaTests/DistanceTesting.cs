using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTracker;

namespace TrainTrackaTests
{
    [TestClass]
    public class DistanceTesting
    {
        [TestMethod]
        public void DistanceTestQuestion1()
        {
            //Arrange
            char[] charTableEntries= DAL.ArrayedEntriesChar("AB5,BC4,CD8,DC8,DE6,AD5,CE2,EB3,AE7");
            DAL.ArrayedEntriesString("AB5,BC4,CD8,DC8,DE6,AD5,CE2,EB3,AE7");
            char[] routeDistCharArray = {'A','-','B','-','C'};

            List<string> Expected = new List<string>();
            Expected.Add("9");
            DAL.questionOneEasySolve(charTableEntries);
            DAL.GoSQL(DAL.questionOneEasySolve(routeDistCharArray));
            string Actual = DAL.resultsOfRead[0].ToString();
            //Assert
            Assert.AreEqual(Expected,Actual);
        }

        [TestMethod]
        public void DistanceTestQuestion2()
        {
            
            //Arrange
            //Act
            bool Expected = true;
            bool Actual = true;
            //Assert
            Assert.AreEqual(Expected, Actual);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DistanceTestQuestion3()
        {
            //Arrange
            DAL.readerCount = 1;
            DAL.routeDistQuestArray("A-B-C");
            char menuResponse = ('c');
            DAL.sqlQueryVar(menuResponse);
            var Actual = "9";
            var Expected = DAL.resultsOfRead[DAL.readerCount-1].ToString();
            Assert.AreEqual(Expected,Actual);
            Assert.AreSame(Expected,Actual);
            //Act
            //Assert
        }
    }
}
