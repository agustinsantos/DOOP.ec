namespace rtps.messages.elements
{
    /// <summary>
    /// Counter for progressive message counting
    /// </summary>
    public class Count : SubMessageElement
    {
        public static int COUNT_SIZE = 4;

        protected int value;

        public Count(int value)
            : base(COUNT_SIZE)
        {
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Count other = (Count)obj;
            return this.value == other.value;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.value;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
