using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter_ClassLibrary1;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest__Fullname__Constructor
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null__Exception()
        {
            var x = new Fullname(null);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyString__Exception()
        {
            var x = new Fullname(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OnlyOneName__Exception()
        {
            // RequiremnetDoc says "A name must have at least 1 given name".
            // so this call should throw exception
            var x = new Fullname("James");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooManyGivennames__Exception()
        {
            // RequiremnetDoc says "A name must have at least 1 given name and may have up to 3 given names"
            // this call has 4 given names and should throw exception
            var x = new Fullname("One Two Three Four James");
        }

        [TestMethod]
        public void TwoNames__OK()
        {
            // RequiremnetDoc says "A name must have at least 1 given name and may have up to 3 given names"
            // this call has 4 given names and should throw exception
            var x = new Fullname("Hans Solo");
        }

        [TestMethod]
        public void FourNames__OK()
        {
            // RequiremnetDoc says "A name must have at least 1 given name and may have up to 3 given names"
            // this call has 4 given names and should throw exception
            var x = new Fullname("Alpha Bravo Charlie Delta");
        }

        [TestMethod]
        public void ManySpaces1__OK()
        {
            // RequiremnetDoc says "A name must have at least 1 given name and may have up to 3 given names"
            // this call has 4 given names and should throw exception
            var x = new Fullname("Alpha  Bravo Charlie Delta");
        }

        [TestMethod]
        public void ManySpaces2__OK()
        {
            // RequiremnetDoc says "A name must have at least 1 given name and may have up to 3 given names"
            // this call has 4 given names and should throw exception
            var x = new Fullname("Alpha  Bravo                           Charlie     Delta");
        }
    }



    [TestClass]
    public class UnitTest__Fullname__Firstname
    {
        [TestMethod]
        public void FirstName1__OK()
        {
            // arrange
            var x = new Fullname("Hans Solo");
            // assert
            Assert.IsTrue(x.Givennames == "Hans");
        }

        [TestMethod]
        public void FirstName2__OK()
        {
            // arrange
            var x = new Fullname("Alpha   Bravo     Charlie       Delta");
            // assert
            Assert.IsTrue(x.Givennames == "Alpha Bravo Charlie");
        }

        [TestMethod]
        public void FirstName_LeadingSpaces__OK()
        {
            //arrange
            var x = new Fullname("   Hans Solo");
            // assert
            Assert.IsTrue(x.Givennames == "Hans");
        }

    }


    [TestClass]
    public class UnitTest__Fullname__Lastname
    {
        [TestMethod]
        public void Lastame1__OK()
        {
            // arrange
            var x = new Fullname("Hans Solo");
            // assert
            Assert.IsTrue(x.Lastname == "Solo");
        }

        [TestMethod]
        public void Lastname2__OK()
        {
            // arrange
            var x = new Fullname("Alpha   Bravo     Charlie       Delta");
            // assert
            Assert.IsTrue(x.Lastname == "Delta");
        }

        [TestMethod]
        public void Lastname_TrailingSpaces__OK()
        {
            //arrange
            var x = new Fullname("   Hans Solo    ");
            // assert
            Assert.IsTrue(x.Lastname == "Solo");
        }
    }

    [TestClass]
    public class UnitTest__Fullname__ToString
    {
        [TestMethod]
        public void ToString1__OK()
        {
            // arrange
            var testname = "Hans Solo";
            var x = new Fullname(testname);
            // assert
            Assert.IsTrue(x.ToString() == testname);
        }

        [TestMethod]
        public void ToString2__OK()
        {
            // arrange
            var testname = "    Hans       Solo      ";
            var x = new Fullname(testname);
            // assert
            Assert.IsTrue(x.ToString() == testname);
        }
    }
}

