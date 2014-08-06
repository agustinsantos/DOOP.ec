namespace Rtps.Messages.Types
{
    /// <summary>
    /// Counter for progressive message counting
    /// </summary>
    public class Count
    {
        public static int COUNT_SIZE = 4;

        protected int value;

        public Count()
        {
            this.value = 0;
        }
        
        public Count(int value)
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
