// <copyright file="LibraryClassTest.cs">Copyright ©  2016</copyright>
using System;
using Library;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests
{
    /// <summary>This class contains parameterized unit tests for LibraryClass</summary>
    [PexClass(typeof(LibraryClass))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class LibraryClassTest
    {
        /// <summary>Test stub for ISBNlength(String)</summary>
        [PexMethod]
        public int ISBNlengthTest([PexAssumeUnderTest]LibraryClass target, string isbn)
        {
            int result = target.ISBNlength(isbn);
            return result;
            // TODO: add assertions to method LibraryClassTest.ISBNlengthTest(LibraryClass, String)
        }

        /// <summary>Test stub for autorLength(String, String)</summary>
        [PexMethod]
        public bool autorLengthTest(
            [PexAssumeUnderTest]LibraryClass target,
            string name,
            string surname
        )
        {
            bool result = target.autorLength(name, surname);
            return result;
            // TODO: add assertions to method LibraryClassTest.autorLengthTest(LibraryClass, String, String)
        }

        /// <summary>Test stub for lendersLength(String, String)</summary>
        [PexMethod]
        public bool lendersLengthTest(
            [PexAssumeUnderTest]LibraryClass target,
            string name,
            string surname
        )
        {
            bool result = target.lendersLength(name, surname);
            return result;
            // TODO: add assertions to method LibraryClassTest.lendersLengthTest(LibraryClass, String, String)
        }

        /// <summary>Test stub for minTitle(String)</summary>
        [PexMethod]
        public bool minTitleTest([PexAssumeUnderTest]LibraryClass target, string title)
        {
            bool result = target.minTitle(title);
            return result;
            // TODO: add assertions to method LibraryClassTest.minTitleTest(LibraryClass, String)
        }

        /// <summary>Test stub for phoneIncludeLetter(String)</summary>
        [PexMethod]
        public bool phoneIncludeLetterTest([PexAssumeUnderTest]LibraryClass target, string number)
        {
            bool result = target.phoneIncludeLetter(number);
            return result;
            // TODO: add assertions to method LibraryClassTest.phoneIncludeLetterTest(LibraryClass, String)
        }

        /// <summary>Test stub for phoneLength(String)</summary>
        [PexMethod]
        public bool phoneLengthTest([PexAssumeUnderTest]LibraryClass target, string number)
        {
            bool result = target.phoneLength(number);
            return result;
            // TODO: add assertions to method LibraryClassTest.phoneLengthTest(LibraryClass, String)
        }

        /// <summary>Test stub for zipCodeInclude(String)</summary>
        [PexMethod]
        public bool zipCodeIncludeTest([PexAssumeUnderTest]LibraryClass target, string zipCode)
        {
            bool result = target.zipCodeInclude(zipCode);
            return result;
            // TODO: add assertions to method LibraryClassTest.zipCodeIncludeTest(LibraryClass, String)
        }

        /// <summary>Test stub for zipCodeLength(String)</summary>
        [PexMethod]
        public bool zipCodeLengthTest([PexAssumeUnderTest]LibraryClass target, string zipCode)
        {
            bool result = target.zipCodeLength(zipCode);
            return result;
            // TODO: add assertions to method LibraryClassTest.zipCodeLengthTest(LibraryClass, String)
        }
    }
}
