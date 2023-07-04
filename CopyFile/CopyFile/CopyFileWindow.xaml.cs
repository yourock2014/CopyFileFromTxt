using CopyFile.Back;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CopyFile
{
    /// <summary>
    /// Логика взаимодействия для CopyFileWindow.xaml
    /// </summary>
    public partial class CopyFileWindow : Window
    {
        public string TextFile;
        public string TextFromPath;
        public string TextInPath;

        public CopyFileWindow()
        {
            InitializeComponent();
        }

        private void ButtonFile_Click(object sender, RoutedEventArgs e)
        {
            PickFile pickFile = new PickFile();
            TextBoxFile.Text = pickFile.ChoiсeFile();
        }

        private void ButtonFromPath_Click(object sender, RoutedEventArgs e)
        {
            PickPath pickPath = new PickPath();
            TextBoxFromPath.Text = pickPath.ChoiсePath();
        }

        private void ButtonInPath_Click(object sender, RoutedEventArgs e)
        {
            PickPath pickPath = new PickPath();
            TextBoxInPath.Text = pickPath.ChoiсePath();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxFile.Text != "" && TextBoxFromPath.Text != "" && TextBoxInPath.Text !="" )
            {
                ScanFile scanFile = new ScanFile();
                string[] fileNameFromTxt = scanFile.ScanFileInMass(TextBoxFile.Text);

                CopyFileAction copyFileAction = new CopyFileAction();
                copyFileAction.CopyFileInFolder(TextBoxFromPath.Text, TextBoxInPath.Text, fileNameFromTxt, ProgressBarCopy, out int intCopy, out int intNoCopy, out List<string> notFoundFiles);

                WriteFile writeFile = new WriteFile();
                writeFile.WriteTxtFile(TextBoxFile.Text, notFoundFiles);

                string message = $"Файлы скопированы: {intCopy}\nФайлы не найдены: {intNoCopy}";
                string caption = "Результат копирования файлов";
                System.Windows.Forms.MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
