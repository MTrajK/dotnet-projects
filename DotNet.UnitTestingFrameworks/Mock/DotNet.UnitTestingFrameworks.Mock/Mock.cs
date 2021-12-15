using Castle.DynamicProxy;

namespace DotNet.UnitTestingFrameworks.Mock
{
    public class Mock<TInterface>
        where TInterface : class
    {
        private readonly MockInterceptor _interceptor;

        public readonly TInterface Object;

        public Mock() {
            _interceptor = new MockInterceptor();
            Object = new ProxyGenerator().CreateInterfaceProxyWithoutTarget<TInterface>(_interceptor);
        }

        public void Setup(string methodName, object[] expectedArguments, object returnValue)
        {
            _interceptor.RegisterMethod(methodName, new MockMethodInfo(expectedArguments, returnValue));
        }
    }
}
