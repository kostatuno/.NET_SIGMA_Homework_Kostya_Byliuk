``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19045.2251)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|      Method |     Mean |    Error |   StdDev |   Median | Rank |   Gen0 | Allocated |
|------------ |---------:|---------:|---------:|---------:|-----:|-------:|----------:|
| RandomPivot | 753.2 ns | 26.46 ns | 76.77 ns | 739.1 ns |    3 | 0.0172 |      72 B |
|  FirstPivot | 706.4 ns | 14.34 ns | 40.22 ns | 687.6 ns |    2 |      - |         - |
|   LastPivot | 789.3 ns |  8.48 ns |  7.93 ns | 787.3 ns |    4 |      - |         - |
| MiddlePivot | 383.8 ns |  6.35 ns |  5.94 ns | 382.0 ns |    1 |      - |         - |
