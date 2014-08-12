using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyTutorial02
{
    public class SampleClass 
    {
        /// <summary>
        /// This method will be intercepted
        /// Only method with "no" in the name will not be intercepted
        /// </summary>
        /// <returns></returns>
        public virtual string SayIntercepted()
        {
            return "This method is intercepted ";
        }

        public virtual string SayNoIntercepted()
        {
            return "This method is not intercepted";
        }

        public string SayNoIntercepted2()
        {
            return "This method is not intercepted";
        }
    }
}
