
using System;
namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// This abstract class is a base class for different encapsulation schemes.
    /// DataEncapsulation is used by <i>Data</i> submessage.
    /// </summary>
    public abstract class DataEncapsulation
    {
        public static readonly byte[] CDR_BE_HEADER = new byte[] { 0, 0, 0, 0 };
        public static readonly byte[] CDR_LE_HEADER = new byte[] { 0, 1, 0, 0 };
        public static readonly byte[] PL_CDR_BE_HEADER = new byte[] { 0, 2, 0, 0 };
        public static readonly byte[] PL_CDR_LE_HEADER = new byte[] { 0, 3, 0, 0 };

        /// <summary>
        /// This method is not implemented at the moment.
        /// Currently, it is only possible to use predefined DataEncapsulations: CDREncapsulation and ParameterListEncapsulation
        /// </summary>
        /// <param name="dEnc"></param>
        public static void RegisterDataEncapsulation(DataEncapsulation dEnc)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks whether this encapsulation holds data or key as serialized
        ///  payload.
        /// </summary>
        /// <returns>true, if this encapsulation holds data</returns>
        public abstract bool ContainsData(); // as opposed to key

        /// <summary>
        /// Gets the payload as a byte array. Payload must contain an encapsulation
        ///  identifier as first 2 bytes.
        /// </summary>
        public abstract byte[] SerializedPayload { get; }

        public override string ToString()
        {
            return BitConverter.ToString(this.SerializedPayload);
        }
    }
}
