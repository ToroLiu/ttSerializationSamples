using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ttProtobufSamples.Models
{
    [Serializable]
    [ProtoContract]
    public class Factory
    {
        [ProtoMember(1)]
        public string Guid { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }

        public Factory() { }
    }
}
