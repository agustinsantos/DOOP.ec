
using System;

namespace Rtps.Attributes
{
    /// <summary>
    /// Declares a member as non filed. This will not be included.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | 
                    AttributeTargets.Field,
                    AllowMultiple = false, Inherited = true)]
    public class NonFieldAttribute : System.Attribute
    {
        public NonFieldAttribute()
        {
        }
    }
}
