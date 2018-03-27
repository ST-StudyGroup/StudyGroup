using System;

namespace StudyGroup
{
    abstract class AbstractTest
    {
        public virtual void AbstractVoidMethodTesting()
        {
            Console.WriteLine("This is an overidden abstract method.");
        }

        public static string AbstractStringMethodTesting()
        {
            return "This is an abstract method not overriden.";
        }
    }
}
