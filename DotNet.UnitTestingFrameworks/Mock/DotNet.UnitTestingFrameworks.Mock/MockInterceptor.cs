using Castle.DynamicProxy;
using System;
using System.Collections.Generic;

namespace DotNet.UnitTestingFrameworks.Mock
{
    internal class MockInterceptor : IInterceptor
    {
        private readonly Dictionary<string, MockMethodInfo> _methods;

        public MockInterceptor() : base()
        {
            _methods = new Dictionary<string, MockMethodInfo>();
        }

        public void RegisterMethod(string methodName, MockMethodInfo methodInfo)
        {
            _methods.Add(methodName, methodInfo);
        }

        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;

            var type = invocation.Method.ReturnType;
            invocation.ReturnValue = type.IsValueType ? Activator.CreateInstance(type) : null;

            if (_methods.ContainsKey(methodName))
            {
                var mockMethodInfo = _methods[methodName];
                var expectedArguments = mockMethodInfo.Arguments;
                var actualArguments = invocation.Arguments;

                if (expectedArguments.Length == actualArguments.Length)
                {
                    var match = true;

                    for (var i = 0; i < expectedArguments.Length; i++)
                    {
                        if (!expectedArguments[i].Equals(actualArguments[i]))
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match)
                        invocation.ReturnValue = mockMethodInfo.ReturnValue;
                }
            }
        }
    }
}