using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;

namespace ttProtobufSamples.Models
{
    [Serializable]
    [ProtoContract]
    public class Person 
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }

        public Person() { 
        }
    }
}
