using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Nikolskiy_lab2;

namespace _12
{
    public class V5DataOnGrid : V5Data, IEnumerable<DataItem>
    {
        public Grid2D grid { get; set; }
        public Vector2[,] value_in_nodes { get; set; }

        public override List<DataItem> dataItems { get; set; }

        public V5DataOnGrid(string x1, DateTime x2, Grid2D x3) : base(x1, x2)
        {
            grid = x3;
            value_in_nodes = new Vector2[grid.num_of_nodes_x, grid.num_of_nodes_y];
            dataItems = new List<DataItem>();

        }

        public void InitRandom(float minValue, float maxValue)
        {
            Random rand = new Random();
            float k1, k2, x, y;
            Vector2 coord, val;
            DataItem tmp;

            dataItems = new List<DataItem>();

            for (int i = 0; i < grid.num_of_nodes_x; i++)
                for (int j = 0; j < grid.num_of_nodes_y; j++)
                {
                    k1 = (float)rand.NextDouble();
                    k2 = (float)rand.NextDouble();
                    x = minValue * k1 + maxValue * (1 - k1);
                    y = minValue * k2 + maxValue * (1 - k2);

                    coord.X = i;
                    coord.Y = j;
                    val.X = x;
                    val.Y = y;
                    tmp = new DataItem(coord, val);

                    value_in_nodes[i, j] = new Vector2(x, y);
                    dataItems.Add(tmp);

                }
        }

        public override Vector2[] NearEqual(float eps)
        {
            List<Vector2> list = new List<Vector2>();
            for (int i = 0; i < grid.num_of_nodes_x; i++)
                for (int j = 0; j < grid.num_of_nodes_y; j++)
                    if (Math.Abs(value_in_nodes[i, j].X - value_in_nodes[i, j].Y) <= eps)
                        list.Add(value_in_nodes[i, j]);
            Vector2[] array = list.ToArray();
            return array;
        }

        public static explicit operator V5DataCollection(V5DataOnGrid x)
        {
            int i, j;
            Vector2 key, value;
            V5DataCollection Result;
            Result = new V5DataCollection(x.info, x.date);
            for (i = 0; i < x.grid.num_of_nodes_x; i++)
                for (j = 0; j < x.grid.num_of_nodes_y; j++)
                {
                    key = new Vector2(i, j);
                    value = new Vector2(x.value_in_nodes[i, j].X, x.value_in_nodes[i, j].Y);
                    Result.elements.Add(key, value);
                }
            return Result;
        }

        public override string ToString()
        {
            string str = "V5DataOnGrid ";
            str += info + " " + date.ToString() + " " + grid.ToString() + "\n";
            return str;
        }

        public override string ToLongString()
        {
            string str = "V5DataOnGrid ";
            str += info + " " + date.ToString() + " " + grid.ToString() + "\n";
            for (int i = 0; i < grid.num_of_nodes_x; i++)
                for (int j = 0; j < grid.num_of_nodes_y; j++)
                {
                    str += "[" + i + "," + j + "] " + "(" + value_in_nodes[i, j].X + "," + value_in_nodes[i, j].Y + ")\n";
                }

            return str;
        }

        public string ToLongString(string format)
        {
            string str = "V5DataOnGrid ";
            str += info + " " + date.ToString(format) + " " + grid.ToString(format) + "\n";
            for (int i = 0; i < grid.num_of_nodes_x; i++)
                for (int j = 0; j < grid.num_of_nodes_y; j++)
                {
                    str += "[" + i + "," + j + "] " + "(" + value_in_nodes[i, j].X.ToString(format) + "," + value_in_nodes[i, j].Y.ToString(format) + ")\n";
                }

            return str;
        }

        public IEnumerator<DataItem> GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            DataItem tmp;
            Vector2 coordinate, value;
            for (int i = 0; i < grid.num_of_nodes_x; i++)
                for (int j = 0; j < grid.num_of_nodes_y; j++)
                {
                    coordinate.X = i;
                    coordinate.Y = j;
                    value.X = value_in_nodes[i, j].X;
                    value.Y = value_in_nodes[i, j].Y;
                    tmp = new DataItem(coordinate, value);
                    list.Add(tmp);
                }
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            DataItem tmp;
            Vector2 coordinate, value;
            for (int i = 0; i < grid.num_of_nodes_x; i++)
                for (int j = 0; j < grid.num_of_nodes_y; j++)
                {
                    coordinate.X = i;
                    coordinate.Y = j;
                    value.X = value_in_nodes[i, j].X;
                    value.Y = value_in_nodes[i, j].Y;
                    tmp = new DataItem(coordinate, value);
                    list.Add(tmp);
                }
            return list.GetEnumerator();
        }
    }
}
