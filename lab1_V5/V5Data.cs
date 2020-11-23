using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;

namespace Nikolskiy_lab1
{
    abstract public class V5Data
    {
        public string info { get; set; }
        public DateTime date { get; set; }

        public V5Data(String x1, DateTime x2)
        {
            info = x1;
            date = x2;
        }

        public abstract Vector2[] NearEqual(float eps);
        public abstract string ToLongString();

        public override string ToString()
        {
            return info.ToString() + " " + date.ToString();
        }
    }
}
