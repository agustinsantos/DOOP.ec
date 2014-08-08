using org.omg.dds.domain;
using System;
using System.Collections.Generic;

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
        public override DomainParticipant createParticipant()
        {
            // Check invalid qos
            // Check inconsistent qos
            // Check if repository exists for domainId
            // Check if Guid is not GUID_UNKNOWN
            DomainParticipantImpl dp =  new DomainParticipantImpl();

            // Add dp to participants
            //participants_.Add();
            return dp;
        }

        public override DomainParticipant createParticipant(int domainId)
        {
            throw new NotImplementedException();
        }

        public override DomainParticipant createParticipant(int domainId, DomainParticipantQos qos, DomainParticipantListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public override DomainParticipant createParticipant(int domainId, string qosLibraryName, string qosProfileName, DomainParticipantListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public override DomainParticipant lookupParticipant(int domainId)
        {
            throw new NotImplementedException();
        }

        public override DomainParticipantFactoryQos getQos()
        {
            throw new NotImplementedException();
        }

        public override void setQos(DomainParticipantFactoryQos qos)
        {
            throw new NotImplementedException();
        }

        public override DomainParticipantQos getDefaultParticipantQos()
        {
            throw new NotImplementedException();
        }

        public override void setDefaultParticipantQos(DomainParticipantQos qos)
        {
            throw new NotImplementedException();
        }

        public override void setDefaultParticipantQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }

        #region Fields
         DomainParticipantFactoryQos qos_;

        /// The default qos value of DomainParticipant.
         DomainParticipantQos default_participant_qos_;

        /// The collection of domain participants.
         IDictionary<long, ISet<DomainParticipant>> participants_;
        #endregion
    }
}
