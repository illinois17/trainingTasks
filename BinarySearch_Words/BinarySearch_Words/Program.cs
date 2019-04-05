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
            string text = File.ReadAllText("text.txt");
            string search = string.Empty;

            while(search!="exit")
            {
                Console.WriteLine("Введите слово которое необходимо найти:");
                search = Console.ReadLine();
                try
                {
                    int foundPos=FindTheWord(text, search);
                    Console.WriteLine("Слово присутствует в тексте\n");
                }
                catch (ArgumentException e)
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
                throw new ArgumentException(String.Format("Слово \"{0}\" не найденно в тексте",searchWord));
            }

        }
    }
}

