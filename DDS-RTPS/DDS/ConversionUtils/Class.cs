using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.ConversionUtils
{
    public class Class<T>
    {
        public Type Type { get; private set; }
        public Class(Type t)
        {
            if (!typeof(T).IsAssignableFrom(t)) throw new Exception();
            Type = t;
        }

        public static implicit operator Class<T>(Type t)
        {
            return new Class<T>(t);
        }
    }

/*
    public class ClassStatus<T> : Class<T> where T : Status
    {
        public Type Type { get; private set; }
        public ClassStatus(Type t)
        {
            if (!typeof(T).IsAssignableFrom(t)) throw new Exception();
            Type = t;
        }

        public static implicit operator Class<T>(Type t)
        {
            return new Class<T>(t);
        }
    }
 */
}
