using System;
using System.Drawing;
using System.Windows.Forms;

namespace TextCleaner
{
    public partial class MainForm : Form
    {
        private static string filename = ""; //содержит последний путь до файла
        private static string lastSavedText = ""; //фиксирует последние изменения 
        private static readonly string _SAVE_TEXT_BEFORE_NEW_OPEN_MSG_TEXT = "Сохранить текст перед открытием нового?";
        private static readonly string _SAVE_TEXT_BEFORE_NEW_OPEN_MSG_TITLE = "Сохранение текста";
        private static readonly string _SAVE_TEXT_BEFORE_CLOSE_APP_MSG_TEXT = "Сохранить текст перед закрытием?";
        private static readonly string _COMPLETE_FIX_ERRTEXT_MSG_TEXT = "Исправление ошибок успешно завершено.";
        private static readonly string _ERRTEXT_NO_FOUND_MSG_TEXT = "Повторяющиеся слова не найдены. Все хорошо!";
        private static readonly string _COMPLETE_FIX_ERRTEXT_MSG_TITLE = "Очистка текста завершена";
        public MainForm()
        {
            InitializeComponent();
        }

        /**
        * Отвечает за реакцию на нажатие на кнопку Открыть...
        * 
        * @param sender - базовый класс
        * @param e      - класс, предназначенный для других классов, содержащих данные событий
        * 
        */
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            
            
            if (!textAreaEdit.Text.Equals(lastSavedText))
            {
                DialogResult result = MessageBox.Show(
                    _SAVE_TEXT_BEFORE_NEW_OPEN_MSG_TEXT,
                    _SAVE_TEXT_BEFORE_NEW_OPEN_MSG_TITLE,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                    );
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                if (result == DialogResult.Yes)
                {
                    if (!SaveFile()) return;
                }
            }
            // получаем выбранный файл
            filename = openFileDialog.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textAreaEdit.Text = fileText;
            lastSavedText = textAreaEdit.Text;
        }

        /**
         * Отвечает за реакцию на нажатие на кнопку Сохранить...
         * 
         * @param sender - базовый класс
         * @param e      - класс, предназначенный для других классов, содержащих данные событий
         * 
         */
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /**
         * Основной метод для записи содержимого текстового поля в файл
         * 
         * @return - возвращает состояние выполнения сохранения:
         * true    - сохранение выполнено успешно
         * false   - текст не был сохранен
         * 
         */
        private bool SaveFile()
        {
            if (filename.Equals(""))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return false;
                // получаем выбранный файл
                filename = saveFileDialog.FileName;
                // сохраняем текст в файл

            }
            System.IO.File.WriteAllText(filename, textAreaEdit.Text);
            lastSavedText = textAreaEdit.Text;
            return true;
        }

        //Здесь расположен код для управления содержимым текстового поля

        /**
        * Метод для поиска ошибок в тексте - выделяет слова красным цветом
        * 
        * @param sender - базовый класс
        * @param e      - класс, предназначенный для других классов, содержащих данные событий
        * 
        */
        private void FindErrorsButton_Click(object sender, EventArgs e)
        {
            int pos = 0;
            String text = textAreaEdit.Text;
            String findText = ErrorsFinder.FindErrors(text);
            
            int posTF = 0;
            while (!findText.Equals(""))
            {
                findText = ErrorsFinder.FindErrors(text);
                pos = text.IndexOf(findText);
                if (posTF == 0) posTF = textAreaEdit.Text.IndexOf(findText + findText.Replace(" ", ""), posTF);
                else posTF = textAreaEdit.Text.IndexOf(" " + findText + findText.Replace(" ", ""), posTF) + 1;
                
                textAreaEdit.Select(posTF, findText.Length-1);
                textAreaEdit.SelectionColor = Color.Red;
                text = text.Remove(pos,findText.Length);
            }

        }

        /**
        * Метод для поиска и исправления ошибок в тексте
        * 
        * @param sender - базовый класс
        * @param e      - класс, предназначенный для других классов, содержащих данные событий
        * 
        */
        private void FindFixErrorsButton_Click(object sender, EventArgs e)
        {
            int pos = 0;
            String text = textAreaEdit.Text;
            String findText = ErrorsFinder.FindErrors(text);
            if (findText.Equals(""))
            {
                textAreaEdit.SelectAll();
                textAreaEdit.SelectionColor = Color.Black;
                MessageBox.Show(
                _ERRTEXT_NO_FOUND_MSG_TEXT,
                _COMPLETE_FIX_ERRTEXT_MSG_TITLE,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
                return;
            }
            while (!findText.Equals(""))
            {
                findText = ErrorsFinder.FindErrors(text);
                pos = text.IndexOf(findText + findText.Replace(" ", ""));
                text = text.Remove(pos, findText.Length);
            }
            textAreaEdit.Text = text;

            MessageBox.Show(
                _COMPLETE_FIX_ERRTEXT_MSG_TEXT,
                _COMPLETE_FIX_ERRTEXT_MSG_TITLE,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }

        /**
        * Вызывается при закрытии приложения
        * 
        * @param sender - базовый класс
        * @param e      - класс, предназначенный для других классов, содержащих данные событий (конкретно - для класса FormClosingEventArgs)
        * 
        */
        private void MainForm_Сlosing(object sender, FormClosingEventArgs e)
        {
            if (!textAreaEdit.Text.Equals(lastSavedText))
            {
                DialogResult result = MessageBox.Show(
                    _SAVE_TEXT_BEFORE_CLOSE_APP_MSG_TEXT,
                    _SAVE_TEXT_BEFORE_NEW_OPEN_MSG_TITLE,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                    );
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                if (result == DialogResult.Yes)
                {
                    if (!SaveFile())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
    }
}