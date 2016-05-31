using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;

namespace CalcTest
{
    [TestClass]
    public class CalcTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestMethod()]
        public void mnozenie_2_liczb()
        {
            Multi target = new Multi(); // TODO: Initialize to an appropriate value
            object[] args = new string[2]; // TODO: Initialize to an appropriate value

            args[0] = "2.0";
            args[1] = "5.5";

            object expected = "11"; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.run(args);
            Assert.AreEqual(expected, actual);
            // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void mnozenie_3_liczb()
        {
            Multi target = new Multi(); // TODO: Initialize to an appropriate value
            object[] args = new string[3]; // TODO: Initialize to an appropriate value

            args[0] = "2.0";
            args[1] = "5";
            args[2] = "2.5";

            object expected = "25"; // TODO: Initialize to an appropriate value
            object actual = target.run(args);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void mul2number()
        {
            Multi target = new Multi();
            object[] args = new string[2];

            args[0] = "2.0";
            args[1] = "3.0";

            object expected = "6";
            object mul = target.run(args);

            Assert.AreEqual(expected, mul);
        }
    }
}
