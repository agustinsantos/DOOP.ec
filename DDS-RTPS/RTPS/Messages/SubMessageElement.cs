
namespace Rtps.Messages
{
    public interface SubmessageElement
    {
        int Size { get; }
    }

    public abstract class SubmessageElement<T> : SubmessageElement
    {
        protected readonly int size;
        protected T value;

        public SubmessageElement(int size)
        {
            this.size = size;
        }

        public SubmessageElement(int size, T val)
        {
            this.size = size;
            this.value = val;
        }

        /// <summary>
        /// Returns the size in bytes of this submessage element
        /// when it is encoded in CDR.
        /// </summary>
        public int Size { get { return size; } }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            SubmessageElement<T> other = (SubmessageElement<T>)obj;
            return this.value.Equals(other.value);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}