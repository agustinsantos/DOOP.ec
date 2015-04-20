using Doopec.Dds.Core.Policy;
using Doopec.DDS.Core;
using Doopec.DDS.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.pub;
using org.omg.dds.pub.modifiable;
using System;

namespace Doopec.Dds.Pub
{
    public class PublisherQosImpl : EntityQosImpl<PublisherQos, ModifiablePublisherQos>, PublisherQos
    {
        private PresentationQosPolicy presentationQosPolicy;
        private PartitionQosPolicy partitionQosPolicy;
        private GroupDataQosPolicy groupDataQosPolicy;
        private EntityFactoryQosPolicy entityFactoryQosPolicy;

        public PublisherQosImpl(Bootstrap boostrap)
            : base(boostrap)
        {
            presentationQosPolicy = new PresentationQosPolicyImpl(this.GetBootstrap());
            partitionQosPolicy = new PartitionQosPolicyImpl(this.GetBootstrap());
            groupDataQosPolicy = new GroupDataQosPolicyImpl(this.GetBootstrap());
            entityFactoryQosPolicy = new EntityFactoryQosPolicyImpl(this.GetBootstrap());

        }
        public PresentationQosPolicy GetPresentation()
        {
            return presentationQosPolicy;
        }

        public PartitionQosPolicy GetPartition()
        {
            return partitionQosPolicy;
        }

        public GroupDataQosPolicy GetGroupData()
        {
            return groupDataQosPolicy;
        }

        public EntityFactoryQosPolicy GetEntityFactory()
        {
            return entityFactoryQosPolicy;
        }

        public new System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override ModifiablePublisherQos Modify()
        {
            throw new NotImplementedException();
        }
    }
}
