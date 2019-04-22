using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinarySearch_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            string search = string.Empty;
            const string commands = "-help/?  - доступные команды\n-change - изменить файл\n-exit - выйти из программы";
            changingPath:
            try
            {
                Console.WriteLine("Введите путь к файлу:");
                string path = Console.ReadLine();
                if (path == "-exit")
                    Environment.Exit(0);
                text = File.ReadAllText(path ?? throw new InvalidOperationException());
            }
            catch (IOException e)
            {
                Console.WriteLine("Путь к файлу не корректный или файла не существует : " + e.Message);
                goto changingPath;
            }
            catch (Exception e)
            {
                Console.WriteLine("Из тебя вышел бы хороший тестировщик,\n ты умудрился вызвать ошибку:"+e.Message);
                goto changingPath;
            }
            while (search!="exit")
            {                
                try
                {
                    Console.WriteLine("help /? -чтобы узнать доступные команды");
                    Console.WriteLine("Введите слово которое необходимо найти: ");
                    search = Console.ReadLine();
                    switch(search)
                    {
                        case "-exit":
                            Environment.Exit(0);
                            continue;
                        case "-change":
                        case "-changetext":
                            goto changingPath;
                        case "-help":
                        case "?":
                            Console.WriteLine(commands);
                            continue;
                    }
                    int foundPos=FindTheWord(text, search);
                    Console.WriteLine("Слово присутствует в тексте\n");
                }
                catch (BinarySearchFoundNothing e)
                {
                    Console.WriteLine(e.Message+"\n");
                }                
            }            

        }
        public static int FindTheWord(string text, string searchWord)
        {
            char[] wordsSeparators = { '.', ',', '-', ' ', '(', ')' };
            var words = text.Split(wordsSeparators).ToList<string>();
            words.Sort();
            return BinarySearch(words, searchWord, 0, words.Count - 1, 0);

            int BinarySearch(IReadOnlyList<string> sortedWords, string item, int first, int last, int wordIndex)
            {
                if (last == first && sortedWords[last] == item)
                    return last;
                if (last >= 1 && !(last < first))
                {
                    int mid = first + (last - first) / 2;
                    if (sortedWords[mid].Length > wordIndex && item.Length > wordIndex)
                    {
                        if (sortedWords[mid][wordIndex] > item[wordIndex])
                            return BinarySearch(sortedWords, item, first, mid, wordIndex);
                        else if (sortedWords[mid][wordIndex] < item[wordIndex])
                            return BinarySearch(sortedWords, item, mid + 1, last, wordIndex);
                        else if (mid + 1 < sortedWords.Count && sortedWords[mid + 1][wordIndex] == item[wordIndex] ||
                             mid - 1 >= 0 && sortedWords[mid - 1][wordIndex] == item[wordIndex])
                            return BinarySearch(sortedWords, item, first, last, wordIndex + 1);
                    }
                    if (sortedWords[mid] == item)
                        return mid;
                }
                throw new BinarySearchFoundNothing($"Слово \"{searchWord}\" не найденно в тексте");
            }

        }
    }

    internal class BinarySearchFoundNothing : Exception
    {
        public BinarySearchFoundNothing(string message)
            : base(message)
        { }
    }
}

