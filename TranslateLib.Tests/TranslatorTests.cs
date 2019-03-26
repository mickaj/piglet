using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TranslateLib.Tests
{
    public class TranslatorTests
    {
        PhoneTypeDetector detector;
        Translator translator;

        Dictionary<string, string> translatedConsonantWords = new Dictionary<string, string>();

        string have = "have";
        string haveTranslated = "avehay";

        string cram = "cram";
        string cramTranslated = "amcray";

        string take = "take";
        string takeTranslated = "aketay";

        string cat = "cat";
        string catTranslated = "atcay";

        string shrimp = "shrimp";
        string shrimpTranslated = "impshray";

        string trebuchet = "trebuchet";
        string trebuchetTranslated = "ebuchettray";

        Dictionary<string, string> translatedVowelWords = new Dictionary<string, string>();

        string ate = "ate";
        string ateTranslated = "ateyay";

        string apple = "apple";
        string appleTranslated = "appleyay";

        string oaken = "oaken";
        string oakenTranslated = "oakenyay";

        string eagle = "eagle";
        string eagleTranslated = "eagleyay";

        public TranslatorTests()
        {
            detector = new PhoneTypeDetector();
            translator = new Translator(detector);

            translatedConsonantWords.Add(have, haveTranslated);
            translatedConsonantWords.Add(cram, cramTranslated);
            translatedConsonantWords.Add(take, takeTranslated);
            translatedConsonantWords.Add(cat, catTranslated);
            translatedConsonantWords.Add(shrimp, shrimpTranslated);
            translatedConsonantWords.Add(trebuchet, trebuchetTranslated);

            translatedVowelWords.Add(ate, ateTranslated);
            translatedVowelWords.Add(apple, appleTranslated);
            translatedVowelWords.Add(oaken, oakenTranslated);
            translatedVowelWords.Add(eagle, eagleTranslated);
        }

        [Fact]
        public void TestVowelWords()
        {
            Dictionary<string, string> result = TranslateWords(translatedVowelWords);
            foreach(KeyValuePair<string, string> pair in result)
            {
                Assert.Equal(translatedVowelWords[pair.Key], pair.Value);
            }
        }

        [Fact]
        public void TestConsonantWords()
        {
            Dictionary<string, string> result = TranslateWords(translatedConsonantWords);
            foreach (KeyValuePair<string, string> pair in result)
            {
                Assert.Equal(translatedConsonantWords[pair.Key], pair.Value);
            }
        }

        private Dictionary<string, string> TranslateWords(Dictionary<string, string> baseDict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach(KeyValuePair<string, string> pair in baseDict)
            {
                result.Add(pair.Key, translator.TranslateWord(pair.Key));
            }
            return result;
        }
    }
}
