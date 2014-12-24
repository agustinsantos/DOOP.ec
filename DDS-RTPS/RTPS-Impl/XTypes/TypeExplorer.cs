using Doopec.Dds.XTypes;
using org.omg.dds.type;
using org.omg.dds.type.typeobject;
using Rtps.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Doopec.XTypes
{
    public static class TypeExplorer
    {
        public static org.omg.dds.type.typeobject.Type ExploreType(System.Type type)
        {
            org.omg.dds.type.typeobject.Type ddsType = null;
            if (type.IsClass || type.IsValueType)
            {
                ddsType = ExploreClass(type);
            }
            else if (type.IsEnum)
            {
                ddsType = ExploreEnum(type);
            }
            else
            {
                throw new NotImplementedException();
            }
            return ddsType;
        }

        private static StructureType ExploreClass(System.Type type)
        {
            StructureType ddsType = new StructureTypeImpl();

            TypeProperty typeProp = new TypePropertyImpl();
            typeProp.SetName(type.FullName);
            typeProp.SetTypeId(type.GetHashCode());
            TypeFlag flag = default(TypeFlag);
            flag |= (type.IsSealed ? TypeFlag.IS_FINAL : 0);
            typeProp.SetFlag(flag);
            ddsType.SetProperty(typeProp);

            List<Member> listMember = new List<Member>();
            var fields = type.GetFields(BindingFlags.Public |
                                        BindingFlags.Instance);
            uint lastId = 0;
            foreach (var member in fields)
            {
                Member memberInfo = new MemberImpl();
                NonFieldAttribute isField = member.GetCustomAttribute<NonFieldAttribute>();
                if (isField != null)
                    continue;

                MemberProperty memberProp = new MemberPropertyImpl();
                memberProp.SetName(member.Name);
                IDAttribute id = member.GetCustomAttribute<IDAttribute>();
                if (id != null)
                {
                    memberProp.SetMemberId(id.Value);
                    lastId = id.Value;
                }
                else
                {
                    lastId++;
                    memberProp.SetMemberId(lastId);
                }
                MemberFlag memberFlag = default(MemberFlag);
                KeyAttribute isKey = member.GetCustomAttribute<KeyAttribute>();
                if (isKey != null)
                {
                    memberFlag |= MemberFlag.IS_KEY;
                }
                OptionalAttribute isOptional = member.GetCustomAttribute<OptionalAttribute>();
                if (isOptional != null)
                {
                    memberFlag |= MemberFlag.IS_OPTIONAL;
                }

                memberProp.SetFlag(memberFlag);
                memberProp.IsProperty = false;
                memberInfo.SetProperty(memberProp);
                listMember.Add(memberInfo);
            }
            var props = type.GetProperties(BindingFlags.Public |
                                           BindingFlags.Instance);
            foreach (var member in props)
            {
                Member memberInfo = new MemberImpl();
                NonFieldAttribute isField = member.GetCustomAttribute<NonFieldAttribute>();
                if (isField != null) 
                    continue;
                MemberProperty memberProp = new MemberPropertyImpl();
                memberProp.SetName(member.Name);
                IDAttribute id = member.GetCustomAttribute<IDAttribute>();
                if (id != null)
                {
                    memberProp.SetMemberId(id.Value);
                    lastId = id.Value;
                }
                else
                {
                    continue; // TODO. Check if only process process members with ID
                    //lastId++;
                    //memberProp.SetMemberId(lastId);
                }
                MemberFlag memberFlag = default(MemberFlag);
                KeyAttribute isKey = member.GetCustomAttribute<KeyAttribute>();
                if (isKey != null)
                {
                    memberFlag |= MemberFlag.IS_KEY;
                }
                OptionalAttribute isOptional = member.GetCustomAttribute<OptionalAttribute>();
                if (isOptional != null)
                {
                    memberFlag |= MemberFlag.IS_OPTIONAL;
                }

                memberProp.SetFlag(memberFlag);
                memberProp.IsProperty = true;
                memberInfo.SetProperty(memberProp);
                listMember.Add(memberInfo);
            }
            ddsType.SetMember(listMember);

            return ddsType;
        }

        private static EnumerationType ExploreEnum(System.Type type)
        {
            EnumerationType ddsType = new EnumerationTypeImpl();

            TypeProperty typeProp = new TypePropertyImpl();
            typeProp.SetName(type.FullName);
            typeProp.SetTypeId(type.GetHashCode());
            TypeFlag flag = default(TypeFlag);
            //TODO flag |= (type.IsSealed? TypeFlag.IS_FINAL : 0);
            typeProp.SetFlag(flag);
            ddsType.SetProperty(typeProp);

            var bitbound = type.GetCustomAttribute<BitBoundAttribute>();
            if (bitbound != null)
            {
                Debug.Assert(bitbound.Value >= 1 && bitbound.Value <= 32, "The Value member may Take any Value from 1 to 32, inclusive, when this annotation is applied to an enumerated type.");

                ddsType.SetBitBound(bitbound.Value);
            }
            else
            {
                var ut = type.GetEnumUnderlyingType();
                if (ut == typeof(int) || ut == typeof(uint))
                {
                    ddsType.SetBitBound(32);
                }
                else if (ut == typeof(byte) || ut == typeof(sbyte))
                {
                    ddsType.SetBitBound(8);
                }
                else if (ut == typeof(short) || ut == typeof(ushort))
                {
                    ddsType.SetBitBound(16);
                }
                else if (ut == typeof(long) || ut == typeof(ulong))
                {
                    ddsType.SetBitBound(64);
                }
                else { throw new NotSupportedException(ut.ToString()); }
            }
            IList<EnumeratedConstant> listConstants = new List<EnumeratedConstant>();
            var fields = type.GetFields();
            var constantNames = type.GetEnumNames();
            var constantValues = type.GetEnumValues();
            for (int i = 0; i < constantNames.Length; i++)
            {
                EnumeratedConstant constant = new EnumeratedConstantImpl();
                constant.SetName(constantNames[i]);
                constant.SetValue((int)constantValues.GetValue(i));
                listConstants.Add(constant);
            }
            ddsType.SetConstant(listConstants);
            return ddsType;
        }
    }
}
