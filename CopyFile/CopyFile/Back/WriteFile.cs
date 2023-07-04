using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CopyFile.Back
{
    public class WriteFile
    {
        public void WriteTxtFile(string TextFile, List<string> notFoundFiles)
        {
            try
            {
                // Записываем данные из списка в файл
                File.WriteAllLines(TextFile, notFoundFiles);
                Console.WriteLine("Данные успешно записаны в файл.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка при записи данных: {e.Message}");
            }
        }
    }
}
