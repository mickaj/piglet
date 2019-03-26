using System;
using System.Collections.Generic;
using System.Text;

namespace TranslateLib
{
    public interface IPhoneTypeDetector
    {
        PhoneType Detect(char c);

        void AddVowel(char c);
        void AddConsonant(char c);
    }
}
