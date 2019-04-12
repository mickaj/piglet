using System;
using System.Collections.Generic;
using System.Text;

namespace TranslateLib
{
    public interface ITranslator
    {
        string TranslateWord(string input);
        string Translate(string input);
    }
}
