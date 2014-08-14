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
        /// We want to check when the app change this value
        /// and propagate this.
        /// </summary>
        public virtual int Value { get; set; }

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
