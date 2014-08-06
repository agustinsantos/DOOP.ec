
using Rtps.Structure.Types;
using RTPS.Utils;
using System.Collections.Generic;
namespace Rtps.Messages.Submessages.Elements
{
    public class LocatorList : IList<Locator>
    {
        IList<Locator> value = new System.Collections.Generic.List<Locator>();

        public LocatorList(ICollection<Locator> value)
        {
        }

        public int IndexOf(Locator item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, Locator item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public Locator this[int index]
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public void Add(Locator item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(Locator item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(Locator[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public int Count
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool Remove(Locator item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<Locator> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
