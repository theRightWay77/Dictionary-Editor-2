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
        public Words words = new Words();
        public DIctionary()
        {
            InitializeComponent();
            loadAllWords();
            ChangeLabelNumberOfCurrentWord(takeTheNumberOfCurrentWordFromFile());
            ChangeLabelTheWord();       
            showDataGridViewes(words, takeTheNumberOfCurrentWordFromFile());          
        }
        
        private int takeTheNumberOfCurrentWordFromFile()//извлекает из файла номер слова, на котором остановилось редактирование
        {           
            StreamReader sr = new StreamReader("numberOfCurrentWord.txt");
            int numOfCurrentWord = int.Parse( sr.ReadLine());        
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
        }//меняет номер слова в окне

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
            return word.lemma;
        }//вытаскивает из списка всех слов, то, которое нам нужно

        private void ChangeLabelTheWord()//меняет слово в окне
        {
           string theWord = WhichWordShow(takeTheNumberOfCurrentWordFromFile());
           this.labelTheWord.Text = theWord;                          
        }      
     
        private void buttonRight_Click(object sender, EventArgs e)//действия при нажатии на стрелку вправо
        {
            int i = NomberOfWord(int.Parse(labelNumberOfCurrentWord.Text), 1);
            labelNumberOfCurrentWord.Text = i.ToString();
            ChangeLabelTheWord();        
           
            showDataGridViewes(words, takeTheNumberOfCurrentWordFromFile());         
        }
        private void buttonLeft_Click(object sender, EventArgs e)//действия при нажатии на стрелку влево
        {
            int i = NomberOfWord(int.Parse(labelNumberOfCurrentWord.Text), -1);
            labelNumberOfCurrentWord.Text = i.ToString();
            ChangeLabelTheWord();        
            showDataGridViewes(words, takeTheNumberOfCurrentWordFromFile());         
        }
    
        private void loadAllWords()//выгружает слова из xml файла в список
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("osetExamples.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"

            XmlNodeList allSense;
            int count = 0;
            foreach (XmlNode entry in nodes)
            {
                Word word = new Word();
                word.lemma = entry.SelectSingleNode("form/orth").InnerText;

                count++;
                if (count == 100) break;
                allSense = entry?.SelectNodes("sense");
                for (int i = 0; i < allSense.Count; i++)
                {
                    Sense sense = new Sense();
                    word.allSenses.Add(sense);
                }
                XmlNodeList cits;

                int indexOfSense = -1;
                foreach (XmlNode oneSense in allSense)
                {
                    indexOfSense++;
                    cits = oneSense.SelectNodes("cit");
                    foreach (XmlNode item in cits)
                    {
                        if (item.Attributes["type"].Value == "translationEquivalent")
                            word.AddTrans(indexOfSense, item.InnerText);
                        if (item.Attributes["type"].Value == "example")
                        {
                            word.AddExample(indexOfSense, item.SelectSingleNode("quote").InnerText);
                            word.AddTransOfExample(indexOfSense, item.LastChild.InnerText);
                        }
                    }
                }
                words.addToAllWords(word);
            }
        }

        private void showDataGridViewes(Words words, int i)//выводит информацию о слове из списка слов в две таблицы
        {
            removeAllRows();        
            dataGridView1.Columns.Add("Trans", "Перевод");         
            dataGridView2.Columns.Add("Examp", "Пример");
            dataGridView2.Columns.Add("Trans", "Перевод");
            Word word = words.allWords[i - 1];
            foreach (Sense sense in word.allSenses)
            {
                foreach (string trans in sense.translationsOfSense)
                {
                    dataGridView1.Rows.Add(trans);
                }
                for (int k = 0; k < sense.examples.Count; k++)
                {
                    dataGridView2.Rows.Add(sense.examples[k], sense.translationsOfExamples[k]);
                }
            }
        }      
        
        private void removeAllRows()
        {

            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Columns.Clear();
        }//удаляет все строки и столбцы обеих таблиц перед внесением информации о новом слове

        void dataGridView1_AddRow(int positionRow, string newText)//сохраняет новую строку перевода значения
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)//сохраняет изменения данных о переводе слова из левой таблицы
        {
            int i = takeTheNumberOfCurrentWordFromFile();        
            Word word = new Word(); // должны взять текушее слово, а не создавать новое
            word = words.GetWordByIndex(i - 1);
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

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)//сохраняет изменения данных о примере употребления слова из правой таблицы(недоработано)
        {
            int positionRow = dataGridView2.CurrentCell.RowIndex;
            int positionColumn = dataGridView2.CurrentCell.ColumnIndex;       
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
                    }
                }
                else k++;
            }
        }        
    }
}
