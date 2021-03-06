﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TranslateLib
{
    public class Translator : ITranslator
    {
        private const string WORD_PATTERN = "[a-zA-Z]+";
        private const string SINGLE_WORD_PATTERN = @"^(\s*)([a-zA-Z]+)(\s*)$";

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
            return Regex.Replace(RunRemover(input), WORD_PATTERN, ReplaceMatch);
        }

        private string TranslateVowelWord(string word)
        {
            return CapitalizeIfHasUpperCase(word + "yay");
        }

        private string TranslateConsonantWord(string word)
        {
            int length = GetFirstVowelIndex(word);
            if(length > 0)
            {
                string movedPart = word.Substring(0, length);
                string vowelPart = word.Substring(length);
                return CapitalizeIfHasUpperCase(vowelPart + movedPart + "ay");
            }
            return CapitalizeIfHasUpperCase(word + "ay");
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
            return -1;
        }

        private string ReplaceMatch(Match m)
        {
            return TranslateWord(m.Value);
        }

        private string RunRemover(string input)
        {
            return remover != null ? remover.Remove(input) : input;
        }

        private string CapitalizeIfHasUpperCase(string word)
        {
            return HasUpperCase(word) ? CapitalizeWord(word) : word;
         }

        private bool HasUpperCase(string word)
        {
            foreach (char c in word)
            {
                if (char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }

        private string CapitalizeWord(string word)
        {
            string result = word.ToLower();
            char firstChar = word[0];
            char firstCharUpper = char.ToUpper(firstChar);
            result = result.Substring(1);
            return firstCharUpper + result;
        }
    }
}
