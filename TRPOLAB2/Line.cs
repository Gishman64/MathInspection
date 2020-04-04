using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPOLAB2
{
    class Line
    {
        private double k;
        private double b;
        private double a;
        private Point start, end;

        public Line(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
            double ax = end.getX() - start.getX();
            double ay = end.getY() - start.getY();
            this.B = -ay;
            this.A = ax;
            this.C = start.getX() * ay - start.getY() * ax;
        }

        public double A { get => k; set => k = value; }
        public double C { get => b; set => b = value; }
        public double B { get => a; set => a = value; }
        public Point Start { get => start; set => start = value; }
        public Point End { get => end; set => end = value; }

        public int pointPositionAboutLine(Point point)
        {
            double a1, a2, a3, a4;
            a1 = point.getX() - start.getX();
            a2 = end.getX() - start.getX();
            a3 = point.getY() - start.getY();
            a4 = end.getY() - start.getY();

            double b1, b2;
            if (a1 == 0 || a2 == 0)
            {
                b1 = 0;
            }
            else b1 = a1 / a2;

            if (a3 == 0 || a4 == 0)
            {
                b2 = 0;
            }
            else b2 = a3 / a4;

            double result = b1 - b2;

            if (result > 0)
            {
                return 2; // справа
            }
            else if (result < 0)
            {
                return 1; //слева
            }
            else if (result == 0) {
                return 0; //на линии
            }
            return -1; //error
        }
    }
}
