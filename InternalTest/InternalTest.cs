using System;

namespace InternalTest
{
    internal class InternalTestClass
    {
        public string InternalTestMethod()
        {
            return "This is the InternalTestMethod";
        }
    }

    public class InternalTestWithinDLLClass
    {
        InternalTestClass internalTestClass = new InternalTestClass(); // ** Can be instantiated because it's a class within the same assembly **

        public void InternalTestClassMethod()
        {
            Console.WriteLine(internalTestClass.InternalTestMethod());
        }
    }
}
