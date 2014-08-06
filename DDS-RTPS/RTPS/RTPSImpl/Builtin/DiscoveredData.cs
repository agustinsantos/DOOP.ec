using log4net;
using rtps.messages.submessage.attribute;
using RTPS.RTPSImpl.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
 
namespace RTPS.RTPSImpl.Builtin
{
    /// <summary>
    /// Base class for data, that is received during discovery.
    /// </summary>
    public class DiscoveredData
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // While reading data from stream, qos policies might come in 'wrong' order.
        // This list keeps track of inconsistencies occured
        private IList<QosPolicy> inconsistenPolicies = new List<QosPolicy>();
        private IList<Parameter> params_ = new List<Parameter>();

        protected QualityOfService qos;

        protected String typeName;
        protected String topicName;

        // On spec, key is BuiltinTopicKey_t (4 bytes), but KeyHash Parameter is 16
        // bytes.
        // see table 9.10, 9.6.3.3 KeyHash.
        // interpretation is, for builtin topics, key is
        // guid_prefix(12) + builtin_topic_key(4), which is equal to prefix(12) +
        // entityid(4), which is guid
        protected Guid key;

        /// <summary>
        /// This constructor is used when DiscoveredData is being created from
        /// IoBuffer
        /// </summary>
        protected DiscoveredData()
        {
            qos = new QualityOfService(); // Initialize QoS with default policies.
        }

        /// <summary>
        /// This constructor is used when DiscoveredData is being created from scratch
        /// </summary>
        /// <param name="typeNameType name of the dataparam>
        /// <param name="topicName">name of the topic</param>
        /// <param name="key">guid of the remote entity, which acts as a key for topic</param>
        /// <param name="qos">QualityOfService of discovered entity</param>
        protected DiscoveredData(String typeName, String topicName, Guid key, QualityOfService qos)
        {
            this.typeName = typeName;
            this.topicName = topicName;
            this.key = key;
            this.qos = qos;
        }

        /// <summary>
        /// This method must be called after all the Parameters have been read from
        /// the stream to resolve possible inconsistent policies.
        /// </summary>
        protected void ResolveInconsistencies()
        {
            if (inconsistenPolicies.Count > 0)
            {
                log.DebugFormat("resolveInconsistencies: {0}", inconsistenPolicies);
                ResolveInconsistencies(inconsistenPolicies);
            }
        }

        /**
         * Adds a Parameter that was not handled by subclass.
         * 
         * @param param
         */
        protected void addParameter(Parameter param)
        {
            params_.Add(param);
        }


        /// <summary>
        /// Gets all the parameters that were received during discovery.
        /// </summary>
        public IList<Parameter> getParameters
        {
            get
            {
                return params_;
            }
        }

        private void ResolveInconsistencies(IList<QosPolicy> inconsistentPolicies)
        {
            int size = inconsistenPolicies.Count;

            foreach (QosPolicy qp in inconsistentPolicies)
            {
                try
                {
                    qos.SetPolicy(qp);
                    inconsistenPolicies.Remove(qp);
                }
                catch (InconsistentPolicy e)
                {
                    // Ignore during resolve
                }
            }

            int __size = inconsistenPolicies.Count;

            if (size != __size)
            { // If the size changes, recursively call again
                ResolveInconsistencies(inconsistentPolicies);
            }
            else
            {
                if (inconsistentPolicies.Count > 0)
                {
                    throw new InconsistentPolicy(inconsistenPolicies.ToString());
                }
            }
        }

        /// <summary>
        /// Get the type name that is associated with this DiscoveresData. Type name
        /// is formed from the PID_TYPE_NAME parameter
        /// </summary>
        public String TypeName
        {
            get
            {
                return typeName;
            }
        }

        /// <summary>
        /// Get the topic name that is associated with this DiscoveredData. Topic
        /// name is formed from the PID_TOPIC_NAME parameter
        /// </summary>
        public String TopicName
        {
            get
            {
                return topicName;
            }
        }

        /// <summary>
        /// Gets the Guid of the entity represented by this DiscoveredData. Guid is
        /// formed from the PID_KEY_HASH parameter.
        /// </summary>
        /// <returns></returns>
        public Guid Key
        {
            get
            {
                return key;
            }
        }

        /// <summary>
        /// Gets the QualityOfService of this DiscoveredData.
        /// </summary>
        /// <returns></returns>
        public QualityOfService QualityOfService
        {
            get
            {
                return qos;
            }
        }

        /// <summary>
        /// Adds a QosPolicy.
        /// </summary>
        /// <param name="policy"></param>
        protected void addQosPolicy(QosPolicy policy)
        {
            try
            {
                qos.SetPolicy(policy);
            }
            catch (InconsistentPolicy e)
            {
                inconsistenPolicies.Add(policy);
            }
        }

        /// <summary>
        /// Get inlineable Qos policies. Such policies implement InlineParameter.
        /// </summary>
        public ISet<QosPolicy> InlineableQosPolicies
        {
            get
            {
                return qos.InlinePolicies;
            }
        }

        public override String ToString()
        {
            return topicName + "(" + typeName + "): " + key + ", QoS: " + qos;
        }
    }
}
