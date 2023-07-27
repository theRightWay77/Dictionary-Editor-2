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
using static System.Windows.Forms.TabControl;


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
            int numOfCurrentWord = int.Parse(sr.ReadLine());
            sr.Close();
            return numOfCurrentWord;
        }

        private int NomberOfWord(int i, int WhereToGo)//меняет номер текущего слова по нажатию стрелок
        {
            //надо добавить ограничения: нельзя долистать до -1 и до 11 489
            //добавить: самому ввести число и перенестить к этому слову
            // string text = (i + WhereToGo).ToString() + Environment.NewLine;
            int num = i + WhereToGo;
            if (num < 1) num = 1;
            string text = num.ToString();

            File.WriteAllText("numberOfCurrentWord.txt", text);
            return (i + WhereToGo);
        }

        private void ChangeLabelNumberOfCurrentWord(int i)
        {
            labelNumberOfCurrentWord.Text = i.ToString();
        }

        private string WhichWordShow(int i)//вытаскивает из списка всех слов, то, которое нам нужно
        {
            Word word = words.GetWordByIndex(i - 1);
            return word.lemma;
        }

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
            //showDataGridViewes(words, takeTheNumberOfCurrentWordFromFile());
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

            for (int t = 0; t < word.allSenses.Count; t++)
            {
                TabPage newTabPage = new TabPage();

                newTabPage.Text = (t + 1).ToString();
                tabControl1.TabPages.Add(newTabPage);
                DataGridView dataGridView3 = new DataGridView();
                dataGridView3.AllowUserToResizeColumns = false;
                dataGridView3.AllowUserToResizeRows = false;
                dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
                dataGridView3.BackgroundColor = System.Drawing.SystemColors.ControlLight;
                dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
                dataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
                dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridView3.Location = new System.Drawing.Point(12, 12);
                dataGridView3.Name = "dataGridView3";
                dataGridView3.RowHeadersVisible = false;
                dataGridView3.RowHeadersWidth = 51;
                dataGridView3.RowTemplate.Height = 24;
                dataGridView3.Size = new System.Drawing.Size(200, 284);
                dataGridView3.TabIndex = 10;
                dataGridView3.Columns.Add("Trans", "Перевод");
                DataGridView dataGridView4 = new DataGridView();
                dataGridView4.AllowUserToResizeColumns = false;
                dataGridView4.AllowUserToResizeRows = false;
                dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
                dataGridView4.BackgroundColor = System.Drawing.SystemColors.ControlLight;
                dataGridView4.BorderStyle = System.Windows.Forms.BorderStyle.None;
                dataGridView4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
                dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridView4.Location = new System.Drawing.Point(220, 12);
                dataGridView4.Name = "dataGridView3";
                dataGridView4.RowHeadersVisible = false;
                dataGridView4.RowHeadersWidth = 51;
                dataGridView4.RowTemplate.Height = 24;
                dataGridView4.Size = new System.Drawing.Size(366, 284);
                dataGridView4.TabIndex = 10;
                dataGridView4.Columns.Add("Examp", "Пример");
                dataGridView4.Columns.Add("Trans", "Перевод");
                foreach (string text in word.allSenses[t].translationsOfSense)
                {
                    newTabPage.Controls.Add(dataGridView3);
                    //  newTabPage.Controls.Add(dataGridView4);

                    dataGridView3.Rows.Add(text);
                }
                for (int q = 0; q < word.allSenses[t].examples.Count; q++)
                {

                    newTabPage.Controls.Add(dataGridView4);

                    dataGridView4.Rows.Add(word.allSenses[t].examples[q], word.allSenses[t].translationsOfExamples[q]);
                    // dataGridView4.Rows.Add(word.allSenses[t].translationsOfExamples[q]);
                }
                if (word.allSenses[t].examples.Count == 0) newTabPage.Controls.Add(dataGridView4);


                string newdata;
                int indexOfRow;
                int indexOfTab;

                // DataGridViewCellEventHandler cellValueChanged = dataGridView3.CellValueChanged;
                dataGridView3.CellValueChanged += (sender, e) => {

                    newdata = dataGridView3.CurrentCell.Value.ToString();
                    indexOfRow = dataGridView3.CurrentCell.RowIndex;
                    indexOfTab = tabControl1.SelectedIndex;
                    CellValueChanged(word, newdata, indexOfRow, indexOfTab);
                    MessageBox.Show("изменения сохранены");
                };

                string newdata2;
                int indexOfRow2;
                int indexOfTab2;
                bool examOrTrans;
                dataGridView4.CellValueChanged += (sender, e) => {
                    newdata2 = dataGridView4.CurrentCell.Value.ToString();
                    if (dataGridView4.CurrentCell.ColumnIndex == 0)
                    {
                        examOrTrans = true;
                    }
                    else examOrTrans = false;
                    indexOfRow2 = dataGridView4.CurrentCell.RowIndex;
                    indexOfTab2 = tabControl1.SelectedIndex;
                    CellValueChanged2(word, newdata2, indexOfRow2, indexOfTab2, examOrTrans);
                    MessageBox.Show("изменения сохранены");
                };
                Console.WriteLine("yup");
                // TabPageCollection
            }

        }


        private void removeAllRows()//удаляет все строки и столбцы обеих таблиц перед внесением информации о новом слове
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Columns.Clear();

            tabControl1.TabPages.Clear();
        }

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




        private void CellValueChanged(Word word, string newdata, int indexOfRow, int indexOfTab)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("osetExamples.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList allEntrys = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"
            XmlNode currentWord = allEntrys[takeTheNumberOfCurrentWordFromFile() - 1];

            XmlNodeList allSense; //все значения нашего слова
            XmlNodeList allCits; //нужный сит


            allSense = currentWord?.SelectNodes("sense");
            allCits = allSense[indexOfTab].SelectNodes("cit");

            allCits[indexOfRow].SelectSingleNode("form/orth").InnerText = newdata;

            xDoc.Save("osetExamples.xml");
            // loadAllWords();
        }

        private void CellValueChanged2(Word word, string newdata, int indexOfRow, int indexOfTab, bool examOrTrans)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("osetExamples.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList allEntrys = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"
            XmlNode currentWord = allEntrys[takeTheNumberOfCurrentWordFromFile() - 1];

            XmlNodeList allSense; //все значения нашего слова                                
            List<XmlNode> allCitsExamp = new List<XmlNode>();

            allSense = currentWord?.SelectNodes("sense");

            foreach (XmlNode cit in allSense[indexOfTab])
            {
                if (cit.Attributes["type"].Value == "example")
                    allCitsExamp.Add(cit);
            }


            //if (allCits[indexOfRow].SelectSingleNode("form/orth").Attributes["type"].Value == "translationEquivalent") Console.WriteLine("yup");
            //allCits[indexOfRow].SelectSingleNode("form/orth").Attributes["type"].Value = newdata;

            if (examOrTrans == true)
                allCitsExamp[indexOfRow].SelectSingleNode("quote").InnerText = newdata;
            else allCitsExamp[indexOfRow].SelectSingleNode("cit/quote").InnerText = newdata;

            xDoc.Save("osetExamples.xml");
            // loadAllWords();
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)//сохраняет изменения данных о примере употребления слова из правой таблицы(недоработано)
        {
            //int positionRow = dataGridView2.CurrentCell.RowIndex;
            //int positionColumn = dataGridView2.CurrentCell.ColumnIndex;       
            //string newText = dataGridView2.CurrentCell.Value.ToString();
            //int i = takeTheNumberOfCurrentWordFromFile();
            //Word word = new Word(); // должны взять текушее слово, а не создавать новое
            //word = words.GetWordByIndex(i - 1);        

            //XmlDocument xDoc = new XmlDocument();
            //xDoc.Load("osetExamples.xml");
            //XmlElement xRoot = xDoc.DocumentElement;
            //XmlNodeList nodes = xRoot.SelectNodes("*"); // выбор всех дочерних узлов "entry"           
            //int indexOfTransl = 0;
            //bool wasChanged = false;
            //int k = 0;
            //bool examOrTrans = false;
            //foreach (XmlNode node in nodes)
            //{
            //    if (wasChanged == true) break;
            //    if (k == i)
            //    {
            //        foreach (XmlNode childrenOfEntry in node)
            //        {
            //            if (wasChanged == true) break;
            //            if (childrenOfEntry.Name == "sense")
            //            {
            //                if (indexOfTransl == positionRow)
            //                {
            //                    foreach (XmlNode citsOfSense in childrenOfEntry)
            //                    {
            //                        foreach (XmlNode formOfSit in citsOfSense)
            //                        {
            //                            if (wasChanged == true) break;
            //                            if (positionColumn != 1)
            //                            {
            //                                if (formOfSit.Name == "quote")
            //                                {
            //                                    if (examOrTrans == false)
            //                                    {                                                
            //                                        words.ChangeKey(word, formOfSit.InnerText, newText);
            //                                        formOfSit.InnerText = newText;
            //                                        examOrTrans = true;
            //                                        wasChanged = true;
            //                                        xDoc.Save("osetExamples.xml");
            //                                    }
            //                                }
            //                                else break;
            //                            }
            //                            else
            //                            if (formOfSit.Name == "cit")
            //                            {
            //                                words.ChangeValue(word, formOfSit.InnerText, newText);
            //                                formOfSit.InnerText = newText;
            //                                examOrTrans = true;
            //                                wasChanged = true;
            //                                xDoc.Save("osetExamples.xml");
            //                            }
            //                        }
            //                    }
            //                }
            //                else
            //                { indexOfTransl++; continue; }                           
            //            }                     
            //        }
            //    }
            //    else k++;
            //}
        }
    }
}
