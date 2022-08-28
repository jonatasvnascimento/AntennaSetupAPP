using System;
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

            string newDirectorySave = $"{path}\\COALARFID\\TESTE";

            if (!Directory.Exists(newDirectorySave))
            {
                Directory.CreateDirectory(newDirectorySave);
            }

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
    }
}
