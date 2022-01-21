using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordleSearch.Model
{
    public static class RegexCreator
    {
        public static string CreateRegex(string[] input, string pressedButtons)
        {
            StringBuilder returnString = new StringBuilder();
            foreach(string letter in input)
            {
                if (letter == null)
                {
                    if (pressedButtons != "")
                    {
                        returnString.Append("[^" + pressedButtons + "]");
                    }
                    else
                    {
                        returnString.Append("\\w");
                    }
                } else
                {
                    returnString.Append(letter.ToLower());
                }
            }
            //Console.WriteLine(returnString.ToString());
            return returnString.ToString();
        }

        public static List<string> FindWords(List<string> words, string regex)
        {
            return words.FindAll(word => Regex.IsMatch(word.ToLower(), regex));
        }

        public static List<string> ReadWords(string path)
        {
            return JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(path));
        }
    }
}
