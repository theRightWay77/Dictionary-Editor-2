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

            ShowTranslationsOfOneSense();
            ShowTranslationsOfExamples();
        }

        private void removeAllRowsTR()
        {

            this.dataGridViewTranslationsOfOneSense.Rows.Clear();
            this.dataGridViewTranslationsOfOneSense.Columns.Clear();
        }
        private void removeAllRowsEX()
        {

            this.dataGridViewExamplesAndTranslationsForOneSense.Rows.Clear();
            this.dataGridViewExamplesAndTranslationsForOneSense.Columns.Clear();
        }
        private void showDataGridViewWithExamples(Word word)
        {
            dataGridViewExamplesAndTranslationsForOneSense.Columns.Add("Examp", "Пример");
            dataGridViewExamplesAndTranslationsForOneSense.Columns.Add("Trans", "Перевод");
            
            foreach (KeyValuePair<string, string> pair in word.examples)
            {
                string k = pair.Key;
                string v = pair.Value;
                dataGridViewExamplesAndTranslationsForOneSense.Rows.Add(k, v);
            } 
            //for (int i = 0; i < word.examples.Count; i++)
            //{
            //    dataGridViewTranslationsOfOneSense.Rows.Add(word.examples[i].);
            //}

        }
        private void ShowTranslationsOfExamples()
        {
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
                                    if (formOfSit.Name == "quote")
                                    {
                                        if (examOrTrans == false)
                                        {
                                            key = formOfSit.InnerText;
                                            examOrTrans = true;
                                        }
                                        //else
                                        //{
                                        //    value = formOfSit.InnerText;
                                        //    examOrTrans = false;
                                        //}
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
            showDataGridViewWithExamples(word);
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
        }

       

        private int takeTheNumberOfCurrentWordFromFile()
        {           
            StreamReader sr = new StreamReader("numberOfCurrentWord.txt");
            int numOfCurrentWord = int.Parse( sr.ReadLine());
            //labelNumberOfCurrentWord.Text = numOfCurrentWord;
            //sr.Close();
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
          //  bool wasChanged = false;
            foreach (XmlNode node in nodes)
            {
               // if (wasChanged == true) break;
                if (k == i)
                {
                    foreach (XmlNode childrenOfEntry in node)
                    {
                        if (childrenOfEntry.Name == "form")
                        {
                            // Console.WriteLine(childrenOfEntry.InnerText);
                            theWord = childrenOfEntry.InnerText;
                            return theWord;
                            //this.labelTheWord.Text = childrenOfEntry.InnerText;
                          //  wasChanged = true;
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


            ShowTranslationsOfOneSense();
            ShowTranslationsOfExamples();


        }

        private void pictureBoxToLeft_Click(object sender, EventArgs e)
        {
            int i = NomberOfWord(int.Parse(labelNumberOfCurrentWord.Text), -1);
            labelNumberOfCurrentWord.Text = i.ToString();
            ChangeLabelTheWord();
            removeAllRowsTR();
            removeAllRowsEX();



            ShowTranslationsOfOneSense();
            ShowTranslationsOfExamples();
        }

        private void dataGridViewTranslationsOfOneSense_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int positionRow = dataGridViewTranslationsOfOneSense.CurrentCell.RowIndex;        
            string newText = dataGridViewTranslationsOfOneSense.Rows[positionRow].Cells[0].Value.ToString();
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
                                        foreach (XmlNode orthOfForm in formOfSit)
                                        {
                                            if (orthOfForm.Name == "orth")
                                            {
                                                orthOfForm.InnerText = newText;
                                                xDoc.Save("osetExamples.xml");
                                            }
                                        }
                                       
                                        
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
    }
}
