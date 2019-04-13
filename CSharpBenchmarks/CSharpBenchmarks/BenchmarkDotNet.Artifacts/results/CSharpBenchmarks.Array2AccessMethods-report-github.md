``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.706 (1803/April2018Update/Redstone4)
Intel Core i7-5820K CPU 3.30GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.105
  [Host]     : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT
  Job-EFNYUQ : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT

Jit=RyuJit  Platform=X64  Server=True  

```
|        Method |     Mean |    Error |   StdDev | Ratio | RatioSD |
|-------------- |---------:|---------:|---------:|------:|--------:|
| ForCacheArray | 451.3 ms | 3.295 ms | 3.083 ms |  1.00 |    0.00 |
|           For | 449.6 ms | 2.171 ms | 1.924 ms |  1.00 |    0.01 |
|       ForEach | 384.0 ms | 4.523 ms | 4.231 ms |  0.85 |    0.01 |
| LinqAggregate | 477.0 ms | 7.807 ms | 6.920 ms |  1.06 |    0.02 |
|       LinqSum | 521.6 ms | 5.052 ms | 4.725 ms |  1.16 |    0.01 |
|       LinqAll | 538.8 ms | 2.262 ms | 2.116 ms |  1.19 |    0.01 |
|       LinqAny | 541.3 ms | 1.262 ms | 1.118 ms |  1.20 |    0.01 |
