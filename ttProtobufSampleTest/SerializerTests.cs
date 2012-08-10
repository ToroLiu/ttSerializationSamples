using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtoBuf;
using System.Xml.Serialization;
using System.IO;

namespace ttProtobufSampleTest
{
    using Models;

    [TestClass]
    public class SerializerTests
    {
        [TestMethod]
        public void TestXML()
        {
            Car orig = CarHelper.CreateCar();
            using (FileStream stream = File.Create("car.xml")) {
                XmlSerializer xml = new XmlSerializer(typeof(Car));
                xml.Serialize(stream, orig);

                stream.Position = 0;
                Car aCar = (Car)xml.Deserialize(stream);

                Assert.IsTrue(aCar.Guid.Equals(orig.Guid));
                Assert.IsTrue(aCar.Owner.Equals(orig.Owner));
                Assert.IsTrue(aCar.Factory.Equals(orig.Factory));

                bool eqaul = Enumerable.SequenceEqual(orig.Friends, aCar.Friends);
                Assert.IsTrue(eqaul);

                //Assert.IsTrue(aCar.Friends.Equals(orig.Friends));
                Assert.IsTrue(aCar.Type.Equals(orig.Type));
            }
        }

        [TestMethod]
        public void TestProtoBuf() {
            Car orig = CarHelper.CreateCar();
            using (FileStream stream = File.Create("car.bin")) {
                Serializer.Serialize(stream, orig);

                stream.Position = 0;
                Car aCar = Serializer.Deserialize<Car>(stream);

                Assert.IsTrue(aCar.Guid.Equals(orig.Guid));
                Assert.IsTrue(aCar.Owner.Equals(orig.Owner));
                Assert.IsTrue(aCar.Factory.Equals(orig.Factory));

                bool eqaul = Enumerable.SequenceEqual(orig.Friends, aCar.Friends);
                Assert.IsTrue(eqaul);
                
                Assert.IsTrue(aCar.Type.Equals(orig.Type));
            }
        }
    }
}
