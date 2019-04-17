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
|        Method |        Mean | Error | Ratio |
|-------------- |------------:|------:|------:|
| FuncAndAction |    302.4 ms |    NA |  1.00 |
|    Reflection | 10,787.2 ms |    NA | 35.68 |
