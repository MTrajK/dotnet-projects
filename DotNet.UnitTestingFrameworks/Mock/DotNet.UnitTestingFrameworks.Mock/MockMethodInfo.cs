namespace DotNet.UnitTestingFrameworks.Mock
{
    internal class MockMethodInfo
    {
        public object[] Arguments;

        public object ReturnValue;

        public MockMethodInfo(object[] arguments, object returnValue)
        {
            Arguments = arguments;
            ReturnValue = returnValue;
        }
    }
}
