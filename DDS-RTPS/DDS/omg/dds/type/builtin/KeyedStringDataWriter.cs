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
using org.omg.dds.pub;
using org.omg.dds.core;
using org.omg.dds.core.modifiable;
using System.Text;

namespace org.omg.dds.type.builtin
{

    public interface KeyedstringDataWriter : DataWriter<Keyedstring>
    {
        InstanceHandle registerInstance(string key);

        InstanceHandle registerInstance(string key, Time sourceTimestamp);

        InstanceHandle registerInstance(string key, long sourceTimestamp, TimeUnit unit);

        void unregisterInstance(string key);

        void unregisterInstance(string key, Time sourceTimestamp);

        void unregisterInstance(
              string key, long sourceTimestamp, TimeUnit unit);

        void write(string key, string str);

        void write(string key, string str, InstanceHandle handle);

        void write(
              string key,
              string str,
              InstanceHandle handle,
              Time sourceTimestamp);

        void write(
              string key,
              string str,
              InstanceHandle handle,
              long sourceTimestamp,
              TimeUnit unit);

        void dispose(string key);

        void dispose(string key, Time sourceTimestamp);

        void dispose(string key, long sourceTimestamp, TimeUnit unit);

        StringBuilder getKeyValue(StringBuilder key, InstanceHandle handle);

        ModifiableInstanceHandle lookupInstance(ModifiableInstanceHandle handle, string key);
    }
}