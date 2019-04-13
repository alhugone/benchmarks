``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.706 (1803/April2018Update/Redstone4)
Intel Core i7-5820K CPU 3.30GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.105
  [Host]     : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT
  Job-EFNYUQ : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT

Jit=RyuJit  Platform=X64  Server=True  

```
|         Method |      Mean |      Error |     StdDev | Ratio | RatioSD |
|--------------- |----------:|-----------:|-----------:|------:|--------:|
|  ForCacheArray |  27.42 ms |  0.1430 ms |  0.1268 ms |  1.00 |    0.00 |
| ForCacheArray2 |  45.02 ms |  0.2463 ms |  0.2057 ms |  1.64 |    0.01 |
|            For |  40.99 ms |  0.1739 ms |  0.1627 ms |  1.50 |    0.01 |
|           For2 |  85.13 ms |  0.3215 ms |  0.3007 ms |  3.11 |    0.02 |
|        ForEach |  27.83 ms |  0.0638 ms |  0.0533 ms |  1.02 |    0.01 |
|       ForEach2 | 235.56 ms |  2.6375 ms |  2.4671 ms |  8.60 |    0.09 |
|  LinqAggregate | 445.13 ms |  2.1853 ms |  2.0441 ms | 16.24 |    0.12 |
| LinqAggregate2 | 703.38 ms |  3.2092 ms |  3.0019 ms | 25.66 |    0.17 |
|        LinqSum | 524.64 ms |  3.7393 ms |  3.4978 ms | 19.14 |    0.11 |
|       LinqSum2 | 787.38 ms | 22.6406 ms | 21.1780 ms | 28.75 |    0.76 |
|        LinqAll | 534.50 ms |  1.4414 ms |  1.2036 ms | 19.50 |    0.11 |
|       LinqAll2 | 773.57 ms |  1.1433 ms |  0.9547 ms | 28.22 |    0.15 |
|        LinqAny | 537.10 ms |  2.6773 ms |  2.5044 ms | 19.59 |    0.12 |
|       LinqAny2 | 797.36 ms |  8.4435 ms |  7.8981 ms | 29.10 |    0.26 |
