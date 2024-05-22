namespace AutoCensorship
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtWordsToCensor;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnCensor;
        private System.Windows.Forms.TextBox txtCensorFilePath; // Новое текстовое поле
        private System.Windows.Forms.Button btnSelectCensorFile; // Новая кнопка
        private System.Windows.Forms.Button btnChangeTheme;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox txtReplacedWords;
        private System.Windows.Forms.ListBox listBoxReplacedWords;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtWordsToCensor = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnCensor = new System.Windows.Forms.Button();
            this.txtCensorFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectCensorFile = new System.Windows.Forms.Button();
            this.btnChangeTheme = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.txtReplacedWords = new System.Windows.Forms.TextBox();
            this.listBoxReplacedWords = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtWordsToCensor
            // 
            this.txtWordsToCensor.Location = new System.Drawing.Point(12, 107);
            this.txtWordsToCensor.Multiline = true;
            this.txtWordsToCensor.Name = "txtWordsToCensor";
            this.txtWordsToCensor.Size = new System.Drawing.Size(388, 160);
            this.txtWordsToCensor.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(634, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(114, 22);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Исходный файл";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 12);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(616, 20);
            this.txtFilePath.TabIndex = 2;
            // 
            // btnCensor
            // 
            this.btnCensor.Location = new System.Drawing.Point(322, 78);
            this.btnCensor.Name = "btnCensor";
            this.btnCensor.Size = new System.Drawing.Size(163, 23);
            this.btnCensor.TabIndex = 3;
            this.btnCensor.Text = "Запуск";
            this.btnCensor.UseVisualStyleBackColor = true;
            this.btnCensor.Click += new System.EventHandler(this.btnCensor_Click);
            // 
            // txtCensorFilePath
            // 
            this.txtCensorFilePath.Location = new System.Drawing.Point(12, 49);
            this.txtCensorFilePath.Name = "txtCensorFilePath";
            this.txtCensorFilePath.Size = new System.Drawing.Size(616, 20);
            this.txtCensorFilePath.TabIndex = 4;
            // 
            // btnSelectCensorFile
            // 
            this.btnSelectCensorFile.Location = new System.Drawing.Point(634, 49);
            this.btnSelectCensorFile.Name = "btnSelectCensorFile";
            this.btnSelectCensorFile.Size = new System.Drawing.Size(114, 23);
            this.btnSelectCensorFile.TabIndex = 5;
            this.btnSelectCensorFile.Text = "Файл со словами";
            this.btnSelectCensorFile.UseVisualStyleBackColor = true;
            this.btnSelectCensorFile.Click += new System.EventHandler(this.btnSelectCensorFile_Click);
            // 
            // btnChangeTheme
            // 
            this.btnChangeTheme.Location = new System.Drawing.Point(314, 315);
            this.btnChangeTheme.Name = "btnChangeTheme";
            this.btnChangeTheme.Size = new System.Drawing.Size(86, 23);
            this.btnChangeTheme.TabIndex = 5;
            this.btnChangeTheme.Text = "Тёмная тема";
            this.btnChangeTheme.UseVisualStyleBackColor = true;
            this.btnChangeTheme.Click += new System.EventHandler(this.btnChangeTheme_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(410, 315);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Справка";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // txtReplacedWords
            // 
            this.txtReplacedWords.Location = new System.Drawing.Point(0, 0);
            this.txtReplacedWords.Name = "txtReplacedWords";
            this.txtReplacedWords.Size = new System.Drawing.Size(100, 20);
            this.txtReplacedWords.TabIndex = 0;
            // 
            // listBoxReplacedWords
            // 
            this.listBoxReplacedWords.FormattingEnabled = true;
            this.listBoxReplacedWords.HorizontalScrollbar = true;
            this.listBoxReplacedWords.Location = new System.Drawing.Point(406, 107);
            this.listBoxReplacedWords.Name = "listBoxReplacedWords";
            this.listBoxReplacedWords.Size = new System.Drawing.Size(330, 160);
            this.listBoxReplacedWords.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 350);
            this.Controls.Add(this.btnSelectCensorFile);
            this.Controls.Add(this.txtCensorFilePath);
            this.Controls.Add(this.btnCensor);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtWordsToCensor);
            this.Controls.Add(this.btnChangeTheme);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.listBoxReplacedWords);
            this.Name = "Form1";
            this.Text = "Цензурирование текста";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}