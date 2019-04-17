using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarks
{
    
    
    public class ArrayUnderIListAccessMethods : IListAccessMethods<SomeClass[]>
    {
        public ArrayUnderIListAccessMethods() : base(new SomeClass[CollectionTestsSettings.ArrayLength])
        {
        }
    }
}