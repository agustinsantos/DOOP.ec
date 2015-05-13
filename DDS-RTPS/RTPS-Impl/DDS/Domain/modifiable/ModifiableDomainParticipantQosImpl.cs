using Doopec.DDS.Domain;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.domain;
using org.omg.dds.domain.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Domain.modifiable
{
    class ModifiableDomainParticipantQosImpl : DomainParticipantQosImpl, ModifiableDomainParticipantQos
    {

       
           public ModifiableDomainParticipantQosImpl(DomainParticipantQos dm)
            : base(dm.GetUserData(),dm.GetEntityFactory(),dm.GetBootstrap())
        {
        }
           public ModifiableDomainParticipantQosImpl(UserDataQosPolicy getUserData,EntityFactoryQosPolicy getEntityFactory, Bootstrap boostrap)
            : base(getUserData,getEntityFactory, boostrap )
        {

        }

        public ModifiableDomainParticipantQos SetUserData(UserDataQosPolicy userData)
        {
            this.UserData=userData;
            return this;
        }

        public ModifiableDomainParticipantQos SetEntityFactory(EntityFactoryQosPolicy entityFactory)
        {
            this.EntityFactoryQosPolicy =entityFactory;
            return this;
        }

        public new System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public POLICY put<POLICY>(QosPolicyId key, POLICY value) where POLICY : QosPolicy
        {
            throw new NotImplementedException();
        }

        public ModifiableDomainParticipantQos CopyFrom(DomainParticipantQos other)
        {
            return new ModifiableDomainParticipantQosImpl(other);
        }

        public DomainParticipantQos FinishModification()
        {
            return new DomainParticipantQosImpl(this.GetUserData(),this.GetEntityFactory(),this.GetBootstrap());
        }
    }
}
