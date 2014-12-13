using DDS.ConversionUtils;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.domain;
using org.omg.dds.pub;
using org.omg.dds.sub;
using org.omg.dds.topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.DDS.Utils
{
    /// <summary>
    /// This class implements methods that verify whether a qos is
    ///        valid, consistent and changeable.
    ///
    /// valid - the values are in acceptable ranges without respect
    ///         to any other values.
    ///
    /// consistent - the values are consistent with each other.
    ///         The spec sometimes calls this "compatible" but I
    ///         this compatible should be reserved for matching
    ///         QoS of subscriptions and publications.
    ///         The spec is confusing in its inconsistency of the
    ///         use of "compatible" and "consistent".
    ///
    /// The qos supported in current implementation:
    ///         Liveliness  :   kind = AUTOMATIC
    ///         Reliability :   kind = RELIABLE | BEST_EFFORT
    ///                        max_blocking_time
    ///         History     :   kind = KEEP_ALL | KEEP_LAST
    ///                         depth > 1
    ///         RESOURCE_LIMITS : max_samples_per_instance
    ///
    /// Other than these supported qos, any qos that is different from the
    /// initial value is invalid.
    /// </summary>
    public static class QosHelper
    {
        public static bool IsConsistent(DomainParticipantQos qos)
        {
            return true;
        }

        public static bool IsConsistent(TopicQos qos)
        {
            return true;
        }

        public static bool IsConsistent(DataWriterQos qos)
        {
            return true;
        }

        public static bool IsConsistent(PublisherQos qos)
        {
            return true;
        }

        public static bool IsConsistent(DataReaderQos qos)
        { throw new NotImplementedException(); }

        public static bool IsConsistent(SubscriberQos qos)
        {
            return true;
        }

        public static bool IsConsistent(DomainParticipantFactoryQos qos)
        {
            return true;
        }

        // The spec does not have specification about the content of
        // UserDataQosPolicy,TopicDataQosPolicy and GroupDataQosPolicy
        // so they are valid with any value.
        public static bool IsValid(UserDataQosPolicy qos)
        {
            return true;
        }

        public static bool IsValid(TopicDataQosPolicy qos)
        {
            return true;
        }

        public static bool IsValid(GroupDataQosPolicy qos)
        {
            return true;
        }

        // All values of TRANSPORT_PRIORITY.value are accepted.
        public static bool IsValid(TransportPriorityQosPolicy qos)
        {
            return true;
        }

        public static bool IsValid(LifespanQosPolicy qos)
        {
            return valid_duration(qos.GetDuration());
        }

        public static bool IsValid(DurabilityQosPolicy qos)
        {
            return
              (qos.GetKind() == DurabilityQosPolicyKind.VOLATILE
               || qos.GetKind() == DurabilityQosPolicyKind.TRANSIENT_LOCAL
               || qos.GetKind() == DurabilityQosPolicyKind.TRANSIENT
               || qos.GetKind() == DurabilityQosPolicyKind.PERSISTENT);
        }

        public static bool IsValid(DurabilityServiceQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(PresentationQosPolicy qos)
        {
            return
              (qos.GetAccessScope() == AccessScopeKind.INSTANCE
               || qos.GetAccessScope() == AccessScopeKind.TOPIC
               || qos.GetAccessScope() == AccessScopeKind.GROUP);
        }

        public static bool IsValid(DeadlineQosPolicy qos)
        {
            return valid_duration(qos.GetPeriod());
        }

        public static bool valid(LatencyBudgetQosPolicy qos)
        {
            return true;
        }

        public static bool IsValid(OwnershipQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(OwnershipStrengthQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(LivelinessQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(TimeBasedFilterQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(PartitionQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(ReliabilityQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(DestinationOrderQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(HistoryQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(ResourceLimitsQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(EntityFactoryQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(WriterDataLifecycleQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(ReaderDataLifecycleQosPolicy qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(DomainParticipantQos qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(TopicQos qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(DataWriterQos qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(PublisherQos qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(DataReaderQos qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(SubscriberQos qos)
        { throw new NotImplementedException(); }

        public static bool IsValid(DomainParticipantFactoryQos qos)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(UserDataQosPolicy qos1,
                               UserDataQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(TopicDataQosPolicy qos1,
                               TopicDataQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(GroupDataQosPolicy qos1,
                               GroupDataQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(TransportPriorityQosPolicy qos1,
                               TransportPriorityQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(LifespanQosPolicy qos1,
                               LifespanQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool changeable(DurabilityQosPolicy qos1,
                               DurabilityQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(DurabilityServiceQosPolicy qos1,
                              DurabilityServiceQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(PresentationQosPolicy qos1,
                               PresentationQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(DeadlineQosPolicy qos1,
                               DeadlineQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(LatencyBudgetQosPolicy qos1,
                               LatencyBudgetQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(OwnershipQosPolicy qos1,
                               OwnershipQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(OwnershipStrengthQosPolicy qos1,
                              OwnershipStrengthQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(LivelinessQosPolicy qos1,
                              LivelinessQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(TimeBasedFilterQosPolicy qos1,
                              TimeBasedFilterQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(PartitionQosPolicy qos1,
                              PartitionQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(ReliabilityQosPolicy qos1,
                              ReliabilityQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(DestinationOrderQosPolicy qos1,
                              DestinationOrderQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(HistoryQosPolicy qos1,
                              HistoryQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(ResourceLimitsQosPolicy qos1,
                              ResourceLimitsQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(EntityFactoryQosPolicy qos1,
                              EntityFactoryQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(WriterDataLifecycleQosPolicy qos1,
                              WriterDataLifecycleQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(ReaderDataLifecycleQosPolicy qos1,
                              ReaderDataLifecycleQosPolicy qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(DomainParticipantQos qos1,
                              DomainParticipantQos qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(TopicQos qos1,
                              TopicQos qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(DataWriterQos qos1,
                              DataWriterQos qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(PublisherQos qos1,
                              PublisherQos qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(DataReaderQos qos1,
                              DataReaderQos qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(SubscriberQos qos1,
                              SubscriberQos qos2)
        { throw new NotImplementedException(); }

        public static bool IsChangeable(DomainParticipantFactoryQos qos1,
                              DomainParticipantFactoryQos qos2)
        { throw new NotImplementedException(); }


        private static bool valid_duration(Duration t)
        {

            // Only accept infinite or positive finite durations.  (Zero
            // excluded).
            //
            // Note that it doesn't make much sense for users to set
            // durations less than 10 milliseconds since the underlying
            // timer resolution is generally no better than that.
            return t.isInfinite() || t.getDuration(TimeUnit.MILLISECONDS) > 0;
        }
    }
}
