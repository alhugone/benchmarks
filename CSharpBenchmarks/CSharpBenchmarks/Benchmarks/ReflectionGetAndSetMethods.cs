using System;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace CSharpBenchmarks
{
    [GcServer(true)]
    [RyuJitX64Job]
    public class ReflectionGetAndSetMethods
    {
        private class TestClass
        {
            public object Field;
        }

        private const int ArrayLoops = 6000_000;
        private FieldInfo _field;
        private TestClass _obj;
        private Action<TestClass, object> _setValue;
        private Func<TestClass, object> _getValue;

        [GlobalSetup]
        public void Setup()
        {
            _obj=new TestClass(){Field = 1 };
            _field= typeof(TestClass).GetField(nameof(TestClass.Field));
            _getValue = (x) => x.Field;
            _setValue = (x, y) => x.Field = y;
        }

        [Benchmark(Baseline = true)]
        public object FuncAndAction()
        {
            object last = null;
            object _ref = new object();
            for (var j = 0; j < ArrayLoops; j++)
            {
                _setValue(_obj, _ref);
                last = _getValue(_obj);
            }
            return last;
        }

        [Benchmark]
        public object Reflection()
        {
            object last = null;
            object _ref = new object();
            for(var j=0;j< ArrayLoops;j++)
            {
                _field.SetValue(_obj, _ref);
                last= _field.GetValue(_obj);
            }
            return last;
        }
    }
}