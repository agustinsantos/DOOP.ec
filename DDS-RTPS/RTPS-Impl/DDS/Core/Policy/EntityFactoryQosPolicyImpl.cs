﻿using Doopec.Dds.Core.Policy.modifiable;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.DDS.Core.Policy
{
    public class EntityFactoryQosPolicyImpl : QosPolicyImpl, EntityFactoryQosPolicy
    {
       
        public bool AutoenableCreatedEntities { get; protected internal set; }

        public EntityFactoryQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

        public EntityFactoryQosPolicyImpl(bool isAutoEnable, Bootstrap boostrap)
            : base(boostrap)
        {
            this.AutoenableCreatedEntities  = isAutoEnable;
        }

        public bool IsAutoEnableCreatedEntities()
        {
            return AutoenableCreatedEntities;
        }

        public ModifiableEntityFactoryQosPolicy Modify()
        {
            return new ModifiableEntityFactoryQosPolicyImpl(this);
        }
    }
}
