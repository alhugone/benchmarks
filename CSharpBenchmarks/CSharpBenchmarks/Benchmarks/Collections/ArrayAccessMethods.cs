using System.Linq;
using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarks
{
    
    
    public class ArrayAccessMethods
    {
        private readonly SomeClass[] _data = new SomeClass[CollectionTestsSettings.ArrayLength];

        [GlobalSetup]
        public void Setup()
        {
            for (var i = 0; i < _data.Length; i++)
            {
                var obj = new SomeClass(CollectionTestsSettings.ValueInit);
                _data[i] = obj;
            }
        }

        [Benchmark(Baseline = true)]
        public int ForSumCacheArray()
        {
            var sum = 0;
            var array = _data;
            for (var j = 0; j < CollectionTestsSettings.ArrayLoops; j++)
            for (var i = 0; i < array.Length; i++)
            {
                sum += array[i].Field;
            }

            return sum;
        }

        [Benchmark]
        public int ForSum()
        {
            var sum = 0;
            for (var j = 0; j < CollectionTestsSettings.ArrayLoops; j++)
            for (var i = 0; i < _data.Length; i++)
            {
                sum += _data[i].Field;
            }

            return sum;
        }

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