
using System.Drawing;
using System.Windows.Forms;

namespace Dictionary_Editor_2
{
    partial class DIctionary
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTheWord = new System.Windows.Forms.Label();
            this.labelCountOfWords = new System.Windows.Forms.Label();
            this.labelNumberOfCurrentWord = new System.Windows.Forms.Label();
            this.gr = new System.Windows.Forms.DataGridView();
            this.Перевод = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Пример = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grr = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTranslationsOfOneSense = new System.Windows.Forms.DataGridView();
            this.dataGridViewExamplesAndTranslationsForOneSense = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTranslationsOfOneSense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExamplesAndTranslationsForOneSense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTheWord
            // 
            this.labelTheWord.AutoSize = true;
            this.labelTheWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTheWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTheWord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTheWord.Location = new System.Drawing.Point(304, 12);
            this.labelTheWord.Name = "labelTheWord";
            this.labelTheWord.Size = new System.Drawing.Size(131, 46);
            this.labelTheWord.TabIndex = 0;
            this.labelTheWord.Text = "слово";
            // 
            // labelCountOfWords
            // 
            this.labelCountOfWords.AutoSize = true;
            this.labelCountOfWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountOfWords.Location = new System.Drawing.Point(362, 58);
            this.labelCountOfWords.Name = "labelCountOfWords";
            this.labelCountOfWords.Size = new System.Drawing.Size(64, 20);
            this.labelCountOfWords.TabIndex = 3;
            this.labelCountOfWords.Text = "/ 11484";
            // 
            // labelNumberOfCurrentWord
            // 
            this.labelNumberOfCurrentWord.AutoSize = true;
            this.labelNumberOfCurrentWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNumberOfCurrentWord.Location = new System.Drawing.Point(308, 58);
            this.labelNumberOfCurrentWord.Name = "labelNumberOfCurrentWord";
            this.labelNumberOfCurrentWord.Size = new System.Drawing.Size(18, 20);
            this.labelNumberOfCurrentWord.TabIndex = 4;
            this.labelNumberOfCurrentWord.Text = "0";
            // 
            // gr
            // 
            this.gr.AllowUserToResizeColumns = false;
            this.gr.AllowUserToResizeRows = false;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black;
            this.gr.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle26;
            this.gr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gr.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gr.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gr.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Перевод,
            this.Пример});
            this.gr.Location = new System.Drawing.Point(422, 132);
            this.gr.Name = "gr";
            this.gr.RowHeadersVisible = false;
            this.gr.RowHeadersWidth = 51;
            this.gr.RowTemplate.Height = 24;
            this.gr.Size = new System.Drawing.Size(366, 153);
            this.gr.TabIndex = 6;
            // 
            // Перевод
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Перевод.DefaultCellStyle = dataGridViewCellStyle27;
            this.Перевод.HeaderText = "Перевод";
            this.Перевод.MinimumWidth = 6;
            this.Перевод.Name = "Перевод";
            // 
            // Пример
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Пример.DefaultCellStyle = dataGridViewCellStyle28;
            this.Пример.HeaderText = "Пример";
            this.Пример.MinimumWidth = 6;
            this.Пример.Name = "Пример";
            // 
            // grr
            // 
            this.grr.AllowUserToResizeColumns = false;
            this.grr.AllowUserToResizeRows = false;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.Black;
            this.grr.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
            this.grr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grr.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grr.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grr.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.grr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.grr.Location = new System.Drawing.Point(12, 132);
            this.grr.Name = "grr";
            this.grr.RowHeadersVisible = false;
            this.grr.RowHeadersWidth = 51;
            this.grr.RowTemplate.Height = 24;
            this.grr.Size = new System.Drawing.Size(366, 153);
            this.grr.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridViewTextBoxColumn2.HeaderText = "Перевод";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTranslationsOfOneSense
            // 
            this.dataGridViewTranslationsOfOneSense.AllowUserToResizeColumns = false;
            this.dataGridViewTranslationsOfOneSense.AllowUserToResizeRows = false;
            this.dataGridViewTranslationsOfOneSense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTranslationsOfOneSense.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewTranslationsOfOneSense.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewTranslationsOfOneSense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTranslationsOfOneSense.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewTranslationsOfOneSense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTranslationsOfOneSense.Location = new System.Drawing.Point(12, 132);
            this.dataGridViewTranslationsOfOneSense.Name = "dataGridViewTranslationsOfOneSense";
            this.dataGridViewTranslationsOfOneSense.RowHeadersVisible = false;
            this.dataGridViewTranslationsOfOneSense.RowHeadersWidth = 51;
            this.dataGridViewTranslationsOfOneSense.RowTemplate.Height = 24;
            this.dataGridViewTranslationsOfOneSense.Size = new System.Drawing.Size(366, 284);
            this.dataGridViewTranslationsOfOneSense.TabIndex = 8;
            // 
            // dataGridViewExamplesAndTranslationsForOneSense
            // 
            this.dataGridViewExamplesAndTranslationsForOneSense.AllowUserToResizeColumns = false;
            this.dataGridViewExamplesAndTranslationsForOneSense.AllowUserToResizeRows = false;
            this.dataGridViewExamplesAndTranslationsForOneSense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExamplesAndTranslationsForOneSense.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewExamplesAndTranslationsForOneSense.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewExamplesAndTranslationsForOneSense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewExamplesAndTranslationsForOneSense.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewExamplesAndTranslationsForOneSense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExamplesAndTranslationsForOneSense.Location = new System.Drawing.Point(422, 132);
            this.dataGridViewExamplesAndTranslationsForOneSense.Name = "dataGridViewExamplesAndTranslationsForOneSense";
            this.dataGridViewExamplesAndTranslationsForOneSense.RowHeadersVisible = false;
            this.dataGridViewExamplesAndTranslationsForOneSense.RowHeadersWidth = 51;
            this.dataGridViewExamplesAndTranslationsForOneSense.RowTemplate.Height = 24;
            this.dataGridViewExamplesAndTranslationsForOneSense.Size = new System.Drawing.Size(366, 284);
            this.dataGridViewExamplesAndTranslationsForOneSense.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(366, 284);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowContextMenuStripChanged += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_RowContextMenuStripChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(422, 132);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(366, 284);
            this.dataGridView2.TabIndex = 11;
            this.dataGridView2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellValueChanged);
            // 
            // buttonRight
            // 
            this.buttonRight.BackColor = System.Drawing.Color.Transparent;
            this.buttonRight.BackgroundImage = global::Dictionary_Editor_2.Properties.Resources.кнопкаСтрелка;
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRight.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonRight.Location = new System.Drawing.Point(568, 12);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(77, 77);
            this.buttonRight.TabIndex = 0;
            this.buttonRight.UseVisualStyleBackColor = false;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            this.buttonRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DIctionary_KeyDown);
            // 
            // buttonLeft
            // 
            this.buttonLeft.BackgroundImage = global::Dictionary_Editor_2.Properties.Resources.кнопкаСтрелка2;
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLeft.Location = new System.Drawing.Point(109, 6);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(77, 77);
            this.buttonLeft.TabIndex = 0;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            this.buttonLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DIctionary_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(228, 400);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(394, 303);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(48, 43);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(235, 193);
            this.dataGridView3.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.BackgroundImage = global::Dictionary_Editor_2.Properties.Resources.кнопкаСтрелка;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button1.Location = new System.Drawing.Point(628, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 77);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DIctionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridViewExamplesAndTranslationsForOneSense);
            this.Controls.Add(this.dataGridViewTranslationsOfOneSense);
            this.Controls.Add(this.grr);
            this.Controls.Add(this.gr);
            this.Controls.Add(this.labelNumberOfCurrentWord);
            this.Controls.Add(this.labelCountOfWords);
            this.Controls.Add(this.labelTheWord);
            this.Name = "DIctionary";
            this.Text = "Dictionary";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DIctionary_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTranslationsOfOneSense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExamplesAndTranslationsForOneSense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTheWord;
        private System.Windows.Forms.Label labelCountOfWords;
        private System.Windows.Forms.Label labelNumberOfCurrentWord;
        private System.Windows.Forms.DataGridView gr;
        private System.Windows.Forms.DataGridView grr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Перевод;
        private System.Windows.Forms.DataGridViewTextBoxColumn Пример;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridView dataGridViewTranslationsOfOneSense;
        private DataGridView dataGridViewExamplesAndTranslationsForOneSense;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button buttonRight;
        private Button buttonLeft;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button1;
        private DataGridView dataGridView3;
        //public void SettingsOfDataGridView(DataGridView gridView)
        //{
        //    System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();

        //    this.gr.AllowUserToResizeColumns = false;
        //    this.gr.AllowUserToResizeRows = false;
        //    dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
        //    dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
        //    dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
        //    dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
        //    dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
        //    this.gr.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
        //    this.gr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        //    this.gr.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
        //    this.gr.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
        //    this.gr.BorderStyle = System.Windows.Forms.BorderStyle.None;
        //    this.gr.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
        //    this.gr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        //    //this.gr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        //    //this.Перевод});
        //    this.gr.Location = new System.Drawing.Point(12, 132);
        //    this.gr.Name = "gr";
        //    this.gr.RowHeadersVisible = true;
        //    this.gr.RowHeadersWidth = 51;
        //    this.gr.RowTemplate.Height = 24;
        //  //  this.gr.Size = new System.Drawing.Size(366, 153);
        //    this.gr.TabIndex = 6;
        //    int n = 1;
        //    n = gr.Columns.Count;
        //    this.Controls.Add(gr);
        //    gr.width = 266;
        //    gr.height = 153;

        //    gr.left = 12; //x coordinate
        //    gr.top = 132; //y coordinate
        //}
    }
}

