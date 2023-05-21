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
        public DIctionary()
        {
            InitializeComponent();
            ChangeLabelNumberOfCurrentWord(takeTheNumberOfCurrentWordFromFile());
            ChangeLabelTheWord();

            ShowTranslationsOfOneSense();
        }

        private void removeAllRows()
        {
           
            for (int i = 0; i < dataGridViewTranslationsOfOneSense.Rows.Count; i++)
                dataGridViewTranslationsOfOneSense.Rows.Remove(dataGridViewTranslationsOfOneSense.Rows[i]);

        }


        private void ShowTranslationsOfOneSense()
        {
            int i = takeTheNumberOfCurrentWordFromFile();
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
                                this.dataGridViewTranslationsOfOneSense.Rows.Add(citsOfSense.InnerText);
                            }
                            //this.dataGridViewTranslationsOfOneSense.Rows.Add(childrenOfEntry.InnerText);
                            // this.labelTheWord.Text = childrenOfEntry.InnerText;
                            wasChanged = true;
                        }
                       // break;

                    }
                }
                else k++;
            }
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
           // removeAllRows();
            ShowTranslationsOfOneSense();
        }

        private void pictureBoxToLeft_Click(object sender, EventArgs e)
        {
            int i = NomberOfWord(int.Parse(labelNumberOfCurrentWord.Text), -1);
            labelNumberOfCurrentWord.Text = i.ToString();
            ChangeLabelTheWord();
          //  removeAllRows();
            ShowTranslationsOfOneSense();
        }
    }
}
