using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarks
{
    [GcServer(true)]
    [RyuJitX64Job]
    [PlainExporter]
    public class ArrayAccessMethods
    {
        private readonly SomeClass[] _data = new SomeClass[Shared.ArrayLength];
        private readonly List<SomeClass> _data2 = new List<SomeClass>(Shared.ArrayLength);

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < _data.Length; i++)
            {
                var obj=new SomeClass() { Field = Shared.ValueInit };
                _data[i] = obj;
                _data2.Add(obj);
            }
        }

        [Benchmark(Baseline = true)]
        public int ForCacheArray()
        {
            var sum = 0;
            var array = _data;
            for (var j = 0; j < Shared.ArrayLoops; j++)
            for (var i = 0; i < array.Length; i++)
            {
                sum += array[i].Field;
            }

            return sum;
        }

        [Benchmark]
        public int ForCacheArray2()
        {
            var sum = 0;
            var array = _data2;
            for (var j = 0; j < Shared.ArrayLoops; j++)
            for (var i = 0; i < array.Count; i++)
            {
                sum += array[i].Field;
            }

            return sum;
        }

        [Benchmark]
        public int For()
        {
            var sum = 0;
            for (var j = 0; j < Shared.ArrayLoops; j++)
            for (var i = 0; i < _data.Length; i++)
            {
                sum += _data[i].Field;
            }

            return sum;
        }

        [Benchmark]
        public int For2()
        {
            var sum = 0;
            for (var j = 0; j < Shared.ArrayLoops; j++)
            for (var i = 0; i < _data2.Count; i++)
            {
                sum += _data2[i].Field;
            }

            return sum;
        }

        [Benchmark]
        public int ForEach()
        {
            var sum = 0;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                foreach (var t in _data)
                {
                    sum += t.Field;
                }

            return sum;
        }

        [Benchmark]
        public int ForEach2()
        {
            var sum = 0;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                foreach (var t in _data2)
                {
                    sum += t.Field;
                }

            return sum;
        }

        [Benchmark]
        public int LinqAggregate()
        {
            var sum = 0;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum += _data.Aggregate(0, (current, t) => current + t.Field);
            return sum;
        }

        [Benchmark]
        public int LinqAggregate2()
        {
            var sum = 0;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum += _data2.Aggregate(0, (current, t) => current + t.Field);
            return sum;
        }

        [Benchmark]
        public int LinqSum()
        {
            var sum = 0;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum += _data.Sum(x => x.Field);
            return sum;
        }

        [Benchmark]
        public int LinqSum2()
        {
            var sum = 0;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum += _data2.Sum(x => x.Field);
            return sum;
        }

        [Benchmark]
        public bool LinqAll()
        {
            var sum = false;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum |= _data.All(x => x.Field == Shared.ValueInit);
            return sum;
        }

        [Benchmark]
        public bool LinqAll2()
        {
            var sum = false;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum |= _data2.All(x => x.Field == Shared.ValueInit);
            return sum;
        }

        [Benchmark]
        public bool LinqAny()
        {
            var sum = false;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum |= _data.Any(x => x.Field != Shared.ValueInit);
            return sum;
        }

        [Benchmark]
        public bool LinqAny2()
        {
            var sum = false;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum |= _data2.Any(x => x.Field != Shared.ValueInit);
            return sum;
        }
    }
}