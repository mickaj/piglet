using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TranslateLib
{
    public class DiacriticsRemover : IRemover
    {
        public string Remove(string input)
        {
            string normalized = input.Normalize(NormalizationForm.FormKD);
            StringBuilder sb = new StringBuilder();

            foreach(char c in normalized)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if(unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    if(c == 'Ł') {sb.Append('L');}
                    else
                    {
                        if(c == 'ł') { sb.Append('l'); }
                        else { sb.Append(c); }
                    }
                }
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
