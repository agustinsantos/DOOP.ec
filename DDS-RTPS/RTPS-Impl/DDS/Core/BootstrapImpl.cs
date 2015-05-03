
using DDS.ConversionUtils;
using Doopec.Dds.Domain;
using Doopec.Dds.Utils;
using org.omg.dds.core;
using org.omg.dds.core.modifiable;
using org.omg.dds.domain;
using org.omg.dds.topic;
using org.omg.dds.type;
using org.omg.dds.type.dynamic;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Core
{

    /// <summary>
    /// A Bootstrap object represents an instantiation of a Service implementation within a process. It
    /// is the “root” for all other DDS objects and assists in their creation by means of an internal
    /// service-provider interface. All stateful types in this PSM implement an interface DDSObject,
    /// through a getBootstrap method on which they can provide access to the Bootstrap from
    /// which they are ultimately derived. (Bootstrap itself implements this interface; a Bootstrap
    /// always returns this from its getBootstrap operation.)
    /// The Bootstrap class allows implementations to avoid the presence of static state, if desired. It
    /// also allows multiple DDS implementations—or multiple versions of the “same”
    /// implementation—to potentially coexist within the same Java run-time environment. A DDS
    /// application’s first step is to instantiate a Bootstrap, which represents the DDS implementation
    /// that it will use. From there, it can create all of its additional DDS objects.
    /// The Bootstrap class is abstract. To avoid compile-time dependencies on concrete
    /// Bootstrap implementations, an application can instantiate a Bootstrap by means of a static
    /// createInstance method on the Bootstrap class. This method looks up a concrete
    /// Bootstrap subclass using a Java system property containing the name of that subclass. This
    /// subclass must be provided by implementers and will therefore have an implementation-specific
    /// name.
    /// </summary>
    public class BootstrapImpl : Bootstrap
    {
        private SPI SPIInstance;

        static BootstrapImpl()
        {
            // Activate the Discovery Service
            var dicovery = DiscoveryService.Instance;
        }

        public BootstrapImpl()
            : this(null)
        { }

        public BootstrapImpl(IDictionary<string, Object> environment)
        { }

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

        public DomainParticipantFactory GetParticipantFactory()
        {
            return new DomainParticipantFactoryImpl(this.boostrap);
        }

        public DynamicTypeFactory GetTypeFactory()
        {
            throw new NotImplementedException();
        }

        public DynamicDataFactory GetDataFactory()
        {
            throw new NotImplementedException();
        }

        public TypeSupport<TYPE> NewTypeSupport<TYPE>(Type type, string registeredName)
        {
            throw new NotImplementedException();
        }

        public ModifiableDuration NewDuration(long duration, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public Duration InfiniteDuration()
        {
            return new DurationImpl(this.boostrap, long.MaxValue);
        }

        public Duration ZeroDuration()
        {
            return new DurationImpl(this.boostrap, 0);
        }

        public ModifiableTime NewTime(long time, TimeUnit units)
        {
            throw new NotImplementedException();
        }

        public Time InvalidTime()
        {
            throw new NotImplementedException();
        }

        public ModifiableInstanceHandle NewInstanceHandle()
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

        public BuiltinTopicKey NewBuiltinTopicKey()
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
