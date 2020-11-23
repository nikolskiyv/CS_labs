using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;

namespace Nikolskiy_lab1
{
    class prog
    {
        public static int Main()
        {
            Console.WriteLine("TASK 1\n\n");
            Grid2D item = new Grid2D(1, 1, 2, 2);
            V5DataOnGrid obj = new V5DataOnGrid("", DateTime.Now, item);
            obj.InitRandom(1, 5);
            Console.WriteLine(obj.ToLongString());
            V5DataCollection obj1 = (V5DataCollection)obj;
            Console.WriteLine(obj1.ToLongString());

            Console.WriteLine("TASK 2\n\n");
            V5MainCollection obj2 = new V5MainCollection();
            obj2.AddDefaults();
            Console.WriteLine(obj2.ToString());
            Console.WriteLine("TASK 3\n\n");
            Vector2[] array;
            foreach (V5Data ob in obj2)
            {
                array = ob.NearEqual(2);
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i].X + " " + array[i].Y + "\n");
                }
            }
            Console.WriteLine(obj2.ToString());
            return 0;
        }
    }
}
