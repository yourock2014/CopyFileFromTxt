using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyFile.Back
{
    public class PickPath
    {
        public string ChoiсePath()
        {
            string textPath = "";
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                // Показать окно выбора папки
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;
                    textPath = selectedPath;
                }
            }
            return textPath;
        }
    }
}
