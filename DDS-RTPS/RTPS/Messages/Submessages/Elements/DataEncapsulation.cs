
using System;
using System.Diagnostics;
namespace Rtps.Messages.Submessages.Elements
{
    public struct EncapsulationScheme
    {
        private byte b0;
        private byte b1;
        private byte b2;
        private byte b3;

        public EncapsulationScheme(byte b0, byte b1, byte b2, byte b3)
        {
            this.b0 = b0;
            this.b1 = b1;
            this.b2 = b2;
            this.b3 = b3;
        }
        public EncapsulationScheme(byte[] b)
        {
            Debug.Assert(b.Length == 4);
            this.b0 = b[0];
            this.b1 = b[1];
            this.b2 = b[2];
            this.b3 = b[3];
        }
        public byte B0
        {
            get { return b0; }
            set { b0 = value; }
        }
        public byte B1
        {
            get { return b1; }
            set { b1 = value; }
        }
        public byte B2
        {
            get { return b2; }
            set { b2 = value; }
        }
        public byte B3
        {
            get { return b3; }
            set { b3 = value; }
        }
    }

    /// <summary>
    /// This abstract class is a base class for different encapsulation schemes.
    /// DataEncapsulation is used by <i>Data</i> submessage.
    /// </summary>
    public abstract class DataEncapsulation
    {
        public static readonly EncapsulationScheme CDR_BE_HEADER = new EncapsulationScheme(0, 0, 0, 0);
        public static readonly EncapsulationScheme CDR_LE_HEADER = new EncapsulationScheme(0, 1, 0, 0);
        public static readonly EncapsulationScheme PL_CDR_BE_HEADER = new EncapsulationScheme(0, 2, 0, 0);
        public static readonly EncapsulationScheme PL_CDR_LE_HEADER = new EncapsulationScheme(0, 3, 0, 0);

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
