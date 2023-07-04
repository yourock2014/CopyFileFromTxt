using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFile.Back
{
    public class ScanFile
    {
        public string[] ScanFileInMass(string filePath)
        {
            string[] fileNameFromTxt = File.ReadAllLines(filePath);
            return fileNameFromTxt;
        }
    }
}
