using System.Reflection;
using System.Text;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace CSharpBenchmarks
{
    public class Program
    {
        public static void Main()
        {
            CollectionTestsSettings.ArrayLength = 1024;
            CollectionTestsSettings.ArrayLoops = 60_000;
            BenchmarkRunner.Run(Assembly.GetExecutingAssembly() ,DefaultConfig.Instance.With(Encoding.UTF8
            ).With(new Job("ID", new GcMode
                {
                    Server = true
                }).WithGcServer(true)
                .WithInvocationCount(1)
                .WithIterationCount(1)
                .WithLaunchCount(1)
                .WithWarmupCount(1)
                .WithMinInvokeCount(1)
                .WithMinIterationCount(1)
                .WithMinWarmupCount(1)
                .WithMaxIterationCount(2)
                .WithMaxWarmupCount(2)
                .WithUnrollFactor(1)));
        }
    }
}