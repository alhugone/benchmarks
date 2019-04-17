using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarks.Benchmarks.Collections.IListAccessMethods
{
    
    
    public class ListAccessMethods : IListAccessMethods<List<SomeClass>>
    {
        public ListAccessMethods() : base(new List<SomeClass>(CollectionTestsSettings.ArrayLength))
        {
        }
    }
}