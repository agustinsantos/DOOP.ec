using DDS.ConversionUtils;
using org.omg.dds.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core
{
    public abstract class EntityImpl<SELF, LISTENER, QOS> : DDSObjectImpl, Entity<SELF, LISTENER, QOS>, IDisposable
        where SELF : Entity<SELF, LISTENER, QOS>
        where LISTENER : EventListener
        where QOS : EntityQos
    {
        public LISTENER Listener { get; set; }
        public QOS QoS { get; set; }
        public bool IsEnabled { get; set; }
        
        public bool IsClosed{ get; set; }

        public StatusCondition<SELF> StatusCondition { get; set; }
        public InstanceHandle InstanceHandle { get; set; }

        public EntityImpl(Bootstrap bootstrap)
            : base(bootstrap)
        {
            this.IsEnabled = false;
            this.IsClosed = false;
        }

        public LISTENER GetListener()
        {
            return this.Listener;
        }

        public void SetListener(LISTENER listener)
        {
            this.Listener = listener;
        }

        public QOS GetQos()
        {
            return this.QoS;
        }

        public void SetQos(QOS qos)
        {
            this.QoS = qos;
        }

        public void SetQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public virtual void Enable()
        {
            this.IsEnabled = true;
        }

        public StatusCondition<SELF> GetStatusCondition()
        {
            return this.StatusCondition;
        }

        public ICollection<TYPE> GetStatusChanges<TYPE>(ICollection<TYPE> statuses)
        {
            throw new NotImplementedException();
        }

        public InstanceHandle GetInstanceHandle()
        {
            return this.InstanceHandle;
        }

        public virtual void Close()
        {
            this.IsClosed = true;
            this.IsEnabled = false;
        }

        public virtual void Retain()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Close();
        }
    }
}
