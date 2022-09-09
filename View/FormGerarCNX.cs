using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntennaSetupAPP.View
{
    public partial class FormGerarCNX : Form
    {
        public string pathApplicationSelection { get; set; }
        public string newDirectorySaveUHF { get; set; }
        public string folderConfig { get; set; }
        public FormGerarCNX()
        {
            InitializeComponent();
        }

        private void FormGerarCNX_Load(object sender, EventArgs e)
        {
            getDirectory();
        }

        private void getDirectory()
        {
            try
            {


                List<string> nameApplication = new List<string>();
                List<string> dirApplaication = new List<string>();

                DirectoryInfo DirectoryApplicationInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                string DirectoryApplication = $@"{DirectoryApplicationInfo.Root}\COALARFID";


                if (!Directory.Exists(DirectoryApplication))
                {
                    Directory.CreateDirectory(DirectoryApplication);
                }

                string[] dirs = Directory.GetDirectories(DirectoryApplication);

                foreach (var dir in dirs)
                {
                    var dirNameFolder = dir.Split(@"\");
                    nameApplication.Add(dirNameFolder[3]);
                    dirApplaication.Add(dir);
                }


                for (int i = 0; i < dirs.Length; i++)
                {
                    DirectoryInfo DateModifyandCreate = new DirectoryInfo(dirApplaication[i]);
                    dataGridView1.Rows.Add(new object[] { nameApplication[i], dirApplaication[i], DateModifyandCreate.LastWriteTime, DateModifyandCreate.CreationTime });
                }

                if (dataGridView1.Rows.Count >= 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }


        }
        private void buttonSaveUHF_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(pathApplicationSelection))
                {
                    MessageBox.Show("Selecione um caminho");
                    return;
                }

                DirectoryInfo directoryCurrent = new DirectoryInfo(Directory.GetCurrentDirectory());
                string FileCopyToFolder = $@"{directoryCurrent.FullName}\Backup\UHFReader.UHF_cnx";

                DirectoryInfo directorySave = new DirectoryInfo(pathApplicationSelection);
                string directoryCondig = $@"{directorySave}\config";

                if (!Directory.Exists(directoryCondig))
                {
                    Directory.CreateDirectory(directoryCondig);
                }

                newDirectorySaveUHF = $@"{pathApplicationSelection}\config\UHFReader.UHF_cnx";

                if (File.Exists(newDirectorySaveUHF))
                {
                    File.Delete(newDirectorySaveUHF);
                }

                File.Copy(FileCopyToFolder, newDirectorySaveUHF);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    pathApplicationSelection = row.Cells["Column3"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }

        private void buttonOpenFolderSystem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(pathApplicationSelection))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(pathApplicationSelection);
                    folderConfig = $@"{directoryInfo}\config";
                    labelPathFolder.Text = folderConfig;

                    if (!Directory.Exists(folderConfig))
                    {
                        MessageBox.Show("Diretorio não existe");
                        return;
                    }

                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = folderConfig,
                        UseShellExecute = true,
                        Verb = "open"
                    });

                }
                else
                {
                    MessageBox.Show("Selecione um diretorio");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
           

        }
    }
};