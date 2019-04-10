using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TranslateLib
{
    public class DiacriticsRemover
    {
        public string Remove(string input)
        {
            string normalized = input.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach(char c in normalized)
            {
                UnicodeCategory unicideCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if(unicideCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
