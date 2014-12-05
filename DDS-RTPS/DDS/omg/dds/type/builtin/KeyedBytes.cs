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

namespace org.omg.dds.type.builtin
{

    public interface KeyedBytes : ModifiableValue<KeyedBytes, KeyedBytes>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The key</returns>
        string getKey();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">The key to set</param>
        /// <returns>this</returns>
        KeyedBytes setKey(CharSequence key);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The value</returns>
        byte[] getValue();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The value to set</param>
        /// <returns>this</returns>
        KeyedBytes setValue(byte[] value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The value to set</param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns>this</returns>
        KeyedBytes setValue(byte[] value, int offset, int length);
    }
}