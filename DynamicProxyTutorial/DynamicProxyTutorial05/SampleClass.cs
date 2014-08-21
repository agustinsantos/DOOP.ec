using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyTutorial03
{

    public interface IDDSObject
    {
        string DomainName { get; set; }
    }

    public class DDSObject : IDDSObject
    {
        public string DomainName { get; set; }
    }

    /// <summary>
    /// This class will be intercepted
    /// </summary>
    public class SampleClass : DDSObject
    {
        /// <summary>
        /// As this method is annotated, it will be intercepted.
        /// </summary>
        [RemoteMethod]
        public virtual void Method1()
        { Console.WriteLine("I'm inside method 1");  }

        /// <summary>
        /// This property is annotated, the set method will be intercepted (but not the get method).
        /// </summary>
        [RemoteProperty]
        public virtual string SomeValue { get; set; }
    }

}
