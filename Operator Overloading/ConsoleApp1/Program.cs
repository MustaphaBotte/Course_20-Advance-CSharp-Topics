namespace ConsoleApp1
{
    class Point
    {
        int X, Y;
        public Point(int X,int Y)
        {
            this.X = X;
            this.Y = Y;            
        }
        public static Point operator + (Point p1,Point p2)
        {
            return new Point(p1.X + p2.X, p2.Y+p1.Y);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p2.Y - p1.Y);
        }   
        public static bool operator == (Point p1, Point p2)
        {          
            return p1.X == p2.X && p2.Y == p1.Y;
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return p1.X != p2.X && p2.Y != p1.Y;
        }
        public static bool operator >(Point p1, Point p2)
        {
            return p1.X > p2.X && p1.Y> p2.Y ;
        }
        public static bool operator <(Point p1, Point p2)
        {
            return p1.X < p2.X && p1.Y < p2.Y;
        }
        public static bool operator true(Point p1)
        {
            return p1.X != 0 || p1.X != 0;
        }
        public static bool operator false(Point p1)
        {
            return p1.X == 0 && p1.Y == 0;
        }
        public static implicit operator double(Point p1)
        {
            return  Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y);
        }
        public static explicit operator Point(double d)
        {
            return new Point((int)d, (int)d);
        }
        public int this[int index]
        {
            get { return index == 0 ? X : Y; }
            set { if (index == 0)
                {
                    this.X = value;
                }
                else if (index == 1)
                    this.Y = value;
                } 
        }
        public override string ToString()
        {
            return $"X ={this.X} Y={this.Y}";
        }
    }
 
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(10, 20);
            Point point2 = new Point(30, 40);
            Console.WriteLine(point1 == point2);
            Console.WriteLine(point1 != point2);
            Console.WriteLine((point1+point2).ToString());
            Console.WriteLine((point1 - point2).ToString());
            //This code defines a Point class to represent 2D points and
            //demonstrates operator overloading in C# by overloading the +, -, ==, and != operators.

            double d = point1;
            Point p = (Point)d;
            Console.WriteLine(p.ToString());
            Console.WriteLine(d.ToString());

            point1[0] = 100;
            Console.WriteLine(point1[0]);
        }
    }
}
