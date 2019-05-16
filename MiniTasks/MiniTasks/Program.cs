using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            Console.ReadLine();
            //1
            var query1 = numbers.First(f => f > 0);
            var query1_1 = numbers.Last(f => f < 0);
            QueryOut(query1);
            QueryOut(query1_1);

            //2
            var query2 = numbers.FirstOrDefault(n => n >= 0 && n.ToString().EndsWith(number.ToString()));
            QueryOut(query2);
            //3
            var query3 = words.Where(n => Char.IsDigit(n, 0) && n.Length == number).LastOrDefault() ?? "Not Found";
            QueryOut(query3);
            //4
            try
            {
                var query4 = words.Where(n => n.EndsWith(C.ToString())).SingleOrDefault();
                QueryOut(query4);
            }
            catch (Exception)
            {
                Console.WriteLine("LinqBegin4: " + "Error");
            }

            //5
            var query5 = words.Where(n => n.Length > 1 && n.StartsWith(C.ToString()) && n.EndsWith(C.ToString()))
                .Count();
            QueryOut(query5);
            //6
            var query6 = words.Sum(n => n.Length);
            QueryOut(query6);
            //7
            var query7 = numbers.Where(n => n < 0).Sum();
            var query7_1 = numbers.Where(n => n < 0).Count();
            QueryOut(query7);
            QueryOut(query7_1);
            //8
            var query8 = numbers.Where(n => n >= 10 && n < 100).Count();
            var query8_1 = numbers.Where(n => n >= 10 && n < 100).Average();
            QueryOut(query8);
            QueryOut(query8_1);
            //9
            var query9 = numbers.Where(n => n >= 0).Min();
            QueryOut(query9);
            //10
            var query10 = words.Select(n => n.ToUpper()).Where(n => n.Length == number).Max();
            QueryOut(query10);
            //11
            var query11 = words.Select(n => n.First().ToString()).Aggregate((a, b) => a + b);
            QueryOut(query11);
            //12
            var query12 = numbers.Select<int, long>(n => (n % 10)).Aggregate<long>((a, b) => a * b);
            QueryOut(query12);
            //13
            var query13 = Enumerable.Range(1, number).Select<int, float>(n => 1.0f / n).Sum();
            QueryOut(query13);
            //16
            var query16 = numbers.Where(n => n >= 0);
            Console.WriteLine("LinqBegin16");
            QueryOut(query16);
            //17
            var query17 = numbers.Where(n => n % 2 != 0).Distinct();
            Console.WriteLine("LinqBegin17");
            QueryOut(query17);
            //18
            var query18 = numbers.Where(n => n % 2 == 0).Reverse();
            Console.WriteLine("LinqBegin18");
            QueryOut(query18);
            //19
            Console.WriteLine("LinqBegin19");
            var query19 = numbers.Where(n => n % 10 == digit).Reverse().Distinct().Reverse();
            QueryOut(query19);
            //20
            var query20 = numbers.Where(n => n >= 10 && n < 100).OrderBy(n => n);
            Console.WriteLine("LinqBegin20");
            QueryOut(query20);

            //21
            var query21 = words.Select(n => n.ToUpper()).OrderBy(n => n.Length).ThenByDescending(n => n);
            Console.WriteLine("LinqBegin21");
            QueryOut(query21);

            //22
            var query22 = words.Select(n => n.ToUpper()).Where(n => n.Length == number && Char.IsDigit(n, n.Length - 1))
                .OrderBy(n => n);
            Console.WriteLine("LinqBegin22");
            QueryOut(query22);

            //23
            var query23 = numbers.Skip(number).Where(n => n >= 10 && n < 100 && n % 2 != 0).OrderByDescending(n => n);
            Console.WriteLine("LinqBegin23");
            QueryOut(query23);
            //24
            var query24 = words.Take(number).Where(n => n.Length % 2 != 0 && Char.IsUpper(n, 0)).Reverse();
            Console.WriteLine("LinqBegin24");
            QueryOut(query24);
            //25
            Console.WriteLine("LinqBegin25");
            var query25 = numbers.Where((n, i) => n >= 0 && i >= number && i <= number2).Sum();
            QueryOut(query25);
            //26
            Console.WriteLine("LinqBegin26");
            var query26 = words.Where((n, i) => i < number || i > number2).Average(n => n.Length);
            QueryOut(query26);
            //27
            var query27 = numbers.SkipWhile(n => n <= number).Where(n => n >= 0 && n % 2 != 0).Reverse();
            Console.WriteLine("LinqBegin27");
            QueryOut(query27);

            //28
            var query28 = words.TakeWhile(n => n.Length <= number).Where(n => Char.IsLetter(n, n.Length - 1))
                .OrderByDescending(n => n.Length).ThenBy(n => n);
            Console.WriteLine("LinqBegin28");
            QueryOut(query28);
            //29
            var query29 = numbers.Distinct().TakeWhile(n => n <= number).Union(numbers.Distinct().Skip(number2 - 1))
                .OrderByDescending(n => n);
            Console.WriteLine("LinqBegin29");
            QueryOut(query29);
            //30
            var query30 = numbers.Where(n => n % 2 == 0).Except(numbers.Skip(number - 1)).OrderByDescending(n => n)
                .Distinct().Reverse();
            Console.WriteLine("LinqBegin30");
            QueryOut(query30);
            //31
            var query31 = words.Take(number)
                .Intersect(words.Reverse().TakeWhile(n => !Char.IsDigit(n, n.Length - 1)).Reverse())
                .OrderBy(n => n.Length).ThenBy(n => n);
            Console.WriteLine("LinqBegin31");
            QueryOut(query31);
            //32
            Console.WriteLine("LinqBegin32");
            var query32 = words.Select(s => s[0]).Reverse().ToArray<char>();
            QueryOut(query32);
            //33
            Console.WriteLine("LinqBegin33");
            var query33 = numbers.Where(w => w >= 0).Select(s => s % 10).Distinct();
            QueryOut(query33);
            //34
            Console.WriteLine("LinqBegin34");
            var query34 = numbers.Where(w => w >= 0 && w % 2 != 0).Select(s=>s.ToString()).OrderBy(o => o);
            QueryOut(query34);
            //35
            Console.WriteLine("LinqBegin35");
            var query35 = numbers.Select((n, i) => n * i).Where(w=>w>-100&&w<=-10 || w>=10&&w<100).Reverse();
            QueryOut(query35);
            //36
            Console.WriteLine("LinqBegin36");
            var query36 = words.Where(w => w.Length % 2 != 0).Select(s => s[0])
                .Concat(words.Where(w => w.Length % 2 == 0).Select(s => s[s.Length - 1])).ToArray<char>().OrderBy(o=>o);
            QueryOut(query36);
            //37
            Console.WriteLine("LinqBegin37");
            var query37 = wordsUpper.Select((s, i) => !string.IsNullOrEmpty(s)? s+i: string.Empty).Where(w=>!string.IsNullOrEmpty(w));
            QueryOut(query37);
            //38
            Console.WriteLine("LinqBegin38");
            var query38 = numbers.Where((_, i) => (i + 1) % 3 != 0).Select((s, i) => i % 2 == 0 ? s * 2 : s);
            QueryOut(query38);
            //39
            Console.WriteLine("LinqBegin39");
            var query39 = words.SelectMany(w => w.Where(char.IsDigit));
            QueryOut(query39);
            //40
            Console.WriteLine("LinqBegin40");
            var query40 = words.SelectMany(n => words.Where(w => w.Length >= number).Reverse());
            QueryOut(query40);
            //41
            Console.WriteLine("LinqBegin41");
            string[] wordsIn = {"Qwesd.Asdfg","Asd.Azcssa","Xxcbs.Zzsdaszvt","R1wds.Xg56.Bb.Fdbyo.Ebfdw"};
            var query41 = wordsIn.SelectMany(w => w.Split('.')).Where(n=>n.Length==number).OrderBy(o=>o);
            QueryOut(query41);
            //42
            Console.WriteLine("LinqBegin42");
            var query42 = words.SelectMany((w, i) => i % 2 == 0 ? w.Where(char.IsLower) : w.Where(char.IsUpper));
            QueryOut(query42);
            //43
            Console.WriteLine("LinqBegin43");
            var query43 = words.SelectMany((w, i) =>
                i <= number ? w.Where((_, ic) => ic % 2 == 0) : w.Where((_, ic) => ic % 2 != 0)).Reverse();
            QueryOut(query43);
            //44
            Console.WriteLine("LinqBegin44");
            var query44 = numbers.Where(n => number > n).Concat(numbers2.Where(n2=>n2<number2)).OrderBy(o=>o);
            QueryOut(query44);
            //45
            Console.WriteLine("LinqBegin45");
            string[] wordsWithNum = { "1SAD", "ASDX2", "ASD234R", "ASD13", "SDF4RFW", "AS", "21SWSD", "SAFF31", "ASC34", "SCAAX21"};
            string[] wordsWithNum2 = {"SDF", "SDF342R", "SDF24", "SDFS3", "SDFW", "WFW32", "SDFSVCX4", "DFGFDF", "APFC", "KYI6"};
            var query45 = wordsWithNum.Where(w => w.Length == number)
                .Concat(wordsWithNum2.Where(w2 => w2.Length == number2));
            QueryOut(query45);
            //46
            Console.WriteLine("LinqBegin46");
            int[] pairNumbers = { 15, 12, 6, 234, 223, 243, 82, 74, 142, 147, 5, 757, 1232, 24 };
            int[] pairNumbers2 = { 14, 312, 46, 2534, 5273, 244, 28, 72, 122, 141, 7, 53, 1233, 42 };

            var query46 = pairNumbers
                .Join(pairNumbers2, o => o % 10, i => i%10
                    ,(o, i) => new string[] {$"{o}-{i}"}).SelectMany(n=>n);
            QueryOut(query46);
            //47
            Console.WriteLine("LinqBegin47");
            var query47 = pairNumbers
                .Join(pairNumbers2, o => o % 10, i => Char.GetNumericValue(i.ToString()[0]), (o, i) => new {o, i})
                .GroupBy(x => x.o)
                .SelectMany(x => x.OrderBy(y => y.i))
                .Select(x => $"{x.o}:{x.i}");
            QueryOut(query47);
            //48
            Console.WriteLine("LinqBegin48");
            var query48 = wordsWithNum.Join(wordsWithNum2, o => o.Length, i => i.Length, (o, i) => new {o, i})
                .OrderBy(ob => ob.o).ThenByDescending(tb => tb.i).Select(s=>$"{s.o}:{s.i}");
            QueryOut(query48);
            //49 
            Console.WriteLine("LinqBegin49");
            string[] words1 = { "SQD23", "YSASD1", "ASD3", "ASCFV", "SAD", "CXZA21", "DVTGD", "DVAD32E", "S3E", "DASFA" };
            string[] words2 = { "GHHN3", "SSADFS", "AXZC", "XZXFV", "ZXC21", "CXXCZ1", "DVZXC", "DDFW32E", "ASFDE", "SFA" };
            string[] words3 = { "SQGN3", "SSHNGH", "AGHN", "GSCFV", "SHJN1", "CXHJN1", "DVHJN", "NKJH32E", "ASVFD", "DASDF" };

            var query49 = words1
                .Join(words2, o => o.First(), i => i.First(), (o, i) => new {o,i})
                .Join(words3,o=>o.o.First(),i=>i.First(),(o2,i2)=>new {o2.o , o2.i , i2})
                .SelectMany(s=> new string[]{ $"{s.o}={s.i}={s.i2}"});
            QueryOut(query49);
            //50
            Console.WriteLine("LinqBegin50");
            var query50 = words1.GroupJoin(words2, o => o.First(), i => i.First(), (o, ia) => new{o, matchesCount = ia.Count()}).Select(s=>$"{s.o}:{s.matchesCount}");
            QueryOut(query50);
            //51
            Console.WriteLine("LinqBegin51");
            var query51 = pairNumbers.GroupJoin(pairNumbers2, o => o % 10, i => i % 10,
                (o, ia) => new {o, Summa = ia.Sum()}).Select(s=>$"{s.Summa}:{s.o}");
            QueryOut(query51);
            //52
            Console.WriteLine("LinqBegin52");
            var query52 = words1.Where(w=>char.IsDigit(w.Last()))
                .Join(words2, o => true, i => char.IsDigit(i.Last()), (o, i) => new { o,i })
                .OrderBy(ob=>ob.o).ThenByDescending(tb=>tb.i)
                .Select(sm=>$"{sm.o}={sm.i}");
            QueryOut(query52);

            //53
            Console.WriteLine("LinqBegin53");
            var query53 = pairNumbers.GroupJoin(pairNumbers2, o => 0, i => 0, (o, ia) => new {o, ia})
                .SelectMany(s => s.ia.Select(b => b + s.o));
            QueryOut(query53);
            //54
            Console.WriteLine("LinqBegin54");
            var query54 = words1.GroupJoin(words2, o => o[0], i => i[0], (o, ia) => new { o, ia = ia.DefaultIfEmpty() })
                .SelectMany(sm=>sm.ia.Select(s=>$"{sm.o}.{s}").OrderBy(ob=>ob));
            QueryOut(query54);
            //55
            Console.WriteLine("LinqBegin55");
            var query55 = pairNumbers
                .GroupJoin(pairNumbers2, o => o % 10, i => i % 10, (o, ia) => new {o, ia = ia.DefaultIfEmpty(0)})
                .SelectMany(sm => sm.ia.Select(s => new{sm.o, ia = s}))
                .OrderByDescending(ob => ob.o).ThenBy(tb => tb.ia)
                .Select(s=>$"{s.o}:{s.ia}");
            QueryOut(query55);
            //56
            Console.WriteLine("LinqBegin56");
            var query56 = pairNumbers.GroupBy(gb => gb % 10)
                .OrderBy(ob=>ob.Key)
                .Select(s => $"{s.Key}:{s.Sum()}");
            QueryOut(query56);
            //57
            Console.WriteLine("LinqBegin57");
            var query57 = pairNumbers.GroupBy(gb => gb % 10)
                .OrderBy(ob=>ob.Key)
                .Select(s=>$"{s.Key}:{s.Max()}");
            QueryOut(query57);
            //58
            Console.WriteLine("LinqBegin58");
            var query58 = words1.GroupBy(gb => gb[0])
                .OrderBy(ob => ob.Key)
                .Select(s => $"{s.Key}-{s.First(f => f.Length==s.Max(m=>m.Length))}");
            QueryOut(query58);
            //59
            Console.WriteLine("LinqBegin59");
            var query59 = words1.GroupBy(gb => gb.Length)
                .Select(s=>s.OrderBy(o=>o).First())
                .OrderByDescending(ob=>ob.Length);
            QueryOut(query59);
            //60
            Console.WriteLine("LinqBegin60");
            var query60 = words1.GroupBy(gb => gb[0])
                .Select(s => new{Sum= s.Sum(sum => sum.Length), s.Key})
                .OrderByDescending(ob=>ob.Sum)
                .ThenBy(tb=>tb.Key)
                .Select(s2=>$"{s2.Sum}-{s2.Key}");
            QueryOut(query60);
            Console.ReadLine();
        }

        public static void QueryOut<T>(IEnumerable<T> query)
        {
            foreach (var word in query) Console.Write(word + " ");
            Console.WriteLine();
        }

        public static void QueryOut(dynamic query)
        {
            Console.WriteLine(query);
        }
    }
}
