
using Rtps.Structure.Types;
using System;
namespace Rtps.Structure
{


    /// <summary>
    /// From OMG RTPS Standard v2.1 p13: Represents an individual change made to a
    ///  data-object. Includes the creation, modification, and deletion of data-objects.
    /// </summary>
    public class CacheChange : IComparable<CacheChange>
    {
        private ChangeKind kind;
        private GUID writerGuid;
        private InstanceHandle instanceHandle = null;
        private SequenceNumber sequenceNumber = null;
        private Data data_value = null;


        public CacheChange(ChangeKind ck, GUID g, SequenceNumber sn, Data d, InstanceHandle ih)
        {
            kind = ck;
            writerGuid = g;
            instanceHandle = ih;
            sequenceNumber = new SequenceNumber(sn);
            data_value = d;
        }

        /// <summary>
        /// Identifies the kind of change.  
        /// </summary>
        public ChangeKind Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        /// <summary>
        /// The GUID_t that identifies the RTPS Writer that made the change
        /// </summary>
        public GUID WriterGuid
        {
            get { return writerGuid; }
            set { writerGuid = value; }
        }

        /// <summary>
        /// Identifies the instance of the data-object to which the change applies.
        /// </summary>
        public InstanceHandle InstanceHandle
        {
            get { return instanceHandle; }
            set { instanceHandle = value; }
        }

        /// <summary>
        /// Sequence number assigned by the RTPS Writer to uniquely identify the change
        /// </summary>
        public SequenceNumber SequenceNumber
        {
            get { return sequenceNumber; }
            set { sequenceNumber = value; }
        }

        /// <summary>
        /// The data value associated with the change. Depending on the kind of 
        /// CacheChange, there may be no associated data. 
        /// </summary>
        public Data DataValue
        {
            get { return data_value; }
            set { data_value = value; }
        }

        public int CompareTo(CacheChange o)
        {
            return this.sequenceNumber.CompareTo(o.sequenceNumber);
        }

    }
}
