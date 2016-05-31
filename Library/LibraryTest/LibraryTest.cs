using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using Microsoft.QualityTools.Testing.Fakes;
using System.Collections.Generic;

namespace LibraryTest
{
    [TestClass]
    public class LibraryTest
    {
        LibraryClass target = new LibraryClass();

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        [TestCategory("ISBNlength")]
        [Priority(0)]
        public void ISBNlengthOK()
        {
            int expected = 13;
            String isbn = "9788307004877";
            int actual = target.ISBNlength(isbn);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("ISBNlength")]
        [Priority(0)]
        public void ISBNlengthBad()
        {
            int expected = 13;
            String isbn = "abc00";
            int actual = target.ISBNlength(isbn);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("TitleLength")]
        [Priority(0)]
        public void TitleLengthOK()
        {
            String title = "Pan Tadeusz";

            Assert.IsTrue(target.minTitle(title));
        }

        [TestMethod]
        [TestCategory("TitleLength")]
        [Priority(0)]
        public void TitleLengthBad()
        {
            String title = "1";

            Assert.IsFalse(target.minTitle(title));
        }

        [TestMethod]
        [TestCategory("AutorLength")]
        [Priority(0)]
        public void AutorLengthOK()
        {
            String name = "Adam";
            String surname = "Mickiewicz";
            Assert.IsTrue(target.autorLength(name, surname));
        }

        [TestMethod]
        [TestCategory("AutorLength")]
        [Priority(0)]
        public void AutorLengthBad()
        {
            String name = "b";
            String surname = "xc";
            Assert.IsFalse(target.autorLength(name, surname));
        }

        [TestMethod]
        [TestCategory("LendersLength")]
        [Priority(0)]
        public void LibrarianLengthOK()
        {
            String name = "Adam";
            String surname = "Mickiewicz";
            Assert.IsTrue(target.librarianLength(name, surname));
        }

        [TestMethod]
        [TestCategory("LendersLength")]
        [Priority(0)]
        public void LibrarianLengthBad()
        {
            String name = "b";
            String surname = "xc";
            Assert.IsFalse(target.librarianLength(name, surname));
            surname = "ewewr";
            Assert.IsFalse(target.librarianLength(name, surname));
        }

        [TestMethod]
        [TestCategory("Phone")]
        [Priority(0)]
        public void PhoneLengthBad()
        {
            String number = "1";

            Assert.IsFalse(target.phoneLength(number));
        }


        [TestMethod]
        [TestCategory("Phone")]
        [Priority(0)]
        public void PhoneLengtOK()
        {
            string number = "48234432345";
            Assert.IsTrue(target.phoneLength(number));
        }

        [TestMethod]
        [TestCategory("Phone")]
        [Priority(0)]
        public void PhoneIncludeLetter()
        {
            String number = "asdsa";
            var result = target.phoneIncludeLetter(number);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("Address")]
        [Priority(0)]
        public void ZipCodeLength()
        {
            String zipCode = "1";

            Assert.IsFalse(target.zipCodeLength(zipCode));

            zipCode = "80-988";
            Assert.IsTrue(target.zipCodeLength(zipCode));
        }

        [TestMethod]
        [TestCategory("Address")]
        [Priority(0)]
        public void ZipCodeInclude()
        {
            String zipCode = "90-099";
            Assert.IsTrue(target.zipCodeInclude(zipCode));

            StringAssert.Contains(zipCode, "-");
        }

        [TestMethod]
        [Priority(0)]
        public void findAutorFakesShims()
        {
            using (var context = ShimsContext.Create())
            {
                var surname = "Mickiewicz";

                var c = new LibraryClass();
                Library.Fakes.ShimLibraryClass.AllInstances.autorsGet = (x) => new List<Autor>(new[] {
                    new Autor ("Adam", "Mickiewicz"),
               new Autor ("Jan", "Kochanowski"),
               new Autor ("Eliza", "Orzeszkowa"),
               new Autor ("Mikolaj", "Rej"),
               new Autor ("Mikolaj", "Rej"),
               new Autor ("Eliza", "Orzeszkowa"),
               new Autor ("Mikolaj", "Rej"),
               new Autor ("Juliusz", "Slowacki")
            });

                var result = c.findAutor(surname);

                Assert.IsNotNull(result);
                Assert.AreEqual(surname, result.Surname);
            }
        }


        [TestMethod]
        [Priority(0)]
        public void findBookFakesStub()
        {
            var d = new Library.Fakes.StubLibraryClass();

            d.books = new List<Book>(new[] { new Book ("Mały książe", "9788310128430", new Autor("Antoine","de Saint-Exupery")),
                    new Book ("Pan Tadeusz", " 9788373271920", new Autor("Adam", "Mickiewicz")),
                    new Book ("Katarynka", "9788378448815", new Autor("Boleslaw", "Prus")),
                    new Book ("Odprawa poslow grackich", "9788373271753", new Autor("Jan", "Kochanowski")),
                    new Book ("Wesele", "9788373272200", new Autor("Stanislaw", "Wyspianski")),
                    new Book ("Ogniem i mieczem", "9788374359443", new Autor("Henryk", "Sienkiewicz")),
                    new Book ("Przedwiosnie", "8386235284", new Autor("Stefan", "Zeromski"))
                });

            var title = "Pan Tadeusz";
            var result2 = d.findBook(title);

            Assert.IsNotNull(result2);
            Assert.AreEqual(title, result2.Title);
      
        }


        [DeploymentItem("data.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"), TestMethod]
        public void findLibrarianCVS()
        {

            var surname = testContextInstance.DataRow[1].ToString();

            var obj = target.findLibrarianList(surname);

            if (obj != null)
                Assert.AreEqual(surname, obj.Surname);
            else
                Assert.AreEqual(null, target.findAutor(testContextInstance.DataRow[1].ToString()));
        }

        [TestMethod]
        public void addNewBook()
        {
            List<Book> books = new List<Book>();

            int size = target.addBook(books);

            Assert.AreEqual(0, size);

            books = new List<Book>(new[] { new Book ("Pan Tadeusz", " 9788373271920", new Autor("Adam", "Mickiewicz")),
                    new Book ("Katarynka", "9788378448815", new Autor("Boleslaw", "Prus")),
                    new Book ("Odprawa poslow grackich", "9788373271753", new Autor("Jan", "Kochanowski")),
                    new Book ("Wesele", "9788373272200", new Autor("Stanislaw", "Wyspianski"))});

            size = target.addBook(books);

            Assert.AreEqual(4, size);
            CollectionAssert.AllItemsAreUnique(books);
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void exception()
        {
            List<Book> books = new List<Book>();

            books = new List<Book>(new[] { new Book ("Pan Tadeusz", " 9788373271920", new Autor("Adam", "Mickiewicz")),
                    new Book ("Katarynka", "9788378448815", new Autor("Boleslaw", "Prus"))
            });

            CollectionAssert.AllItemsAreNotNull(books);
            CollectionAssert.Contains(books, "Słowacki");
        }
    }
}