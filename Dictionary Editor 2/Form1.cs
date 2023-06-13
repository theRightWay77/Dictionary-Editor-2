﻿using System;
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
       
        public Words words = new Words();
        public DIctionary()
        {
            InitializeComponent();
            loadAllWords();
            ChangeLabelNumberOfCurrentWord(takeTheNumberOfCurrentWordFromFile());
            ChangeLabelTheWord();
         // loadAllWords();
            // ShowTranslationsOfOneSense();
           
            showDataGridViewes(words, takeTheNumberOfCurrentWordFromFile());
            // ShowTranslationsOfExamples();
        }
        
       
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
           // string text = (i + WhereToGo).ToString() + Environment.NewLine;
            string text = (i + WhereToGo).ToString();
            File.WriteAllText("numberOfCurrentWord.txt", text);
            return (i + WhereToGo); //.ToString();
        }

        private void ChangeLabelNumberOfCurrentWord(int i)
        {
            labelNumberOfCurrentWord.Text = i.ToString();
        }

        //переделала с классами в две строчки
        //private string WhichWordShow(int i) 
        //{
        //    string theWord = "";
        //    XmlDocument xDoc = new XmlDocument();
        //    xDoc.Load("osetExamples.xml");
        //    XmlElement xRoot = xDoc.DocumentElement;
        //    XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"
        //    int k = 1;

        //    foreach (XmlNode node in nodes)
        //    {            
        //        if (k == i)
        //        {
        //            foreach (XmlNode childrenOfEntry in node)
        //            {
        //                if (childrenOfEntry.Name == "form")
        //                {                        
        //                    theWord = childrenOfEntry.InnerText;
        //                    return theWord;                      
        //                }
        //                break;
        //            }
        //        }
        //        else k++;
        //    }
        //    return theWord;
        //}
        private string WhichWordShow(int i)
        {
           Word word = words.GetWordByIndex(i - 1);
            return word.nameOfTheWord;
        }
        private void ChangeLabelTheWord()
        {
           string theWord = WhichWordShow(takeTheNumberOfCurrentWordFromFile());
           this.labelTheWord.Text = theWord;                          
        }      

       
        private void buttonRight_Click(object sender, EventArgs e)
        {
            int i = NomberOfWord(int.Parse(labelNumberOfCurrentWord.Text), 1);
            labelNumberOfCurrentWord.Text = i.ToString();
            ChangeLabelTheWord();        
           
            showDataGridViewes(words, takeTheNumberOfCurrentWordFromFile());         
        }
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            int i = NomberOfWord(int.Parse(labelNumberOfCurrentWord.Text), -1);
            labelNumberOfCurrentWord.Text = i.ToString();
            ChangeLabelTheWord();
        
            showDataGridViewes(words, takeTheNumberOfCurrentWordFromFile());
           
        }
        
        

      
      
        private void loadAllWords()
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
        private void showDataGridViewes(Words words, int i)
        {
            removeAllRows();
          //  removeAllRowsDGV1();
            dataGridView1.Columns.Add("Trans", "Перевод");
           // removeAllRowsDGV2();
            dataGridView2.Columns.Add("Examp", "Пример");
            dataGridView2.Columns.Add("Trans", "Перевод");
            Word word = words.allWords[i - 1];
            foreach (KeyValuePair<string, string> examp in word.examples)
            {
               // dataGridView2.Rows.Add("Пример 1", "");
                dataGridView2.Rows.Add(examp.Key, examp.Value);              
            }
           // int countOfSecse = 1;
            foreach (string trans in word.translations)
            {
              //  dataGridView1.Rows.Add("Значение " + countOfSecse); countOfSecse++;
                dataGridView1.Rows.Add(trans);
            }
            
        }
        ////было 2 функции, я сделала все в одной
        ////private void showDataGridView1(Words words, int i)
        ////{
        ////    removeAllRowsDGV1();
        ////    dataGridView1.Columns.Add("Trans", "Перевод");
        ////    Word word = words.allWords[i-1];
        ////    foreach (string trans in word.translations)
        ////    {
        ////        dataGridView1.Rows.Add(trans);
        ////    }
             
        ////    //foreach (Word word in words.allWords)
        ////    //{
        ////    //    for (int k = 0; k < word.translations.Count; k++)
        ////    //    {
        ////    //        dataGridView1.Rows.Add(word.nameOfTheWord + " " + word.translations[k]);
        ////    //    }
        ////    //}

        ////}
        
        private void removeAllRows()
        {

            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Columns.Clear();
        }
       void dataGridView1_AddRow(int positionRow, string newText)
       {
            int i = takeTheNumberOfCurrentWordFromFile();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("osetExamples.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"                  
            int k = 1;
           
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
                            XmlElement TranslElem = xDoc.CreateElement("cit");

                            XmlAttribute TranslAttr = xDoc.CreateAttribute("type");
                           
                    
                         
                            TranslElem.SetAttribute("type", "translationEquivalent");
                            TranslElem.SetAttribute("xml:lang", "ru");

                            XmlElement companyElem = xDoc.CreateElement("form");
                            XmlElement orthElem = xDoc.CreateElement("orth");
                            XmlText orthText = xDoc.CreateTextNode(newText);

                            TranslElem.AppendChild(companyElem);
                            companyElem.AppendChild(orthElem);

                           

                            childrenOfEntry.AppendChild(TranslElem);


                            xDoc.Save("osetExamples.xml");
                            wasChanged = true;


                        }
                    }
                }
                else k++;
            }
            loadAllWords();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i = takeTheNumberOfCurrentWordFromFile();
          //  string nameOfCurrentWord = labelTheWord.Text;

            Word word = new Word(); // должны взять текушее слово, а не создавать новое
            word = words.GetWordByIndex(i - 1);

            //foreach (Word item in words.allWords)  //добавила как метод в класс Words
            //{
            //    if (item.nameOfTheWord == nameOfCurrentWord)
            //        word = item;
            //}
            int positionRow = dataGridView1.CurrentCell.RowIndex;
            string newText = dataGridView1.Rows[positionRow].Cells[0].Value.ToString();
            if (word.translations.Count <= positionRow)
            {
                word.translations.Add(newText);
                dataGridView1_AddRow(positionRow, newText);
            }
            else word.translations[positionRow] = newText;
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
            loadAllWords();
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int positionRow = dataGridView2.CurrentCell.RowIndex;
            int positionColumn = dataGridView2.CurrentCell.ColumnIndex;
           // string newText = dataGridView2.Rows[positionRow].Cells[0].Value.ToString();
            string newText = dataGridView2.CurrentCell.Value.ToString();

            int i = takeTheNumberOfCurrentWordFromFile();
            Word word = new Word(); // должны взять текушее слово, а не создавать новое
            word = words.GetWordByIndex(i - 1);
          

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("osetExamples.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"           
            int indexOfTransl = 0;
            bool wasChanged = false;
            int k = 0;
            bool examOrTrans = false;
          
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
                            if (indexOfTransl == positionRow)
                            {
                                foreach (XmlNode citsOfSense in childrenOfEntry)
                                {
                                    foreach (XmlNode formOfSit in citsOfSense)
                                    {

                                        if (wasChanged == true) break;
                                        if (positionColumn != 1)
                                        {

                                            if (formOfSit.Name == "quote")
                                            {
                                                if (examOrTrans == false)
                                                {
                                                    // word.examples.Remove(formOfSit.InnerText);                              


                                                    words.ChangeKey(word, formOfSit.InnerText, newText);
                                                    formOfSit.InnerText = newText;
                                                    examOrTrans = true;
                                                    wasChanged = true;
                                                    xDoc.Save("osetExamples.xml");
                                                }
                                            }
                                            else break;

                                        }
                                        else
                                        if (formOfSit.Name == "cit")
                                        {

                                            words.ChangeValue(word, formOfSit.InnerText, newText);
                                            formOfSit.InnerText = newText;
                                            examOrTrans = true;
                                            wasChanged = true;
                                            xDoc.Save("osetExamples.xml");
                                        }

                                    }
                                }
                            }
                            else
                            { indexOfTransl++; continue; }
                            
                        }
                       // wasChanged = true;
                    }
                }
                else k++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = NomberOfWord(int.Parse(labelNumberOfCurrentWord.Text), 1);
            labelNumberOfCurrentWord.Text = i.ToString();
            ChangeLabelTheWord();
            removeAllRows3();
            showDataGridView3(words, takeTheNumberOfCurrentWordFromFile());
        }
        private void showDataGridView3(Words words, int i)
        {
            removeAllRows();
           // removeAllRowsDGV1();
            dataGridView3.Columns.Add("Trans", "Перевод");
            //removeAllRowsDGV2();
         //   dataGridView2.Columns.Add("Examp", "Пример");
          //  dataGridView2.Columns.Add("Trans", "Перевод");
            Word word = words.allWords[i - 1];
            //foreach (KeyValuePair<string, string> examp in word.examples)
            //{
            //    // dataGridView2.Rows.Add("Пример 1", "");
            //    dataGridView3.Rows.Add(examp.Key, examp.Value);
            //}
            // int countOfSecse = 1;
            foreach (string trans in word.translations)
            {
                //  dataGridView1.Rows.Add("Значение " + countOfSecse); countOfSecse++;
                dataGridView3.Rows.Add(trans);
            }
        }
        private void removeAllRows3()
        {
            this.dataGridView3.Rows.Clear();
            this.dataGridView3.Columns.Clear();
        }

        private void DIctionary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                MessageBox.Show("kdjfhdkjgh");
                //buttonRight.PerformClick();
            }
            
        }

        private void dataGridView1_RowContextMenuStripChanged(object sender, DataGridViewRowEventArgs e)
        {
            MessageBox.Show("gkjhgodfg");
        }
    }
}
