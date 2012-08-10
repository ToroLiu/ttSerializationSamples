using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ProtoBuf;

namespace ttProtobufSampleTest.Models
{
    public enum CarType {
        Blue,
        Black,
        Classic,
        Standard,
    }

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

        [ProtoMember(4)]
        public CarType Type { get; set; }

        public Car() : base() {
            Random r = new Random();
            this.Type = (CarType)(r.Next(4));
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            
            Car a = obj as Car;
            if (a == null) return false;

            bool equal =
                a.Owner.Equals(this.Owner) &&
                a.Factory.Equals(this.Factory) &&
                a.Friends.Equals(this.Friends) &&
                a.Type.Equals(this.Type);

            return equal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
