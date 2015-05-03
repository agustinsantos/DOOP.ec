using org.omg.dds.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core
{
    public class DDSObjectImpl : DDSObject
    {
        /// <summary>
        /// The Bootstrap object that directly or indirectly created this object.
        /// </summary>
        private readonly Bootstrap bootstrap;

        public DDSObjectImpl(Bootstrap bootstrap)
        {
            this.bootstrap = bootstrap;
        }

        /// <summary>
        /// The Bootstrap object that directly or indirectly created this object.
        /// </summary>
        public Bootstrap Bootstrap
        {
            get { return this.bootstrap; }
        }

        /// <summary>
        /// The Bootstrap object that directly or indirectly created this object.
        /// </summary>
         public Bootstrap GetBootstrap()
         { 
             return this.bootstrap;
         }

    }
}
