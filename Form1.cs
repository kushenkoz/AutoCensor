using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace AutoCensorship
{
    public partial class Form1 : Form
    {
        private bool isDarkTheme = false;
        private string replacedWordsInfo = "";
        private string[] wordsToCensorFromFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private void btnSelectCensorFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Техстовые файлы (*.txt)|*.txt|Censor-файлы (*.censor)|*.censor|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtCensorFilePath.Text = openFileDialog.FileName;

                if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".censor")
                {
                    LoadCensorWordsFromFile(openFileDialog.FileName);
                }
            }
        }

        private void LoadCensorWordsFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length > 0)
            {
                if (Path.GetExtension(filePath).ToLower() == ".censor")
                {
                    char separator = lines[0][0];
                    wordsToCensorFromFile = lines.Skip(1)
                                                 .SelectMany(line => line.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries))
                                                 .ToArray();
                }
                else
                {
                    wordsToCensorFromFile = lines;
                }

                txtWordsToCensor.Text = string.Join(Environment.NewLine, wordsToCensorFromFile);
            }
        }

        private void btnCensor_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            string[] wordsToCensor;

            // Если выбран файл со словами для цензуры, использовать его, иначе использовать слова из текстового поля
            if (!string.IsNullOrEmpty(txtCensorFilePath.Text))
            {
                // Проверяем, существует ли файл
                if (!File.Exists(txtCensorFilePath.Text))
                {
                    MessageBox.Show("Файл со словами для цензуры не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Загружаем слова из файла
                LoadCensorWordsFromFile(txtCensorFilePath.Text);
                wordsToCensor = wordsToCensorFromFile;
            }
            else
            {
                wordsToCensor = txtWordsToCensor.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            }

            // Проверка, что массив не является нулевым
            if (wordsToCensor != null)
            {
                // Проверка на наличие пробелов в словах для цензуры
                foreach (var word in wordsToCensor)
                {
                    if (word.Contains(" "))
                    {
                        MessageBox.Show("Пожалуйста, уберите пробелы из списка слов для цензуры.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите слова для цензуры или выберите файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);

                // Проверка, что список цензурируемых слов не пустой
                if (wordsToCensor.Length > 0)
                {
                    foreach (var word in wordsToCensor)
                    {

                        string pattern = $@"\b{Regex.Escape(word)}\b";
                        fileContent = Regex.Replace(fileContent, pattern, new string('*', word.Length));
                        listBoxReplacedWords.Items.Add($"Слово '{word}' заменено ");

                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите в исходный файл какие-либо слова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Сохраняем файл автоматически, перезаписывая его
                File.WriteAllText(filePath, fileContent);
                MessageBox.Show("Файл успешно цензурирован и сохранен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReplacedWords.Text = replacedWordsInfo;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnChangeTheme_Click(object sender, EventArgs e)
        {
            // Переключаем тему
            isDarkTheme = !isDarkTheme;

            // Если установлена темная тема
            if (isDarkTheme)
            {
                // Изменяем цвета для темной темы
                this.BackColor = Color.FromArgb(45, 45, 48);
                txtFilePath.ForeColor = txtCensorFilePath.ForeColor = txtWordsToCensor.ForeColor = Color.White;
                txtFilePath.BackColor = txtCensorFilePath.BackColor = txtWordsToCensor.BackColor = Color.FromArgb(69, 69, 74);
                btnSelectFile.BackColor = btnSelectCensorFile.BackColor = btnCensor.BackColor = btnChangeTheme.BackColor = Color.FromArgb(69, 69, 74);
                btnSelectFile.ForeColor = btnSelectCensorFile.ForeColor = btnCensor.ForeColor = btnChangeTheme.ForeColor = Color.White;
                btnChangeTheme.Text = "Светлая тема"; // Изменяем текст кнопки
                listBoxReplacedWords.BackColor = Color.FromArgb(69, 69, 74); // Добавляем цвет для списка замененных слов
                listBoxReplacedWords.ForeColor = Color.White; // Добавляем цвет для текста в списке замененных слов
                btnHelp.BackColor = Color.FromArgb(69, 69, 74); // Изменяем цвет кнопки "Справка"
                btnHelp.ForeColor = Color.White; // Изменяем цвет текста кнопки "Справка"
            }
            else // В противном случае возвращаем светлую тему
            {
                this.BackColor = SystemColors.Control;
                txtFilePath.ForeColor = txtCensorFilePath.ForeColor = txtWordsToCensor.ForeColor = SystemColors.ControlText;
                txtFilePath.BackColor = txtCensorFilePath.BackColor = txtWordsToCensor.BackColor = SystemColors.Window;
                btnSelectFile.BackColor = btnSelectCensorFile.BackColor = btnCensor.BackColor = btnChangeTheme.BackColor = SystemColors.Control;
                btnSelectFile.ForeColor = btnSelectCensorFile.ForeColor = btnCensor.ForeColor = btnChangeTheme.ForeColor = SystemColors.ControlText;
                btnChangeTheme.Text = "Тёмная тема"; // Изменяем текст кнопки
                listBoxReplacedWords.BackColor = SystemColors.Window; // Возвращаем цвет по умолчанию для списка замененных слов
                listBoxReplacedWords.ForeColor = SystemColors.ControlText; // Возвращаем цвет по умолчанию для текста в списке замененных слов
                btnHelp.BackColor = SystemColors.Control; // Возвращаем цвет кнопки "Справка"
                btnHelp.ForeColor = SystemColors.ControlText; // Возвращаем цвет текста кнопки "Справка"
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpText = "AutoCensor\n\n\n" +
                              "В первой строке выбирается файл, который необходимо подвергнуть цензуре.\n\n" +
                              "Во второй строке выбирается файл, из которого необходимо брать слова, которые необходимо подвергнуть цензуре.\nЕсли файл имеет расширение .censor, то первая строка является разделителем всех последующих слов. По умолчанию разделителем является Enter (символ новой строки).\n\n" +
                              "Также, можно вводить слова вручную, нажимая Enter для разделения слов. Слова не должны содержать пробелы.\n\n" +
                              "Для смены темы, нажмите на соответствующую кнопку.";

            MessageBox.Show(helpText, "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
