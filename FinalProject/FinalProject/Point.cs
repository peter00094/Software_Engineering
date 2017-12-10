using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    //store a information of a point, which contain a value of x and y
    public class Point
    {
        private int x, y;

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(int newX, int newY)
        {
            x = newX;
            y = newY;
        }

        public int Getx() { return x; }
        public void Setx(int newx) { x = newx; }
        public int Gety() { return y; }
        public void Sety(int newy) { y = newy; }
    }
}
