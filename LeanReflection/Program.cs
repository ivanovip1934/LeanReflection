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
            MyClass reflectOb = new MyClass(10, 20);
            int val;

            Console.WriteLine("Вызов методов, определенных в классе " + t.Name);
            Console.WriteLine();
            MethodInfo[] mi = t.GetMethods(BindingFlags.Public|BindingFlags.DeclaredOnly|BindingFlags.Instance);

            // Вывести методы, поддерживаемые в классе MyClass.
            foreach (MethodInfo m in mi) {
                
                // Получить параметры.
                ParameterInfo[] pi = m.GetParameters();

                if (m.Name.CompareTo("Set") == 0 && pi[0].ParameterType == typeof(int))
                {
                    object[] _args = new object[2];
                    _args[0] = 9;
                    _args[1] = 18;
                    m.Invoke(reflectOb, _args);
                }
                else if (m.Name.CompareTo("Set") == 0 && pi[0].ParameterType == typeof(double))
                {
                    object[] _args = new object[2];
                    _args[0] = 1.12;
                    _args[1] = 23.4;
                    m.Invoke(reflectOb, _args);
                }
                else if (m.Name.CompareTo("Sum") == 0)
                {
                    val = (int)m.Invoke(reflectOb, null);
                    Console.WriteLine($"Сумма равна {val}");
                }
                else if (m.Name.CompareTo("IsBetween") == 0)
                {
                    object[] _args = new object[1];
                    _args[0] = 14;
                    if ((bool)m.Invoke(reflectOb, _args))
                        Console.WriteLine("Значение 14 находится между x и у");
                }
                else if (m.Name.CompareTo("Show") == 0) {
                    m.Invoke(reflectOb, null);
                }

            }

            Console.ReadKey();
            
        }
    }
}
