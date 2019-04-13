``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.706 (1803/April2018Update/Redstone4)
Intel Core i7-5820K CPU 3.30GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.105
  [Host]     : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT
  Job-EFNYUQ : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT

Jit=RyuJit  Platform=X64  Server=True  

```
|        Method |      Mean |     Error |    StdDev | Ratio | RatioSD |
|-------------- |----------:|----------:|----------:|------:|--------:|
| FuncAndAction |  28.28 ms | 0.2364 ms | 0.1974 ms |  1.00 |    0.00 |
|    Reflection | 883.73 ms | 5.9813 ms | 4.6698 ms | 31.28 |    0.24 |
