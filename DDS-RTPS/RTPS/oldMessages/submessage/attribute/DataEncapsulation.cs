using Mina.Core.Buffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Messages.submessage.attribute
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

        /// <summary>
        /// Creates an instance of DataEncapsulation. Encapsulation identified by
        ///  reading first 2 bytes of serializedPayload.
        /// </summary>
        /// <param name="serializedPayload"></param>
        /// <returns></returns>
        public static DataEncapsulation CreateInstance(byte[] serializedPayload)
        {
            IoBuffer bb = IoBuffer.Wrap(serializedPayload);
            byte[] encapsulationHeader = new byte[2];
            bb.Get(encapsulationHeader, 0, 2);

            short eh = (short)(((short)encapsulationHeader[0] << 8) | (encapsulationHeader[1] & 0xff));

            switch (eh)
            {
                case 0:
                case 1:
                    bool littleEndian = (eh & 0x1) == 0x1;
                    if (littleEndian)
                    {
                        bb.Order = ByteOrder.LittleEndian;
                    }
                    else
                    {
                        bb.Order = ByteOrder.BigEndian;
                    }

                    return new CDREncapsulation(bb);
                case 2:
                case 3:

                    littleEndian = (eh & 0x1) == 0x1;
                    if (littleEndian)
                    {
                        bb.Order = ByteOrder.LittleEndian;
                    }
                    else
                    {
                        bb.Order = ByteOrder.BigEndian;
                    }

                    return new ParameterListEncapsulation(bb);
            }

            // TODO: handle this more gracefully
            return null;
        }

        public override string ToString()
        {
            return  BitConverter.ToString(this.SerializedPayload) ;
        }
    }
}
