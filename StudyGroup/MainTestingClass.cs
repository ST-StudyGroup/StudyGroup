using System;

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

            // Abstract tests
            // var abstractmethods = new AbstractTest(); Cannot instantiate Abstract classes or interfaces. They are static by default
            interfaceAbstractMethod.AbstractVoidMethodTesting();
            Console.WriteLine(AbstractStringMethodTesting());

            // Sealed tests
            SealedTest sealedMethod = new SealedTest(); // Sealed can be instantiated but not inherited
            Console.WriteLine(sealedMethod.SealedMethodTest());

            // Interfaced tests
            Console.WriteLine(interfaceAbstractMethod.InterfaceMethodStringTesting());
            interfaceAbstractMethod.InterfaceVoidMethodTesting("Void");

            //Inheritance tests
            InheritanceTest inheritanceTest = new InheritanceTest()
        }

        // Overridden virtual abstract method
        public override void AbstractVoidMethodTesting() 
        {
            base.AbstractVoidMethodTesting();
        }

        // Interface implementation (the contact)
        public string InterfaceMethodStringTesting()
        {
            return "This is the Interface method!";
        }

        // Interface implementation (the contact)
        public void InterfaceVoidMethodTesting(string methodName)
        {
            Console.WriteLine($"This is {methodName} method!");
        }

        // Interface implementation (the contact)
        // Cannot make this static because an Interface is a contract not an implementation
        public void InterfaceStaticMethodTesting(string methodName) 
        {
            Console.WriteLine($"This is {methodName} method!");
        }
    }
}
