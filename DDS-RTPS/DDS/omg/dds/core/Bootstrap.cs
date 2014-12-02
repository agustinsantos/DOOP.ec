/// <copyright file="Bootstrap.cs" Company="Doop.ec">
/// Copyright 2010, Object Management Group, Inc.
/// Copyright 2010, PrismTech, Inc.
/// Copyright 2010, Real-Time Innovations, Inc.
/// All rights reserved.
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///     http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
///</copyright>



using DDS.ConversionUtils;
using org.omg.dds.core.modifiable;
using org.omg.dds.core.policy;
using org.omg.dds.core.status;
using org.omg.dds.domain;
using org.omg.dds.sub;
using org.omg.dds.topic;
using org.omg.dds.type;
using org.omg.dds.type.dynamic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace org.omg.dds.core
{
    /// <summary>
    /// DDS implementations are rooted in this class, a concrete subclass
    ///  of which can be instantiated based on a system property.
    ///  
    /// All public concrete and abstract methods of this class are reentrant. The
    /// reentrancy of any new methods that may be defined by subclasses is
    /// unspecified.
    /// </summary>
    public abstract class Bootstrap : DDSObject
    {
        // -----------------------------------------------------------------------
        // Public Fields
        // -----------------------------------------------------------------------

        public const string IMPLEMENTATION_CLASS_NAME_PROPERTY = "org.omg.dds.serviceClassName";



        // -----------------------------------------------------------------------
        // Private Fields
        // -----------------------------------------------------------------------

        private const string ERROR_STRING = "Unable to load OMG DDS implementation. ";



        // -----------------------------------------------------------------------
        // Object Life Cycle
        // -----------------------------------------------------------------------

        /// <summary>
        /// Create and return a new instance of a concrete implementation of this
        /// class. This method is equivalent to calling:
        /// <code>CreateInstance((Map) null);</code>
        /// </summary>
        /// <returns>A non-null Bootstrap.</returns>
        public static Bootstrap CreateInstance()
        {
            return CreateInstance(null);
        }

        /// <summary>
        /// Create and return a new instance of a concrete implementation of this
        /// class with the given environment. This method is equivalent to calling:
        /// <code>
        /// CreateInstance(IMPLEMENTATION_CLASS_NAME_PROPERTY, environment);
        /// </code>
        /// </summary>
        /// <param name="environment"></param>
        /// <returns>A non-null Bootstrap.</returns>
        public static Bootstrap CreateInstance(IDictionary<string, Object> environment)
        {
            return CreateInstance(IMPLEMENTATION_CLASS_NAME_PROPERTY, environment);
        }


        /// <summary>
        /// Look up the system property identified by the given string and load,
        /// then instantiate, the Bootstrap implementation class identified by its
        /// value. The class must be accessible and have a public constructor.
        /// 
        /// The public constructors of the implementation class will first be
        /// searched for one accepting a single argument of type {@link Map}. If
        /// one is found, it will be called with the <code>environment</code> map
        /// provided to this method as its argument. If no such constructor is
        /// found, a no-argument constructor will be used instead, and the
        /// provided <code>environment</code>, if any, will be ignored. If the
        /// implementation class provides no public constructor with either of
        /// these signatures, an exception will be thrown.
        /// 
        /// By default, the class loader for the <code>Bootstrap</code> class will
        /// be used to load the indicated class. If this class loader is null --
        /// for instance, if it is the bootstrap class loader -- then the system
        /// class loader will be used in its place. If it is also null, a
        /// <code>ServiceConfigurationException</code> will be thrown.
        /// 
        /// Neither the class loader nor the loaded class will be cached between
        /// invocations of this method. As a result, execution of this method is
        /// expected to be relatively expensive. However, as any DDS object can
        /// provide a reference to its creating Bootstrap via
        /// {@link DDSObject#getBootstrap()}, executions of this method are also
        /// expected to be rare.
        /// </summary>
        /// <param name="implClassNameProperty">The name of a system property,
        ///          the value of which will be taken as the name of a Bootstrap
        ///          implementation class to load.
        ///          </param>
        /// <param name="environment">A collection of name-value pairs
        ///          to be provided to the concrete Bootstrap subclass. If that
        ///          class does not provide a constructor that can accept this
        ///          environment, the environment will be ignored. This argument
        ///          may be null; a null environment shall be considered equivalent
        ///          to an empty map.</param>
        /// <returns>A non-null Bootstrap.</returns>
        /// <exception cref="ServiceConfigurationException">
        ///          If the class could not be
        ///          loaded because of an issue with the the invocation of this
        ///          method or the configuration of the runtime environment. For
        ///          example, the class may not be on the class path, it may
        ///          require a native library that is not available, or an
        ///          inappropriate class may have been requested (e.g. one that is
        ///          not a Bootstrap or that doesn't have a no-argument
        ///          constructor).
        /// </exception>
        /// <exception cref="ServiceInitializationException">
        ///          If the class was found but
        ///          could not be initialized and/or instantiated because of an
        ///          error that occurred within its implementation.
        /// </exception>         
        public static Bootstrap CreateInstance(string implClassNameProperty, IDictionary<string, Object> environment)
        {
            // --- Get implementation class name --- //
            /* System.getProperty checks the implClassNameProperty argument as
             * described in the specification for this method and throws
             * NullPointerException or IllegalArgumentException if necessary.
             */
            
            string className = ConfigurationManager.AppSettings[implClassNameProperty];
            if (string.IsNullOrWhiteSpace(className))
            {
                // no implementation class name specified
                throw new ServiceConfigurationException(ERROR_STRING + "Please set " + implClassNameProperty + " property.");
            }

            try
            {
                Type ctxClass = Type.GetType(className, true);


                // --- Instantiate new object --- //
                try
                {
                    // First, try a constructor that will accept the environment.
                    object newInstance = Activator.CreateInstance(ctxClass, environment);
                    if (newInstance != null)
                        return (Bootstrap)newInstance;
                }
                catch (Exception)
                {
                    /// No Map constructor found; try a no-argument constructor
                    /// instead.
                    ///
                    /// Get the constructor and call it explicitly rather than
                    /// calling Class.newInstance(). The latter propagates all
                    /// exceptions, even checked ones, complicating error handling
                    /// for us and the user.
                    object newInstance = Activator.CreateInstance(ctxClass);
                    return (Bootstrap)newInstance;
                }

                // --- Initialization problems --- //
            }
            //catch (Exception ex)
            //{
            //    throw new ServiceInitializationException(ERROR_STRING + "Error during static initialization.", ex);
            //}
            catch (TargetInvocationException itx)
            {
                // Thrown by Constructor.newInstance
                throw new ServiceInitializationException(ERROR_STRING + "Error during object initialization.", itx);

                // --- Configuration problems --- //
            }
            catch (InvalidOperationException isx)
            {
                // Thrown by ClassLoader.getSystemClassLoader.
                throw new ServiceConfigurationException(ERROR_STRING, isx);
            }
#if TODO
           catch (ClassNotFoundException cnfx)
            {
                // Thrown by ClassLoader.loadClass.
                throw new ServiceConfigurationException(
                        ERROR_STRING + className + " was not found.",
                        cnfx);
            }
            catch (LinkageError linkx)
            {
                // Presumably thrown by ClassLoader.loadClass, but not documented.
                throw new ServiceConfigurationException(
                        ERROR_STRING + className + " could not be loaded.",
                        linkx);
            }
            catch (NoSuchMethodException nsmx)
            {
                // Thrown by Class.getConstructor: no no-argument constructor
                throw new ServiceConfigurationException(
                        ERROR_STRING + className +
                            " has no appropriate constructor.",
                        nsmx);
            }
            catch (IllegalAccessException iax)
            {
                // Thrown by Constructor.newInstance
                throw new ServiceConfigurationException(
                        ERROR_STRING + className +
                            " has no appropriate constructor.",
                        iax);
            }
            catch (InstantiationException ix)
            {
                // Thrown by Constructor.newInstance
                throw new ServiceConfigurationException(
                        ERROR_STRING + className + " could not be instantiated.",
                        ix);
            }
            catch (SecurityException sx)
            {
                // Thrown by ClassLoader.getSystemClassLoader.
                // Thrown by Class.getConstructor.
                throw new ServiceConfigurationException(
                        ERROR_STRING + "Prevented by security manager.", sx);
            }
            catch (ClassCastException ccx)
            {
                // Thrown by type cast
                throw new ServiceConfigurationException(
                        ERROR_STRING + className + " is not a Bootstrap.", ccx);

                // --- Implementation problems --- //
            }
            catch (IllegalArgumentException argx)
            {
                /* Thrown by Constructor.newInstance to indicate that formal
                 * parameters and provided arguments are not compatible. Since
                 * the constructor doesn't take any arguments, and we didn't
                 * provide any, we shouldn't be able to get here.
                 */
                throw new AssertionError(argx);
            }
#endif
            /// If any other RuntimeException or Error gets thrown above, it's
            ///  either a bug in the implementation of this method or an
            /// undocumented behavior of the Java standard library. In either
            /// case, there's not much we can do about it, so let the exception
            /// propagate up the call stack as-is.
       
            return null;
        }


        protected Bootstrap()
        {
            // empty
        }



        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        public abstract ServiceProviderInterface getSPI();


        // --- From DDSObject: ---------------------------------------------------

        public Bootstrap getBootstrap()
        {
            return this;
        }



        // -----------------------------------------------------------------------
        // Service-Provider Interface
        // -----------------------------------------------------------------------

        /// <summary>
        /// This interface is for the use of the DDS implementation, not of DDS
        /// applications. It simplifies the creation of objects of certain types in
        /// the DDS API.
        /// </summary>
        public interface ServiceProviderInterface
        {
            // --- Singleton factories: ------------------------------------------

            DomainParticipantFactory getParticipantFactory();

            DynamicTypeFactory getTypeFactory();

            DynamicDataFactory getDataFactory();


            // --- Types: --------------------------------------------------------

            /// <summary>
            /// Create a new {@link TypeSupport} object for the given physical
            /// type. The Service will register this type under the given name
            /// with any participant with which the <code>TypeSupport</code> is
            /// used
            /// </summary>
            /// <typeparam name="TYPE">The physical type of all samples read or written
            ///                        by any {@link org.omg.dds.sub.DataReader} or
            ///                        {@link org.omg.dds.pub.DataWriter} typed by the
            ///                        resulting <code>TypeSupport</code>
            /// </typeparam>
            /// <param name="type">The physical type of all samples read or written
            ///                    by any {@link org.omg.dds.sub.DataReader} or
            ///                    {@link org.omg.dds.pub.DataWriter} typed by the
            ///                    resulting <code>TypeSupport</code>
            /// </param>
            /// <param name="registeredName">The logical name under which this type
            ///                              will be registered with any
            ///                              {@link org.omg.dds.domain.DomainParticipant}
            ///                              with which the resulting
            ///                              <code>TypeSupport</code> is used
            /// </param>
            /// <returns>A new <code>TypeSupport</code> object, which can
            ///          subsequently be used to create one or more
            ///          {@link org.omg.dds.topic.Topic}s
            /// </returns>
            TypeSupport<TYPE> newTypeSupport<TYPE>(Type type, string registeredName);


            // --- Time & Duration: ----------------------------------------------


            /// <summary>
            /// Construct a {@link Duration} of the given magnitude.
            /// 
            /// A duration of magnitude {@link Long#MAX_VALUE} indicates an
            /// infinite duration, regardless of the units specified.
            /// </summary>
            /// <param name="duration"></param>
            /// <param name="unit"></param>
            /// <returns></returns>
            ModifiableDuration newDuration(long duration, TimeUnit unit);

            /// <summary>
            /// 
            /// </summary>
            /// <returns>A {@link Duration} of infinite length</returns>
            Duration infiniteDuration();

            /// <summary>
            /// 
            /// </summary>
            /// <returns>A {@link Duration} of zero length</returns>
            Duration zeroDuration();

            /// <summary>
            /// Construct a specific instant in time.
            /// 
            /// Negative values are considered invalid and will result in the
            /// construction of a time <code>t</code> such that:
            /// 
            /// <code>t.isValid() == false</code>
            /// </summary>
            /// <param name="time"></param>
            /// <param name="units"></param>
            /// <returns></returns>
            ModifiableTime newTime(long time, TimeUnit units);

            /// <summary>
            /// 
            /// </summary>
            /// <returns>A {@link Time} that is not valid</returns>
            Time invalidTime();


            // --- Instance handle: ----------------------------------------------

            ModifiableInstanceHandle newInstanceHandle();

            InstanceHandle nilHandle();


            // --- Conditions & WaitSet: -----------------------------------------

            GuardCondition newGuardCondition();

            WaitSet newWaitSet();


            // --- Built-in topics: ----------------------------------------------

            BuiltinTopicKey newBuiltinTopicKey();

            ParticipantBuiltinTopicData newParticipantBuiltinTopicData();

            PublicationBuiltinTopicData newPublicationBuiltinTopicData();

            SubscriptionBuiltinTopicData newSubscriptionBuiltinTopicData();

            TopicBuiltinTopicData newTopicBuiltinTopicData();


            // --- QoS: ----------------------------------------------------------

            QosPolicyId getQosPolicyId(Type policyClass);


            // --- Status: -------------------------------------------------------

            ISet<Type> allStatusKinds();

            ISet<Type> noStatusKinds();

            LivelinessLostStatus<TYPE> newLivelinessLostStatus<TYPE>();

            OfferedDeadlineMissedStatus<TYPE> newOfferedDeadlineMissedStatus<TYPE>();

            OfferedIncompatibleQosStatus<TYPE> newOfferedIncompatibleQosStatus<TYPE>();

            PublicationMatchedStatus<TYPE> newPublicationMatchedStatus<TYPE>();

            LivelinessChangedStatus<TYPE> newLivelinessChangedStatus<TYPE>();

            RequestedDeadlineMissedStatus<TYPE> newRequestedDeadlineMissedStatus<TYPE>();

            RequestedIncompatibleQosStatus<TYPE> newRequestedIncompatibleQosStatus<TYPE>();

            SampleLostStatus<TYPE> newSampleLostStatus<TYPE>();

            SampleRejectedStatus<TYPE> newSampleRejectedStatus<TYPE>();

            SubscriptionMatchedStatus<TYPE> newSubscriptionMatchedStatus<TYPE>();

            DataAvailableStatus<TYPE> newDataAvailableStatus<TYPE>();

            DataOnReadersStatus newDataOnReadersStatus();

            InconsistentTopicStatus<TYPE> newInconsistentTopicStatus<TYPE>();


            // --- Sample & Instance Life Cycle: ---------------------------------

            ISet<InstanceState> anyInstanceStateSet();

            ISet<InstanceState> notAliveInstanceStateSet();

            ISet<SampleState> anySampleStateSet();

            ISet<ViewState> anyViewStateSet();
        }
    }
}