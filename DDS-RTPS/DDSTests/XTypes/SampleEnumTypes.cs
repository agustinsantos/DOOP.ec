using org.omg.dds.type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTests.XTypes
{
    #region ENUM WITHOUT ATTRIBUTES/ANNOTATIONS
    public enum MyEnum
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five
    }

    public enum ByteEnum : byte
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five
    }

    public enum ShortEnum : short
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five
    }

    public enum IntEnum : int
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five
    }

    public enum LongEnum : long
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five
    }
    #endregion
    #region ENUM WITH ATTRIBUTES/ANNOTATIONS

    [BitBound(16)]
    public enum MyAnnotatedEnum
    {
        [Value(10)]
        Zero,
        [Value(11)]
        One,
        [Value(12)]
        Two,
        [Value(13)]
        Three,
        [Value(14)]
        Four,
        [Value(15)]
        Five
    }

    public enum ByteAnnotatedEnum : byte
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five
    }

    public enum ShortAnnotatedEnum : short
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five
    }

    public enum IntAnnotatedEnum : int
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five
    }

    public enum LongAnnotatedEnum : long
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five
    }
    #endregion
}
