using RTPS.RTPSImpl.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.RTPSImpl
{
    public class QualityOfService
    {
        private Dictionary<Type, QosPolicy> policies = new Dictionary<Type, QosPolicy>();

        /// <summary>
        /// Constructor with default QosPolicies.
        /// </summary>
        public QualityOfService()
        {
            throw new NotImplementedException();
        }

        public ISet<QosPolicy> InlinePolicies
        {
            get
            { throw new NotImplementedException(); }
        }

        /*
     * Sets a given QosPolicy. Old value will be overridden.
     * 
     * @param policy
     *            QosPolicy to set.
     * @throws InconsistentPolicy
     *             is thrown if there is some inconsistent value with the policy
     */
        public void SetPolicy(QosPolicy policy)
        {
            CheckForInconsistencies(policy);

            policies.Add(policy.GetType(), policy);
        }

        private void CheckForInconsistencies(QosPolicy policy)
        {
#if TODO
        if (policy instanceof QosDeadline) { // ---  DEADLINE  ---
            QosTimeBasedFilter tbf = (QosTimeBasedFilter) policies.get(typeof(QosTimeBasedFilter));
            if (tbf == null) {
                tbf = QosTimeBasedFilter.defaultTimeBasedFilter();
            }

            QosDeadline dl = (QosDeadline) policy;
            if (dl.getPeriod().asMillis() < tbf.getMinimumSeparation().asMillis()) {
                throw new InconsistentPolicy("DEADLINE.period(" + dl.getPeriod()
                        + ") must be >= TIME_BASED_FILTER.minimum_separation(" + tbf.getMinimumSeparation() + ")");
            }
        } 
        else if (policy instanceof QosTimeBasedFilter) { // ---  TIME_BASED_FILTER  ---
            QosDeadline dl = (QosDeadline) policies.get(typeof(QosDeadline));
            if (dl == null) {
                dl = QosDeadline.defaultDeadline();
            }

            QosTimeBasedFilter tbf = (QosTimeBasedFilter) policy;
            if (dl.getPeriod().asMillis() < tbf.getMinimumSeparation().asMillis()) {
                throw new InconsistentPolicy("DEADLINE.period(" + dl.getPeriod()
                        + ") must be >= TIME_BASED_FILTER.minimum_separation(" + tbf.getMinimumSeparation() + ")");
            }
        } 
        else if (policy instanceof QosHistory) { // ---  HISTORY  ---
            QosResourceLimits rl = (QosResourceLimits) policies.get(typeof(QosResourceLimits));
            if (rl == null) {
                rl = QosResourceLimits.defaultResourceLimits();
            }

            QosHistory h = (QosHistory) policy;

            if (rl.getMaxSamplesPerInstance() != -1 && rl.getMaxSamplesPerInstance() < h.getDepth()) {
                throw new InconsistentPolicy("HISTORY.depth must be <= RESOURCE_LIMITS.max_samples_per_instance");
            }
        } 
        else if (policy instanceof QosResourceLimits) { // ---  RESOURCE_LIMITS  ---
            QosResourceLimits rl = (QosResourceLimits) policy;
            if (rl.getMaxSamples() < rl.getMaxSamplesPerInstance()) {
                throw new InconsistentPolicy(
                        "RESOURCE_LIMITS.max_samples must be >= RESOURCE_LIMITS.max_samples_per_instance");
            }

            QosHistory h = (QosHistory) policies.get(typeof(QosHistory));
            if (h == null) {
                h = QosHistory.defaultHistory();
            }

            if (rl.getMaxSamplesPerInstance() != -1 && rl.getMaxSamplesPerInstance() < h.getDepth()) {
                throw new InconsistentPolicy("HISTORY.depth must be <= RESOURCE_LIMITS.max_samples_per_instance");
            }
#endif
        }
    }
}
