using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ProtoBuf;

namespace ttProtobufSamples.Models
{
    [Serializable]
    [ProtoContract]
    public class Car : BaseCar
    {
        [ProtoMember(1)]
        public Person Owner { get; set; }
        [ProtoMember(2)]
        public Factory Factory { get; set; }

        [ProtoMember(3)]
        public Person[] Friends { get; set; }

        public Car() : base() { 
        }
    }
}
