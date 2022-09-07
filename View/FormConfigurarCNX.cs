using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntennaSetupAPP.Ultils;
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
            //ResetValues();
            getConfigFromJsonTXT();
        }
        public void getConfigFromJsonTXT()
        {
            try
            {
                var getValuesFromObjJson = ExportTXT.JsonToObject();

                if (getValuesFromObjJson == null)
                {
                    MessageBox.Show("Sem valores no arquivo");
                }

                checkBoxTMR.Checked = getValuesFromObjJson.ConnectionMode == "TMR" ? true : false;
                checkBoxSERIAL.Checked = getValuesFromObjJson.ConnectionMode == "SERIAL" ? true : false;
                checkBoxTCP.Checked = getValuesFromObjJson.ConnectionMode == "TCP" ? true : false;
                vConnectionMode = getValuesFromObjJson.ConnectionMode;
                textBoxName.Text = getValuesFromObjJson.Name;
                textBoxIPAddress.Text = getValuesFromObjJson.IPAddress;

                comboBoxIPPort.Items.Clear();
                comboBoxIPPort.Items.Add("5084");
                comboBoxIPPort.Items.Add("8081");
                comboBoxIPPort.Text = comboBoxIPPort.Items[getValuesFromObjJson.IPPort == "5084" ? 0 : 1].ToString();

                comboBoxIPPortA.Items.Clear();
                comboBoxIPPortA.Items.Add("5085");
                comboBoxIPPortA.Text = comboBoxIPPortA.Items[getValuesFromObjJson.IPPort == "5084" ? 0 : 0].ToString();

                comboBoxComPort.Items.Clear();

                int indexComPort = 0;
                switch (getValuesFromObjJson.ComPort)
                {
                    case "COM1":
                        indexComPort = 0;
                        break;
                    case "COM2":
                        indexComPort = 1;
                        break;
                    case "COM3":
                        indexComPort = 2;
                        break;
                    case "COM4":
                        indexComPort = 3;
                        break;
                    case "COM5":
                        indexComPort = 4;
                        break;
                    case "COM6":
                        indexComPort = 5;
                        break;
                    case "COM7":
                        indexComPort = 6;
                        break;
                    case "COM8":
                        indexComPort = 7;
                        break;
                    default:
                        break;
                }
                comboBoxComPort.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", });
                comboBoxComPort.Text = comboBoxComPort.Items[indexComPort].ToString();

                comboBoxInitialBaudRate.Items.Clear();
                comboBoxInitialBaudRate.Items.Add("115200");
                comboBoxInitialBaudRate.Text = comboBoxInitialBaudRate.Items[getValuesFromObjJson.InitialBaudRate == "115200" ? 0 : 0].ToString();

                comboBoxFinalBaudRate.Items.Clear();
                comboBoxFinalBaudRate.Items.Add("115200");
                comboBoxFinalBaudRate.Text = comboBoxFinalBaudRate.Items[getValuesFromObjJson.FinalBaudRate == "115200" ? 0 : 0].ToString();


                textBoxKanbanAntenaList1.Text = getValuesFromObjJson.KanbanAntenaList[0].ToString();
                textBoxKanbanAntenaList2.Text = getValuesFromObjJson.KanbanAntenaList[1].ToString();
                textBoxKanbanAntenaList3.Text = getValuesFromObjJson.KanbanAntenaList[2].ToString();
                textBoxKanbanAntenaList4.Text = getValuesFromObjJson.KanbanAntenaList[3].ToString();

                textBoxPositionAntenaList1.Text = getValuesFromObjJson.PositionAntenaList[0].ToString();
                textBoxPositionAntenaList2.Text = getValuesFromObjJson.PositionAntenaList[1].ToString();
                textBoxPositionAntenaList3.Text = getValuesFromObjJson.PositionAntenaList[2].ToString();
                textBoxPositionAntenaList4.Text = getValuesFromObjJson.PositionAntenaList[3].ToString();

                textBoxDirectionAntenaList1.Text = getValuesFromObjJson.DirectionAntenaList[0].ToString();
                textBoxDirectionAntenaList2.Text = getValuesFromObjJson.DirectionAntenaList[1].ToString();
                textBoxDirectionAntenaList3.Text = getValuesFromObjJson.DirectionAntenaList[2].ToString();
                textBoxDirectionAntenaList4.Text = getValuesFromObjJson.DirectionAntenaList[3].ToString();

                textBoxAliveTagList.Text = getValuesFromObjJson.AliveTagList.ToString();

                textBoxImproperTagList.Text = getValuesFromObjJson.ImproperTagList.ToString();

                checkBoxSendAlwaysReadTagsFalse.Checked = getValuesFromObjJson.SendAlwaysReadTags ? true : false;
                checkBoxSendAlwaysReadTagsTrue.Checked = getValuesFromObjJson.SendAlwaysReadTags ? true : false; ;

                textBoxSpecialParameter.Text = getValuesFromObjJson.SpecialParameter.ToString();

                comboBoxSupplier.Items.Clear();
                comboBoxSupplier.Items.Add("UHF_ThingMagic");
                comboBoxSupplier.Items.Add("UHF_Impinj");
                comboBoxSupplier.Text = comboBoxSupplier.Items[getValuesFromObjJson.Supplier == "UHF_ThingMagic" ? 0 : 1].ToString();

                foreach (var item in getValuesFromObjJson.AntenaList)
                {
                    if (item.Antena == 1 && item.Used == true)
                    {
                        checkBoxAntena1True.Checked = true;
                        checkBoxAntena1False.Checked = false;
                    }
                    else
                    {
                        checkBoxAntena1True.Checked = false;
                        checkBoxAntena1False.Checked = true;
                    }
                    //if (item.Antena == 2 && item.Used == true)
                    //{
                    //    checkBoxAntena2True.Checked = true;
                    //    checkBoxAntena2False.Checked = false;
                    //}
                    //else
                    //{
                    //    checkBoxAntena2True.Checked = false;
                    //    checkBoxAntena2False.Checked = true;
                    //}
                    //if (item.Antena == 3 && item.Used == true)
                    //{
                    //    checkBoxAntena3True.Checked = true;
                    //    checkBoxAntena3False.Checked = false;
                    //}
                    //else
                    //{
                    //    checkBoxAntena3True.Checked = false;
                    //    checkBoxAntena3False.Checked = true;
                    //}
                    //if (item.Antena == 4 && item.Used == true)
                    //{
                    //    checkBoxAntena4True.Checked = true;
                    //    checkBoxAntena4False.Checked = false;
                    //}
                    //else
                    //{
                    //    checkBoxAntena4True.Checked = false;
                    //    checkBoxAntena4False.Checked = true;
                    //}
                }


               

                List<AntenaProps> antenaProps = new List<AntenaProps>();
                antenaProps.Add(new AntenaProps() { Antena = 1, Used = vAntenaList[0] });
                antenaProps.Add(new AntenaProps() { Antena = 2, Used = vAntenaList[1] });
                antenaProps.Add(new AntenaProps() { Antena = 3, Used = vAntenaList[2] });
                antenaProps.Add(new AntenaProps() { Antena = 4, Used = vAntenaList[3] });


            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }


        private void getCNX()
        {
            textBoxConfigCNX.ReadOnly = true;
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            string fileDirectory = $"{directoryInfo.FullName}\\Backup\\UHFReader.UHF_cnx";

            if (File.Exists(fileDirectory))
            {
                List<AntenaProps> antenaProps = new List<AntenaProps>() { 
                        new AntenaProps() { Antena = 1, Used = vAntenaList[0] },
                        new AntenaProps() { Antena = 2, Used = vAntenaList[1] },
                        new AntenaProps() { Antena = 3, Used = vAntenaList[2] },
                        new AntenaProps() { Antena = 4, Used = vAntenaList[3] }
                };

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
                    SendAlwaysReadTags = vSendAlwaysReadTags,
                    SpecialParameter = vSpecialParameter,
                    Supplier = vSupplier,
                    AntenaList = antenaProps

                };
            }
          

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            textBoxConfigCNX.Text = json;


            //CNX deserializedProduct = JsonConvert.DeserializeObject<CNX>(json);
        }



        private void ResetValues()
        {

            checkBoxTMR.Checked = true;
            checkBoxSERIAL.Checked = false;
            checkBoxTCP.Checked = false;
            vConnectionMode = "TMR";


            textBoxName.Text = "EDGE50AID";
            textBoxIPAddress.Text = "172.16.2.53";

            comboBoxIPPort.Items.Clear();
            comboBoxIPPort.Items.Add("5084");
            comboBoxIPPort.Items.Add("8081");
            comboBoxIPPort.Text = comboBoxIPPort.Items[0].ToString();

            comboBoxIPPortA.Items.Clear();
            comboBoxIPPortA.Items.Add("5085");
            comboBoxIPPortA.Text = comboBoxIPPortA.Items[0].ToString();

            comboBoxComPort.Items.Clear();
            comboBoxComPort.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", });
            comboBoxComPort.Text = comboBoxComPort.Items[0].ToString();

            comboBoxInitialBaudRate.Items.Clear();
            comboBoxInitialBaudRate.Items.Add("115200");
            comboBoxInitialBaudRate.Text = comboBoxInitialBaudRate.Items[0].ToString();

            comboBoxFinalBaudRate.Items.Clear();
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
            checkBoxSendAlwaysReadTagsTrue.Checked = false;

            textBoxSpecialParameter.Text = "SINGLE";

            comboBoxSupplier.Items.Clear();
            comboBoxSupplier.Items.Add("UHF_ThingMagic");
            comboBoxSupplier.Items.Add("UHF_Impinj");
            comboBoxSupplier.Text = comboBoxSupplier.Items[0].ToString();

            checkBoxAntena1False.Checked = true;
            checkBoxAntena1True.Checked = false;

            checkBoxAntena2False.Checked = true;
            checkBoxAntena2True.Checked = false;

            checkBoxAntena3False.Checked = true;
            checkBoxAntena3True.Checked = false;

            checkBoxAntena4True.Checked = true;
            checkBoxAntena4False.Checked = false;

            vAntenaList = new List<bool>() { false, false, false, true };

            getCNX();

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
            ResetValues();
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
            vSendAlwaysReadTags = true;
            validCheckBox(checkBoxSendAlwaysReadTagsTrue);
            getCNX();
        }

        private void checkBoxSendAlwaysReadTagsFalse_Click(object sender, EventArgs e)
        {
            vSendAlwaysReadTags = false;
            validCheckBox(checkBoxSendAlwaysReadTagsFalse);
            getCNX();
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ExportTXT.ExportJsonToTxt(Directory.GetCurrentDirectory(), textBoxConfigCNX);
        }

        private void textBoxConfigCNX_TextChanged(object sender, EventArgs e)
        {
            ExportTXT.SaveBackup(Directory.GetCurrentDirectory(), textBoxConfigCNX);
        }
    }
}
