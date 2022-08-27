using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static AntennaSetupAPP.Model.modelCNX;

namespace AntennaSetupAPP.View
{
    public partial class FormConfigurarCNX : Form
    {
        string vConnectionMode = "TMR";
        string vName;
        string vIPAddress;
        string vIPPort;
        string vIPPortA;
        string vComPort;
        string vInitialBaudRate;
        string vFinalBaudRate;
        List<int> vKanbanAntenaList = new List<int>() { 1, 2, 0, 0 };
        List<int> vPositionAntenaList = new List<int>() { 1, 2, 2, 4 };
        List<int> vDirectionAntenaList = new List<int>() { 1, 1, 2, 2 };
        string vAliveTagList;
        string vImproperTagList;
        bool vSendAlwaysReadTags;
        string vSpecialParameter;
        string vSupplier;
        List<bool> vAntenaList = new List<bool>() { false, false, false, true };

        CNX config = new CNX();
        public FormConfigurarCNX()
        {
            InitializeComponent();
        }

        private void FormConfigurarCNX_Load(object sender, EventArgs e)
        {
            LoadValuesCNX();
        }

        private void getCNX()
        {
            textBoxConfigCNX.ReadOnly = true;

            List<AntenaProps> antenaProps = new List<AntenaProps>();
            antenaProps.Add(new AntenaProps() { Antena = 1, Used = vAntenaList[0] });
            antenaProps.Add(new AntenaProps() { Antena = 2, Used = vAntenaList[1] });
            antenaProps.Add(new AntenaProps() { Antena = 3, Used = vAntenaList[2] });
            antenaProps.Add(new AntenaProps() { Antena = 4, Used = vAntenaList[3] });


            config = new CNX
            {
                ConnectionMode = vConnectionMode,
                Name = vName,
                IPAddress = vIPAddress,
                IPPort = vIPPort,
                IPPortA = vIPPortA,
                ComPort = vComPort,
                InitialBaudRate = vInitialBaudRate,
                FinalBaudRate = vFinalBaudRate,
                KanbanAntenaList = new[] { vKanbanAntenaList[0], vKanbanAntenaList[1], vKanbanAntenaList[2], vKanbanAntenaList[3] },
                PositionAntenaList = new[] { vPositionAntenaList[0], vPositionAntenaList[1], vPositionAntenaList[2], vPositionAntenaList[3] },
                DirectionAntenaList = new[] { vDirectionAntenaList[0], vDirectionAntenaList[1], vDirectionAntenaList[2], vDirectionAntenaList[3] },
                AliveTagList = vAliveTagList,
                ImproperTagList = vImproperTagList,
                SendAlwaysReadTags = false,
                SpecialParameter = vSpecialParameter,
                Supplier = vSupplier,
                AntenaList = antenaProps

            };

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            textBoxConfigCNX.Text = json;
            //CNX deserializedProduct = JsonConvert.DeserializeObject<CNX>(json);
        }



        private void LoadValuesCNX()
        {
            checkBoxTMR.Checked = true;


            textBoxName.Text = "EDGE50AID";
            textBoxIPAddress.Text = "172.16.2.53";


            comboBoxIPPort.Items.Add("5084");
            comboBoxIPPort.Items.Add("8081");
            comboBoxIPPort.Text = comboBoxIPPort.Items[0].ToString();

            comboBoxIPPortA.Items.Add("5085");
            comboBoxIPPortA.Text = comboBoxIPPortA.Items[0].ToString();

            comboBoxComPort.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", });
            comboBoxComPort.Text = comboBoxComPort.Items[0].ToString();

            comboBoxInitialBaudRate.Items.Add("115200");
            comboBoxInitialBaudRate.Text = comboBoxInitialBaudRate.Items[0].ToString();

            comboBoxFinalBaudRate.Items.Add("115200");
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

            checkBoxSendAlwaysReadTagsFalse.Checked = true;

            textBoxSpecialParameter.Text = "SINGLE";

            comboBoxSupplier.Items.Add("UHF_ThingMagic");
            comboBoxSupplier.Items.Add("UHF_Impinj");
            comboBoxSupplier.Text = comboBoxSupplier.Items[0].ToString();

            checkBoxAntena1False.Checked = true;
            checkBoxAntena2False.Checked = true;
            checkBoxAntena3False.Checked = true;
            checkBoxAntena4True.Checked = true;

        }

        private void validNumAntena(TextBox textBox, int index)
        {
            int numAntena = 0;
            int.TryParse(textBox.Text, out numAntena);
            if (numAntena < 0)
            {
                return;
            }
            else
            {
                if (textBox.Name.Contains("KanbanAntena"))
                {
                    vKanbanAntenaList[index] = numAntena;
                    getCNX();
                }
                else if (textBox.Name.Contains("PositionAntena"))
                {
                    vPositionAntenaList[index] = numAntena;
                    getCNX();
                }
                else if (textBox.Name.Contains("DirectionAntenaList"))
                {
                    vDirectionAntenaList[index] = numAntena;
                    getCNX();
                }

            }
        }

        private void validCheckBox(CheckBox checkBox)
        {
            if (checkBox.Name.Contains("TMR"))
            {
                checkBoxTMR.Checked = true;
                checkBoxSERIAL.Checked = false;
                checkBoxTCP.Checked = false;
                return;
            }
            else if (checkBox.Name.Contains("SERIAL"))
            {
                checkBoxTMR.Checked = false;
                checkBoxSERIAL.Checked = true;
                checkBoxTCP.Checked = false;
                return;

            }
            else if (checkBox.Name.Contains("TCP"))
            {
                checkBoxTMR.Checked = false;
                checkBoxSERIAL.Checked = false;
                checkBoxTCP.Checked = true;
                return;
            }

            if (checkBox.Name.Contains("SendAlwaysReadTagsTrue"))
            {
                checkBoxSendAlwaysReadTagsTrue.Checked = true;
                checkBoxSendAlwaysReadTagsFalse.Checked = false;
            }
            else if (checkBox.Name.Contains("SendAlwaysReadTagsFalse"))
            {
                checkBoxSendAlwaysReadTagsTrue.Checked = false;
                checkBoxSendAlwaysReadTagsFalse.Checked = true;
            }

            if (checkBox.Name.Contains("Antena1True"))
            {
                checkBoxAntena1True.Checked = true;
                checkBoxAntena1False.Checked = false;
            }
            else if (checkBox.Name.Contains("Antena1False"))
            {
                checkBoxAntena1True.Checked = false;
                checkBoxAntena1False.Checked = true;
            }
            else if (checkBox.Name.Contains("Antena2True"))
            {
                checkBoxAntena2True.Checked = true;
                checkBoxAntena2False.Checked = false;
            }
            else if (checkBox.Name.Contains("Antena2False"))
            {
                checkBoxAntena2True.Checked = false;
                checkBoxAntena2False.Checked = true;
            }
            else if (checkBox.Name.Contains("Antena3True"))
            {
                checkBoxAntena3True.Checked = true;
                checkBoxAntena3False.Checked = false;
            }
            else if (checkBox.Name.Contains("Antena3False"))
            {
                checkBoxAntena3True.Checked = false;
                checkBoxAntena3False.Checked = true;
            }
            else if (checkBox.Name.Contains("Antena4True"))
            {
                checkBoxAntena4True.Checked = true;
                checkBoxAntena4False.Checked = false;
            }
            else if (checkBox.Name.Contains("Antena4False"))
            {
                checkBoxAntena4True.Checked = false;
                checkBoxAntena4False.Checked = true;
            }

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            vName = textBoxName.Text;
            getCNX();
        }

        private void textBoxIPAddress_TextChanged(object sender, EventArgs e)
        {
            vIPAddress = textBoxIPAddress.Text;
            getCNX();
        }

        private void comboBoxIPPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            vIPPort = comboBoxIPPort.Text;
            getCNX();
        }

        private void comboBoxIPPortA_SelectedIndexChanged(object sender, EventArgs e)
        {
            vIPPortA = comboBoxIPPortA.Text;
            getCNX();
        }

        private void comboBoxComPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            vComPort = comboBoxComPort.Text;
            getCNX();
        }

        private void comboBoxInitialBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            vInitialBaudRate = comboBoxInitialBaudRate.Text;
            getCNX();
        }

        private void comboBoxFinalBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            vFinalBaudRate = comboBoxFinalBaudRate.Text;
            getCNX();
        }

        private void textBoxKanbanAntenaList1_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxKanbanAntenaList1, 0);

        }

        private void textBoxKanbanAntenaList2_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxKanbanAntenaList2, 1);
        }



        private void textBoxKanbanAntenaList3_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxKanbanAntenaList3, 2);
        }

        private void textBoxKanbanAntenaList4_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxKanbanAntenaList4, 3);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            LoadValuesCNX();
        }

        private void textBoxPositionAntenaList1_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxPositionAntenaList1, 0);
        }

        private void textBoxPositionAntenaList2_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxPositionAntenaList2, 1);
        }

        private void textBoxPositionAntenaList3_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxPositionAntenaList3, 2);
        }

        private void textBoxPositionAntenaList4_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxPositionAntenaList4, 3);
        }

        private void textBoxDirectionAntenaList1_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxDirectionAntenaList1, 0);
        }

        private void textBoxDirectionAntenaList2_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxDirectionAntenaList2, 1);

        }

        private void textBoxDirectionAntenaList3_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxDirectionAntenaList3, 2);

        }

        private void textBoxDirectionAntenaList4_TextChanged(object sender, EventArgs e)
        {
            validNumAntena(textBoxDirectionAntenaList4, 3);

        }

        private void textBoxAliveTagList_TextChanged(object sender, EventArgs e)
        {
            vAliveTagList = textBoxAliveTagList.Text;
            getCNX();
        }

        private void textBoxImproperTagList_TextChanged(object sender, EventArgs e)
        {
            vImproperTagList = textBoxImproperTagList.Text;
            getCNX();
        }

        private void checkBoxTCP_CheckedChanged(object sender, EventArgs e)
        {

            validCheckBox(checkBoxTCP);
        }

        private void checkBoxTMR_Click(object sender, EventArgs e)
        {
            vConnectionMode = "TMR";
            validCheckBox(checkBoxTMR);
            getCNX();
        }

        private void checkBoxSERIAL_Click(object sender, EventArgs e)
        {
            vConnectionMode = "SERIAL";
            validCheckBox(checkBoxSERIAL);
            getCNX();
        }

        private void checkBoxTCP_Click(object sender, EventArgs e)
        {
            vConnectionMode = "TCP";
            validCheckBox(checkBoxTCP);
            getCNX();
        }

        private void textBoxSpecialParameter_TextChanged(object sender, EventArgs e)
        {
            vSpecialParameter = textBoxSpecialParameter.Text;
            getCNX();
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            vSupplier = comboBoxSupplier.Text;
            getCNX();
        }

        private void checkBoxSendAlwaysReadTagsTrue_Click(object sender, EventArgs e)
        {
            validCheckBox(checkBoxSendAlwaysReadTagsTrue);
        }

        private void checkBoxSendAlwaysReadTagsFalse_Click(object sender, EventArgs e)
        {
            validCheckBox(checkBoxSendAlwaysReadTagsFalse);
        }

        private void checkBoxAntena1True_Click(object sender, EventArgs e)
        {
            vAntenaList[0] = true;
            validCheckBox(checkBoxAntena1True);
            getCNX();
        }

        private void checkBoxAntena1False_Click(object sender, EventArgs e)
        {
            vAntenaList[0] = false;
            validCheckBox(checkBoxAntena1False);
            getCNX();
        }

        private void checkBoxAntena2True_Click(object sender, EventArgs e)
        {
            vAntenaList[1] = true;
            validCheckBox(checkBoxAntena2True);
            getCNX();
        }

        private void checkBoxAntena2False_Click(object sender, EventArgs e)
        {
            vAntenaList[1] = false;
            validCheckBox(checkBoxAntena2False);
            getCNX();
        }

        private void checkBoxAntena3True_Click(object sender, EventArgs e)
        {
            vAntenaList[2] = true;
            validCheckBox(checkBoxAntena3True);
            getCNX();
        }

        private void checkBoxAntena3False_Click(object sender, EventArgs e)
        {
            vAntenaList[2] = false;
            validCheckBox(checkBoxAntena3False);
            getCNX();
        }

        private void checkBoxAntena4True_Click(object sender, EventArgs e)
        {
            vAntenaList[3] = true;
            validCheckBox(checkBoxAntena4True);
            getCNX();
        }

        private void checkBoxAntena4False_Click(object sender, EventArgs e)
        {
            vAntenaList[3] = false;
            validCheckBox(checkBoxAntena4False);
            getCNX();
        }
    }
}
