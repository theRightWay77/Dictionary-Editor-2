using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dictionary_Editor_2
{
    public class Sense
    {

        public List<string> translationsOfSense = new List<string>();
        public List<string> examples = new List<string>();
        public List<string> translationsOfExamples = new List<string>();

        public Sense()
        {

        }
    }
    public class Word
    {
        public List<Sense> allSenses = new List<Sense>();
        public List<string> translations = new List<string>();
        public Dictionary<string, string> examples = new Dictionary<string, string>();
        public string lemma;
        public Word()
        {

        }

        public void AddTrans(int indexOfSense, string text)
        {
            allSenses[indexOfSense].translationsOfSense.Add(text);
        }
        public void AddExample(int indexOfSense, string text)
        {
            allSenses[indexOfSense].examples.Add(text);
        }
        public void AddTransOfExample(int indexOfSense, string text)
        {
            allSenses[indexOfSense].translationsOfExamples.Add(text);
        }
        public void AddTranslation(string examp, string trans)
        {
            if (!examples.ContainsKey(examp))
                examples.Add(examp, trans);
        }
        public void AddToDictOfExamples(string examp, string trans)
        {
            if (!examples.ContainsKey(examp))
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
            foreach (KeyValuePair<string, string> item in word.examples)
            {
                if (item.Value == oldValue) key = item.Key;
            }
            word.examples.Remove(key);
            word.examples[key] = newValue;
        }
    }
}
