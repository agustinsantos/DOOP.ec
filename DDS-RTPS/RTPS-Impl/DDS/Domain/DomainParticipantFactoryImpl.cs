using Doopec.Configuration;
using Doopec.Dds.Core;
using Doopec.Dds.Utils;
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
            string qosProfile = ddsConfig.Domains[0].QoSProfile.Name;
            Doopec.Configuration.Dds.DomainParticipantFactoryQoS qos = ddsConfig.QoSProfiles[qosProfile].DomainParticipantFactoryQos;

            this.Qos = DomainParticipantFactoryQosImpl.ConvertTo(qos, bootstrap);
        }

        /// <summary>
        /// Create a new participant in the domain with ID 0 having default QoS
        /// and no listener.
        /// </summary>
        /// <returns>New participant</returns>
        public override DomainParticipant CreateParticipant()
        {
            return this.CreateParticipant(0);
        }

        /// <summary>
        /// Create a new participant in the domain with a fixed ID and having default QoS
        /// and no listener.
        /// </summary>
        /// <returns>New participant</returns>
        public override DomainParticipant CreateParticipant(int domainId)
        {
            string qosProfile = ddsConfig.Domains[domainId].QoSProfile.Name;
            Doopec.Configuration.Dds.DomainParticipantQoS qosConfig = ddsConfig.QoSProfiles[qosProfile].DomainParticipantQos;

            DomainParticipantQos qos = DomainParticipantQosImpl.ConvertTo(qosConfig, this.bootstrap_);

            return this.CreateParticipant(domainId, qos, null, null);
        }

        /// <summary>
        /// Create a new domain participant.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status 
        ///                        changes</param>
        /// <returns></returns>

        public override DomainParticipant CreateParticipant(int domainId, DomainParticipantQos qos, DomainParticipantListener listener, ICollection<Type> statuses)
        {
            DomainParticipant dp = new DomainParticipantImpl(domainId, qos, listener, this.bootstrap_);
            if (((DomainParticipantFactoryQosImpl)this.Qos).EntityFactoryQosPolicy.IsAutoEnableCreatedEntities())
                dp.Enable();

            return dp;
        }

        /// <summary>
        /// Create a new domain participant.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>

        public override DomainParticipant CreateParticipant(int domainId, string qosLibraryName, string qosProfileName, DomainParticipantListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This operation retrieves a previously created DomainParticipant belonging to specified domain_id. If no such
        /// DomainParticipant exists, the operation will return a ‘nil’ value.
        /// If multiple DomainParticipant entities belonging to that domain_id exist, then the operation will return one of them. It is not
        /// specified which one.
        /// </summary>
        /// <param name="domainId">The Domain identified by the domainId argument</param>
        /// <returns></returns>
        public override DomainParticipant LookupParticipant(int domainId)
        {
            DomainParticipant dp = DiscoveryService.Instance.LookupParticipant(domainId);
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


        private readonly Bootstrap bootstrap_ = null;

        private DDSConfigurationSection ddsConfig = Doopec.Configuration.DDSConfigurationSection.Instance;

        #endregion
    }
}
