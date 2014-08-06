using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyTutorial02
{
    public static class SimpleEngine
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();


        public static TInterceptable MakeObject<TInterceptable>() where TInterceptable : class, new()
        {
            var interceptor = new Interceptor();
            var options = new ProxyGenerationOptions(new SimpleProxyGenerationHook());
            var proxy = _generator.CreateClassProxy<TInterceptable>(options, new Interceptor());
            return proxy;
        }
    }

    public class SimpleProxyGenerationHook : IProxyGenerationHook
    {
        public bool ShouldInterceptMethod(Type type, MethodInfo memberInfo)
        {
            return !memberInfo.Name.ToLowerInvariant().Contains("no");
        }

        public void NonVirtualMemberNotification(Type type, MemberInfo memberInfo)
        {
            Console.WriteLine("Warning, only virtual methods are interceptables. Method {0} is not virtual.", memberInfo.Name); 
        }

        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
            Console.WriteLine("Warning, only virtual methods are interceptables. Method {0} is not interceptable.", memberInfo.Name); 
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
