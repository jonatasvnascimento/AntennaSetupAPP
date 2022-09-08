using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntennaSetupAPP.View
{
    public partial class FormGerarCNX : Form
    {
        public FormGerarCNX()
        {
            InitializeComponent();
            dataGridView1.Rows.Add(new object[] { "select True", "ASSOCIAÇÃO", "C/COALARFID",   "Arquivo criado","Teste OK" });
            dataGridView1.Rows.Add(new object[] { "select True", "MERCADO", "C/COALARFID",      "Arquivo criado","Teste OK" });
            dataGridView1.Rows.Add(new object[] { "select True", "SCANOUT", "C/COALARFID",      "Arquivo criado","Teste OK" });
            dataGridView1.Rows.Add(new object[] { "select True", "WRITETAG", "C/COALARFID",     "Arquivo criado","Teste OK" });
        }

        private void FormGerarCNX_Load(object sender, EventArgs e)
        {
           
        }
    }
}
