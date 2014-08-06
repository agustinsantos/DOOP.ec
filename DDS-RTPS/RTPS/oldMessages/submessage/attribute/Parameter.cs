

using Mina.Core.Buffer;
using rtps.messages.elements;
namespace rtps.messages.submessage.attribute
{
    /// <summary>
    /// Parameter is used to encapsulate data for builtin entities. see 9.6.2.2.2
    /// ParameterID values
    /// A ParameterList contains a list of Parameters, terminated with a sentinel. Each Parameter within the
    /// ParameterList starts aligned on a 4-byte boundary with respect to the start of the ParameterList.
    /// </summary>
    public class Parameter
    {
        private ParameterId parameterId;
        private byte[] bytes;

        public Parameter()
            : this(ParameterId.PID_UNKNOWN_PARAMETER, null)
        {
        }

        /// <summary>
        /// Constructs Parameter with null bytes. 
        /// Bytes are expected to be read by encoders
        /// </summary>
        /// <param name="id"></param>
        protected Parameter(ParameterId id)
            : this(id, null)
        {
        }

        /// <summary>
        /// Constructs Parameter with given bytes.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bytes"></param>
        protected Parameter(ParameterId id, byte[] bytes)
        {
            this.parameterId = id;
            this.bytes = bytes;
        }

        /// <summary>
        /// Get the parameterId of this parameter. see 9.6.2.2.2 ParameterID values
        /// </summary>
        public ParameterId ParameterId
        {
            get
            {
                return parameterId;
            }
            set
            {
                parameterId = value;
            }
        }

        /// <summary>
        /// Parameter value
        /// </summary>
        /// <returns></returns>
        public byte[] Bytes
        {
            get
            {
                return bytes;
            }
        }
    }
}
