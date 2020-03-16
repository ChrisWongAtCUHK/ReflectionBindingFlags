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
            var method = instance.GetType().GetTypeInfo().GetMethod("PrivateMethod", BindingFlags.Public | BindingFlags.NonPublic |
                                                    BindingFlags.Instance |
                                                    BindingFlags.Static);
            method.Invoke(instance, new object[] {});
        }
    }
}
