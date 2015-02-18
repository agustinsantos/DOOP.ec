
using DDS.ConversionUtils;
using Doopec.Dds.Domain;
using org.omg.dds.core;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Core
{
    public class BootstrapImpl : Bootstrap
    {
        private SPI SPIInstance;

        public override Bootstrap.ServiceProviderInterface GetSPI()
        {
            if (SPIInstance == null)
                SPIInstance = new SPI(this);

            return SPIInstance;
        }
    }

    public class SPI : Bootstrap.ServiceProviderInterface
    {

        private readonly Bootstrap boostrap;

        public SPI(Bootstrap boostrap)
        {
            this.boostrap = boostrap;
        }

        public org.omg.dds.domain.DomainParticipantFactory GetParticipantFactory()
        {
            return new DomainParticipantFactoryImpl(this.boostrap);
        }

        public org.omg.dds.type.dynamic.DynamicTypeFactory GetTypeFactory()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.dynamic.DynamicDataFactory GetDataFactory()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.TypeSupport<TYPE> NewTypeSupport<TYPE>(Type type, string registeredName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.modifiable.ModifiableDuration NewDuration(long duration, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public Duration InfiniteDuration()
        {
            throw new NotImplementedException();
        }

        public Duration ZeroDuration()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.modifiable.ModifiableTime NewTime(long time, TimeUnit units)
        {
            throw new NotImplementedException();
        }

        public Time InvalidTime()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.modifiable.ModifiableInstanceHandle NewInstanceHandle()
        {
            throw new NotImplementedException();
        }

        public InstanceHandle NilHandle()
        {
            throw new NotImplementedException();
        }

        public GuardCondition NewGuardCondition()
        {
            throw new NotImplementedException();
        }

        public WaitSet NewWaitSet()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.BuiltinTopicKey NewBuiltinTopicKey()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.ParticipantBuiltinTopicData NewParticipantBuiltinTopicData()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.PublicationBuiltinTopicData NewPublicationBuiltinTopicData()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.SubscriptionBuiltinTopicData NewSubscriptionBuiltinTopicData()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.TopicBuiltinTopicData NewTopicBuiltinTopicData()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.QosPolicyId GetQosPolicyId(Type policyClass)
        {
            throw new NotImplementedException();
        }

        public ISet<Type> AllStatusKinds()
        {
            throw new NotImplementedException();
        }

        public ISet<Type> NoStatusKinds()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.LivelinessLostStatus<TYPE> NewLivelinessLostStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.OfferedDeadlineMissedStatus<TYPE> NewOfferedDeadlineMissedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.OfferedIncompatibleQosStatus<TYPE> NewOfferedIncompatibleQosStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.PublicationMatchedStatus<TYPE> NewPublicationMatchedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.LivelinessChangedStatus<TYPE> NewLivelinessChangedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.RequestedDeadlineMissedStatus<TYPE> NewRequestedDeadlineMissedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.RequestedIncompatibleQosStatus<TYPE> NewRequestedIncompatibleQosStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SampleLostStatus<TYPE> NewSampleLostStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SampleRejectedStatus<TYPE> NewSampleRejectedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SubscriptionMatchedStatus<TYPE> NewSubscriptionMatchedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.DataAvailableStatus<TYPE> NewDataAvailableStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.DataOnReadersStatus NewDataOnReadersStatus()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.InconsistentTopicStatus<TYPE> NewInconsistentTopicStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public ISet<org.omg.dds.sub.InstanceState> AnyInstanceStateSet()
        {
            throw new NotImplementedException();
        }

        public ISet<org.omg.dds.sub.InstanceState> NotAliveInstanceStateSet()
        {
            throw new NotImplementedException();
        }

        public ISet<org.omg.dds.sub.SampleState> AnySampleStateSet()
        {
            throw new NotImplementedException();
        }

        public ISet<org.omg.dds.sub.ViewState> AnyViewStateSet()
        {
            throw new NotImplementedException();
        }
    }
}
