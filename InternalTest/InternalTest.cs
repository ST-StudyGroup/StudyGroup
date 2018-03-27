using System;

namespace InternalTest
{
    internal class InternalTest
    {
        public string InternalTestMethod()
        {
            return "This is the InternalTestMethod";
        }
    }

    public class InternalTestWithinDLL 
    {
        InternalTest internalTest = new InternalTest();

        public void InternalTestPrintStatement()
        {
            Console.WriteLine(internalTest.InternalTestMethod());
        }
    }
}
