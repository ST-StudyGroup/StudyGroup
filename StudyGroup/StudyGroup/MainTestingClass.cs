using System;
using InternalTest;
using StudyGroup.KeywordTests;

namespace StudyGroup
{
    class MainTestingClass : AbstractTest, IInterfaceTest
    {
        public MainTestingClass()
        {

        }

        static void Main(string[] args)
        {
            MainTestingClass interfaceAbstractMethod = new MainTestingClass();

            // InternalTestClass internalTest = new InternalTestClass(); ** Holds the internal keyword and cannot be accessed since it's outside of the assembly **
            InternalTestWithinDLLClass internalTest = new InternalTestWithinDLLClass();
            internalTest.InternalTestClassMethod(); // ** Works because it is instantiated within another class which is not internal **

            // var abstractmethods = new AbstractTest(); Cannot instantiate Abstract classes or interfaces. They are static by default
            interfaceAbstractMethod.AbstractVoidMethodTesting();
            Console.WriteLine(AbstractStringMethodTesting());

            SealedTest sealedMethod = new SealedTest(); // Sealed can be instantiated but not inherited
            Console.WriteLine(sealedMethod.SealedMethodTest());

            Console.WriteLine(interfaceAbstractMethod.InterfaceMethodStringTesting());
            interfaceAbstractMethod.InterfaceVoidMethodTesting("Void");

            InheritanceTest inheritanceTest = new InheritanceTest();

            CheckedTest checking = new CheckedTest();
            Console.WriteLine(checking.AccountTotalNotChecking(25, false));

            // This will throw a runtime error because it's enclosed by the "checked" keyword 
            Console.WriteLine(checking.AccountTotalChecking(25));
        }
        
        public override void AbstractVoidMethodTesting() 
        {
            base.AbstractVoidMethodTesting();
        }
        
        public string InterfaceMethodStringTesting()
        {
            return "This is the Interface method!";
        }
        
        public void InterfaceVoidMethodTesting(string methodName)
        {
            Console.WriteLine($"This is {methodName} method!");
        }
        
        public void InterfaceStaticMethodTesting(string methodName) 
        {
            Console.WriteLine($"This is {methodName} method!");
        }
    }
}
