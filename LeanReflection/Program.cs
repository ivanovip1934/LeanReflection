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

            Console.WriteLine("Анализ методов, определенных " +
                "в классе " + t.Name);
            Console.WriteLine();
            Console.WriteLine("Поддерживаемые методы: ");
            MethodInfo[] mi = t.GetMethods();

            // Вывести методы, поддерживаемые в классе MyClass.
            foreach (MethodInfo m in mi) {
                // Вывести возвращаемый тип и имя каждого метода.
                Console.Write(" " + m.ReturnType.Name + " " + m.Name + "(");

                // Вывести параметры.
                ParameterInfo[] pi = m.GetParameters();
                for (int i = 0; i < pi.Length; i++) {
                    Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);
                    if (i + 1 < pi.Length)
                        Console.Write(", ");
                }
                Console.WriteLine(")");

                Console.WriteLine();                

            }

            Console.ReadKey();
            
        }
    }
}
