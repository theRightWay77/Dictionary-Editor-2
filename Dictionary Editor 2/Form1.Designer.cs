
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTheWord = new System.Windows.Forms.Label();
            this.pictureBoxToLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxToRight = new System.Windows.Forms.PictureBox();
            this.labelCountOfWords = new System.Windows.Forms.Label();
            this.labelNumberOfCurrentWord = new System.Windows.Forms.Label();
            this.dataGridViewExamplesAndTranslationsForOneSense = new System.Windows.Forms.DataGridView();
            this.Перевод = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Пример = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTranslationsOfOneSense = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExamplesAndTranslationsForOneSense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTranslationsOfOneSense)).BeginInit();
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
            // pictureBoxToLeft
            // 
            this.pictureBoxToLeft.Image = global::Dictionary_Editor_2.Properties.Resources.кнопкаСтрелка2;
            this.pictureBoxToLeft.Location = new System.Drawing.Point(93, 12);
            this.pictureBoxToLeft.Name = "pictureBoxToLeft";
            this.pictureBoxToLeft.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxToLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxToLeft.TabIndex = 2;
            this.pictureBoxToLeft.TabStop = false;
            this.pictureBoxToLeft.Click += new System.EventHandler(this.pictureBoxToLeft_Click);
            // 
            // pictureBoxToRight
            // 
            this.pictureBoxToRight.Image = global::Dictionary_Editor_2.Properties.Resources.кнопкаСтрелка;
            this.pictureBoxToRight.Location = new System.Drawing.Point(599, 12);
            this.pictureBoxToRight.Name = "pictureBoxToRight";
            this.pictureBoxToRight.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxToRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxToRight.TabIndex = 1;
            this.pictureBoxToRight.TabStop = false;
            this.pictureBoxToRight.Click += new System.EventHandler(this.pictureBoxToRight_Click);
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
            // dataGridViewExamplesAndTranslationsForOneSense
            // 
            this.dataGridViewExamplesAndTranslationsForOneSense.AllowUserToResizeColumns = false;
            this.dataGridViewExamplesAndTranslationsForOneSense.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewExamplesAndTranslationsForOneSense.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewExamplesAndTranslationsForOneSense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExamplesAndTranslationsForOneSense.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewExamplesAndTranslationsForOneSense.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewExamplesAndTranslationsForOneSense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewExamplesAndTranslationsForOneSense.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewExamplesAndTranslationsForOneSense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExamplesAndTranslationsForOneSense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Перевод,
            this.Пример});
            this.dataGridViewExamplesAndTranslationsForOneSense.Location = new System.Drawing.Point(422, 132);
            this.dataGridViewExamplesAndTranslationsForOneSense.Name = "dataGridViewExamplesAndTranslationsForOneSense";
            this.dataGridViewExamplesAndTranslationsForOneSense.RowHeadersVisible = false;
            this.dataGridViewExamplesAndTranslationsForOneSense.RowHeadersWidth = 51;
            this.dataGridViewExamplesAndTranslationsForOneSense.RowTemplate.Height = 24;
            this.dataGridViewExamplesAndTranslationsForOneSense.Size = new System.Drawing.Size(366, 153);
            this.dataGridViewExamplesAndTranslationsForOneSense.TabIndex = 6;
            // 
            // Перевод
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Перевод.DefaultCellStyle = dataGridViewCellStyle2;
            this.Перевод.HeaderText = "Перевод";
            this.Перевод.MinimumWidth = 6;
            this.Перевод.Name = "Перевод";
            // 
            // Пример
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Пример.DefaultCellStyle = dataGridViewCellStyle3;
            this.Пример.HeaderText = "Пример";
            this.Пример.MinimumWidth = 6;
            this.Пример.Name = "Пример";
            // 
            // dataGridViewTranslationsOfOneSense
            // 
            this.dataGridViewTranslationsOfOneSense.AllowUserToResizeColumns = false;
            this.dataGridViewTranslationsOfOneSense.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTranslationsOfOneSense.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTranslationsOfOneSense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTranslationsOfOneSense.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewTranslationsOfOneSense.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewTranslationsOfOneSense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTranslationsOfOneSense.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewTranslationsOfOneSense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTranslationsOfOneSense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewTranslationsOfOneSense.Location = new System.Drawing.Point(12, 132);
            this.dataGridViewTranslationsOfOneSense.Name = "dataGridViewTranslationsOfOneSense";
            this.dataGridViewTranslationsOfOneSense.RowHeadersVisible = false;
            this.dataGridViewTranslationsOfOneSense.RowHeadersWidth = 51;
            this.dataGridViewTranslationsOfOneSense.RowTemplate.Height = 24;
            this.dataGridViewTranslationsOfOneSense.Size = new System.Drawing.Size(366, 153);
            this.dataGridViewTranslationsOfOneSense.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Перевод";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DIctionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewTranslationsOfOneSense);
            this.Controls.Add(this.dataGridViewExamplesAndTranslationsForOneSense);
            this.Controls.Add(this.labelNumberOfCurrentWord);
            this.Controls.Add(this.labelCountOfWords);
            this.Controls.Add(this.pictureBoxToLeft);
            this.Controls.Add(this.pictureBoxToRight);
            this.Controls.Add(this.labelTheWord);
            this.Name = "DIctionary";
            this.Text = "Dictionary";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExamplesAndTranslationsForOneSense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTranslationsOfOneSense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTheWord;
        private System.Windows.Forms.PictureBox pictureBoxToRight;
        private System.Windows.Forms.PictureBox pictureBoxToLeft;
        private System.Windows.Forms.Label labelCountOfWords;
        private System.Windows.Forms.Label labelNumberOfCurrentWord;
        private System.Windows.Forms.DataGridView dataGridViewExamplesAndTranslationsForOneSense;
        private System.Windows.Forms.DataGridView dataGridViewTranslationsOfOneSense;
        private System.Windows.Forms.DataGridViewTextBoxColumn Перевод;
        private System.Windows.Forms.DataGridViewTextBoxColumn Пример;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}

