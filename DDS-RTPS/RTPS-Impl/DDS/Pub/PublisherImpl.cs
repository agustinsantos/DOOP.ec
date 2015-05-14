﻿using DDS.ConversionUtils;
using Doopec.Configuration;
using Doopec.Dds.Core;
using Doopec.Dds.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using org.omg.dds.domain;
using org.omg.dds.pub;
using org.omg.dds.pub.modifiable;
using org.omg.dds.topic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Doopec.Dds.Pub
{
    public class PublisherImpl : Publisher
    {
        private PublisherQos qos;
        private DomainParticipant parent;
        private DataWriterQosImpl dataWriterqos;
        private PublisherListener listener;
        private IList datawriters;
        private DDSConfigurationSection ddsConfig = Doopec.Configuration.DDSConfigurationSection.Instance;
        public Bootstrap Bootstrap { get; internal set; }

        public PublisherImpl(PublisherQos qos, PublisherListener listener, DomainParticipant dp, Bootstrap bootstrap)
        {
            this.qos = qos;
            this.listener = listener;
            this.parent = dp;
            this.Bootstrap = bootstrap;
            datawriters = new System.Collections.ArrayList();
            dataWriterqos = new DataWriterQosImpl(this.GetBootstrap());

            string qosConfigProfile = ddsConfig.Domains[dp.DomainId].QoSProfile.Name;
            Doopec.Configuration.Dds.QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[qosConfigProfile];

            if (qosProfile != null)
            {
                Doopec.Configuration.Dds.DataWriterQoS dataWriterProfileQos = qosProfile.DataWriterQoS;
                // TODO Assign values to dataWriterqos from configuration
                if (dataWriterProfileQos == null)
                    return;
                if (dataWriterProfileQos.Reliability != null)
                {
                    ReliabilityQosPolicyImpl dpqMod = new ReliabilityQosPolicyImpl(this.GetBootstrap());
                    if (dataWriterProfileQos.Reliability.Kind == Doopec.Configuration.Reliability.RELIABLE)
                        dpqMod = new ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind.RELIABLE, this.GetBootstrap());
                    else if (dataWriterProfileQos.Reliability.Kind == Doopec.Configuration.Reliability.BEST_EFFORT)
                        dpqMod = new ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind.BEST_EFFORT, this.GetBootstrap());
                    dpqMod.MaxBlockingTimeQos = new DurationImpl(this.GetBootstrap(), dataWriterProfileQos.Reliability.MaxBlockingTime);
                    dataWriterqos.Reliability = dpqMod;
                }

                if (dataWriterProfileQos.Durability != null)
                {
                    DurabilityQosPolicyImpl dpqMod = new DurabilityQosPolicyImpl(this.GetBootstrap());
                    switch (dataWriterProfileQos.Durability.Kind)
                    {
                        case Durability.PERSISTENT:
                            dpqMod.KindQos = DurabilityQosPolicyKind.PERSISTENT;
                            break;
                        case Durability.TRANSIENT:
                            dpqMod.KindQos = DurabilityQosPolicyKind.TRANSIENT;
                            break;
                        case Durability.TRANSIENT_LOCAL:
                            dpqMod.KindQos = DurabilityQosPolicyKind.TRANSIENT_LOCAL;
                            break;
                        case Durability.VOLATILE:
                            dpqMod.KindQos = DurabilityQosPolicyKind.VOLATILE;
                            break;
                    }
                    dataWriterqos.Durability = dpqMod;
                }
                if (dataWriterProfileQos.Deadline != null)
                {
                    // TODO dataWriterProfileQos.Deadline
                }
                if (dataWriterProfileQos.DurabilityService != null)
                {
                    // TODO dataWriterProfileQos.Deadline
                }
                if (dataWriterProfileQos.LatencyBudget != null)
                {
                    // TODO dataWriterProfileQos.LatencyBudget
                }
                if (dataWriterProfileQos.Liveliness != null)
                {
                    // TODO dataWriterProfileQos.LatencyBudget
                }
                if (dataWriterProfileQos.DestinationOrder != null)
                {
                    // TODO dataWriterProfileQos.DestinationOrder
                }
                if (dataWriterProfileQos.History != null)
                {
                    // TODO dataWriterProfileQos.History
                }
                if (dataWriterProfileQos.ResourceLimits != null)
                {
                    // TODO dataWriterProfileQos.ResourceLimits
                }
                if (dataWriterProfileQos.UserData != null)
                {
                    // TODO dataWriterProfileQos.UserData
                }
                if (dataWriterProfileQos.Ownership != null)
                {
                    // TODO dataWriterProfileQos.Ownership
                }
            }

        }

        public DataWriter<TYPE> CreateDataWriter<TYPE>(Topic<TYPE> topic)
        {
            DataWriter<TYPE> dw = null;
            dw = new DataWriterImpl<TYPE>(this, topic);
            datawriters.Add(dw);
            return dw;
        }

        public DataWriter<TYPE> CreateDataWriter<TYPE>(Topic<TYPE> topic, DataWriterQos qos, DataWriterListener<TYPE> listener, ICollection<Type> statuses)
        {
            DataWriter<TYPE> dw = null;
            dw = new DataWriterImpl<TYPE>(this, topic, qos, listener, statuses);
            datawriters.Add(dw);
            return dw;
        }

        public DataWriter<TYPE> CreateDataWriter<TYPE>(Topic<TYPE> topic, string qosLibraryName, string qosProfileName, DataWriterListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataWriter CreateBytesDataWriter(Topic<byte[]> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataWriter CreateBytesDataWriter(Topic<byte[]> topic, DataWriterQos qos, DataWriterListener<byte[]> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataWriter CreateBytesDataWriter(Topic<byte[]> topic, string qosLibraryName, string qosProfileName, DataWriterListener<byte[]> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataWriter CreateKeyedBytesDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.KeyedBytes> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataWriter CreateKeyedBytesDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.KeyedBytes> topic, DataWriterQos qos, DataWriterListener<org.omg.dds.type.builtin.KeyedBytes> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataWriter CreateKeyedBytesDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.KeyedBytes> topic, string qosLibraryName, string qosProfileName, DataWriterListener<org.omg.dds.type.builtin.KeyedBytes> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataWriter CreatestringDataWriter(org.omg.dds.topic.Topic<string> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataWriter CreatestringDataWriter(org.omg.dds.topic.Topic<string> topic, DataWriterQos qos, DataWriterListener<string> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataWriter CreatestringDataWriter(org.omg.dds.topic.Topic<string> topic, string qosLibraryName, string qosProfileName, DataWriterListener<string> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataWriter CreateKeyedstringDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.Keyedstring> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataWriter CreateKeyedstringDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.Keyedstring> topic, DataWriterQos qos, DataWriterListener<org.omg.dds.type.builtin.Keyedstring> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataWriter CreateKeyedstringDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.Keyedstring> topic, string qosLibraryName, string qosProfileName, DataWriterListener<org.omg.dds.type.builtin.Keyedstring> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public DataWriter<TYPE> LookupDataWriter<TYPE>(string topicName)
        {
            throw new NotImplementedException();
        }

        public DataWriter<TYPE> LookupDataWriter<TYPE>(org.omg.dds.topic.Topic<TYPE> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataWriter LookupBytesDataWriter(org.omg.dds.topic.Topic<byte[]> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataWriter LookupKeyedBytesDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.KeyedBytes> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataWriter LookupstringDataWriter(org.omg.dds.topic.Topic<string> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataWriter LookupKeyedstringDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.Keyedstring> topicName)
        {
            throw new NotImplementedException();
        }

        public void CloseContainedEntities()
        {
            throw new NotImplementedException();
        }

        public void SuspendPublications()
        {
            throw new NotImplementedException();
        }

        public void ResumePublications()
        {
            throw new NotImplementedException();
        }

        public void BeginCoherentChanges()
        {
            throw new NotImplementedException();
        }

        public void EndCoherentChanges()
        {
            throw new NotImplementedException();
        }

        public void WaitForAcknowledgments(org.omg.dds.core.Duration maxWait)
        {
            throw new NotImplementedException();
        }

        public void WaitForAcknowledgments(long maxWait, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public DataWriterQos GetDefaultDataWriterQos()
        {
            return this.dataWriterqos;
        }

        public void SetDefaultDataWriterQos(DataWriterQos qos)
        {
            throw new NotImplementedException();
        }

        public void SetDefaultDataWriterQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void CopyFromTopicQos(DataWriterQos dst, org.omg.dds.topic.TopicQos src)
        {
            throw new NotImplementedException();
        }

        public DomainParticipant GetParent()
        {
            return this.parent;
        }

        public PublisherListener GetListener()
        {
            return this.listener;
        }

        public void SetListener(PublisherListener listener)
        {
            this.listener = listener;
        }

        public PublisherQos GetQos()
        {
            return this.qos;
        }

        public void SetQos(PublisherQos qos)
        {
            this.qos = qos;
        }

        public void SetQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.StatusCondition<Publisher> GetStatusCondition()
        {
            throw new NotImplementedException();
        }

        public ICollection<TYPE> GetStatusChanges<TYPE>(ICollection<TYPE> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.InstanceHandle GetInstanceHandle()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Retain()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            return Bootstrap;
        }
    }
}
