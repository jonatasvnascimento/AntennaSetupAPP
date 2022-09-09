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

            //Salvar com SaveFileDialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "UHFReader|*.UHF_cnx", ValidateNames = true })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter textWriter = new StreamWriter(new FileStream(saveFileDialog.FileName, FileMode.Create), Encoding.UTF8))
                    {
                        foreach (var item in objExport.Text)
                        {
                            textWriter.Write($"{item}");
                        }
                        MessageBox.Show("Salvo");
                    }
                }
            }

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
