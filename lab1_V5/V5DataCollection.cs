using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;

namespace Nikolskiy_lab1
{
    public class V5DataCollection : V5Data
    {
        public Dictionary<System.Numerics.Vector2, System.Numerics.Vector2> elements { get; set; }

        public V5DataCollection(string x1, DateTime x2) : base(x1, x2)
        {
            elements = new Dictionary<Vector2, Vector2>();
        }

        public void InitRandom(int nItems, float xmax, float ymax, float minValue, float maxValue)
        {
            Random rand = new Random();
            float k1, k2, k3, k4, x, y, x_data, y_data;
            Vector2 key, value;
            for (int i = 0; i < nItems; i++)
            {
                k1 = (float)rand.NextDouble();
                k2 = (float)rand.NextDouble();
                k3 = (float)rand.NextDouble();
                k4 = (float)rand.NextDouble();
                x_data = minValue * k1 + maxValue * (1 - k1);
                y_data = minValue * k2 + maxValue * (1 - k2);
                x = xmax * k3;
                y = ymax * k4;
                key = new Vector2(x, y);
                value = new Vector2(x_data, y_data);
                elements.Add(key, value);
            }
        }

        public override Vector2[] NearEqual(float eps)
        {
            List<Vector2> list = new List<Vector2>();
            foreach (KeyValuePair<Vector2, Vector2> kvp in elements)
            {
                Vector2 theElement = kvp.Value;
                if (Math.Abs(theElement.X - theElement.Y) <= eps)
                    list.Add(theElement);

            }
            Vector2[] array = list.ToArray();
            return array;
        }

        public override string ToString()
        {
            string str = "V5DataCollection ";
            str += info + " " + date.ToString() + "\nNum of elements: " + elements.Count + "\n";
            return str;
        }

        public override string ToLongString()
        {
            string str = "V5DataCollection ";
            str += info + " " + date.ToString() + "\nNum of elements: " + elements.Count + "\n";
            foreach (KeyValuePair<Vector2, Vector2> kvp in elements)
            {
                str += kvp.Key + " " + kvp.Value + "\n";
            }
            return str;
        }

    }
}
