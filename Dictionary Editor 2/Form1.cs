using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Dictionary_Editor_2
{
    public partial class DIctionary : Form
    {
      //  DataGridView dataGridViewTranslationsOfOneSense = new DataGridView();
        public DIctionary()
        {
            InitializeComponent();
            ChangeLabelNumberOfCurrentWord(takeTheNumberOfCurrentWordFromFile());
            ChangeLabelTheWord();
         //    loadAllWords();
            // ShowTranslationsOfOneSense();
            loadAllWords11111111111();
            showDataGridView2(words, takeTheNumberOfCurrentWordFromFile());
            // ShowTranslationsOfExamples();
        }

        private void removeAllRowsTR()
        {

            this.dataGridViewTranslationsOfOneSense.Rows.Clear();
            this.dataGridViewTranslationsOfOneSense.Columns.Clear();
        }//надо объединить
        private void removeAllRowsEX()
        {

            this.dataGridViewExamplesAndTranslationsForOneSense.Rows.Clear();
            this.dataGridViewExamplesAndTranslationsForOneSense.Columns.Clear();
        }
        //private void showDataGridViewWithExamples(Word word)
        //{
        //    dataGridViewExamplesAndTranslationsForOneSense.Columns.Add("Examp", "Пример");
        //    dataGridViewExamplesAndTranslationsForOneSense.Columns.Add("Trans", "Перевод");
            
        //    foreach (KeyValuePair<string, string> pair in word.examples)
        //    {
        //        string k = pair.Key;
        //        string v = pair.Value;
        //        dataGridViewExamplesAndTranslationsForOneSense.Rows.Add(k, v);
        //    } 
        //    //for (int i = 0; i < word.examples.Count; i++)
        //    //{
        //    //    dataGridViewTranslationsOfOneSense.Rows.Add(word.examples[i].);
        //    //}

        //}
        //private void ShowTranslationsOfExamples()
        //{
        //    int i = takeTheNumberOfCurrentWordFromFile();
        //    Word word = new Word();
        //    XmlDocument xDoc = new XmlDocument();
        //    xDoc.Load("osetExamples.xml");
        //    XmlElement xRoot = xDoc.DocumentElement;
        //    XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"           
        //    bool wasChanged = false;
        //    int k = 1;
        //    bool examOrTrans = false;
        //    string key = "";
        //    string value = "";
        //    foreach (XmlNode node in nodes)
        //    {
        //        if (wasChanged == true) break;
        //        if (k == i)
        //        {
        //            foreach (XmlNode childrenOfEntry in node)
        //            {
        //                if (childrenOfEntry.Name == "sense")
        //                {
        //                    foreach (XmlNode citsOfSense in childrenOfEntry)
        //                    {
        //                        foreach (XmlNode formOfSit in citsOfSense)
        //                        {
        //                            if (formOfSit.Name == "quote")
        //                            {
        //                                if (examOrTrans == false)
        //                                {
        //                                    key = formOfSit.InnerText;
        //                                    examOrTrans = true;
        //                                }
        //                                //else
        //                                //{
        //                                //    value = formOfSit.InnerText;
        //                                //    examOrTrans = false;
        //                                //}
        //                            }
        //                            if (formOfSit.Name == "cit")
        //                            {
        //                                value = formOfSit.InnerText;
        //                                examOrTrans = false;
        //                                word.AddToDictOfExamples(key, value);
        //                            }
        //                        }
                                
                               
        //                    }
                           
        //                    wasChanged = true;
        //                }
        //            }
        //        }
        //        else k++;
        //    }
        //    showDataGridViewWithExamples(word);
        //}
        private void showDataGridViewWithTranslations(Word word)
        {
            dataGridViewTranslationsOfOneSense.Columns.Add("Trans", "Перевод");
        
            for (int i = 0; i < word.translations.Count; i++)
            {

                dataGridViewTranslationsOfOneSense.Rows.Add(word.translations[i]);
            }

        }

        private void ShowTranslationsOfOneSense()
        {
            int i = takeTheNumberOfCurrentWordFromFile();
            Word word = new Word();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("osetExamples.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"           
            bool wasChanged = false;
            int k = 1;
            foreach (XmlNode node in nodes)
            {
                if (wasChanged == true) break;
                if (k == i)
                {
                    foreach (XmlNode childrenOfEntry in node)
                    {
                        if (childrenOfEntry.Name == "sense")
                        {
                            foreach (XmlNode citsOfSense in childrenOfEntry)
                            {
                                foreach (XmlNode formOfSit in citsOfSense)
                                {
                                    if (formOfSit.Name == "form")
                                    {
                                        string t = citsOfSense.InnerText;
                                        word.AddToTransList(t);
                                    }
                                }                               
                            }
                            wasChanged = true;
                        }                  
                    }
                }
                else k++;
            }
            showDataGridViewWithTranslations(word);
        } // переделано

       

        private int takeTheNumberOfCurrentWordFromFile()
        {           
            StreamReader sr = new StreamReader("numberOfCurrentWord.txt");
            int numOfCurrentWord = int.Parse( sr.ReadLine());
            //labelNumberOfCurrentWord.Text = numOfCurrentWord;
            sr.Close();
            return numOfCurrentWord;
        }

        private int NomberOfWord(int i, int WhereToGo)//меняет номер текущего слова по нажатию стрелок
        {
            //надо добавить ограничения: нельзя долистать до -1 и до 11 489
            //добавить: самому ввести число и перенестить к этому слову
            string text = (i + WhereToGo).ToString() + Environment.NewLine;
            File.WriteAllText("numberOfCurrentWord.txt", text);
            return (i + WhereToGo); //.ToString();
        }

        private void ChangeLabelNumberOfCurrentWord(int i)
        {
            labelNumberOfCurrentWord.Text = i.ToString();
        }

        private string WhichWordShow(int i) 
        {
            string theWord = "";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("osetExamples.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"
            int k = 1;
          
            foreach (XmlNode node in nodes)
            {            
                if (k == i)
                {
                    foreach (XmlNode childrenOfEntry in node)
                    {
                        if (childrenOfEntry.Name == "form")
                        {                        
                            theWord = childrenOfEntry.InnerText;
                            return theWord;                      
                        }
                        break;
                    }
                }
                else k++;
            }
            return theWord;
        }

        private void ChangeLabelTheWord()
        {
           string theWord = WhichWordShow(takeTheNumberOfCurrentWordFromFile());
           this.labelTheWord.Text = theWord;
                            
        }      

        private void pictureBoxToRight_Click(object sender, EventArgs e)
        {
            int i = NomberOfWord(int.Parse(labelNumberOfCurrentWord.Text), 1);
            labelNumberOfCurrentWord.Text = i.ToString();
            ChangeLabelTheWord();
            removeAllRowsTR();
            removeAllRowsEX();
        //    loadAllWords();
          //  loadAllWords11111111111();
            showDataGridView2(words, takeTheNumberOfCurrentWordFromFile());
            //  ShowTranslationsOfOneSense();
            // ShowTranslationsOfExamples();
        }

        private void pictureBoxToLeft_Click(object sender, EventArgs e)
        {
            int i = NomberOfWord(int.Parse(labelNumberOfCurrentWord.Text), -1);
            labelNumberOfCurrentWord.Text = i.ToString();
            ChangeLabelTheWord();
            removeAllRowsTR();
            removeAllRowsEX();
           // loadAllWords();

            // loadAllWords11111111111();
            showDataGridView2(words, takeTheNumberOfCurrentWordFromFile());
            //  ShowTranslationsOfOneSense();
            //ShowTranslationsOfExamples();
        }

        //private void dataGridViewTranslationsOfOneSense_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    int i = takeTheNumberOfCurrentWordFromFile();
        //    string nameOfCurrentWord = labelTheWord.Text;

        //    Word word = new Word(); // должны взять текушее слово, а не создавать новое
        //    foreach (Word item in words.allWords)
        //    {
        //        if (item.nameOfTheWord == nameOfCurrentWord)
        //            word = item;
        //    }
        //    int positionRow = dataGridView1.CurrentCell.RowIndex;
        //    string newText = dataGridView1.Rows[positionRow].Cells[0].Value.ToString();


        //    XmlDocument xDoc = new XmlDocument();
        //    xDoc.Load("osetExamples.xml");
        //    XmlElement xRoot = xDoc.DocumentElement;
        //    XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"                  
        //    int k = 1;
        //    int indexOfTransl = positionRow;
        //    bool wasChanged = false;
        //    foreach (XmlNode node in nodes)
        //    {
        //        if (wasChanged == true) break;
        //        if (k == i)
        //        {
        //            foreach (XmlNode childrenOfEntry in node)
        //            {
        //                if (wasChanged == true) break;
        //                if (childrenOfEntry.Name == "sense")
        //                {
        //                    foreach (XmlNode citsOfSense in childrenOfEntry)
        //                    {
        //                        foreach (XmlNode formOfSit in citsOfSense)
        //                        {
        //                            if (wasChanged == true) break;
        //                            if (formOfSit.Name == "form")
        //                            {
        //                                foreach (XmlNode orthOfForm in formOfSit)
        //                                {
        //                                    if (wasChanged == true) break;
        //                                    if (orthOfForm.Name == "orth")
        //                                    {
        //                                        //word.translations[indexOfTransl] = newText;
        //                                        orthOfForm.InnerText = newText;
        //                                        // word.translations.Add(newText);
        //                                        xDoc.Save("osetExamples.xml");
        //                                        wasChanged = true;
        //                                    }
        //                                }


        //                            }
        //                        }
        //                    }

        //                }
        //            }
        //        }
        //        else k++;
        //    }

        //}

        private void dataGridViewExamplesAndTranslationsForOneSense_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int positionRow = dataGridViewExamplesAndTranslationsForOneSense.CurrentCell.RowIndex;
            string newText = dataGridViewExamplesAndTranslationsForOneSense.Rows[positionRow].Cells[0].Value.ToString();
            int i = takeTheNumberOfCurrentWordFromFile();
            Word word = new Word();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("osetExamples.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"           
            bool wasChanged = false;
            int k = 1;
            bool examOrTrans = false;
            string key = "";
            string value = "";
            
            foreach (XmlNode node in nodes)
            {
                if (wasChanged == true) break;
                if (k == i)
                {
                    foreach (XmlNode childrenOfEntry in node)
                    {
                        if (childrenOfEntry.Name == "sense")
                        {
                            foreach (XmlNode citsOfSense in childrenOfEntry)
                            {
                                foreach (XmlNode formOfSit in citsOfSense)
                                {
                                    if (wasChanged == true) break;
                                    if (formOfSit.Name == "quote")
                                    {
                                        if (examOrTrans == false)
                                        {
                                            word.examples.Remove(formOfSit.InnerText);
                                            formOfSit.InnerText = newText;
                                            key = newText;
                                            
                                            examOrTrans = true;
                                            wasChanged = true;
                                            xDoc.Save("osetExamples.xml");
                                        }
                                       
                                    }
                                    if (formOfSit.Name == "cit")
                                    {
                                        value = formOfSit.InnerText;
                                        examOrTrans = false;
                                        word.AddToDictOfExamples(key, value);
                                    }
                                }


                            }

                            wasChanged = true;
                        }
                    }
                }
                else k++;
            }
        }
        public Words words = new Words();
        //    private void loadAllWords() //объединила в один
        //    {
        //        Words words = new Words();

        //    XmlDocument xDoc = new XmlDocument();
        //    xDoc.Load("osetExamples.xml");
        //        XmlElement xRoot = xDoc.DocumentElement;
        //        //bool examOrTrans = false;
        //        //  string key = "";
        //        // string value = "";
        //        int g =0 ;
        //    XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"
        //        foreach (XmlNode node in nodes)
        //        {
        //            if (g == 100) break;
        //            g++;
        //            Word word = new Word();
        //            foreach (XmlNode childrenOfEntry in node)
        //            {
        //                if (childrenOfEntry.Name == "form")
        //                {
        //                    string theWord;
        //                    theWord = childrenOfEntry.InnerText;
        //                    word.nameOfTheWord = theWord;                    
        //                }
        //                break;
        //            }
        //            foreach (XmlNode childrenOfEntry in node)
        //            {
        //                if (childrenOfEntry.Name == "sense")
        //                {
        //                    foreach (XmlNode citsOfSense in childrenOfEntry)
        //                    {
        //                        foreach (XmlNode formOfSit in citsOfSense)
        //                        {
        //                            if (formOfSit.Name == "form")
        //                            {
        //                                string t = citsOfSense.InnerText;
        //                                word.AddToTransList(t);

        //                            }

        ////if (formOfSit.Name == "quote")
        ////{
        ////    if (examOrTrans == false)
        ////    {
        ////        key = formOfSit.InnerText;
        ////        examOrTrans = true;
        ////    }

        ////}
        ////if (formOfSit.Name == "cit")
        ////{
        ////    value = formOfSit.InnerText;
        ////    examOrTrans = false;
        ////    word.AddToDictOfExamples(key, value);
        ////}
        //                        }
        //                    }   
        //                }

        //            }
        //            words.allWords.Add(word);
        //          //  showDataGridView1(words);
        //          if(g == 100)
        //            break;

        //        }
        //         showDataGridView1(words, takeTheNumberOfCurrentWordFromFile());
        //    } 
        private void loadAllWords11111111111()
        {
          

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("osetExamples.xml");
            XmlElement xRoot = xDoc.DocumentElement;           
            int g = 0;
            bool examOrTrans = false;
            string key = "";
            string value = "";
            XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"
            foreach (XmlNode node in nodes)
            {
                if (g == 100) break;
                g++;
                Word word = new Word();
                foreach (XmlNode childrenOfEntry in node)
                {
                    if (childrenOfEntry.Name == "form")
                    {
                        string theWord;
                        theWord = childrenOfEntry.InnerText;
                        word.nameOfTheWord = theWord;
                    }
                    break;
                }
                foreach (XmlNode childrenOfEntry in node)
                {
                    if (childrenOfEntry.Name == "sense")
                    {
                        foreach (XmlNode citsOfSense in childrenOfEntry)
                        {
                            foreach (XmlNode formOfSit in citsOfSense)
                            {                              
                                if (formOfSit.Name == "quote")
                                {
                                    if (examOrTrans == false)
                                    {
                                        key = formOfSit.InnerText;
                                          examOrTrans = true;                                                                            
                                    }
                                }
                                if (formOfSit.Name == "cit")
                                {
                                    value = formOfSit.InnerText;
                                    examOrTrans = false;
                                    word.AddToDictOfExamples(key, value);
                                }
                            }
                        }                                                                             
                    }
                }
                foreach (XmlNode childrenOfEntry in node)
                {
                    if (childrenOfEntry.Name == "sense")
                    {
                        foreach (XmlNode citsOfSense in childrenOfEntry)
                        {
                            foreach (XmlNode formOfSit in citsOfSense)
                            {
                                if (formOfSit.Name == "form")
                                {
                                    string t = citsOfSense.InnerText;
                                    word.AddToTransList(t);
                                }
                            }
                        }
                    }
                }
                words.allWords.Add(word);          
                if (g == 100)
                    break;

            }
          //  showDataGridView2(words, takeTheNumberOfCurrentWordFromFile());
        }
        private void showDataGridView2(Words words, int i)
        {
            removeAllRowsDGV1();
            dataGridView1.Columns.Add("Trans", "Перевод");
            removeAllRowsDGV2();
            dataGridView2.Columns.Add("Examp", "Пример");
            dataGridView2.Columns.Add("Trans", "Перевод");
            Word word = words.allWords[i - 1];
            foreach (KeyValuePair<string, string> examp in word.examples)
            {
                dataGridView2.Rows.Add(examp.Key, examp.Value);
               
            }
            foreach (string trans in word.translations)
            {
                dataGridView1.Rows.Add(trans);
            }
        }
        private void removeAllRowsDGV2()
        {
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Columns.Clear();
        }
        //private void showDataGridView1(Words words, int i)
        //{
        //    removeAllRowsDGV1();
        //    dataGridView1.Columns.Add("Trans", "Перевод");
        //    Word word = words.allWords[i-1];
        //    foreach (string trans in word.translations)
        //    {
        //        dataGridView1.Rows.Add(trans);
        //    }
             
        //    //foreach (Word word in words.allWords)
        //    //{
        //    //    for (int k = 0; k < word.translations.Count; k++)
        //    //    {
        //    //        dataGridView1.Rows.Add(word.nameOfTheWord + " " + word.translations[k]);
        //    //    }
        //    //}

        //}
        private void removeAllRowsDGV1()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int i = takeTheNumberOfCurrentWordFromFile();
            string nameOfCurrentWord = labelTheWord.Text;

            Word word = new Word(); // должны взять текушее слово, а не создавать новое
            foreach (Word item in words.allWords)
            {
                if (item.nameOfTheWord == nameOfCurrentWord)
                    word = item;
            }
            int positionRow = dataGridView1.CurrentCell.RowIndex;
            string newText = dataGridView1.Rows[positionRow].Cells[0].Value.ToString();


            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("osetExamples.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"                  
            int k = 1;
            int indexOfTransl = 0;
            bool wasChanged = false;
            foreach (XmlNode node in nodes)
            {
                if (wasChanged == true) break;
                if (k == i)
                {
                    foreach (XmlNode childrenOfEntry in node)
                    {
                        if (wasChanged == true) break;
                        if (childrenOfEntry.Name == "sense")
                        {
                            foreach (XmlNode citsOfSense in childrenOfEntry)
                            {
                                foreach (XmlNode formOfSit in citsOfSense)
                                {
                                    if (wasChanged == true) break;
                                    if (formOfSit.Name == "form")
                                    {
                                        foreach (XmlNode orthOfForm in formOfSit)
                                        {
                                            if (wasChanged == true) break;
                                            if (orthOfForm.Name == "orth" && indexOfTransl == positionRow)
                                            {
                                                //word.translations[indexOfTransl] = newText;
                                                orthOfForm.InnerText = newText;
                                                // word.translations.Add(newText);
                                                xDoc.Save("osetExamples.xml");
                                                wasChanged = true;
                                               
                                            }
                                            else indexOfTransl++;
                                        }


                                    }
                                }
                            }

                        }
                    }
                }
                else k++;
            }
            loadAllWords11111111111();
        }
    }
}
