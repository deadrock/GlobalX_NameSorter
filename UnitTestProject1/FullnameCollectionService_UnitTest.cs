using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter_ClassLibrary1;
using System;
using System.IO;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest__FullnameCollectionService__LoadFromFile
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null__Exception()
        {
            // arrange
            var service = new FullnameCollectionService();

            // act
            var collection = service.LoadFromFile(null);

            // assert
            // Exception should be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BadFilename__Exception()
        {
            // arrange
            var service = new FullnameCollectionService();

            // act
            var collection = service.LoadFromFile("BadFileName.bad");

            // assert
            // Exception should be thrown
        }
    }

    [TestClass]
    public class UnitTest__FullnameCollectionService__SortByLastnameGivenname
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
            var service = new FullnameCollectionService();
            var collection = service.LoadFromFile(TestFilepath);

            // act
            collection = service.SortByLastnameGivenname(collection);

            // assert
            //  make sure first entry is "alpha alpha alpha alpha"
            string topEntry = collection.First().ToString();
            Assert.IsTrue(topEntry == LOWEST);
        }

        [TestMethod]
        public void LastEntry__OK()
        {
            // arrange
            var service = new FullnameCollectionService();
            var collection = service.LoadFromFile(TestFilepath);

            // act
            collection = service.SortByLastnameGivenname(collection);

            // assert
            //  make sure first entry is "zulu zulu zulu zulu"
            string bottomEntry = collection.Last().ToString();
            Assert.IsTrue(bottomEntry == HIGHEST);
        }
    }

    [TestClass]
    public class UnitTest__FullnameCollectionService__WriteToFile
    {
        private const string LOWEST = "alpha alpha alpha alpha";
        private const string HIGHEST = "zulu zulu zulu zulu";
        private const string TestInputFilepath = "testdata.txt";
        private const string TestOutputFilepath = "testdata.txt";

        [TestInitialize]
        public void Initialise()
        {
            // create test file.
            string[] lines = { "alpha alpha alpha bravo", HIGHEST, LOWEST, "alpha alpha alpha charlie", "alpha alpha alpha delta" };
            System.IO.File.WriteAllLines(TestInputFilepath, lines);
        }

        [TestMethod]
        public void WriteToFile__OK()
        {
            // arrange
            var service = new FullnameCollectionService();
            var collection = service.LoadFromFile(TestInputFilepath);
            if (new System.IO.FileInfo(TestOutputFilepath).Exists)
            {
                System.IO.File.Delete(TestOutputFilepath);
            }

            // act
            service.WriteToFile(collection, TestOutputFilepath);

            // assert
            //  make sure first entry is "alpha alpha alpha alpha"
            // test out was created
            Assert.IsTrue(new System.IO.FileInfo(TestOutputFilepath).Exists);
            // test it has content.
            Assert.IsTrue(new System.IO.FileInfo(TestOutputFilepath).Length > 30 );
        }
    }
}
