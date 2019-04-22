using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 11, 11, 33, 9534, 2123, 43, 23, 784, 45, 1234, 5, 753, -123, 2 };
            string[] words = { "1qwe", "sfsd", "se5s", "adqs3", "Aaaa", "Bbbbb", "1qweqw", "sdsa12", "sfsd", "dsf" };
            int number = 5;
            int number2 = 10;
            int digit = -2;
            char C = 's';
            //1
            var query1   = numbers.First(f => f > 0);
            var query1_1 = numbers.Last(f => f < 0);
            Console.WriteLine("LinqBegin1: "+query1);
            Console.WriteLine("LinqBegin1: " + query1_1);

            //2
            var query2 = numbers.FirstOrDefault(n => n >= 0 && n.ToString().EndsWith(number.ToString()));
            Console.WriteLine("LinqBegin2: " + query2);
            //3
            var query3 = words.Where(n => Char.IsDigit(n, 0) && n.Length == number).LastOrDefault() ?? "Not Found";
            Console.WriteLine("LinqBegin3: " + query3);
            //4
            try
            {
                var query4 = words.Where(n => n.EndsWith(C.ToString())).SingleOrDefault();
                Console.WriteLine("LinqBegin4: " + query4);
            }
            catch (Exception)
            {
                Console.WriteLine("LinqBegin4: " + "Error");
            }
            //5
            var query5 = words.Where(n => n.Length > 1 && n.StartsWith(C.ToString()) && n.EndsWith(C.ToString())).Count();
            Console.WriteLine("LinqBegin5: " + query5);
            //6
            var query6 = words.Sum(n => n.Length);
            Console.WriteLine("LinqBegin6: " + query6);
            //7
            var query7 = numbers.Where(n => n < 0).Sum();
            var query7_2 = numbers.Where(n => n < 0).Count();
            Console.WriteLine("LinqBegin7: " + query7);
            Console.WriteLine("LinqBegin7: " + query7_2);
            //8
            var query8 = numbers.Where(n => n >= 10 && n < 100).Count();
            var query8_1 = numbers.Where(n => n >= 10 && n < 100).Average();
            Console.WriteLine("LinqBegin8: " + query8);
            Console.WriteLine("LinqBegin8: " + query8_1);
            //9
            var query9 = numbers.Where(n => n >= 0).Min();
            Console.WriteLine("LinqBegin9: " + query9);
            //10
            var query10 = words.Select(n => n.ToUpper()).Where(n => n.Length == number).Max();
            Console.WriteLine("LinqBegin10: " + query10);
            //11
            var query11 = words.Select(n => n.First().ToString()).Aggregate((a, b) => a + b);
            Console.WriteLine("LinqBegin11: " + query11);
            //12
            var query12 = numbers.Select<int, long>(n => (n % 10)).Aggregate<long>((a, b) => a * b);
            Console.WriteLine("LinqBegin12: " + query12);
            //13
            var query13 = Enumerable.Range(1, number).Select<int, float>(n => 1.0f / n).Sum();
            Console.WriteLine("LinqBegin13: " + query13);
            //16
            var query16 = numbers.Where(n => n >= 0);
            Console.WriteLine("LinqBegin16");
            foreach (var num in query16) Console.Write(num + " | ");
            Console.WriteLine();
            //17
            var query17 = numbers.Where(n => n % 2 != 0).Distinct();
            Console.WriteLine("LinqBegin17");
            foreach (var num in query17) Console.Write(num + " | ");
            Console.WriteLine();
            //18
            var query18 = numbers.Where(n => n % 2 == 0).Reverse();
            Console.WriteLine("LinqBegin18");
            foreach (var num in query18) Console.Write(num + " | ");
            Console.WriteLine();
            //19
            Console.WriteLine("LinqBegin19");
            var query19 = numbers.Where(n => n % 10 == digit).Reverse().Distinct().Reverse();
            foreach (var num in query19) Console.Write(num + " | ");
            //20
            var query20 = numbers.Where(n => n >= 10 && n < 100).OrderBy(n => n);
            Console.WriteLine("LinqBegin20");
            foreach (var num in query20) Console.Write(num + " | ");
            Console.WriteLine();

            //21
            var query21 = words.Select(n => n.ToUpper()).OrderBy(n => n.Length).ThenByDescending(n => n);
            Console.WriteLine("LinqBegin21");
            foreach (var word in query21) Console.Write(word + " | ");
            Console.WriteLine();

            //22
            var query22 = words.Select(n => n.ToUpper()).Where(n => n.Length == number && Char.IsDigit(n, n.Length - 1)).OrderBy(n => n);
            Console.WriteLine("LinqBegin22");
            foreach (var word in query22) Console.Write(word + " | ");
            Console.WriteLine();

            //23
            var query23 = numbers.Skip(number).Where(n => n >= 10 && n < 100 && n % 2 != 0).OrderByDescending(n => n);
            Console.WriteLine("LinqBegin23");
            foreach (var num in query23) Console.Write(num + " | ");
            Console.WriteLine();
            //24
            var query24 = words.Take(number).Where(n => n.Length % 2 != 0 && Char.IsUpper(n, 0)).Reverse();
            Console.WriteLine("LinqBegin24");
            foreach (var word in query24) Console.Write(word + " | ");
            Console.WriteLine();
            //25
            var query25 = numbers.Where((n, i) => n >= 0 && i >= number && i <= number2).Sum();
            Console.WriteLine("LinqBegin25" + query25);
            //26
            var query26 = words.Where((n, i) => i < number || i > number2).Average(n => n.Length);
            Console.WriteLine("LinqBegin26"+query26);
            //27
            var query27 = numbers.SkipWhile(n => n <= number).Where(n => n >= 0 && n % 2 != 0).Reverse();
            Console.WriteLine("LinqBegin27");
            foreach (var num in query27) Console.Write(num + " | ");
            Console.WriteLine();

            //28
            var query28 = words.TakeWhile(n => n.Length <= number).Where(n => Char.IsLetter(n, n.Length - 1))
                                .OrderByDescending(n => n.Length).ThenBy(n => n);
            Console.WriteLine("LinqBegin28");
            foreach (var word in query28) Console.Write(word + " | ");
            Console.WriteLine();
            //29
            var query29 = numbers.Distinct().TakeWhile(n => n <= number).Union(numbers.Distinct().Skip(number2 - 1)).OrderByDescending(n => n);
            Console.WriteLine("LinqBegin29");
            foreach (var num in query29) Console.Write(num + " | ");
            Console.WriteLine();
            //30
            var query30 = numbers.Where(n => n % 2 == 0).Except(numbers.Skip(number - 1)).OrderByDescending(n => n).Distinct().Reverse();
            Console.WriteLine("LinqBegin30");
            foreach (var num in query30) Console.Write(num + " | ");
            Console.WriteLine();
            //31
            var query31 = words.Take(number).Intersect(words.Reverse().TakeWhile(n => !Char.IsDigit(n, n.Length - 1)).Reverse())
                .OrderBy(n => n.Length).ThenBy(n => n);
            Console.WriteLine("LinqBegin31");
            foreach (var word in query31) Console.Write(word + " | ");
            Console.ReadLine();
        }
    }
}
