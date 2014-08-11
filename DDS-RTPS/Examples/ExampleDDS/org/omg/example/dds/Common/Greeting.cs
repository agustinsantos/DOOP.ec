namespace ExampleDDS.Common
{
    public class Greeting
    {
        private readonly string value;

        public Greeting(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return this.value; }
        }
    }
}