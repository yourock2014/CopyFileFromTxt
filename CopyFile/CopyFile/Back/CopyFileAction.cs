using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyFile.Back
{
    public class CopyFileAction
    {
        public void CopyFileInFolder(string fromPath, string inPath, string[] fileNameFromTxt, 
                                     System.Windows.Controls.ProgressBar progressBarCopy, 
                                     out int intCopy, out int intNoCopy, out List<string> notFoundFiles)
        {
            int totalCount = fileNameFromTxt.Length;
            int currentCount = 0;
            intCopy = 0;
            intNoCopy = 0;
            notFoundFiles = new List<string>();

            foreach (string lineFileNameFromTxt in fileNameFromTxt)
            {
                DirectoryInfo sourceDir = new DirectoryInfo(fromPath);
                FileInfo[] files = sourceDir.GetFiles($"{lineFileNameFromTxt}.*", SearchOption.TopDirectoryOnly);

                if (files.Length > 0)
                {
                    intCopy++;
                }
                else
                {
                    notFoundFiles.Add(lineFileNameFromTxt); // Добавляем ненайденный файл в список
                }

                foreach (FileInfo file in files)
                {
                    string inFilePath = Path.Combine(inPath, file.Name);
                    string fromFilePath = Path.Combine(fromPath, file.Name);

                    try
                    {
                        // Копируем файл
                        File.Copy(fromFilePath, inFilePath, true);
                        Console.WriteLine("Файл успешно скопирован.");
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine($"Ошибка при копировании файла: {e.Message}");
                    }
                }

                currentCount++;
                int progressPercentage = (int)((double)currentCount / totalCount * 100);
                progressBarCopy.Value = progressPercentage;

                intNoCopy = fileNameFromTxt.Length - intCopy;
                
                Console.WriteLine($"Файлы скопированы: {intCopy}");
                Console.WriteLine($"Файлы не найдены: {intNoCopy}");

            }
        }
    }
}
