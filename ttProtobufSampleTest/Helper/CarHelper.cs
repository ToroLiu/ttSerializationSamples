using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttProtobufSampleTest
{
    using Models;

    public class CarHelper
    {
        private static string[] _name_map = new[] { 
            "Ashe", "Rammus", "Anny", "Ryze",
        };
        private const int _kFriendCount = 10;

        public static Car CreateCar() {
            Car aCar = new Car()
            {
                Owner = new Person()
                {
                    Id = 1,
                    Name = "Maya",
                },
                Factory = new Factory()
                {
                    Name = "Garena",
                },
            };

            Random r = new Random();
            List<Person> f = new List<Person>();
            for (int i = 0; i < _kFriendCount; ++i) {
                
                int idx = r.Next(_name_map.Count());
                f.Add(new Person { 
                    Id = i+1,
                    Name = _name_map[idx],
                });
            }
            aCar.Friends = f.ToArray();

            return aCar;
        }
    }
}
