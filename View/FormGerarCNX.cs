﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
;