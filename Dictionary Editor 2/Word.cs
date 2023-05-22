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
        public Word()
        {
            
        }
        
        public void AddToTransList(string translation)
        {
            translations.Add(translation);
        }
        //public void show(DataGridView trans)
        //{
        //    //int n;
        //    // n = gr.Columns.Count;
           
        //    DataTable dgr = new DataTable();
        //    dgr.Columns.Add("Перевод", typeof(string));
        //    //dgr.Rows.Add(translations.Count);
        //    for (int i = 0; i < translations.Count; i++)
        //    {
        //        dgr.Rows.Add(translations[i]);
        //    }
        //    dataGridView.DataSource = dgr;
            

        //}
        

    }
}
