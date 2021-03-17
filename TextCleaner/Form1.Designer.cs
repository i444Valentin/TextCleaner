using System;

namespace TextCleaner
{
    partial class MainForm
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
            this.textAreaEdit = new System.Windows.Forms.RichTextBox();
            this.findErrorsButton = new System.Windows.Forms.Button();
            this.findFixErrorsButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // textAreaEdit
            // 
            this.textAreaEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textAreaEdit.Location = new System.Drawing.Point(12, 74);
            this.textAreaEdit.Name = "textAreaEdit";
            this.textAreaEdit.Size = new System.Drawing.Size(675, 184);
            this.textAreaEdit.TabIndex = 0;
            this.textAreaEdit.Text = "";
            // 
            // findErrorsButton
            // 
            this.findErrorsButton.Location = new System.Drawing.Point(142, 273);
            this.findErrorsButton.Name = "findErrorsButton";
            this.findErrorsButton.Size = new System.Drawing.Size(111, 27);
            this.findErrorsButton.TabIndex = 1;
            this.findErrorsButton.Text = "Найти ошибки";
            this.findErrorsButton.UseVisualStyleBackColor = true;
            this.findErrorsButton.Click += new System.EventHandler(this.FindErrorsButton_Click);
            // 
            // findFixErrorsButton
            // 
            this.findFixErrorsButton.Location = new System.Drawing.Point(417, 273);
            this.findFixErrorsButton.Name = "findFixErrorsButton";
            this.findFixErrorsButton.Size = new System.Drawing.Size(166, 27);
            this.findFixErrorsButton.TabIndex = 2;
            this.findFixErrorsButton.Text = "Найти и исправить ошибки";
            this.findFixErrorsButton.UseVisualStyleBackColor = true;
            this.findFixErrorsButton.Click += new System.EventHandler(this.FindFixErrorsButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(12, 12);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(111, 27);
            this.openFileButton.TabIndex = 3;
            this.openFileButton.Text = "Открыть файл...";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(142, 12);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(111, 27);
            this.saveFileButton.TabIndex = 4;
            this.saveFileButton.Text = "Сохранить...";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Текстовые документы|*.txt|Все файлы|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Текстовые документы|*.txt|Все файлы|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(699, 343);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.findFixErrorsButton);
            this.Controls.Add(this.findErrorsButton);
            this.Controls.Add(this.textAreaEdit);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Исправление ошибок";
            this.ResumeLayout(false);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Сlosing);

        }



        #endregion

        private System.Windows.Forms.RichTextBox textAreaEdit;
        private System.Windows.Forms.Button findErrorsButton;
        private System.Windows.Forms.Button findFixErrorsButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

