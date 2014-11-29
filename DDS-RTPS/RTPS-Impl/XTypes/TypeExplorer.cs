using Doopec.Dds.XTypes;
using org.omg.dds.type;
using org.omg.dds.type.typeobject;
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
            if (type.IsClass)
            {
                ddsType = ExploreClass(type);
            }
            else if (type.IsValueType)
            {
                ddsType = ExploreValueType(type); 
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
        private static StructureType ExploreValueType(System.Type type)
        {
            throw new NotImplementedException();
        }
        private static StructureType ExploreClass(System.Type type)
        {
            StructureType ddsType = new StructureTypeImpl();

            TypeProperty typeProp = new TypePropertyImpl();
            typeProp.setName(type.FullName);
            typeProp.setTypeId(type.GetHashCode());
            TypeFlag flag = default(TypeFlag);
            //TODO flag |= (type.IsSealed? TypeFlag.IS_FINAL : 0);
            typeProp.setFlag(flag);
            ddsType.setProperty(typeProp);

            List<Member> listMember = new List<Member>();
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            uint lastId = 0;
            foreach (var member in fields)
            {
                Member memberInfo = new MemberImpl();

                MemberProperty memberProp = new MemberPropertyImpl();
                memberProp.setName(member.Name);
                IDAttribute id = member.GetCustomAttribute<IDAttribute>();
                if (id != null)
                {
                    memberProp.setMemberId(id.Value);
                    lastId = id.Value;
                }
                else
                {
                    lastId++;
                    memberProp.setMemberId(lastId);
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

                memberProp.setFlag(memberFlag);

                memberInfo.setProperty(memberProp);
                listMember.Add(memberInfo);
            }
            ddsType.SetMember(listMember);

            return ddsType;
        }

        private static EnumerationType ExploreEnum(System.Type type)
        {
            EnumerationType ddsType = new EnumerationTypeImpl();

            TypeProperty typeProp = new TypePropertyImpl();
            typeProp.setName(type.FullName);
            typeProp.setTypeId(type.GetHashCode());
            TypeFlag flag = default(TypeFlag);
            //TODO flag |= (type.IsSealed? TypeFlag.IS_FINAL : 0);
            typeProp.setFlag(flag);
            ddsType.setProperty(typeProp);

            var bitbound = type.GetCustomAttribute<BitBoundAttribute>();
            if (bitbound != null)
            {
                Debug.Assert(bitbound.Value >= 1 && bitbound.Value <= 32, "The value member may take any value from 1 to 32, inclusive, when this annotation is applied to an enumerated type.");

                ddsType.setBitBound(bitbound.Value);
            }
            else
            {
                var ut = type.GetEnumUnderlyingType();
                if (ut == typeof(int) || ut == typeof(uint))
                {
                    ddsType.setBitBound(32);
                }
                else if (ut == typeof(byte) || ut == typeof(sbyte))
                {
                    ddsType.setBitBound(8);
                }
                else if (ut == typeof(short) || ut == typeof(ushort))
                {
                    ddsType.setBitBound(16);
                }
                else if (ut == typeof(long) || ut == typeof(ulong))
                {
                    ddsType.setBitBound(64);
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
                constant.setName(constantNames[i]);
                constant.setValue((int)constantValues.GetValue(i));
                listConstants.Add(constant);
            }
            ddsType.setConstant(listConstants);
            return ddsType;
        }
    }
}
