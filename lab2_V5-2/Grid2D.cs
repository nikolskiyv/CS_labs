using System;

namespace Nikolskiy_lab2
{
    public struct Grid2D
    {
        public float step_x { get; set; }
        public int num_of_nodes_x { get; set; }
        public float step_y { get; set; }
        public int num_of_nodes_y { get; set; }

        public Grid2D(float x1 = 1, float y1 = 1, int x2 = 5, int y2 = 5)
        {
            step_x = x1;
            step_y = y1;
            num_of_nodes_x = x2;
            num_of_nodes_y = y2;
        }

        public override string ToString()
        {
            return "\nStep x: " + step_x.ToString() + " Num of nodes x: " + num_of_nodes_x.ToString() +
                " Step y: " +
                step_y.ToString() + " Num of nodes y: " + num_of_nodes_y.ToString();
        }

        public string ToString(string format)
        {
            return "\nStep x: " + step_x.ToString(format) + " Num of nodes x: " + num_of_nodes_x.ToString(format) +
                " Step y: " +
                step_y.ToString(format) + " Num of nodes y: " + num_of_nodes_y.ToString(format);
        }
    }
}
