
using Doopec.Dds.Domain;
using org.omg.dds.core;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Core
{
    public class BootstrapImpl : Bootstrap
    {
        private static readonly SPI SPIInstance = new SPI();

        public override Bootstrap.ServiceProviderInterface getSPI()
        {
            return SPIInstance;
        }
    }

    public class SPI : Bootstrap.ServiceProviderInterface
    {
        public org.omg.dds.domain.DomainParticipantFactory getParticipantFactory()
        {
            return new DomainParticipantFactoryImpl();
        }

        public org.omg.dds.type.dynamic.DynamicTypeFactory getTypeFactory()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.dynamic.DynamicDataFactory getDataFactory()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.TypeSupport<TYPE> newTypeSupport<TYPE>(Type type, string registeredName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.modifiable.ModifiableDuration newDuration(long duration, DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public Duration infiniteDuration()
        {
            throw new NotImplementedException();
        }

        public Duration zeroDuration()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.modifiable.ModifiableTime newTime(long time, DDS.ConversionUtils.TimeUnit units)
        {
            throw new NotImplementedException();
        }

        public Time invalidTime()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.modifiable.ModifiableInstanceHandle newInstanceHandle()
        {
            throw new NotImplementedException();
        }

        public InstanceHandle nilHandle()
        {
            throw new NotImplementedException();
        }

        public GuardCondition newGuardCondition()
        {
            throw new NotImplementedException();
        }

        public WaitSet newWaitSet()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.BuiltinTopicKey newBuiltinTopicKey()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.ParticipantBuiltinTopicData newParticipantBuiltinTopicData()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.PublicationBuiltinTopicData newPublicationBuiltinTopicData()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.SubscriptionBuiltinTopicData newSubscriptionBuiltinTopicData()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.topic.TopicBuiltinTopicData newTopicBuiltinTopicData()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.QosPolicyId getQosPolicyId(Type policyClass)
        {
            throw new NotImplementedException();
        }

        public ISet<Type> allStatusKinds()
        {
            throw new NotImplementedException();
        }

        public ISet<Type> noStatusKinds()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.status.LivelinessLostStatus<TYPE> newLivelinessLostStatus<TYPE>()
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
