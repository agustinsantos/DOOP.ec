
using log4net;
using Rtps.messages.submessage.attribute;
using Rtps.Structure;
using System.Collections.Generic;
using System.Reflection;
namespace Rtps.messages.elements
{

    /// <summary>
    ///  StatusInfo parameter. See 9.6.3.4 StatusInfo_t (PID_STATUS_INFO) for detailed
    ///  description.
    /// </summary>
    public class StatusInfo : Parameter
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected byte[] flags; // byte[4]

        public StatusInfo(params ChangeKind[] changeKinds)
            : base(ParameterId.PID_STATUS_INFO)
        {
            //(ParameterEnum.PID_STATUS_INFO);
            this.flags = new byte[4];

            foreach (ChangeKind kind in changeKinds)
            {
                switch (kind)
                {
                    case ChangeKind.DISPOSE:
                        this.flags[3] |= 0x1;
                        break;
                    case ChangeKind.UNREGISTER:
                        this.flags[3] |= 0x2;
                        break;
                    case ChangeKind.WRITE:
                        break; // Ignore
                    default:
                        log.WarnFormat("{o} not handled", kind);
                        break;
                }
            }
        }

        public StatusInfo()
            : this(ChangeKind.WRITE)
        {
        }

        /// <summary>
        /// If return value is <code>true</true>, means that the Data-object no longer exists.<br/>
        ///  Otherwise (return value is <code>false</code>) the Data-object continues existing.
        /// </summary>
        /// <returns></returns>
        public bool IsDisposed
        {
            get
            {
                return (flags[3] & 0x1) == 0x1;
            }
        }

        /// <summary>
        /// If return value is <code>true</code>, means that the writer will not provide further informations
        /// on the Data-object, in other words it has unregistered the Data-object.
        /// If return value is <code>false</code>, means that the writer plans to provide further informations
        /// on the Data-object.<br/>
        /// </summary>
        /// <returns></returns>
        public bool IsUnregistered
        {
            get
            {
                return (flags[3] & 0x2) == 0x2;
            }
        }

        public IList<ChangeKind> getChangeKinds()
        {
            IList<ChangeKind> ckList = new List<ChangeKind>();
            if (IsDisposed)
            {
                ckList.Add(ChangeKind.DISPOSE);
            }
            if (IsUnregistered)
            {
                ckList.Add(ChangeKind.UNREGISTER);
            }

            return ckList;
        }

        /// <summary>
        /// Gets the Kind of change represented by this StatusInfo. 
        ///  Note, that only one kind is returned, even if there are multiple flags set on
        ///  StatusInfo. Most significant change is DISPOSE, then UNREGISTER, and finally WRITE.
        /// </summary>
        /// <returns></returns>
        public ChangeKind getKind()
        {
            if (IsDisposed)
            {
                return ChangeKind.DISPOSE;
            }
            else if (IsUnregistered)
            {
                return ChangeKind.UNREGISTER;
            }
            else
            {
                return ChangeKind.WRITE;
            }
        }

        public byte[] FlagsBytes
        {
            get { return flags; }
            set { flags = value; }
        }
    }
}
