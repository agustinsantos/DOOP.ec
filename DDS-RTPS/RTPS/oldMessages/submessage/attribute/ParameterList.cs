using log4net;
using rtps.messages.elements;
using RTPS.Utils;
using System.Collections.Generic;
using System.Reflection;

namespace rtps.messages.submessage.attribute
{
    /// <summary>
    /// A ParameterList contains a list of Parameters, terminated with a sentinel. Each Parameter within the
    /// ParameterList starts aligned on a 4-byte boundary with respect to the start of the ParameterList.
    /// </summary>
    public class ParameterList : IList<Parameter>
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        IList<Parameter> params_;

        public ParameterList()
        {
            params_ = new System.Collections.Generic.List<Parameter>();
        }

        public ParameterList(ICollection<Parameter> val)
        {
            params_ = new System.Collections.Generic.List<Parameter>(val);
        }

        public int IndexOf(Parameter item)
        {
            return params_.IndexOf(item);
        }

        public void Insert(int index, Parameter item)
        {
            params_.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            params_.RemoveAt(index);
        }

        public Parameter this[int index]
        {
            get
            {
                return params_[index];
            }
            set
            {
                params_[index] = value;
            }
        }

        public void Add(Parameter item)
        {
            params_.Add(item);
        }

        public void Clear()
        {
            params_.Clear();
        }

        public bool Contains(Parameter item)
        {
            return params_.Contains(item);
        }

        public void CopyTo(Parameter[] array, int arrayIndex)
        {
            params_.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return params_.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return params_.IsReadOnly;
            }
        }

        public bool Remove(Parameter item)
        {
            return params_.Remove(item);
        }

        public IEnumerator<Parameter> GetEnumerator()
        {
            return params_.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return params_.GetEnumerator();
        }

        public Parameter this[ParameterId pid]
        {
            get
            {
                foreach (Parameter p in params_)
                {
                    if (pid.Equals(p.ParameterId))
                    {
                        return p;
                    }
                }
                return null;
            }
        }
    }
}
