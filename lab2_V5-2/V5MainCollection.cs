using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Nikolskiy_lab2;

namespace _12
{
    public struct V5MainCollection
    {
        private List<V5Data> list;
        IEnumerable<V5Data> Data;

        public IEnumerable<DataItem> DataItems
        {
            get
            {
                IEnumerable<DataItem> res;
                res = from data in list
                      from item in data.dataItems
                      orderby item.coordinate
                      select item;
                return res;
            }
        }

        float x1 = 1;
        float y1 = 1;
        int x2 = 5;
        int y2 = 5;

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
            V5DataCollection obj1;
            V5DataOnGrid obj2;
            int bin;
            list = new List<V5Data>();

            obj1 = new V5DataCollection("", DateTime.Now);
            obj1.InitRandom(0, 0, 0, 0, 0);
            list.Add(obj1);

            item = new Grid2D(0, 0, 0, 0);
            obj2 = new V5DataOnGrid("", DateTime.Now, item);
            obj2.InitRandom(0, 0);
            list.Add(obj2);

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

        public string ToLongString(string format)
        {
            string str = "";
            foreach (V5Data item in list)
            {
                str += item.ToString(format);
            }
            return str;
        }

        public float MaxDistance(Vector2 v)
        {
            var res = from data in list
                      from item in data.dataItems
                      select Vector2.Distance(v, item.coordinate);
            return res.Max();
        }

        public IEnumerable<DataItem> MaxDistanceItems(Vector2 v)
        {
            var res = from data in list
                      from item in data.dataItems
                      where Vector2.Distance(v, item.coordinate) == MaxDistance(v)
                      select item;
            return res;
        }

    }
}
