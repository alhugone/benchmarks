using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarks
{
    public class IListAccessMethods<T> where T: IList<SomeClass>
    {



        private readonly T _data;

        public IListAccessMethods(T data)
        {
            _data = data;
            for (int i = 0; i < Shared.ArrayLength; i++)
            {
                if (_data is SomeClass[])
                {
                    _data[i] = new SomeClass() {Field = Shared.ValueInit};
                }
                else
                {
                    _data.Add(new SomeClass() {Field = Shared.ValueInit});
                }
            }

        }

        [GlobalSetup]
        public void Setup()
        {

        }


        bool DumpOp(SomeClass cl)
        {
            return cl.Field == Shared.ValueInit;
        }

        [Benchmark(Baseline = true)]
        public int ForCacheArray()
        {
            var sum = 0;
            var array = _data;
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
                for (var i = 0; i < _data.Count; i++)
                {
                    sum += _data[i].Field;
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
        public int LinqAggregate()
        {
            var sum = 0;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum += _data.Aggregate(0, (current, t) => current + t.Field);
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
        public bool LinqAll()
        {
            var sum = false;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum |= Enumerable.All(_data, x => x.Field == Shared.ValueInit);
            return sum;
        }

        [Benchmark]
        public bool FastLinqAll()
        {
            var sum = false;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum |= _data.All(x => x.Field == Shared.ValueInit);
            return sum;
        }

        [Benchmark]
        public bool LinqAny()
        {
            var sum = false;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum |= Enumerable.Any(_data,x => x.Field != Shared.ValueInit);
            return sum;
        }

        [Benchmark]
        public bool FastLinqAny()
        {
            var sum = false;
            for (var j = 0; j < Shared.ArrayLoops; j++)
                sum |= _data.Any(x => x.Field != Shared.ValueInit);
            return sum;
        }
    }
}