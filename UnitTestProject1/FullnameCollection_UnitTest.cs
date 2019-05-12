using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter_ClassLibrary1;
using System;
using System.IO;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest__FullnameCollection__Constructor
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null__Exception()
        {
            var x = new FullnameCollection(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BadFilename__Exception()
        {
            var x = new FullnameCollection("BadFileName.bad");
        }
    }

    [TestClass]
    public class UnitTest__FullnameCollection__ByLastnameGivenname
    {
        private const string LOWEST = "alpha alpha alpha alpha";
        private const string HIGHEST = "zulu zulu zulu zulu";
        private const string TestFilepath = "testdata.txt";

        [TestInitialize]
        public void Initialise()
        {
            // create test file.
            string[] lines = { "alpha alpha alpha bravo", HIGHEST, LOWEST, "alpha alpha alpha charlie", "alpha alpha alpha delta" };
            System.IO.File.WriteAllLines(TestFilepath, lines);
        }

        [TestMethod]
        public void FirstEntry__OK()
        {
            // arrange
            var x = new FullnameCollection(TestFilepath);

            // act
            string topEntry = x.ByLastnameGivenname.First().ToString();

            // assert
            //  make sure first entry is "alpha alpha alpha alpha"
            Assert.IsTrue(topEntry == LOWEST);
        }

        [TestMethod]
        public void LastEntry__OK()
        {
            // arrange
            var x = new FullnameCollection(TestFilepath);

            // act
            string bottomEntry = x.ByLastnameGivenname.Last().ToString();

            // assert
            //  make sure first entry is "alpha alpha alpha alpha"
            Assert.IsTrue(bottomEntry == HIGHEST);
        }
    }
}