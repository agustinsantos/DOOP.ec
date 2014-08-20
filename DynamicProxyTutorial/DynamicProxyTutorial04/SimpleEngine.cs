using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyTutorial03
{
    public static class SimpleEngine
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();
        private static ProxyGenerationOptions options = new ProxyGenerationOptions(new SimpleProxyGenerationHook());

        public static TInterceptable MakeDDSObject<TInterceptable>(string domain) where TInterceptable : class, IDDSObject, new()
        {
            DDSProxySink interceptor = new DDSProxySink();
            var proxy = _generator.CreateClassProxy<TInterceptable>(options, new DDSProxySink());
            IDDSObject ddsproxy = proxy as IDDSObject;
            if (ddsproxy != null)
                ddsproxy.DomainName = domain;
            return proxy;
        }
    }

    public class SimpleProxyGenerationHook : IProxyGenerationHook
    {
        public bool ShouldInterceptMethod(Type type, MethodInfo memberInfo)
        {
            return IsSetMethodForDDSObject(type, memberInfo);
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

        protected Boolean IsSetMethodForDDSObject(Type type, MethodInfo methodInfo)
        {
            IEnumerable<CustomAttributeData> attrs = methodInfo.CustomAttributes;
            foreach (var attr in attrs)
                if (attr.AttributeType == typeof(RemoteMethodAttribute))
                    return true;
            return false;
        }
    }

    public class DDSProxySink : StandardInterceptor
    {
        //protected override void PreProceed(IInvocation invocation)
        //{
        //    Console.WriteLine(">>> INSIDE THE ENGINE : In PreProceed " + invocation.Method);
        //}

        //protected override void PostProceed(IInvocation invocation)
        //{
        //    Console.WriteLine(">>> INSIDE THE ENGINE : In PostProceed " + invocation.Method);
        //}

        protected override void PerformProceed(IInvocation invocation)
        {
            IDDSObject obj = invocation.InvocationTarget as IDDSObject;

            string domain = obj.DomainName;
            if (!String.IsNullOrWhiteSpace(domain))
            {
                Console.WriteLine(">>> INSIDE THE ENGINE : This object is in the domain: " + domain);
                Console.WriteLine(">>> INSIDE THE ENGINE : The Method to intercepted is: " + invocation.Method.Name);
                invocation.Proceed();
            }
        }
    }
}
