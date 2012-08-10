using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ttProtobufSampleTest.Models
{
    [Serializable]
    [ProtoContract]
    [ProtoInclude(50, typeof(Car))]
    public class BaseCar 
    {
        [ProtoMember(1)]
        public Guid Guid { get; set; }
        [ProtoMember(2)]
        public DateTime CreatedTime { get; set; }

        public BaseCar() {
            this.Guid = System.Guid.NewGuid();
            this.CreatedTime = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            BaseCar a = obj as BaseCar;
            if (a == null) return false;

            return a.Guid.Equals(this.Guid) && a.CreatedTime.Equals(this.CreatedTime);
        }
        
        public override int GetHashCode()
        {
            return this.Guid.GetHashCode();
        }
    }
}
