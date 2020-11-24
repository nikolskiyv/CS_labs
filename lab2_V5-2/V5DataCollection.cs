using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace _12
{
    public class V5DataCollection : V5Data, IEnumerable<DataItem>
    {
        public Dictionary<System.Numerics.Vector2, System.Numerics.Vector2> elements { get; set; }

        public override List<DataItem> dataItems { get; set; }

        public V5DataCollection(string x1, DateTime x2) : base(x1, x2)
        {
            elements = new Dictionary<Vector2, Vector2>();
            dataItems = new List<DataItem>();
        }

        public V5DataCollection(string x1, DateTime x2, string filename) : base(x1, x2)
        {
            /* Данные хранятся в виде четырех столбцов "x y x_data y_data", где x и y - координаты, а x_data и y_data - значения поля в точке
               Разделители - пробелы */
            try
            {
                elements = new Dictionary<Vector2, Vector2>();
                dataItems = new List<DataItem>();

                DataItem tmp;

                using (StreamReader sr = new StreamReader(filename))
                {
                    string line, cop;
                    Vector2 key, value;
                    float x, y, x_data, y_data;
                    while ((line = sr.ReadLine()) != null)
                    {
                        cop = line;

                        string[] words = cop.Split(new char[] { ' ' });

                        x = float.Parse(words[0]);
                        y = float.Parse(words[1]);
                        x_data = float.Parse(words[2]);
                        y_data = float.Parse(words[3]);

                        key = new Vector2(x, y);
                        value = new Vector2(x_data, y_data);

                        elements.Add(key, value);

                        tmp = new DataItem(key, value);
                        dataItems.Add(tmp);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void InitRandom(int nItems, float xmax, float ymax, float minValue, float maxValue)
        {
            Random rand = new Random();

            float k1, k2, k3, k4, x, y, x_data, y_data;
            Vector2 key, value;

            DataItem tmp;

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

                tmp = new DataItem(key, value);
                dataItems.Add(tmp);
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

        public string ToLongString(string format)
        {
            string str = "V5DataCollection ";
            str += info + " " + date.ToString(format) + "\nNum of elements: " + elements.Count + "\n";
            foreach (KeyValuePair<Vector2, Vector2> kvp in elements)
            {
                str += kvp.Key + " " + kvp.Value.ToString(format) + "\n";
            }
            return str;
        }

        public IEnumerator<DataItem> GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            Vector2 val, coord;
            DataItem tmp;

            foreach (KeyValuePair<Vector2, Vector2> kvp in elements)
            {
                val = kvp.Value;
                coord = kvp.Key;
                tmp = new DataItem(coord, val);
                list.Add(tmp);
            }
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            Vector2 val, coord;
            DataItem tmp;

            foreach (KeyValuePair<Vector2, Vector2> kvp in elements)
            {
                val = kvp.Value;
                coord = kvp.Key;
                tmp = new DataItem(coord, val);
                list.Add(tmp);
            }
            return list.GetEnumerator();
        }
    }
}
