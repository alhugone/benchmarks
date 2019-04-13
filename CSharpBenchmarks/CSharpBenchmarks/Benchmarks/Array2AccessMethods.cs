using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarks
{
    [GcServer(true)]
    [RyuJitX64Job]
    [PlainExporter]
    public class Array2AccessMethods : IListAccessMethods<SomeClass[]>
    {
        public Array2AccessMethods() : base(new SomeClass[Shared.ArrayLength])
        {
        }
    }
}