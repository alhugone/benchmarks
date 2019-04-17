``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.706 (1803/April2018Update/Redstone4)
Intel Core i7-5820K CPU 3.30GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.105
  [Host] : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT
  ID     : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT

Job=ID  MinInvokeCount=1  Server=True  
InvocationCount=1  IterationCount=1  LaunchCount=1  
MaxIterationCount=2  MaxWarmupIterationCount=2  MinIterationCount=1  
MinWarmupIterationCount=1  UnrollFactor=1  WarmupCount=1  

```
|           Method |    Mean | Error | Ratio |
|----------------- |--------:|------:|------:|
| ForSumCacheArray | 3.702 s |    NA |  1.00 |
|           ForSum | 3.722 s |    NA |  1.01 |
|       ForEachSum | 2.730 s |    NA |  0.74 |
| LinqAggregateSum | 3.526 s |    NA |  0.95 |
|          LinqSum | 4.332 s |    NA |  1.17 |
|          LinqAll | 4.245 s |    NA |  1.15 |
|      FastLinqAll | 4.249 s |    NA |  1.15 |
|          LinqAny | 4.261 s |    NA |  1.15 |
|      FastLinqAny | 4.259 s |    NA |  1.15 |
