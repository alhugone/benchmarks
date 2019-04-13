using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Running;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpBenchmarks
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<ListAccessMethods>();
            //BenchmarkRunner.Run<Array2AccessMethods>();
            //BenchmarkRunner.Run(Assembly.GetExecutingAssembly());
        }
    }

    public static class FastLinq
    {
        public static bool All<T>(this IList<T> list, Func<T, bool> func)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (!func(list[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<T>(this IList<T> list, Func<T, bool> func)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (func(list[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}