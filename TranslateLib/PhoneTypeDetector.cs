using System;
using System.Collections.Generic;
using System.Text;

namespace TranslateLib
{
    public class PhoneTypeDetector
    {
        private List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u', 'y' };
        private List<char> consonants = new List<char> { 'b', 'c', 'd', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };

        public PhoneType Detect(char c)
        {
            if(IsVowel(Char.ToLower(c))) { return PhoneType.Vowel; }
            if(IsConsonant(Char.ToLower(c))) { return PhoneType.Consonant; }
            return PhoneType.Unspecified;
        }

        private bool IsVowel(char c)
        {
            foreach (char vowel in vowels)
            {
                if (c == vowel) { return true; }
            }
            return false;
        }

        private bool IsConsonant(char c)
        {
            foreach (char consonant in consonants)
            {
                if (c == consonant) { return true; }
            }
            return false;
        }

        public void AddVowel(char c)
        {
            vowels.Add(Char.ToLower(c));
        }

        public void AddConsonant(char c)
        {
            consonants.Add(Char.ToLower(c));
        }    
    }
}
