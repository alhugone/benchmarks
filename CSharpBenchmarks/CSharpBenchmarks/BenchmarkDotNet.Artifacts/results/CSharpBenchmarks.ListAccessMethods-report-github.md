``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.706 (1803/April2018Update/Redstone4)
Intel Core i7-5820K CPU 3.30GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.105
  [Host]     : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT
  Job-CZKOFT : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT

Jit=RyuJit  Platform=X64  Server=True  

```
|        Method |     Mean |     Error |    StdDev | Ratio | RatioSD |
|-------------- |---------:|----------:|----------:|------:|--------:|
| ForCacheArray | 342.2 ms | 1.8579 ms | 1.7379 ms |  1.00 |    0.00 |
|           For | 341.9 ms | 1.5545 ms | 1.4540 ms |  1.00 |    0.01 |
|       ForEach | 613.5 ms | 2.3578 ms | 2.2054 ms |  1.79 |    0.01 |
| LinqAggregate | 707.1 ms | 5.1347 ms | 4.8030 ms |  2.07 |    0.02 |
|       LinqSum | 797.6 ms | 5.9377 ms | 5.2636 ms |  2.33 |    0.02 |
|       LinqAll | 775.7 ms | 1.7412 ms | 1.5436 ms |  2.27 |    0.01 |
|   FastLinqAll | 485.4 ms | 0.6999 ms | 0.5465 ms |  1.42 |    0.01 |
|       LinqAny | 794.9 ms | 4.4813 ms | 4.1918 ms |  2.32 |    0.02 |
|   FastLinqAny | 469.1 ms | 2.9600 ms | 2.7688 ms |  1.37 |    0.01 |
