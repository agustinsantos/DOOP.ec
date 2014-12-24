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
 * See the License for the specific Language governing permissions and
 * limitations under the License.
 */


using DDS.ConversionUtils;
using org.omg.dds.core.modifiable;
using org.omg.dds.type;

namespace org.omg.dds.type.typeobject
{
    /// <summary>
    /// Literal Value of an annotation member: either the default Value in its
    /// definition or the Value applied in its usage
    /// </summary>
    [Extensibility(ExtensibilityKind.EXTENSIBLE_EXTENSIBILITY)]
    [Nested]
    public interface AnnotationMemberValue : ModifiableValue<AnnotationMemberValue, AnnotationMemberValue>
    {
        TypeKind Discriminator();


        bool BoolValue();

        void BoolValue(bool value);


        byte ByteValue();

        void ByteValue(byte value);


        short Int16Value();

        void Int16Value(short value);


        short Uint16Value();

        void Uint16Value(short value);


        int Int32Value();

        void Int32Value(int value);


        int Uint32Value();

        void Uint32Value(int value);


        long Int64Value();

        void Int64Value(long value);


        long Uint64Value();

        void Uint64Value(long value);


        float Float32Value();

        void Float32Value(float value);


        double Float64Value();

        void Float64Value(double value);


        BigDecimal Float128Value();

        void Float128Value(BigDecimal value);


        char CharacterValue();

        void CharacterValue(char value);


        char WideCharacterValue();

        void WideCharacterValue(char value);


        int EnumerationValue();

        void EnumerationValue(int value);


        string StringValue();

        void StringValue(string value);
    }
}