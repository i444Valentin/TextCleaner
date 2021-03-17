using System;
/**
 * Класс, представляет решение для поиска двух 
 * одинаковых слов, встречающихся вплотную 
 * к друг другу.
 * 
 * 
 */

namespace TextCleaner
{
    internal class ErrorsFinder
    {
        internal static String FindErrors(string text)
        {
            int j;
            String firstWord = "", secondWord = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (!text[i].ToString().Equals(" "))
                {
                    j = i;
                    firstWord = "";
                    while (j <= text.Length - 1 && !text[j].ToString().Equals(" "))
                    {
                        firstWord = firstWord + text[j].ToString();
                        j++;
                    }

                    if (secondWord.Equals(firstWord))
                    {
                        return secondWord + " ";
                    }

                    j++;
                    secondWord = "";

                    while (j <= text.Length - 1 && !text[j].ToString().Equals(" "))
                    {
                        secondWord = secondWord + text[j].ToString();
                        j++;
                    }

                    if (secondWord.Equals(firstWord))
                    {
                        return secondWord + " ";
                    }
                    i = j;
                }
            }
            return "";
        }
    }
}