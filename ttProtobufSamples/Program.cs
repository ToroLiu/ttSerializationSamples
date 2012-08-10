using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using ProtoBuf;
using System.Xml.Serialization;

namespace ttProtobufSamples
{
    using Models;

    class Program
    {
        static void Main(string[] args)
        {
            Car aCar = new Car()
            {
                CreatedTime = DateTime.Now,
                Guid = System.Guid.NewGuid().ToString(),
                Owner = new Person
                {
                    Id = 2,
                    Name = "HelloKitty",
                },
                Factory = new Factory
                {
                    Guid = System.Guid.NewGuid().ToString(),
                    Name = "Garena",
                },
            };

            List<Person> list = new List<Person>();
            for (int i = 0; i < 1000; i++) {
                list.Add(new Person() { 
                    Id = i,
                    Name = "Soraka" + i.ToString(),
                });
            }
            aCar.Friends = list.ToArray();

            using (FileStream stream = File.Create("car.bin"))
            {
                Serializer.Serialize<Car>(stream, aCar);
                stream.Position = 0;

                Car bCar = Serializer.Deserialize<Car>(stream);
                Console.Write(bCar.Owner.Name);
            }

            using (FileStream stream = File.Create("car.xml")) {
                XmlSerializer xml = new XmlSerializer(typeof(Car));
                xml.Serialize(stream, aCar);

                stream.Position = 0;
                Car bCar = (Car)xml.Deserialize(stream);
                Console.Write(bCar.Owner.Name);
            }

            

        }
    }
}
