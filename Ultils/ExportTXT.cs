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

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            string root = directoryInfo.Root.ToString();
            string newDirectorySave = $"{root}\\COALARFID\\TESTE";

            if (!Directory.Exists(newDirectorySave))
            {
                Directory.CreateDirectory(newDirectorySave);
            }

            FileStream fs = new FileStream(newDirectorySave, FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fs))
            {
                using (StreamWriter sw = new StreamWriter(newDirectorySave))
                {
                    sw.WriteLine(objExport.Text);
                }
            }

        }
    }
}
