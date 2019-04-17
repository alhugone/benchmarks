using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarks
{
    
    
    public class ListAccessMethods
    {
        private readonly List<SomeClass> _data = new List<SomeClass>(CollectionTestsSettings.ArrayLength);

        [GlobalSetup]
        public void Setup()
        {
            for (var i = 0; i < CollectionTestsSettings.ArrayLength; i++)
            {
                _data.Add(new SomeClass(CollectionTestsSettings.ValueInit));
            }
        }

        [Benchmark(Baseline = true)]
        public int ForSumCache()
        {
            var sum = 0;
            var array = _data;
            for (var j = 0; j < CollectionTestsSettings.ArrayLoops; j++)
            for (var i = 0; i < array.Count; i++)
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
            for (var i = 0; i < _data.Count; i++)
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