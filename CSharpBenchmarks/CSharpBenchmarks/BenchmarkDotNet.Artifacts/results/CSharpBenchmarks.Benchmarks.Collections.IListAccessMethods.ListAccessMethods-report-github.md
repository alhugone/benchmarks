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
| ForSumCacheArray | 2.564 s |    NA |  1.00 |
|           ForSum | 2.631 s |    NA |  1.03 |
|       ForEachSum | 4.856 s |    NA |  1.89 |
| LinqAggregateSum | 5.644 s |    NA |  2.20 |
|          LinqSum | 6.445 s |    NA |  2.51 |
|          LinqAll | 6.591 s |    NA |  2.57 |
|      FastLinqAll | 6.447 s |    NA |  2.51 |
|          LinqAny | 6.602 s |    NA |  2.58 |
|      FastLinqAny | 6.589 s |    NA |  2.57 |
