
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
            this.labelTheWord = new System.Windows.Forms.Label();
            this.labelCountOfWords = new System.Windows.Forms.Label();
            this.labelNumberOfCurrentWord = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTheWord
            // 
            this.labelTheWord.AutoSize = true;
            this.labelTheWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTheWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTheWord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTheWord.Location = new System.Drawing.Point(295, 12);
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
            // 
            // buttonRight
            // 
            this.buttonRight.BackColor = System.Drawing.Color.Transparent;
            this.buttonRight.BackgroundImage = global::Dictionary_Editor_2.Properties.Resources.кнопкаСтрелка;
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRight.Location = new System.Drawing.Point(589, 12);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(77, 77);
            this.buttonRight.TabIndex = 0;
            this.buttonRight.UseVisualStyleBackColor = false;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
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
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 107);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 331);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(781, 314);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DIctionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelNumberOfCurrentWord);
            this.Controls.Add(this.labelCountOfWords);
            this.Controls.Add(this.labelTheWord);
            this.Name = "DIctionary";
            this.Text = "Dictionary";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTheWord;
        private System.Windows.Forms.Label labelCountOfWords;
        private System.Windows.Forms.Label labelNumberOfCurrentWord;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button buttonRight;
        private Button buttonLeft;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
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

