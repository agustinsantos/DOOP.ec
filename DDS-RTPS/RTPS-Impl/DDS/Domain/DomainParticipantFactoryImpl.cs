using Doopec.Dds.Config;
using Doopec.DDS.Domain;
using Doopec.DDS.Utils;
using org.omg.dds.core;
using org.omg.dds.domain;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Doopec.Dds.Domain
{
    /// <summary>
    /// Implements the DomainParticipantFactory interfaces.
    ///
    /// This class acts as factory of the DomainParticipant.
    ///
    /// See the DDS specification, OMG formal/04-12-02, for a description of
    /// the interface this class is implementing.
    /// </summary>
    public class DomainParticipantFactoryImpl : DomainParticipantFactory
    {

        public DomainParticipantFactoryImpl(Bootstrap bootstrap)
        {
            this.bootstrap_ = bootstrap;
            if (default_participant_qos_ == null)
            {
                default_participant_qos_ = new DomainParticipantQosImpl();

                if (config.Settings["DefaultDomainQoS"] != null)
                {
                    string defaultQoS = config.Settings["DefaultDomainQoS"].Value;
                    // TODO Assign values to default_participant_qos_ from configuration
                }
            }
        }

        public override DomainParticipant createParticipant()
        {
            int domainId = config.DefaultDomainId;
            DomainParticipantQos qos = this.getDefaultParticipantQos();

            return this.createParticipant(domainId, qos, null, null);
        }

        public override DomainParticipant createParticipant(int domainId)
        {
            DomainParticipantQos qos = this.getDefaultParticipantQos();

            return this.createParticipant(domainId, qos, null, null);
        }

        public override DomainParticipant createParticipant(int domainId, DomainParticipantQos qos, DomainParticipantListener listener, ICollection<Type> statuses)
        {
            DomainParticipant dp = new DomainParticipantImpl(domainId, qos, listener);
            participants_.Add(domainId, dp);
            return dp;
        }

        public override DomainParticipant createParticipant(int domainId, string qosLibraryName, string qosProfileName, DomainParticipantListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public override DomainParticipant lookupParticipant(int domainId)
        {
            DomainParticipant dp = null;
            participants_.TryGetValue(domainId, out dp);
            return dp;
        }

        public override DomainParticipantFactoryQos getQos()
        {
            return qos_;
        }

        public override void setQos(DomainParticipantFactoryQos qos)
        {
            if (QosHelper.IsValid(qos) && QosHelper.IsConsistent(qos))
            {
                if (!(qos_ == qos) && QosHelper.IsChangeable(qos_, qos))
                    qos_ = qos;
            }
            else
            {
                throw new InconsistentPolicyException();
            }
        }

        public override DomainParticipantQos getDefaultParticipantQos()
        {
            return this.default_participant_qos_;
        }

        public override void setDefaultParticipantQos(DomainParticipantQos qos)
        {
            if (QosHelper.IsValid(qos) && QosHelper.IsConsistent(qos))
            {
                this.default_participant_qos_ = qos;
            }
            else
            {
                throw new InconsistentPolicyException();
            }
        }

        public override void setDefaultParticipantQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public override Bootstrap getBootstrap()
        {
            return bootstrap_;
        }

        #region Fields
        private DomainParticipantFactoryQos qos_;

        /// The default qos value of DomainParticipant.
        private DomainParticipantQos default_participant_qos_;

        /// The collection of domain participants.
        private IDictionary<long, DomainParticipant> participants_ = new Dictionary<long, DomainParticipant>();

        private readonly Bootstrap bootstrap_ = null;

        private DdsConfigurationSectionHandler config = ConfigurationManager.GetSection("Doopec.Dds") as DdsConfigurationSectionHandler;

        #endregion
    }
}
