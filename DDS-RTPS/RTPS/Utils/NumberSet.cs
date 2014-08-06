 
using System;
using System.Collections.Generic;
using System.Text;
 

namespace RTPS.Utils
{
    public interface Diff<E>
    {
        int Diff(E val);
    }

    public class NumberSet<E>  where E : Diff<E>
    {
        public const int MAX_SET_INTERVAL = 256;

        private E base_;
        private IList<E> set = new System.Collections.Generic.List<E>();

        public NumberSet(E base_)
        {
            this.base_ = base_;
        }

        public NumberSet(E b, ICollection<E> c)
        {
            this.base_ = b;
            foreach (E e in c)
            {
                Add(e);
            }
        }

        public void Add(E e)
        {
            if (e.Diff(base_) > MAX_SET_INTERVAL)
            {
                throw new System.IndexOutOfRangeException();
            }
            set.Add(e);
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(base_.ToString() + "\n");
            foreach (E e in set)
            {
                s.Append("--" + e.ToString() + "\n");
            }
            return s.ToString();
        }

    }
}
