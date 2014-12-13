using org.omg.dds.core;
using org.omg.dds.core.modifiable;
using System;

namespace Doopec.DDS.Core
{
    public class ModifiableValueImpl<UNMOD_SELF, MOD_SELF> : ValueImpl<UNMOD_SELF, MOD_SELF>, ModifiableValue<UNMOD_SELF, MOD_SELF>
        where UNMOD_SELF : Value<UNMOD_SELF, MOD_SELF>
        where MOD_SELF : UNMOD_SELF
    {
        public MOD_SELF CopyFrom(UNMOD_SELF other)
        {
            throw new NotImplementedException();
        }

        public UNMOD_SELF FinishModification()
        {
            throw new NotImplementedException();
        }
    }
}
