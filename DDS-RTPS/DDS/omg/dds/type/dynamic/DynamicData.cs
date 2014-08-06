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
        DynamicType getType();

        /**
         * Modifying an element of the given list modifies the descriptor of this
         * DynamicData object, not a copy. Adding to or removing from the list
         * is not allowed.
         */
        List<MemberDescriptor> getDescriptors();

        int getMemberIdByName(string name);
        int getMemberIdAtIndex(int index);


        void clearAllValues();
        void clearNonkeyValues();
        void clearValue(int id);


        DynamicData loanValue(int id);
        void returnLoanedValue(DynamicData value);


        int getInt32Value(int id);
        /**
         * @return  this
         */
        DynamicData setInt32Value(int id, int value);

        short getInt16Value(int id);
        /**
         * @return  this
         */
        DynamicData setInt16Value(int id, short value);

        long getInt64Value(int id);
        /**
         * @return  this
         */
        DynamicData setInt64Value(int id, long value);

        BigInteger getBigIntegerValue(int id);
        /**
         * @return  this
         */
        DynamicData setBigIntegerValue(int id, BigInteger value);

        float getFloat32Value(int id);
        /**
         * @return  this
         */
        DynamicData setFloat32Value(int id, float value);

        double getFloat64Value(int id);
        /**
         * @return  this
         */
        DynamicData setFloat64Value(int id, double value);

        BigDecimal getBigDecimalValue(int id);
        /**
         * @return  this
         */
        DynamicData setBigDecimalValue(int id, BigDecimal value);

        char getCharValue(int id);
        /**
         * @return  this
         */
        DynamicData setCharValue(int id, char value);

        byte getByteValue(int id);
        /**
         * @return  this
         */
        DynamicData setByteValue(int id, byte value);

        bool getBooleanValue(int id);
        /**
         * @return  this
         */
        DynamicData setBooleanValue(int id, bool value);

        string getstringValue(int id);
        /**
         * @return  this
         */
        DynamicData setstringValue(int id, CharSequence value);

        DynamicData getComplexValue(DynamicData value, int id);
        /**
         * @return  this
         */
        DynamicData setComplexValue(int id, DynamicData value);


        int getInt32Values(int[] value, int offset, int length, int id);
        /**
         * @return  this
         */
        DynamicData setInt32Values(int id, int[] value, int offset, int length);
        /**
         * @return  this
         */
        DynamicData setInt32Values(int id, params int[] value);

        int getInt16Values(short[] value, int offset, int length, int id);
        /**
         * @return  this
         */
        DynamicData setInt16Values(int id, short[] value, int offset, int length);
        /**
         * @return  this
         */
        DynamicData setInt16Values(int id, params short[] value);

        int getInt64Values(long[] value, int offset, int length, int id);
        /**
         * @return  this
         */
        DynamicData setInt64Values(int id, long[] value, int offset, int length);
        /**
         * @return  this
         */
        DynamicData setInt64Values(int id, params long[] value);

        int getBigIntegerValues(BigInteger[] value, int offset, int length, int id);
        List<BigInteger> getBigIntegerValues(List<BigInteger> value, int id);
        /**
         * @return  this
         */
        DynamicData setBigIntegerValues(int id, BigInteger[] value, int offset, int length);
        /**
         * @return  this
         */
        DynamicData setBigIntegerValues(int id, List<BigInteger> value);

        int getFloat32Values(float[] value, int offset, int length, int id);
        /**
         * @return  this
         */
        DynamicData setFloat32Values(int id, float[] value, int offset, int length);
        /**
         * @return  this
         */
        DynamicData setFloat32Values(int id, params float[] value);

        int getFloat64Values(double[] value, int offset, int length, int id);
        /**
         * @return  this
         */
        DynamicData setFloat64Values(int id, double[] value, int offset, int length);
        /**
         * @return  this
         */
        DynamicData setFloat64Values(int id, params double[] value);

        int getBigDecimalValues(BigDecimal[] value, int offset, int length, int id);
        List<BigDecimal> getBigDecimalValues(List<BigDecimal> value, int id);
        /**
         * @return  this
         */
        DynamicData setBigDecimalValues(int id, BigDecimal[] value, int offset, int length);
        /**
         * @return  this
         */
        DynamicData setBigDecimalValues(int id, List<BigDecimal> value);

        int getCharValues(char[] value, int offset, int length, int id);
        StringBuilder getCharValues(StringBuilder value, int id);
        /**
         * @return  this
         */
        DynamicData setCharValues(int id, char[] value, int offset, int length);
        /**
         * @return  this
         */
        DynamicData setCharValues(int id, params char[] value);
        /**
         * @return  this
         */
        DynamicData setCharValues(int id, CharSequence value);

        int getByteValues(byte[] value, int offset, int length, int id);
        /**
         * @return  this
         */
        DynamicData setByteValues(int id, byte[] value, int offset, int length);

        int getBooleanValues(
               bool[] value, int offset, int length, int id);

        void getBooleanValues(List<bool> value, int id);
        /**
         * @return  this
         */
        DynamicData setBooleanValues(int id, bool[] value, int offset, int length);

        /**
         * @return  this
         */
        DynamicData setBooleanValues(int id, params bool[] value);

        int getstringValues(
               string[] value, int offset, int length, int id);
        void getstringValues(List<string> value, int id);

        /**
         * @return  this
         */
        DynamicData setstringValues(int id, string[] value, int offset, int length);

        /**
         * @return  this
         */
        DynamicData setstringValues(int id, params string[] value);

        /**
         * @return  this
         */
        DynamicData setstringValues(int id, List<string> value);


        //DynamicData clone();
    }
}