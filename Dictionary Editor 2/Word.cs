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
}
