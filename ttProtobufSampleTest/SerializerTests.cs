using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtoBuf;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ttProtobufSampleTest
{
    using Models;

    [TestClass]
    public class SerializerTests
    {
        private const int _test_count = 10000;

        private void CheckEquality(Car orig, Car newCar) {
            Assert.IsTrue(newCar.Guid.Equals(orig.Guid));
            Assert.IsTrue(newCar.Owner.Equals(orig.Owner));
            Assert.IsTrue(newCar.Factory.Equals(orig.Factory));

            bool equal = false;

            Assert.IsTrue(newCar.Type.Equals(orig.Type));

            Assert.IsNotNull(orig.Friends);
            equal = Enumerable.SequenceEqual(orig.Friends, newCar.Friends);
            Assert.IsTrue(equal);

            Assert.IsNotNull(orig.Maintainers);
            equal = Enumerable.SequenceEqual(orig.Maintainers, newCar.Maintainers);
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestXML()
        {
            for (int i = 0; i < _test_count; ++i) {
                Car orig = CarHelper.CreateCar();
                using (MemoryStream stream = new MemoryStream())
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Car));
                    xml.Serialize(stream, orig);

                    stream.Position = 0;
                    Car aCar = (Car)xml.Deserialize(stream);

                    CheckEquality(orig, aCar);

                    stream.Close();
                }
            }
        }

        [TestMethod]
        public void TestProtoBuf() {

            for (int i = 0; i < _test_count; ++i) {
                Car orig = CarHelper.CreateCar();
                using (MemoryStream stream = new MemoryStream())
                {
                    Serializer.Serialize(stream, orig);

                    stream.Position = 0;
                    Car aCar = Serializer.Deserialize<Car>(stream);

                    CheckEquality(orig, aCar);

                    stream.Close();
                }
            }
        }

        [TestMethod]
        public void TestBinaryFormatter() {
            for (int i = 0; i < _test_count; ++i) {
                Car orig = CarHelper.CreateCar();
                using (MemoryStream stream = new MemoryStream()) {
                    BinaryFormatter binary = new BinaryFormatter();
                    binary.Serialize(stream, orig);

                    stream.Position = 0;
                    Car aCar = (Car)binary.Deserialize(stream);
                    CheckEquality(orig, aCar);

                    stream.Close();
                }
            }
        }
    }
}
