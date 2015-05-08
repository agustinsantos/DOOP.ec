<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="d0ed9acb-0435-4532-afdd-b5115bc4d562" namespace="Configuration" xmlSchemaNamespace="urn:Configuration" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
    <enumeratedType name="LogLevel" namespace="Doopec.Configuration">
      <literals>
        <enumerationLiteral name="ALL" value="0" />
        <enumerationLiteral name="DEBUG" value="1" />
        <enumerationLiteral name="WARN" value="3" />
        <enumerationLiteral name="INFO" value="2" />
        <enumerationLiteral name="ERROR" />
        <enumerationLiteral name="FATAL" />
        <enumerationLiteral name="OFF" />
      </literals>
    </enumeratedType>
    <enumeratedType name="Durability" namespace="Doopec.Configuration">
      <literals>
        <enumerationLiteral name="VOLATILE" />
        <enumerationLiteral name="TRANSIENT_LOCAL" />
        <enumerationLiteral name="TRANSIENT" />
        <enumerationLiteral name="PERSISTENT" />
      </literals>
    </enumeratedType>
    <enumeratedType name="Reliability" namespace="Doopec.Configuration">
      <literals>
        <enumerationLiteral name="BEST_EFFORT" />
        <enumerationLiteral name="RELIABLE" />
      </literals>
    </enumeratedType>
    <enumeratedType name="History" namespace="Doopec.Configuration">
      <literals>
        <enumerationLiteral name="KEEP_LAST" />
        <enumerationLiteral name="KEEP_ALL" />
      </literals>
    </enumeratedType>
    <enumeratedType name="DataRepresentation" namespace="Doopec.Configuration">
      <literals>
        <enumerationLiteral name="XCDR_DATA_REPRESENTATION" value="0" />
        <enumerationLiteral name="XML_DATA_REPRESENTATION" value="1" />
      </literals>
    </enumeratedType>
    <enumeratedType name="DestinationOrder" namespace="Doopec.Configuration">
      <literals>
        <enumerationLiteral name="BY_SOURCE_TIMESTAMP" />
        <enumerationLiteral name="BY_RECEPTION_TIMESTAMP" />
      </literals>
    </enumeratedType>
    <enumeratedType name="Liveliness" namespace="Doopec.Configuration">
      <literals>
        <enumerationLiteral name="AUTOMATIC" />
        <enumerationLiteral name="MANUAL_BY_PARTICIPANT" />
        <enumerationLiteral name="MANUAL_BY_TOPIC" />
      </literals>
    </enumeratedType>
    <enumeratedType name="Ownership" namespace="Doopec.Configuration">
      <literals>
        <enumerationLiteral name="SHARED" />
        <enumerationLiteral name="EXCLUSIVE" />
      </literals>
    </enumeratedType>
    <enumeratedType name="AccessScope" namespace="Doopec.Configuration">
      <literals>
        <enumerationLiteral name="INSTANCE" />
        <enumerationLiteral name="GROUP" />
        <enumerationLiteral name="TOPIC" />
      </literals>
    </enumeratedType>
    <enumeratedType name="TypeConsistencyEnforcement" namespace="Doopec.Configuration">
      <literals>
        <enumerationLiteral name="EXACT_TYPE_TYPE_CONSISTENCY" value="0" />
        <enumerationLiteral name="EXACT_NAME_TYPE_CONSISTENCY" value="1" />
        <enumerationLiteral name="DECLARED_TYPE_CONSISTENCY" value="2" />
        <enumerationLiteral name="ASSIGNABLE_TYPE_CONSISTENCY" value="3" />
      </literals>
    </enumeratedType>
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="DDSConfigurationSection" namespace="Doopec.Configuration" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="DDS">
      <elementProperties>
        <elementProperty name="Domains" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="domains" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Domains" />
          </type>
        </elementProperty>
        <elementProperty name="LogLevel" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="logLevel" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Log4NetLevel" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationSection name="RTPSConfigurationSection" namespace="Doopec.Configuration" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="RTPS">
      <elementProperties>
        <elementProperty name="Transports" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="transports" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Transports" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="Transport" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false" defaultValue="&quot;&quot;">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Type" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="type" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="TTL" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="ttl" isReadOnly="false" documentation="The value of the Time-To-Live (TTL) field of multicast datagrams sent as part of discovery. This value specifies the number of hops the datagram will traverse before being discarded by the network. he default value of 1 means that all data is restricted to the local network subnet.">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/TTL" />
          </type>
        </elementProperty>
        <elementProperty name="Discovery" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="discovery" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Discovery" />
          </type>
        </elementProperty>
        <elementProperty name="RtpsWriter" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="rtpsWriter" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/RtpsWriter" />
          </type>
        </elementProperty>
        <elementProperty name="RtpsReader" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="rtpsReader" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/RtpsReader" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElementCollection name="Transports" namespace="Doopec.Configuration.Rtps" xmlItemName="transport" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Transport" />
      </itemType>
    </configurationElementCollection>
    <configurationElementCollection name="Domains" namespace="Doopec.Configuration.Dds" xmlItemName="domain" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Domain" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="Domain" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="true" defaultValue="&quot;&quot;">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Id" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="id" isReadOnly="false" documentation="Domain IDs should be between 0 and 231 (inclusive) due to the way UDP ports are assigned to domain IDs. In each  process, up to 120 domain participants are supported in each domain" defaultValue="0">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="TransportProfile" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="transportProfile" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/TransportProfile" />
          </type>
        </elementProperty>
        <elementProperty name="QoS" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="qoS" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/DomainQoS" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="Log4NetLevel" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="LevelMin" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="levelMin" isReadOnly="false" defaultValue="Configuration.LogLevel.ALL">
          <type>
            <enumeratedTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LogLevel" />
          </type>
        </attributeProperty>
        <attributeProperty name="LevelMax" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="levelMax" isReadOnly="false" defaultValue="Configuration.LogLevel.FATAL">
          <type>
            <enumeratedTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LogLevel" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="Discovery" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false" defaultValue="&quot;&quot;">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="ResendPeriod" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="resendPeriod" isReadOnly="false" documentation="The number of seconds that a process waits between the announcement of participants (see section 8.5.3 in the OMG DDS-RTPS specification  for details).">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/ResendPeriod" />
          </type>
        </elementProperty>
        <elementProperty name="PortBase" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="portBase" isReadOnly="false" documentation="Port Base number. This number sets the starting point for deriving port numbers used for Simple Endpoint Discovery Protocol (SEDP). This property is used in conjunction with DG, PG, D0, and D1 to construct the necessary Endpoints for RTPS discovery communication. (see section 9.6.1.1 in the OMG DDS-RTPS specification in how these Endpoints are constructed)">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/PortBase" />
          </type>
        </elementProperty>
        <elementProperty name="DomainGain" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="domainGain" isReadOnly="false" documentation="An integer value representing the Domain Gain. This is a multiplier that assists in formulating Multicast or Unicast ports for RTPS.">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/PortGain" />
          </type>
        </elementProperty>
        <elementProperty name="OffsetMetatrafficUnicast" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="offsetMetatrafficUnicast" isReadOnly="false" documentation="D0. An integer value that assists in providing an offset for calculating an assignable port in SPDP Multicast configurations. The formula used is: PB + DG * domainId + d0 (see section 9.6.1.1 in the OMG DDS-RTPS specification in how these Endpoints are constructed)">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/OffsetUnicast" />
          </type>
        </elementProperty>
        <elementProperty name="OffsetMetatrafficMulticast" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="offsetMetatrafficMulticast" isReadOnly="false" documentation="D1. An integer value that assists in providing an offset for calculating an assignable port in SPDP Unicast configurations. The formula used is: PB + DG * domainId + d1 + PG * participantId (see section 9.6.1.1 in the OMG DDS-RTPS specification in how these Endpoints are constructed)">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/OffsetMulticast" />
          </type>
        </elementProperty>
        <elementProperty name="UseSedpMulticast" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="useSedpMulticast" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/UseSedpMulticast" />
          </type>
        </elementProperty>
        <elementProperty name="MetatrafficUnicastLocatorList" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="metatrafficUnicastLocatorList" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LocatorAddrs" />
          </type>
        </elementProperty>
        <elementProperty name="MetatrafficMulticastLocatorList" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="metatrafficMulticastLocatorList" isReadOnly="false" documentation="A network address specifying the multicast group to be used for SPDP discovery. This overrides the interoperability group of the specification. It ca be used, for example, to specify use of a routed group address to provide a larger discovery scope.">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LocatorAddrs" />
          </type>
        </elementProperty>
        <elementProperty name="ParticipantGain" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="participantGain" isReadOnly="false" documentation="An integer that assists in configuring SPDP Unicast ports and serves as an offset multiplier as participants are assigned addresses using the formula: PB + DG * domainId + d1 + PG * participantId (see section 9.6.1.1 in the OMG DDS-RTPS specification in how these Endpoints are constructed)">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/PortGain" />
          </type>
        </elementProperty>
        <elementProperty name="DefaultUnicastLocatorList" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="defaultUnicastLocatorList" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LocatorAddrs" />
          </type>
        </elementProperty>
        <elementProperty name="DefaultMulticastLocatorList" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="defaultMulticastLocatorList" isReadOnly="false" documentation="A network address specifying the multicast group to be used for SPDP discovery. This overrides the interoperability group of the specification. It ca be used, for example, to specify use of a routed group address to provide a larger discovery scope.">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LocatorAddrs" />
          </type>
        </elementProperty>
        <elementProperty name="OffsetUserTrafficUnicast" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="offsetUserTrafficUnicast" isReadOnly="false" documentation="D0. An integer value that assists in providing an offset for calculating an assignable port in SPDP Multicast configurations. The formula used is: PB + DG * domainId + d0 (see section 9.6.1.1 in the OMG DDS-RTPS specification in how these Endpoints are constructed)">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/OffsetUnicast" />
          </type>
        </elementProperty>
        <elementProperty name="OffsetUserTrafficMulticast" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="offsetUserTrafficMulticast" isReadOnly="false" documentation="D1. An integer value that assists in providing an offset for calculating an assignable port in SPDP Unicast configurations. The formula used is: PB + DG * domainId + d1 + PG * participantId (see section 9.6.1.1 in the OMG DDS-RTPS specification in how these Endpoints are constructed)">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/OffsetMulticast" />
          </type>
        </elementProperty>
        <elementProperty name="AvailableBuiltinEndpoints" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="availableBuiltinEndpoints" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Generic_TODO" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="ResendPeriod" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false" defaultValue="30000L">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int64" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoS" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="PortBase" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false" defaultValue="7400">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="PortGain" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false" defaultValue="250">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="OffsetUnicast" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false" defaultValue="2">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="OffsetMulticast" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false" defaultValue="0">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="UseSedpMulticast" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false" defaultValue="true">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="LocatorAddrs" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="TTL" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false" defaultValue="1">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="DomainParticipantQoS" namespace="Doopec.Configuration.Dds">
      <baseClass>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoS" />
      </baseClass>
      <elementProperties>
        <elementProperty name="UserData" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="userData" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QosData" />
          </type>
        </elementProperty>
        <elementProperty name="EntityFactory" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="entityFactory" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSEntityFactory" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="QosData" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Value" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSEntityFactory" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="AutoenableCreatedEntities" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="autoenableCreatedEntities" isReadOnly="false" defaultValue="true">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="PublisherQoS" namespace="Doopec.Configuration.Dds">
      <baseClass>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoS" />
      </baseClass>
      <elementProperties>
        <elementProperty name="GroupData" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="groupData" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QosData" />
          </type>
        </elementProperty>
        <elementProperty name="Presentation" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="presentation" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSPresentation" />
          </type>
        </elementProperty>
        <elementProperty name="Partition" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="partition" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSPartition" />
          </type>
        </elementProperty>
        <elementProperty name="EntityFactory" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="entityFactory" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSEntityFactory" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="QoSPresentation" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="AccessScope" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="accessScope" isReadOnly="false" defaultValue="AccessScope.INSTANCE">
          <type>
            <enumeratedTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/AccessScope" />
          </type>
        </attributeProperty>
        <attributeProperty name="CoherentAccess" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="coherentAccess" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="OrderedAccess" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="orderedAccess" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="SubscriberQoS" namespace="Doopec.Configuration.Dds">
      <baseClass>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoS" />
      </baseClass>
      <elementProperties>
        <elementProperty name="GroupData" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="groupData" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QosData" />
          </type>
        </elementProperty>
        <elementProperty name="Presentation" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="presentation" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSPresentation" />
          </type>
        </elementProperty>
        <elementProperty name="Partition" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="partition" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QosData" />
          </type>
        </elementProperty>
        <elementProperty name="EntityFactory" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="entityFactory" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSEntityFactory" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="DomainQoS" namespace="Doopec.Configuration.Dds">
      <elementProperties>
        <elementProperty name="DomainParticipantQos" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="domainParticipantQos" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/DomainParticipantQoS" />
          </type>
        </elementProperty>
        <elementProperty name="PublisherQoS" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="publisherQoS" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/PublisherQoS" />
          </type>
        </elementProperty>
        <elementProperty name="SubscriberQoS" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="subscriberQoS" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/SubscriberQoS" />
          </type>
        </elementProperty>
        <elementProperty name="TopicQoS" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="topicQoS" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/TopicQoS" />
          </type>
        </elementProperty>
        <elementProperty name="DataWriterQoS" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="dataWriterQoS" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/DataWriterQoS" />
          </type>
        </elementProperty>
        <elementProperty name="DataReaderQoS" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="dataReaderQoS" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/DataReaderQoS" />
          </type>
        </elementProperty>
        <elementProperty name="DomainParticipantFactoryQos" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="domainParticipantFactoryQos" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/DomainParticipantFactoryQoS" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="TopicQoS" namespace="Doopec.Configuration.Dds">
      <baseClass>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoS" />
      </baseClass>
      <elementProperties>
        <elementProperty name="TopicData" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="topicData" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QosData" />
          </type>
        </elementProperty>
        <elementProperty name="Durability" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="durability" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSDurability" />
          </type>
        </elementProperty>
        <elementProperty name="Deadline" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="deadline" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSDeadline" />
          </type>
        </elementProperty>
        <elementProperty name="Reliability" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="reliability" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSReability" />
          </type>
        </elementProperty>
        <elementProperty name="TransportPriority" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="transportPriority" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSTransportPriority" />
          </type>
        </elementProperty>
        <elementProperty name="History" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="history" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSHistory" />
          </type>
        </elementProperty>
        <elementProperty name="DurabilityService" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="durabilityService" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSDurabilityService" />
          </type>
        </elementProperty>
        <elementProperty name="LatencyBudget" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="latencyBudget" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSLatencyBudget" />
          </type>
        </elementProperty>
        <elementProperty name="Ownership" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="ownership" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSOwnership" />
          </type>
        </elementProperty>
        <elementProperty name="Liveliness" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="liveliness" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSLiveliness" />
          </type>
        </elementProperty>
        <elementProperty name="Lifespan" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="lifespan" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSLifespan" />
          </type>
        </elementProperty>
        <elementProperty name="DestinationOrder" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="destinationOrder" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSDestinationOrder" />
          </type>
        </elementProperty>
        <elementProperty name="ResourceLimits" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="resourceLimits" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSResourceLimits" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="QoSDurability" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Kind" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="kind" isReadOnly="false" defaultValue="Durability.VOLATILE">
          <type>
            <enumeratedTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Durability" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="DataWriterQoS" namespace="Doopec.Configuration.Dds">
      <baseClass>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoS" />
      </baseClass>
      <elementProperties>
        <elementProperty name="UserData" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="userData" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QosData" />
          </type>
        </elementProperty>
        <elementProperty name="Durability" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="durability" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSDurability" />
          </type>
        </elementProperty>
        <elementProperty name="Deadline" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="deadline" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSDeadline" />
          </type>
        </elementProperty>
        <elementProperty name="Reliability" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="reliability" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSReability" />
          </type>
        </elementProperty>
        <elementProperty name="TransportPriority" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="transportPriority" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSTransportPriority" />
          </type>
        </elementProperty>
        <elementProperty name="History" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="history" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSHistory" />
          </type>
        </elementProperty>
        <elementProperty name="DurabilityService" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="durabilityService" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSDurabilityService" />
          </type>
        </elementProperty>
        <elementProperty name="LatencyBudget" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="latencyBudget" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSLatencyBudget" />
          </type>
        </elementProperty>
        <elementProperty name="Ownership" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="ownership" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSOwnership" />
          </type>
        </elementProperty>
        <elementProperty name="OwnershipStrength" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="ownershipStrength" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSOwnershipStrength" />
          </type>
        </elementProperty>
        <elementProperty name="Liveliness" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="liveliness" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSLiveliness" />
          </type>
        </elementProperty>
        <elementProperty name="Lifespan" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="lifespan" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSLifespan" />
          </type>
        </elementProperty>
        <elementProperty name="DestinationOrder" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="destinationOrder" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSDestinationOrder" />
          </type>
        </elementProperty>
        <elementProperty name="ResourceLimits" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="resourceLimits" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSResourceLimits" />
          </type>
        </elementProperty>
        <elementProperty name="WriterDataLifecycle" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="writerDataLifecycle" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSWriterDataLifecycle" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="DataReaderQoS" namespace="Doopec.Configuration.Dds">
      <baseClass>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoS" />
      </baseClass>
      <elementProperties>
        <elementProperty name="UserData" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="userData" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QosData" />
          </type>
        </elementProperty>
        <elementProperty name="Durability" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="durability" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSDurability" />
          </type>
        </elementProperty>
        <elementProperty name="Deadline" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="deadline" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSDeadline" />
          </type>
        </elementProperty>
        <elementProperty name="Reliability" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="reliability" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSReability" />
          </type>
        </elementProperty>
        <elementProperty name="History" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="history" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSHistory" />
          </type>
        </elementProperty>
        <elementProperty name="LatencyBudget" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="latencyBudget" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSLatencyBudget" />
          </type>
        </elementProperty>
        <elementProperty name="Ownership" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="ownership" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSOwnership" />
          </type>
        </elementProperty>
        <elementProperty name="Liveliness" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="liveliness" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSLiveliness" />
          </type>
        </elementProperty>
        <elementProperty name="TimeBasedFilter" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="timeBasedFilter" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSTimeBasedFilter" />
          </type>
        </elementProperty>
        <elementProperty name="DestinationOrder" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="destinationOrder" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSDestinationOrder" />
          </type>
        </elementProperty>
        <elementProperty name="ResourceLimits" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="resourceLimits" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSResourceLimits" />
          </type>
        </elementProperty>
        <elementProperty name="ReaderDataLifecycle" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="readerDataLifecycle" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSReaderDataLifecycle" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="QoSReability" namespace="Doopec.Configuration.Dds" documentation="Indicates the level of reliability offered/requested by the Service.">
      <attributeProperties>
        <attributeProperty name="Kind" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="kind" isReadOnly="false" defaultValue="Reliability.BEST_EFFORT">
          <type>
            <enumeratedTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Reliability" />
          </type>
        </attributeProperty>
        <attributeProperty name="MaxBlockingTime" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="maxBlockingTime" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int64" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSTransportPriority" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Value" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false" defaultValue="0">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSHistory" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Kind" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="kind" isReadOnly="false" defaultValue="History.KEEP_ALL">
          <type>
            <enumeratedTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/History" />
          </type>
        </attributeProperty>
        <attributeProperty name="Depth" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="depth" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="RtpsWriter" namespace="Doopec.Configuration.Rtps">
      <elementProperties>
        <elementProperty name="PushMode" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="pushMode" isReadOnly="false" documentation="This configuration parameter affects how writer communicates changes to readers. If push-mode is false, writer will announce new data to readers by sending a Heartbeat message. If set to true, writer will send the changes to all matched readers directly.">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/PushMode" />
          </type>
        </elementProperty>
        <elementProperty name="HeartbeatPeriod" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="heartbeatPeriod" isReadOnly="false" documentation="This configuration parameter tells how often writer will advertise the changes it has by sending a Heartbeat message. Note, that Heartbeats will be sent regardless of push-mode">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/HeartbeatPeriod" />
          </type>
        </elementProperty>
        <elementProperty name="NackResponseDelay" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="nackResponseDelay" isReadOnly="false" documentation="When writer receives a AckNack message, it will wait nack-response-delay before it considers how to respond to reader.">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/ResponseDelay" />
          </type>
        </elementProperty>
        <elementProperty name="NackSuppressionDuration" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="nackSuppressionDuration" isReadOnly="false" documentation="This parameter let's writer discard reception of AckNack message, if it arrives 'too soon'.">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/SuppressionDuration" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="RtpsReader" namespace="Doopec.Configuration.Rtps">
      <elementProperties>
        <elementProperty name="HeartbeatResponseDelay" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="heartbeatResponseDelay" isReadOnly="false" documentation="Reader waits this amount of time before reacting on writers Heartbeat message.">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/ResponseDelay" />
          </type>
        </elementProperty>
        <elementProperty name="HeartbeatSuppressionDuration" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="heartbeatSuppressionDuration" isReadOnly="false" documentation="This parameter allows reader to discard reception Heartbeat messages that arrive 'too soon'.">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/SuppressionDuration" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="PushMode" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false" defaultValue="true">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="HeartbeatPeriod" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false" defaultValue="250">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="ResponseDelay" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false" defaultValue="250">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="SuppressionDuration" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false" defaultValue="250">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSLifespan" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Duration" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="duration" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSOwnership" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Kind" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="kind" isReadOnly="false">
          <type>
            <enumeratedTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Ownership" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSOwnershipStrength" namespace="Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Value" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSWriterDataLifecycle" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="AutodisposeUnregisteredInstances" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="autodisposeUnregisteredInstances" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSReaderDataLifecycle" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="AutopurgeDisposedSamplesDelay" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="autopurgeDisposedSamplesDelay" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int64" />
          </type>
        </attributeProperty>
        <attributeProperty name="AutopurgeNowriterSamplesDelay" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="autopurgeNowriterSamplesDelay" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int64" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSLatencyBudget" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Duration" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="duration" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int64" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSDeadline" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Period" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="period" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int64" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSTimeBasedFilter" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="MinimumSeparation" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="minimumSeparation" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int64" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSPartition" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Value" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSLiveliness" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="LeaseDuration" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="leaseDuration" isReadOnly="false" defaultValue="0L">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int64" />
          </type>
        </attributeProperty>
        <attributeProperty name="Kind" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="kind" isReadOnly="false">
          <type>
            <enumeratedTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Liveliness" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSResourceLimits" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="MaxSamples" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="maxSamples" isReadOnly="false" defaultValue="0">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="MaxInstances" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="maxInstances" isReadOnly="false" defaultValue="0">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="MaxSamplesPerInstance" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="maxSamplesPerInstance" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSDurabilityService" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="ServiceCleanupDelay" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="serviceCleanupDelay" isReadOnly="false" defaultValue="0L">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int64" />
          </type>
        </attributeProperty>
        <attributeProperty name="HistoryKind" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="historyKind" isReadOnly="false" defaultValue="History.KEEP_LAST">
          <type>
            <enumeratedTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/History" />
          </type>
        </attributeProperty>
        <attributeProperty name="HistoryDepth" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="historyDepth" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="MaxSamples" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="maxSamples" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="MaxInstances" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="maxInstances" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="MaxSamplesPerInstance" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="maxSamplesPerInstance" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="QoSDestinationOrder" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Kind" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="kind" isReadOnly="false" defaultValue="DestinationOrder.BY_RECEPTION_TIMESTAMP">
          <type>
            <enumeratedTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/DestinationOrder" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="DomainParticipantFactoryQoS" namespace="Configuration.Dds">
      <baseClass>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoS" />
      </baseClass>
      <elementProperties>
        <elementProperty name="EntityFactory" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="entityFactory" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/QoSEntityFactory" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="TransportProfile" namespace="Doopec.Configuration.Dds">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="Generic_TODO" namespace="Doopec.Configuration.Rtps">
      <attributeProperties>
        <attributeProperty name="Val" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="val" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>