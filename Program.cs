using System;
using System.Reflection;

namespace ReflectionBindingFlags
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("ReflectionBindingFlags.PrivateMethodClass");
            PrivateMethodClass instance = (PrivateMethodClass)Activator.CreateInstance(type);
            try {
                var method = instance.GetType().GetTypeInfo().GetMethod("PrivateMethod", BindingFlags.NonPublic | 
                                                    BindingFlags.Public |
                                                    BindingFlags.Instance |
                                                    BindingFlags.Static);
                method.Invoke(instance, new object[] {});
            } catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
