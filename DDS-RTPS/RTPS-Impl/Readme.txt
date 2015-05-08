There are some state machines in the design of DDS and RTPS. This can be done using hard code logic or 
using a library. 
I found this http://stackoverflow.com/questions/5923767/simple-state-machine-example-in-c
that can help. I liked the idea of using  http://code.google.com/p/bbvcommon/wiki/StateMachine.

In order to implement the query language of DDS, I found nice the idea of applying 
Expression Tress at  http://stackoverflow.com/questions/6488034/how-to-implement-a-rule-engine
and http://coding-time.blogspot.com.es/2011/07/how-to-implement-rule-engine-in-c.html

TODO. Review this code and apply if appropiate.

TODO. Review the design of ReadOnlyCollection<T> and try to apply it to QoS and ModifiableQoS
TODO. Domain configuration: set default and set id as a key
TODO. DomainParticipantFactoryQosImpl should be defined outside Domains. 
TODO. UserData is wrong in domainParticipantQos. 
TODO. Add in DDS config an entry for "org.omg.dds.serviceClassName" value="Doopec.Dds.Core.BootstrapImpl, Doopec"
TODO. Define the GUID generation process
TODO. Default values in RTPS discovery HeartbeatResponseDelay = 500 ms, HeartbeatSuppressionDuration = 0.
TODO. Add protocol version and vendorId to configuration