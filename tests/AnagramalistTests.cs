﻿using System.Linq;
using anagram_kata;
using NUnit.Framework;

namespace tests
{
    [TestFixture]
    public class AnagramalistTests
    {
        [Test]
        public void ComputeAll2WordsAnagrams_GivenNoWords_ReturnsNoAnagrams()
        {
            var emptList = new string[0];
            var sut = new Anagramalist(emptList);

            var result = sut.ComputeAll2WordsAnagrams("whatever");

            Assert.IsEmpty(result);
        }

        [Test]
        public void ComputeAll2WordsAnagrams_GivenOneMatchingAnagram_ReturnsOneAnagram()
        {
            var wordsWithOnePossibleAnagram = new string[]{"document", "ing"};
            var sut = new Anagramalist(wordsWithOnePossibleAnagram);

            var result = sut.ComputeAll2WordsAnagrams("documenting").ToArray();

            CollectionAssert.AreEqual(new []{"document ing"} ,result);
        }

        [Test]
        public void ComputeAll2WordsAnagrams_GivenInputWordWithLetterNotPresentInSubject_ReturnsCorrectAnagrams()
        {
            var wordsWithOnePossibleAnagram = new string[]{"document", "documentX", "ing"};
            var sut = new Anagramalist(wordsWithOnePossibleAnagram);

            var result = sut.ComputeAll2WordsAnagrams("documenting").ToArray();

            CollectionAssert.AreEqual(new []{"document ing"}, result.ToArray());
        }

        [Test]
        public void ComputeAll2WordsAnagrams_Given3InputWordsWhichCanProduce2Anagrams_Returns2Anagrams()
        {
            var wordsWithOnePossibleAnagram = new string[]{"document", "ing", "nig"};
            var sut = new Anagramalist(wordsWithOnePossibleAnagram);

            var result = sut.ComputeAll2WordsAnagrams("documenting");

            CollectionAssert.AreEqual(new []{"document ing", "document nig"} ,result);
        }

        [Test]
        public void ComputeAll2WordsAnagrams_WordsThatHaveTooManyCharacters_AreNotInResultAnagrams()
        {
            var words = new string[]{"documenttttt", "ing"};
            var sut = new Anagramalist(words);

            var result = sut.ComputeAll2WordsAnagrams("documenting");

            Assert.IsEmpty(result);
        }

        [Test]
        public void ComputeAll2WordsAnagrams_SecondWordHasTooManyCharacters_IsNotPresentInResultAnagram()
        {
            var words = new string[]{"document", "inn"};
            var sut = new Anagramalist(words);

            var result = sut.ComputeAll2WordsAnagrams("documenting");

            Assert.IsEmpty(result);
        }
    }
}
