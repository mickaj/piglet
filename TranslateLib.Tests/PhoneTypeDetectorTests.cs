using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TranslateLib.Tests
{
    public class PhoneTypeDetectorTests
    {
        PhoneTypeDetector detector = new PhoneTypeDetector();

        [Fact]
        public void IsAVowel()
        {
            PhoneType resultUpperCase = detector.Detect('A');
            PhoneType resultLowerCase = detector.Detect('a');

            Assert.Equal(PhoneType.Vowel, resultLowerCase);
            Assert.Equal(PhoneType.Vowel, resultUpperCase);
        }

        [Fact]
        public void IsSConsonant()
        {
            PhoneType resultUpperCase = detector.Detect('S');
            PhoneType resultLowerCase = detector.Detect('s');

            Assert.Equal(PhoneType.Consonant, resultUpperCase);
            Assert.Equal(PhoneType.Consonant, resultLowerCase);
        }

        [Fact]
        public void IsOtherUnspecified()
        {
            PhoneType resultNumber = detector.Detect('6');
            PhoneType resultDot = detector.Detect('.');
            PhoneType resultSymbol = detector.Detect('^');

            Assert.Equal(PhoneType.Unspecified, resultNumber);
            Assert.Equal(PhoneType.Unspecified, resultDot);
            Assert.Equal(PhoneType.Unspecified, resultSymbol);
        }

        [Fact]
        public void IsAddedVowelVowel()
        {
            detector.AddVowel('ą');

            PhoneType resultLowerCase = detector.Detect('ą');
            PhoneType resultUpperCase = detector.Detect('Ą');

            Assert.Equal(PhoneType.Vowel, resultLowerCase);
            Assert.Equal(PhoneType.Vowel, resultUpperCase);
        }

        [Fact]
        public void IsAddedConsonantConsonant()
        {
            detector.AddConsonant('Ł');

            PhoneType resultLowerCase = detector.Detect('ł');
            PhoneType resultUpperCase = detector.Detect('Ł');

            Assert.Equal(PhoneType.Consonant, resultLowerCase);
            Assert.Equal(PhoneType.Consonant, resultUpperCase);
        }
    }
}
