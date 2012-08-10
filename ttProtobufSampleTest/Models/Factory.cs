using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ttProtobufSampleTest.Models
{
    [Serializable]
    [ProtoContract]
    public class Factory
    {
        [ProtoMember(1)]
        public Guid Guid { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }

        public Factory() {
            this.Guid = System.Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            Factory a = obj as Factory;
            if (a == null) return false;

            return a.Guid.Equals(this.Guid) && string.Compare(a.Name, this.Name) == 0;
        }

        public override int GetHashCode()
        {
            return this.Guid.GetHashCode();
        }
    }
}
