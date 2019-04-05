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
            string commands = "-help/? - посмотреть доступные команды\n-change - изменить файл\n-exit - выйти из программы";
            changingPath:
            Console.WriteLine("Введите путь к файлу:");
            try
            {
                string path = Console.ReadLine();
                text = File.ReadAllText(path);
                Console.WriteLine("help /? -чтобы узнать доступные команды");
            }
            catch (IOException e)
            {
                Console.WriteLine("Путь к файлу не корректный или файла не существует");
                goto changingPath;
            }
            catch (Exception e)
            {
                Console.WriteLine("Из тебя бы вышел хороший тестировщик, ты умудрился вызвать ошибку:"+e.Message);
                goto changingPath;
            }
            while (search!="exit")
            {                
                try
                {
                    Console.WriteLine("Введите слово которое необходимо найти: ");
                    search = Console.ReadLine();
                    switch(search)
                    {
                        case "-exit":
                            break;
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
        static int FindTheWord(string text, string searchWord)
        {
            char[] wordsSeparators = { '.', ',', '-', ' ', '(', ')' };
            List<string> words = text.Split(wordsSeparators).ToList<string>();
            words.Sort();
            return BinarySearch(words, searchWord, 0, words.Count - 1, 0);

            int BinarySearch(List<string> sortedWords, string item, int first, int last, int wordIndex)
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
                throw new BinarySearchFoundNothing(String.Format("Слово \"{0}\" не найденно в тексте",searchWord));
            }

        }
    }
    class BinarySearchFoundNothing : Exception
    {
        public BinarySearchFoundNothing(string message)
            : base(message)
        { }
    }
}

