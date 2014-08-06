using Castle.DynamicProxy;
using System;

namespace DynamicProxyTutorial01
{
    public static class SimpleEngine
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();


        public static TInterceptable MakeObject<TInterceptable>() where TInterceptable : class, new()
        {
            var interceptor = new Interceptor();
            var proxy = _generator.CreateClassProxy<TInterceptable>(new Interceptor());
            return proxy;
        }
    }

    public class Interceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Before target call:" + invocation.Method.Name);
            invocation.Proceed();
            Console.WriteLine("After target call:" + invocation.Method.Name);
        }
    }
}
