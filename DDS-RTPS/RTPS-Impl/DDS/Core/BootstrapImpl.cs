
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
        
        public override Bootstrap.ServiceProviderInterface getSPI()
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

        public org.omg.dds.domain.DomainParticipantFactory ParticipantFactory
        {
            get
            {
                return new DomainParticipantFactoryImpl(this.boostrap);
            }
        }

        public org.omg.dds.type.dynamic.DynamicTypeFactory TypeFactory
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public org.omg.dds.type.dynamic.DynamicDataFactory DataFactory
        {
            get
            {
                throw new NotImplementedException();
            }
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

        public Time invalidTime()
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

        public org.omg.dds.core.policy.QosPolicyId getQosPolicyId(Type policyClass)
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

        public org.omg.dds.core.status.OfferedDeadlineMissedStatus<TYPE> newOfferedDeadlineMissedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.OfferedIncompatibleQosStatus<TYPE> newOfferedIncompatibleQosStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.PublicationMatchedStatus<TYPE> newPublicationMatchedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.LivelinessChangedStatus<TYPE> newLivelinessChangedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.RequestedDeadlineMissedStatus<TYPE> newRequestedDeadlineMissedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.RequestedIncompatibleQosStatus<TYPE> newRequestedIncompatibleQosStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SampleLostStatus<TYPE> newSampleLostStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SampleRejectedStatus<TYPE> newSampleRejectedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.SubscriptionMatchedStatus<TYPE> newSubscriptionMatchedStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.DataAvailableStatus<TYPE> newDataAvailableStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.DataOnReadersStatus newDataOnReadersStatus()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.InconsistentTopicStatus<TYPE> newInconsistentTopicStatus<TYPE>()
        {
            throw new NotImplementedException();
        }

        public ISet<org.omg.dds.sub.InstanceState> anyInstanceStateSet()
        {
            throw new NotImplementedException();
        }

        public ISet<org.omg.dds.sub.InstanceState> notAliveInstanceStateSet()
        {
            throw new NotImplementedException();
        }

        public ISet<org.omg.dds.sub.SampleState> anySampleStateSet()
        {
            throw new NotImplementedException();
        }

        public ISet<org.omg.dds.sub.ViewState> anyViewStateSet()
        {
            throw new NotImplementedException();
        }
    }
}
