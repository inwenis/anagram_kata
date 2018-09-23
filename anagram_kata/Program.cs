﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anagram_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var anagramSubject = "documenting";

            var anagramalist = new Anagramalist(new [] { "document", "ing"});
            var anagrams = anagramalist.ComputeAll2WordsAnagrams(anagramSubject);
            foreach (var anagram in anagrams)
            {
                Console.WriteLine(anagram);
            }

            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();
        }
    }

    public class Anagramalist
    {
        private string[] _words;

        public Anagramalist(string[] words)
        {
            _words = words;
        }

        public IEnumerable<string> ComputeAll2WordsAnagrams(string anagramSubject)
        {
            var onlyWordsWithMatchingLetters = _words.Where(word => word.All(c => anagramSubject.Contains(c))).ToArray();

            if (onlyWordsWithMatchingLetters.Length > 1)
            {
                var anagram = onlyWordsWithMatchingLetters[0] + " " + onlyWordsWithMatchingLetters[1];
                return new []{anagram};
            }
            else
            {
                return new string[0];
            }
        }
    }
}
