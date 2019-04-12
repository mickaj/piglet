using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TranslateLib
{
    public class Translator : ITranslator
    {
        private const string WORD_PATTERN = "[a-zA-Z]+";
        private const string SINGLE_WORD_PATTERN = @"^(\s*)([a-zA-Z]+)(\s*)$";
        private readonly Regex SENTENCE = new Regex(@"(^[a-z])|\.\s+(.)", RegexOptions.ExplicitCapture);

        private readonly IPhoneTypeDetector phoneTypeDetector;
        private readonly IRemover remover;
        
        public Translator(IPhoneTypeDetector phoneTypeDetector)
        {
            this.phoneTypeDetector = phoneTypeDetector;
        }

        public Translator(IPhoneTypeDetector phoneTypeDetector, IRemover remover)
        {
            this.phoneTypeDetector = phoneTypeDetector;
            this.remover = remover;
        }

        public string TranslateWord(string word)
        {
            word.Trim();
            if (Regex.IsMatch(RunRemover(word), SINGLE_WORD_PATTERN))
            {
                if(phoneTypeDetector.Detect(word[0]) == PhoneType.Vowel) { return TranslateVowelWord(word); }
                else { return TranslateConsonantWord(word); }
            }
            throw new ArgumentException("Given string is not a single word!");
        }

        public string Translate(string input)
        {
            string translated = Regex.Replace(RunRemover(input), WORD_PATTERN, ReplaceMatch);
            return CapitalizeSentence(translated);
        }

        private string TranslateVowelWord(string word)
        {
            return word + "yay";
        }

        private string TranslateConsonantWord(string word)
        {
            int length = GetFirstVowelIndex(word);
            string movedPart = word.Substring(0, length);
            string vowelPart = word.Substring(length);
            return vowelPart + movedPart + "ay";
        }

        private int GetFirstVowelIndex(string word)
        {
            int index = 0;
            foreach (char c in word)
            {
                if(phoneTypeDetector.Detect(c) == PhoneType.Vowel)
                {
                    return index;
                }
                index++;
            }
            throw new ArgumentOutOfRangeException("This word has no vowels!");
        }

        private string ReplaceMatch(Match m)
        {
            return TranslateWord(m.Value);
        }

        private string CapitalizeSentence(string input)
        {
            string lower = input.ToLower();
            return SENTENCE.Replace(lower, s => s.Value.ToUpper());
        }

        private string RunRemover(string input)
        {
            return remover != null ? remover.Remove(input) : input;
        }
    }
}
