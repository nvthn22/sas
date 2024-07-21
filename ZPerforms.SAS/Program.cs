using BenchmarkDotNet.Running;
using ZPerforms.SAS.Public.Convert;
using ZPerforms.SAS.Public.Data;

BenchmarkRunner.Run<BMRandom>();
BenchmarkRunner.Run<BMConvert>();
