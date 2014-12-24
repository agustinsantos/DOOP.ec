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

        public override DomainParticipant CreateParticipant()
        {
            int domainId = config.DefaultDomainId;
            DomainParticipantQos qos = this.GetDefaultParticipantQos();

            return this.CreateParticipant(domainId, qos, null, null);
        }

        public override DomainParticipant CreateParticipant(int domainId)
        {
            DomainParticipantQos qos = this.GetDefaultParticipantQos();

            return this.CreateParticipant(domainId, qos, null, null);
        }

        public override DomainParticipant CreateParticipant(int domainId, DomainParticipantQos qos, DomainParticipantListener listener, ICollection<Type> statuses)
        {
            DomainParticipant dp = new DomainParticipantImpl(domainId, qos, listener);
            participants_.Add(domainId, dp);
            return dp;
        }

        public override DomainParticipant CreateParticipant(int domainId, string qosLibraryName, string qosProfileName, DomainParticipantListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public override DomainParticipant LookupParticipant(int domainId)
        {
            DomainParticipant dp = null;
            participants_.TryGetValue(domainId, out dp);
            return dp;
        }

        public override DomainParticipantFactoryQos Qos
        {
            get { return qos_;  }
            set
            {
                if (QosHelper.IsValid(value) && QosHelper.IsConsistent(value))
                {
                    if (!(qos_ == value) && QosHelper.IsChangeable(qos_, value))
                        qos_ = value;
                }
                else
                {
                    throw new InconsistentPolicyException();
                }
            }
            
        }


        public override DomainParticipantQos GetDefaultParticipantQos()
        {
            return this.default_participant_qos_;
        }

        public override void SetDefaultParticipantQos(DomainParticipantQos qos)
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

        public override void SetDefaultParticipantQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public override Bootstrap GetBootstrap()
        {
            return bootstrap_;
        }

        #region Fields
        private DomainParticipantFactoryQos qos_;

        /// The default qos Value of DomainParticipant.
        private DomainParticipantQos default_participant_qos_;

        /// The collection of domain participants.
        private IDictionary<long, DomainParticipant> participants_ = new Dictionary<long, DomainParticipant>();

        private readonly Bootstrap bootstrap_ = null;

        private DdsConfigurationSectionHandler config = ConfigurationManager.GetSection("Doopec.Dds") as DdsConfigurationSectionHandler;

        #endregion
    }
}
