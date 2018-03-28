namespace StudyGroup
{
    interface IInterfaceTest
    {
        string InterfaceMethodStringTesting();
        void InterfaceVoidMethodTesting(string methodName);
        void InterfaceStaticMethodTesting(string methodName); // Cannot implement static methods from interfaces.
    }
}
