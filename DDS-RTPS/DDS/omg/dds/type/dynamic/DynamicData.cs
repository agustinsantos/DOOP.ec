/* Copyright 2010, Object Management Group, Inc.
 * Copyright 2010, PrismTech, Inc.
 * Copyright 2010, Real-Time Innovations, Inc.
 * All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


using DDS.ConversionUtils;
using org.omg.dds.core;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace org.omg.dds.type.dynamic
{

    public interface DynamicData : DDSObject, ICloneable
    {
        DynamicType GetType();

        /// <summary>
        /// Modifying an element of the given list modifies the descriptor of this
        /// DynamicData object, not a copy. Adding to or removing from the list
        /// is not allowed.
        /// </summary>
        /// <returns></returns>
        List<MemberDescriptor> GetDescriptors();

        int GetMemberIdByName(string name);
        int GetMemberIdAtIndex(int index);


        void ClearAllValues();
        void ClearNonkeyValues();
        void ClearValue(int id);


        DynamicData LoanValue(int id);
        void ReturnLoanedValue(DynamicData value);


        int GetInt32Value(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetInt32Value(int id, int value);

        short GetInt16Value(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetInt16Value(int id, short value);

        long GetInt64Value(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetInt64Value(int id, long value);

        BigInteger GetBigIntegerValue(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetBigIntegerValue(int id, BigInteger value);

        float GetFloat32Value(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetFloat32Value(int id, float value);

        double GetFloat64Value(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetFloat64Value(int id, double value);

        BigDecimal GetBigDecimalValue(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetBigDecimalValue(int id, BigDecimal value);

        char GetCharValue(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetCharValue(int id, char value);

        byte GetByteValue(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData setByteValue(int id, byte value);

        bool GetBooleanValue(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetBooleanValue(int id, bool value);

        string GetstringValue(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetstringValue(int id, CharSequence value);

        DynamicData GetComplexValue(DynamicData value, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetComplexValue(int id, DynamicData value);


        int GetInt32Values(int[] value, int offset, int length, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        DynamicData SetInt32Values(int id, int[] value, int offset, int length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetInt32Values(int id, params int[] value);

        int GetInt16Values(short[] value, int offset, int length, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        DynamicData SetInt16Values(int id, short[] value, int offset, int length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetInt16Values(int id, params short[] value);

        int GetInt64Values(long[] value, int offset, int length, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        DynamicData SetInt64Values(int id, long[] value, int offset, int length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetInt64Values(int id, params long[] value);

        int GetBigIntegerValues(BigInteger[] value, int offset, int length, int id);
        List<BigInteger> GetBigIntegerValues(List<BigInteger> value, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        DynamicData SetBigIntegerValues(int id, BigInteger[] value, int offset, int length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetBigIntegerValues(int id, List<BigInteger> value);

        int GetFloat32Values(float[] value, int offset, int length, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        DynamicData SetFloat32Values(int id, float[] value, int offset, int length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetFloat32Values(int id, params float[] value);

        int GetFloat64Values(double[] value, int offset, int length, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        DynamicData SetFloat64Values(int id, double[] value, int offset, int length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetFloat64Values(int id, params double[] value);

        int GetBigDecimalValues(BigDecimal[] value, int offset, int length, int id);
        List<BigDecimal> GetBigDecimalValues(List<BigDecimal> value, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        DynamicData SetBigDecimalValues(int id, BigDecimal[] value, int offset, int length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetBigDecimalValues(int id, List<BigDecimal> value);

        int GetCharValues(char[] value, int offset, int length, int id);
        StringBuilder GetCharValues(StringBuilder value, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        DynamicData SetCharValues(int id, char[] value, int offset, int length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetCharValues(int id, params char[] value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetCharValues(int id, CharSequence value);

        int GetByteValues(byte[] value, int offset, int length, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        DynamicData SetByteValues(int id, byte[] value, int offset, int length);

        int GetBooleanValues(
               bool[] value, int offset, int length, int id);

        void GetBooleanValues(List<bool> value, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        DynamicData SetBooleanValues(int id, bool[] value, int offset, int length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetBooleanValues(int id, params bool[] value);

        int GetstringValues(
               string[] value, int offset, int length, int id);
        void GetstringValues(List<string> value, int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        DynamicData SetstringValues(int id, string[] value, int offset, int length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetstringValues(int id, params string[] value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Value"></param>
        /// <returns>this</returns>
        DynamicData SetstringValues(int id, List<string> value);


        //DynamicData clone();
    }
}