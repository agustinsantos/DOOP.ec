using org.omg.dds.core;
using System;

namespace Doopec.DDS.Core
{
    public class ValueImpl<UNMOD_SELF, MOD_SELF> : Value<UNMOD_SELF, MOD_SELF>
        where UNMOD_SELF : Value<UNMOD_SELF, MOD_SELF>
        where MOD_SELF : UNMOD_SELF
    {
        public MOD_SELF modify()
        {
            throw new NotImplementedException();
        }

        public Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
