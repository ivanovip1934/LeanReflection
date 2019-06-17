using System;
using System.Reflection;

namespace LeanReflection
{
   
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Type t = typeof(MyClass);
            int val;

            // Получить сведения о конструкторе.
            ConstructorInfo[] ci = t.GetConstructors();

            Console.WriteLine("Доступные конструкторы: ");
            foreach (ConstructorInfo c in ci)
            {
                // Вывести возвращаемый тип и имя.
                Console.Write(" " + t.Name + "(");

                // Вывести параметры.
                ParameterInfo[] pi = c.GetParameters();

                for (int i = 0; i < pi.Length; i++) {
                    Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);
                    if (i + 1 < pi.Length)
                        Console.Write(", ");
                }

                Console.WriteLine(")");
            }

            Console.WriteLine();

            // Найти подходящий констуктор.
            int x;
            for (x = 0; x < ci.Length; x++)
            {
                ParameterInfo[] pi = ci[x].GetParameters();
                if (pi.Length == 2)
                    break;
            }

            if (x == ci.Length)
            {
                Console.WriteLine("Подходящий конструктор не найден.");
                return;
            }
            else
                Console.WriteLine("Найден конструктор с двумя параметрами.\n");

            // Сконструировать объект.
            object[] consargs = new object[2];
            consargs[0] = 10;
            consargs[1] = 20;
            object reflectOb = ci[x].Invoke(consargs);

            Console.WriteLine("\nВызов методов для объекта reflectOb.");
            Console.WriteLine();
          

            Console.ReadKey();
            
        }
    }
}
