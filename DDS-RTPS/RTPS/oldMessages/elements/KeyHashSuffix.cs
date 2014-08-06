#if TODO
namespace rtps.messages.elements
{

    public class KeyHashSuffix : EntityId
    {

        protected KeyHashSuffix_t value;

        public KeyHashSuffix(KeyHashSuffix_t value)
        {
            super(new EntityId_t(new byte[] { value.value[0], value.value[1], value.value[2] }, value.value[3]));
            this.value = value;
        }

        public void write(OutputStream os)
        {
            KeyHashSuffix_tHelper.write(os, value);
        }
    }
}
#endif