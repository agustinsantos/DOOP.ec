using Mina.Core.Buffer;
using rtps.messages.elements;
using rtps.messages.submessage.interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders
{
    public static class InfoReplyEncoder
    {
        public static void PutInfoReply(this IoBuffer buffer, InfoReply obj)
        {
            buffer.PutInt64(obj.UnicastLocatorList.Count);
            foreach (Locator loc in obj.UnicastLocatorList)
            {
                buffer.PutLocator(loc);
            }

            if (obj.HasMulticastFlag)
            {
                buffer.PutInt64(obj.MulticastLocatorList.Count);
                foreach (Locator loc in obj.MulticastLocatorList)
                {
                    buffer.PutLocator(loc);
                }
            }
        }

        public static InfoReply GetInfoReply(this IoBuffer buffer)
        {
            InfoReply obj = new InfoReply();
            buffer.GetInfoReply(ref obj);
            return obj;
        }

        public static void GetInfoReply(this IoBuffer buffer, ref InfoReply obj)
        {
            long numLocators = buffer.GetInt64();
            //log.DebugFormat("Reading {}(0x{}) locators", numLocators, string.Format("%08x", numLocators));
            for (int i = 0; i < numLocators; i++)
            {
                Locator loc = buffer.GetLocator();

                obj.UnicastLocatorList.Add(loc);
            }

            if (obj.HasMulticastFlag)
            {
                numLocators = buffer.GetInt64();
                for (int i = 0; i < numLocators; i++)
                {
                    Locator loc = buffer.GetLocator();

                    obj.MulticastLocatorList.Add(loc);
                }
            }
        }
    }
}
