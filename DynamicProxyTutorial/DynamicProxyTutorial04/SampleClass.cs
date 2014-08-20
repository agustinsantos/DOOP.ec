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

    /// <summary>
    /// This class will be intercepted
    /// </summary>
    public class SampleClass : IDDSObject
    {
        /// <summary>
        /// As this method is annotated, it will be intercepted.
        /// </summary>
        [RemoteMethodAttribute]
        public virtual void Method1()
        { Console.WriteLine("I'm inside method 1");  }

        /// <summary>
        /// This method is NOT annotated, therefore, it will NOT be intercepted.
        /// </summary>
        public virtual void Method2()
        { Console.WriteLine("I'm inside method 2"); }

        public string DomainName { get; set; }
    }

    /// <summary>
    /// This class can't be intercepted
    /// </summary>
    public class NormalClass
    {
        public virtual int Value { get; set; }
    }
}
