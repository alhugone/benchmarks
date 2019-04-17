using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarks
{
    public class IEnumerableAccessMethods<T> where T : IEnumerable<SomeClass>
    {
        private readonly T _data;

        public IEnumerableAccessMethods(T data) => _data = data;

        private bool DumpOp(SomeClass cl) => cl.Field == CollectionTestsSettings.ValueInit;

        [Benchmark]
        public int ForEachSum()
        {
            var sum = 0;
            for (var j = 0; j < CollectionTestsSettings.ArrayLoops; j++)
            {
                foreach (var t in _data)
                {
                    sum += t.Field;
                }
            }

            return sum;
        }

        [Benchmark]
        public int LinqAggregateSum()
        {
            var sum = 0;
            for (var j = 0; j < CollectionTestsSettings.ArrayLoops; j++)
            {
                sum += _data.Aggregate(0, (current, t) => current + t.Field);
            }

            return sum;
        }

        [Benchmark]
        public int LinqSum()
        {
            var sum = 0;
            for (var j = 0; j < CollectionTestsSettings.ArrayLoops; j++)
            {
                sum += _data.Sum(x => x.Field);
            }

            return sum;
        }

        [Benchmark]
        public bool LinqAll()
        {
            var sum = false;
            for (var j = 0; j < CollectionTestsSettings.ArrayLoops; j++)
            {
                sum |= _data.All(x => x.Field == CollectionTestsSettings.ValueInit);
            }

            return sum;
        }

        [Benchmark]
        public bool LinqAny()
        {
            var sum = false;
            for (var j = 0; j < CollectionTestsSettings.ArrayLoops; j++)
            {
                sum |= _data.Any(x => x.Field != CollectionTestsSettings.ValueInit);
            }

            return sum;
        }
    }
}