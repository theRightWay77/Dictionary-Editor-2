using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary_Editor_2
{
   public class Word
    {
        public List<string> translations = new List<string>();
        public Dictionary<string, string> examples = new Dictionary<string, string>();
        public string nameOfTheWord;
        public Word()
        {
            
        }
        
        public void AddToDictOfExamples(string examp, string trans)
        {
            if(!examples.ContainsKey(examp))
                examples.Add(examp, trans);
        }
        public void AddToTransList(string translation)
        {
            translations.Add(translation);
        }
        
        

    }
    public class Words
    {
        public Words() { }
        public List<Word> allWords = new List<Word>();
        public void addToAllWords(Word word)
        {
            allWords.Add(word);
        }

        public Word GetWordByIndex(int i)
        {
            return allWords[i];
        }
        public void ChangeKey(Word word, string oldKey, string newKey)
        {
            string value = word.examples[oldKey];         
            word.examples.Remove(oldKey);
            word.examples[newKey] = value;  
           
        }
        public void ChangeValue(Word word, string oldValue, string newValue)
        {
            string key = "";
            foreach (KeyValuePair<string,string> item in word.examples)
            {
                if (item.Value == oldValue) key = item.Key;
            }
            word.examples.Remove(key);
            word.examples[key] = newValue; 

        }

    }

}
