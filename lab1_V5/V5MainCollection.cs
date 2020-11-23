using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;

namespace Nikolskiy_lab1
{
    class V5MainCollection : IEnumerable
    {
        private List<V5Data> list;
        IEnumerable<V5Data> Data;

        float x1 = 1, y1 = 1;
        int x2 = 5, y2 = 5;

        Grid2D item;

        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int Count()
        {
            return list.Count;
        }

        public void Add(V5Data item)
        {
            list.Add(item);
        }

        public bool Remove(string id, DateTime date)
        {
            bool f = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (String.Equals(list[i].info, id) == true && list[i].date.CompareTo(date) == 0)
                {
                    list.RemoveAt(i);
                    i--;
                    f = true;
                }
            }
            return f;
        }

        public void AddDefaults()
        {
            Random rnd = new Random();
            int NumOfElements = rnd.Next(3, 5), n;
            Grid2D item;
            V5Data obj;
            V5DataCollection obj1;
            V5DataOnGrid obj2;
            int bin;
            list = new List<V5Data>();
            for (int i = 0; i < NumOfElements; i++)
            {
                bin = rnd.Next(0, 2);
                item = new Grid2D(1, 1, 2, 2);
                if (bin == 0)
                {
                    obj2 = new V5DataOnGrid("", DateTime.Now, item);
                    obj2.InitRandom(1, 4);
                    list.Add(obj2);
                }
                else
                {
                    n = rnd.Next(1, 20);
                    obj1 = new V5DataCollection("", DateTime.Now);
                    obj1.InitRandom(n, 4, 5, 1, 4);
                    list.Add(obj1);
                }
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (V5Data item in list)
            {
                str += item.ToString();
            }
            return str;
        }


    }
}
