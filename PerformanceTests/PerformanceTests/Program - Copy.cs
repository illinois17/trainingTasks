using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace PerformanceTests
{
    public class TestStrings
    {
        /*private string[] strMass;

        [Params(2, 100, 200)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            strMass = new string[N];
            new Random(42).Next().ToString();
        }*/

        string test1 = "test1";
        string test2 = "test2";
        string test3 = "test3";
        string test4 = "test4";
        string test5 = "test5";
        string test6 = "test6";
        string test7 = "test7";
        string test8 = "test8";
        string test9 = "test9";
        string test10 = "test10";
        string test11 = "test11";
        string test12 = "test12";
        string test13 = "test13";
        string test14 = "test14";
        string test15 = "test15";
        [Benchmark(Description = "string.Concat()")]
        public string TestStringConcat()
        {

            return string.Concat(test1, test2, test3, test4, test5, test6, test7, test8, test9, test10, test11, test12,
                test13, test14, test15);
        }
        
        [Benchmark(Description = "StringPlus")]
        public string TestConcatPlus()
        {

            return test1 + test2+ test3+ test4+ test5+ test6+ test7+ test8+ test9+ test10+ test11+ test12+
            test13+ test14+ test15;
        }

        [Benchmark(Description = "string.Format()")]
        public string TestStringFormat()
        {
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}", test1, test2, test3, test4, test5, test6, test7, test8, test9, test10, test11, test12,
                test13, test14, test15);
        }
        [Benchmark(Description = "StringInterpolation")]
        public string TestStringInterpolation()
        {

            return $"{test1}{test2}{test3}{test4}{test5}{test6}{test7}{test8}{test9}{test10}{test11}{test12}{test13}{test14}{test15}";
        }

        [Benchmark(Description = "StringBuilder")]
        public string TestStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(test1);
            sb.Append(test2);
            sb.Append(test3);
            sb.Append(test4);
            sb.Append(test5);
            sb.Append(test6);
            sb.Append(test7);
            sb.Append(test8);
            sb.Append(test9);
            sb.Append(test10);
            sb.Append(test11);
            sb.Append(test12);
            sb.Append(test13);
            sb.Append(test14);
            sb.Append(test15);

            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringsBenchBench>();
            Console.ReadLine();

        }
    }
}
