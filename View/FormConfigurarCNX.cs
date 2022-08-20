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
    public partial class FormConfigurarCNX : Form
    {
        public FormConfigurarCNX()
        {
            InitializeComponent();
        }

        private void FormConfigurarCNX_Load(object sender, EventArgs e)
        {
            LoadValuesCNX();
        }

        private void LoadValuesCNX()
        {
            checkBoxTMR.Checked = true;

            textBoxName.Text = "EDGE50AID";
            textBoxIPAddress.Text = "";

            comboBoxIPPort.Items.Add("5084");
            comboBoxIPPort.Items.Add("8081");
            comboBoxIPPort.Text = comboBoxIPPort.Items[0].ToString();

            comboBoxIPPortA.Items.Add("5085");
            comboBoxIPPortA.Text = comboBoxIPPortA.Items[0].ToString();

            comboBoxComPort.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", });
            comboBoxComPort.Text = comboBoxComPort.Items[0].ToString();

            comboBoxInitialBaudRate.Items.Add("115200");
            comboBoxInitialBaudRate.Text = comboBoxInitialBaudRate.Items[0].ToString();

            comboBoxFinalBaudRate.Items.Add("FinalBaudRate");
            comboBoxFinalBaudRate.Text = comboBoxFinalBaudRate.Items[0].ToString();

            textBoxKanbanAntenaList1.Text = "1";
            textBoxKanbanAntenaList2.Text = "2";
            textBoxKanbanAntenaList3.Text = "0";
            textBoxKanbanAntenaList4.Text = "0";

            textBoxPositionAntenaList1.Text = "1";
            textBoxPositionAntenaList2.Text = "2";
            textBoxPositionAntenaList3.Text = "2";
            textBoxPositionAntenaList4.Text = "4";

            textBoxDirectionAntenaList1.Text = "1";
            textBoxDirectionAntenaList2.Text = "1";
            textBoxDirectionAntenaList3.Text = "2";
            textBoxDirectionAntenaList4.Text = "2";

            textBoxAliveTagList.Text = "300ED89F3350008CCCD16C71";

            textBoxImproperTagList.Text = "E0AABBBBFF00002222AAAAAA,E0AABBBBFF00002222AAAAAB,E0AABBBBFF00002222AAAAAC";

            radioButtonSendAlwaysReadTagsFalse.Checked = true;

            textBoxSpecialParameter.Text = "SINGLE";

            comboBoxSupplier.Items.Add("UHF_ThingMagic");
            comboBoxSupplier.Text = comboBoxSupplier.Items[0].ToString();





        }
    }
}
