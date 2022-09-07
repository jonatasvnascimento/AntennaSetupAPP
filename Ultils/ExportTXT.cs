﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntennaSetupAPP.Ultils
{
    static class ExportTXT
    {
        public static void ExportJsonToTxt(string path, TextBox objExport)
        {
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Informe o caminho expecifico");
                return;
            }

            // get directory root
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            string root = directoryInfo.Root.ToString();
            
            string newDirectorySave = $"{root}\\COALARFID\\TESTE\\";

            if (!Directory.Exists(newDirectorySave))
            {
                Directory.CreateDirectory(newDirectorySave);
            }


            //using (TextWriter textWriter = new StreamWriter(new FileStream($"{newDirectorySave}UHFReader.UHF_cnx", FileMode.Create), Encoding.UTF8))
            //{
            //    foreach (var item in objExport.Text)
            //    {
            //        textWriter.Write($"{item}");
            //    }
            //    MessageBox.Show("Salvo");
            //}

            File.WriteAllText($"{newDirectorySave}_teste.txt", objExport.Text);

            

        }
    }
}
