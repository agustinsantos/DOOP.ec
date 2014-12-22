using Doopec.Dds.Core.Policy;
using Doopec.DDS.Core;
using Doopec.DDS.Core.Policy;
using org.omg.dds.core.policy;
using org.omg.dds.pub;
using org.omg.dds.pub.modifiable;
using System;

namespace Doopec.Dds.Pub
{
    public class PublisherQosImpl : EntityQosImpl<PublisherQos, ModifiablePublisherQos>, PublisherQos
    {
        private PresentationQosPolicy presentationQosPolicy = new PresentationQosPolicyImpl();
        private PartitionQosPolicy partitionQosPolicy = new PartitionQosPolicyImpl();
        private GroupDataQosPolicy groupDataQosPolicy = new GroupDataQosPolicyImpl();
        private EntityFactoryQosPolicy entityFactoryQosPolicy = new EntityFactoryQosPolicyImpl();

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
    }
}
