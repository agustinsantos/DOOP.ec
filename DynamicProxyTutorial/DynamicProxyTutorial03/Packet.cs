using System;

namespace Sxta.GenericProtocol
{
	[System.AttributeUsage( System.AttributeTargets.Class |
                       		System.AttributeTargets.Struct ) 
	]
	public class Packet : System.Attribute
	{			
		public Packet ()
		{
		}
		
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public String Name { get; protected set; }
	}
}

