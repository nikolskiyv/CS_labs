using System;
using System.Collections.Generic;
using System.Numerics;
using Nikolskiy_lab2;

namespace _12
{
    abstract public class V5Data
    {
        public string info { get; set; }
        public DateTime date { get; set; }

        public abstract List<DataItem> dataItems { get; set; }

        public V5Data(String x1, DateTime x2)
        {
            info = x1;
            date = x2;
            dataItems = new List<DataItem>();
        }

        public abstract Vector2[] NearEqual(float eps);
        public abstract string ToLongString();

        public override string ToString()
        {
            return info.ToString() + " " + date.ToString();
        }

        public virtual string ToString(string format)
        {
            return info.ToString() + " " + date.ToString(format);
        }
    }
}
