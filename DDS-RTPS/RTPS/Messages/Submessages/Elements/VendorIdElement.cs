using Rtps.Structure.Types;
namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// The VendorId identifies the vendor of the middleware implementing the RTPS protocol and allows this vendor to add
    /// specific extensions to the protocol. The vendor ID does not refer to the vendor of the device or product that contains DDS
    /// middleware.
    /// </summary>
    public class VendorIdElement : SubmessageElement<VendorId>
    {
        public static int VENDOR_ID_SIZE = 2;

        public VendorIdElement(VendorId value)
            : base(VENDOR_ID_SIZE, value)
        {
        }

        public VendorIdElement()
            : this(new VendorId())
        {
        }
    }
}
