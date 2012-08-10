using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;

namespace ttProtobufSampleTest.Models
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

        public override bool Equals(object obj)
        {
            Person a = obj as Person;
            if (a == null) return false;

            return this.Equals(a);
        }
        public virtual bool Equals(Person obj) {
            return obj.Id == this.Id && string.Compare(this.Name, obj.Name) == 0;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
