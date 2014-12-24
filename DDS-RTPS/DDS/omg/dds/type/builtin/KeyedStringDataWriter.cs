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
using org.omg.dds.pub;
using org.omg.dds.core;
using org.omg.dds.core.modifiable;
using System.Text;

namespace org.omg.dds.type.builtin
{

    public interface KeyedstringDataWriter : DataWriter<Keyedstring>
    {
        InstanceHandle RegisterInstance(string key);

        InstanceHandle RegisterInstance(string key, Time sourceTimestamp);

        InstanceHandle RegisterInstance(string key, long sourceTimestamp, TimeUnit unit);

        void UnregisterInstance(string key);

        void UnregisterInstance(string key, Time sourceTimestamp);

        void UnregisterInstance(
              string key, long sourceTimestamp, TimeUnit unit);

        void Write(string key, string str);

        void Write(string key, string str, InstanceHandle handle);

        void Write(
              string key,
              string str,
              InstanceHandle handle,
              Time sourceTimestamp);

        void Write(
              string key,
              string str,
              InstanceHandle handle,
              long sourceTimestamp,
              TimeUnit unit);

        void Dispose(string key);

        void Dispose(string key, Time sourceTimestamp);

        void Dispose(string key, long sourceTimestamp, TimeUnit unit);

        StringBuilder GetKeyValue(StringBuilder key, InstanceHandle handle);

        ModifiableInstanceHandle LookupInstance(ModifiableInstanceHandle handle, string key);
    }
}