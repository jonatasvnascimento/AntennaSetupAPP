using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AntennaSetupAPP.Model.modelCNX;

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

            File.WriteAllText($"{newDirectorySave}UHFReader.UHF_cnx", objExport.Text);

        }
        public static void SaveBackup(string path, TextBox objExport)
        {
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Informe o caminho expecifico");
                return;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            string newDirectorySave = $"{directoryInfo.FullName}\\Backup\\";

            if (!Directory.Exists(newDirectorySave))
            {
                Directory.CreateDirectory(newDirectorySave);
            }

            File.WriteAllText($"{newDirectorySave}UHFReader.UHF_cnx", objExport.Text);
        }

        public static CNX JsonToObject()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            string fileDirectory = $"{directoryInfo.FullName}\\Backup\\UHFReader.UHF_cnx";
            string txtCNX = File.ReadAllText(fileDirectory);

            var result = JsonConvert.DeserializeObject<CNX>(txtCNX);
            return result;
        }
    }
}
