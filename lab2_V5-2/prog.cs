using System;
using System.Numerics;

namespace _12
{
    class prog
    {
        public static int Main()
        {
            Console.WriteLine("START\n");

            V5DataCollection obj1 = new V5DataCollection("", DateTime.Now, "file.txt");
            Console.WriteLine(obj1.ToLongString("e3"));

            V5MainCollection obj2 = new V5MainCollection();
            obj2.AddDefaults();
            Console.WriteLine(obj2.ToString());

            Vector2 point;
            point.X = 1;
            point.Y = 1;

            Console.WriteLine("MaxDistance");
            Console.WriteLine(obj2.MaxDistance(point).ToString("e3"));

            Console.WriteLine("MaxDistanceItem");
            foreach (DataItem s1 in obj2.MaxDistanceItems(point))
                Console.WriteLine(s1.ToString("e3"));

            Console.WriteLine("DataItems");
            foreach (DataItem s2 in obj2.DataItems)
                Console.WriteLine(s2.ToString());
            return 0;
        }
    }
}
