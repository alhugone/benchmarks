using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarks
{
    [GcServer(true)]
    [RyuJitX64Job]
    [PlainExporter]
    public class ListAccessMethods : IListAccessMethods<List<SomeClass>>
    {
        public ListAccessMethods() : base(new List<SomeClass>(Shared.ArrayLength))
        {
        }
    }
}