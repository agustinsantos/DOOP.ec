﻿using Doopec.DDS.Core;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.domain;
using org.omg.dds.domain.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Domain
{
    public class ModifiableDomainParticipantFactoryQosImpl : EntityQosImpl<DomainParticipantFactoryQos, ModifiableDomainParticipantFactoryQos>, ModifiableDomainParticipantFactoryQos
    {
        public ModifiableDomainParticipantFactoryQosImpl(DomainParticipantFactoryQosImpl qos)
            : base(qos.GetBootstrap())
        {

        }
        public ModifiableDomainParticipantFactoryQosImpl(Bootstrap boostrap)
            : base(boostrap)
        {
 
        }

        public override ModifiableDomainParticipantFactoryQos Modify()
        {
            throw new NotImplementedException();
        }

        public ModifiableDomainParticipantFactoryQos SetEntityFactory(EntityFactoryQosPolicy entityFactory)
        {
            throw new NotImplementedException();
        }

        public EntityFactoryQosPolicy GetEntityFactory()
        {
            throw new NotImplementedException();
        }

      
        public POLICY put<POLICY>(org.omg.dds.core.policy.QosPolicyId key, POLICY value) where POLICY : org.omg.dds.core.policy.QosPolicy
        {
            throw new NotImplementedException();
        }

        public ModifiableDomainParticipantFactoryQos CopyFrom(DomainParticipantFactoryQos other)
        {
            return new ModifiableDomainParticipantFactoryQosImpl(other.GetBootstrap());
        }

        public DomainParticipantFactoryQos FinishModification()
        {
            return new DomainParticipantFactoryQosImpl(this.GetBootstrap());
        }
    }
}
