﻿using Mina.Core.Buffer;
using rtps.messages.submessage.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders.RTPS
{
    public static class NackFragEncoder
    {
        public static void PutNackFrag(this IoBuffer buffer, NackFrag obj)
        {
            buffer.PutEntityId(obj.ReaderId);
            buffer.PutEntityId(obj.WriterId);
            buffer.PutSequenceNumber(obj.WriterSequenceNumber);
            buffer.PutSequenceNumberSet(obj.FragmentNumberState);
            buffer.PutInt32(obj.Count);
        }

        public static NackFrag GetNackFrag(this IoBuffer buffer)
        {
            NackFrag obj = new NackFrag();
            buffer.GetNackFrag(ref obj);
            return obj;
        }

        public static void GetNackFrag(this IoBuffer buffer, ref NackFrag obj)
        {
            obj.ReaderId = buffer.GetEntityId();
            obj.WriterId = buffer.GetEntityId();
            obj.WriterSequenceNumber = buffer.GetSequenceNumber();
            obj.FragmentNumberState = buffer.GetSequenceNumberSet();
            obj.Count = buffer.GetInt32();
        }
    }
}
