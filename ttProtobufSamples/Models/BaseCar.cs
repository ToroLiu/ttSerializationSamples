using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ttProtobufSamples.Models
{
    [Serializable]
    [ProtoContract]
    public class BaseCar 
    {
        [ProtoMember(1)]
        public string Guid { get; set; }
        [ProtoMember(2)]
        public DateTime CreatedTime { get; set; }

        public BaseCar() {
            this.Guid = System.Guid.NewGuid().ToString();
            this.CreatedTime = DateTime.Now;
        }
    }
}
