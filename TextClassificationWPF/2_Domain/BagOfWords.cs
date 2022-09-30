using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextClassification.Domain
{
    public class BagOfWords
    {
        readonly IDictionary<string, int> bagOfWords;

        public BagOfWords()
        {
            bagOfWords = new SortedDictionary<string, int>();
        }

        public void InsertEntry(string word)
        {

            word = word.Trim();
            word = removeAccessChars(word);
            if (word.Length == 0)
            {
                return;
            }


            if (bagOfWords.ContainsKey(word))
            {
                int count = bagOfWords[word];
                count++;
                bagOfWords[word] = count;
            }
            else
            {
                bagOfWords.Add(word, 1);
            }
        }

        public ICollection<string> GetAllWordsInDictionary()
        {
            return bagOfWords.Keys;
        }

        public List<string> GetEntriesInDictionary()
        {
            List<string> entries = new List<string>();
            foreach (string key in bagOfWords.Keys)
            {
                entries.Add(key + " " + bagOfWords[key]);
            }
            return entries;
        }





        public string removeAccessChars(string input)
        {
            //punctuation to remove     - "\"" does not remove " for some reason
            string[] charsToRemove = new string[] {",","!","-",".","?","\""};


            //loop through the list of chars to remove
            for (int i = 0; i < charsToRemove.Length; i++)
            {
                //replace caracters with nothing 
                input = input.Replace(charsToRemove[i], "");

            }

            return input;
        }

    }
}