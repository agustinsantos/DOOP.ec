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
using org.omg.dds.core.modifiable;
using org.omg.dds.type;

namespace org.omg.dds.type.typeobject
{
    /* Literal value of an annotation member: either the default value in its
     * definition or the value applied in its usage.
     */
    [Extensibility(ExtensibilityKind.EXTENSIBLE_EXTENSIBILITY)]
    [Nested]
    public interface AnnotationMemberValue : ModifiableValue<AnnotationMemberValue, AnnotationMemberValue>
    {
        TypeKind discriminator();


        bool boolValue();

        void boolValue(bool value);


        byte byteValue();

        void byteValue(byte value);


        short int16Value();

        void int16Value(short value);


        short uint16Value();

        void uint16Value(short value);


        int int32Value();

        void int32Value(int value);


        int uint32Value();

        void uint32Value(int value);


        long int64Value();

        void int64Value(long value);


        long uint64Value();

        void uint64Value(long value);


        float float32Value();

        void float32Value(float value);


        double float64Value();

        void float64Value(double value);


        BigDecimal float128Value();

        void float128Value(BigDecimal value);


        char characterValue();

        void characterValue(char value);


        char wideCharacterValue();

        void wideCharacterValue(char value);


        int enumerationValue();

        void enumerationValue(int value);


        string stringValue();

        void stringValue(string value);
    }
}