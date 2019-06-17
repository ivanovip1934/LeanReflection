using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanReflection
{
    class MyClass
    {
        int x;
        int y;

        public MyClass(int i, int j) {
            x = i;
            y = j;
        }

        public int Sum() {
            return x + y;
        }

        public bool IsBetween(int i) {
            if (x < i && i < y) return true;
            else return false;
        }

        public void Set(int a, int b) {
            x = a;
            y = b;
        }

        public void Set(double a, double b) {
            x = (int)a;
            y = (int)b;
        }

        public void Show() {
            Console.WriteLine($"x: {x}, y: {y}");
        }


    }

    
}
