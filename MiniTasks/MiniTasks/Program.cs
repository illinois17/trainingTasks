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
            int[] numbers = {11, -11, 33, 9534, 2123, 3, 23, 784, 4, 1234, 5, 753, -123, 2};
            int[] numbers2 = {1, 12, 6, 234, 223, 243, 2, 74, 142, 144, -5, -753, 1232, 24};
            string[] words = {"1qwE", "sfSd", "sE5s", "adXs3", "Aaaa", "Bbbbb", "1qwAqw", "sdNa12", "sfsMd", "dsKf"};
            string[] wordsUpper = {"", "QWES", "SAXC", "ZXC", "AAAA", "", "WDXZZ", "SDAXVR", "SA", ""}; //with Empty strings
            int number = 5; //number>0
            int number2 = 10;
            int digit = -2;
            char C = 's';
            //1
            var query1 = numbers.First(f => f > 0);
            var query1_1 = numbers.Last(f => f < 0);
            Console.WriteLine("LinqBegin1: " + query1);
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
            var query5 = words.Where(n => n.Length > 1 && n.StartsWith(C.ToString()) && n.EndsWith(C.ToString()))
                .Count();
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
            var query22 = words.Select(n => n.ToUpper()).Where(n => n.Length == number && Char.IsDigit(n, n.Length - 1))
                .OrderBy(n => n);
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
            Console.WriteLine("LinqBegin26" + query26);
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
            var query29 = numbers.Distinct().TakeWhile(n => n <= number).Union(numbers.Distinct().Skip(number2 - 1))
                .OrderByDescending(n => n);
            Console.WriteLine("LinqBegin29");
            foreach (var num in query29) Console.Write(num + " | ");
            Console.WriteLine();
            //30
            var query30 = numbers.Where(n => n % 2 == 0).Except(numbers.Skip(number - 1)).OrderByDescending(n => n)
                .Distinct().Reverse();
            Console.WriteLine("LinqBegin30");
            foreach (var num in query30) Console.Write(num + " | ");
            Console.WriteLine();
            //31
            var query31 = words.Take(number)
                .Intersect(words.Reverse().TakeWhile(n => !Char.IsDigit(n, n.Length - 1)).Reverse())
                .OrderBy(n => n.Length).ThenBy(n => n);
            Console.WriteLine("LinqBegin31");
            foreach (var word in query31) Console.Write(word + " | ");
            Console.WriteLine();
            //32
            var query32 = words.Select(s => s[0]).Reverse().ToArray<char>();
            foreach (var ch in query32) Console.Write(ch + " | ");
            Console.WriteLine();
            //33
            var query33 = numbers.Where(w => w >= 0).Select(s => s % 10).Distinct();
            foreach (var num in query33) Console.Write(num + " | ");
            Console.WriteLine();
            //34
            var query34 = numbers.Where(w => w >= 0 && w % 2 != 0).Select(s=>s.ToString()).OrderBy(o => o);
            foreach (var wordnum in query34) Console.Write(wordnum + " | ");
            Console.WriteLine();
            //35
            var query35 = numbers.Select((n, i) => n * i).Where(w=>w>-100&&w<=-10 || w>=10&&w<100).Reverse();
            foreach (var num in query35) Console.Write(num + " | ");
            Console.WriteLine();
            //36
            var query36 = words.Where(w => w.Length % 2 != 0).Select(s => s[0])
                .Concat(words.Where(w => w.Length % 2 == 0).Select(s => s[s.Length - 1])).ToArray<char>().OrderBy(o=>o);
            foreach (var wordnum in query36) Console.Write(wordnum + " | ");
            Console.WriteLine();
            //37
            var query37 = wordsUpper.Select((s, i) => !string.IsNullOrEmpty(s)? s+i: string.Empty).Where(w=>!string.IsNullOrEmpty(w));
            foreach (var word in query37) Console.Write(word + " | ");
            Console.WriteLine();
            //38
            var query38 = numbers.Where((_, i) => (i + 1) % 3 != 0).Select((s, i) => i % 2 == 0 ? s * 2 : s);
            foreach (var word in query38) Console.Write(word + " | ");
            Console.WriteLine();
            //39
            var query39 = words.SelectMany(w => w.Where(char.IsDigit));
            foreach (var charIn in query39) Console.Write(charIn + " ");
            Console.WriteLine();
            //40
            var query40 = words.SelectMany(n => words.Where(w => w.Length >= number).Reverse());
            foreach (var charIn in query40) Console.Write(charIn + " ");
            Console.WriteLine();
            //41
            string[] wordsIn = {"Qwesd.Asdfg","Asd.Azcssa","Xxcbs.Zzsdaszvt","R1wds.Xg56.Bb.Fdbyo.Ebfdw"};
            var query41 = wordsIn.SelectMany(w => w.Split('.')).Where(n=>n.Length==number).OrderBy(o=>o);
            foreach (var word in query41) Console.Write(word + " ");
            Console.WriteLine();
            //42
            var query42 = words.SelectMany((w, i) => i % 2 == 0 ? w.Where(char.IsLower) : w.Where(char.IsUpper));
            foreach (var charIn in query42) Console.Write(charIn + " ");
            Console.WriteLine();
            //43
            var query43 = words.SelectMany((w, i) =>
                i <= number ? w.Where((_, ic) => ic % 2 == 0) : w.Where((_, ic) => ic % 2 != 0)).Reverse();
            foreach (var charIn in query43) Console.Write(charIn + " ");
            Console.WriteLine();
            //44
            var query44 = numbers.Where(n => number > n).Concat(numbers2.Where(n2=>n2<number2)).OrderBy(o=>o);
            foreach (var nums in query44) Console.Write(nums + " ");
            Console.WriteLine();
            //45
            string[] wordsWithNum = {"1SAD", "ASDX2", "ASD234R", "ASD13", "SDF4RFW", "AS", "21SWSD", "SAFF31", "ASC34", "SCAAX21"};
            string[] wordsWithNum2 = {"SDF", "SDF342R", "SDF24", "SDFS3", "SDFW", "WFW32", "SDFSVCX4", "DFGFDF", "APFC", "KYI6"};
            var query45 = wordsWithNum.Where(w => w.Length == number)
                .Concat(wordsWithNum2.Where(w2 => w2.Length == number2));
            foreach (var nums in query45) Console.Write(nums + " ");
            Console.WriteLine();
            //46
            int[] pairNumbers = { 15, 12, 6, 234, 223, 243, 82, 74, 142, 144, 5, 753, 1232, 24 };
            int[] pairNumbers2 = { 14, 312, 46, 2534, 5273, 243, 28, 74, 142, 144, 5, 53, 1233, 42 };

            var query46 = pairNumbers
                .Join(pairNumbers2, o => o % 10, i => i%10, (o, i) => new string[] {$"{o}-{i}"}).SelectMany(n=>n);
            foreach (var word in query46) Console.Write(word + " ");
            Console.WriteLine();
            //47 Упорядочить
            var query47 = pairNumbers
                .Join(pairNumbers2, o => o % 10,  i=> Char.GetNumericValue(i.ToString()[0]), (o, i) => new{o,i}).Select(n => $"{n.o}:{n.i}");
            foreach (var word in query47) Console.Write(word + " ");
            Console.WriteLine();
            //48
            var query48 = wordsWithNum.Join(wordsWithNum2, o => o.Length, i => i.Length, (o, i) => new {o, i})
                .OrderBy(ob => ob.o).ThenByDescending(tb => tb.i).Select(s=>$"{s.o}:{s.i}");
            foreach (var word in query48) Console.Write(word + " ");
            Console.WriteLine();
            //49 Упорядочить
            string[] words1 = { "SQD23", "SSASD1", "ASD3", "ASCFV", "SAD21", "CXZA21", "DVTGD", "DVAD32E", "ASD3E", "DASFA" };
            string[] words2 = { "GHHN3", "SSADFS", "AXZC", "ZZXFV", "ZXC21", "CXXCZ1", "DVZXC", "DDFW32E", "ASFDE", "SFA" };
            string[] words3 = { "SQGN3", "SSHNGH", "AGHN", "GSCFV", "SHJN1", "CXHJN1", "DVHJN", "NKJH32E", "ASVFD", "DASDF" };

            var query49 = words1
                .Join(words2, o => o.First(), i => i.First(), (o, i) => new {o,i})
                .Join(words3,o=>o.o.First(),i=>i.First(),(o2,i2)=>new {o2.o , o2.i , i2})
                .SelectMany(s=> new string[]{ $"{s.o}={s.i}={s.i2}"});
            foreach (var word in query49) Console.Write(word + " ");
            Console.WriteLine();
            //50
            var query50 = words1.GroupJoin(words2, o => o.First(), i => i.First(), (o, ia) => new{o, matchesCount = ia.Count()}).Select(s=>$"{s.o}:{s.matchesCount}");
            foreach (var word in query50) Console.Write(word + " ");
            Console.WriteLine();
            //51
            var query51 = pairNumbers.GroupJoin(pairNumbers2, o => o % 10, i => i % 10,
                (o, ia) => new {o, Summa = ia.Sum()}).Select(s=>$"{s.Summa}:{s.o}");
            foreach (var word in query51) Console.Write(word + " ");
            Console.WriteLine();
            //52
            var query52 = words1.Where(w=>char.IsDigit(w.Last()))
                .Join(words2, o => true, i => char.IsDigit(i.Last()), (o, i) => new { o,i })
                .OrderBy(ob=>ob.o).ThenByDescending(tb=>tb.i)
                .Select(sm=>$"{sm.o}={sm.i}");
            foreach (var word in query52) Console.Write(word + " ");
            Console.WriteLine();

            //53
            var query53 = pairNumbers.GroupJoin(pairNumbers2, o => 0, i => 0, (o, ia) => new {o, ia})
                .SelectMany(s => s.ia.Select(b => b + s.o));
            foreach (var word in query53) Console.Write(word + " ");
            Console.WriteLine();
            //54
            Console.WriteLine("TEST");
            var query54 = words1.GroupJoin(words2, o => o[0], i => i[0], (o, ia) =>ia.DefaultIfEmpty("0").Select(d=> new { o, ia })).Select(s => s.Select(sm=> $"{sm.ia}.{sm.ia}") );
            foreach (var word in query54) Console.Write(word + " ");
            Console.WriteLine();
            Console.WriteLine("TEST");
            Console.ReadLine();
        }
    }
}
