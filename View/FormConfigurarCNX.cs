﻿using System;
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
        string vConnectionMode;
        string vName;
        string vIPAddress;
        string vIPPort;
        string vIPPortA;
        string vComPort;
        string vInitialBaudRate;
        string vFinalBaudRate;
        List<int> vKanbanAntenaList;
        List<int> vPositionAntenaList;
        List<int> vDirectionAntenaList;
        string vAliveTagList;
        string vImproperTagList;
        bool vSendAlwaysReadTags;
        string vSpecialParameter;
        string vSupplier;
        List<bool> vAntenaList;

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
            antenaProps.Add(new AntenaProps() { Antena = 1, Used = false });
            antenaProps.Add(new AntenaProps() { Antena = 2, Used = false });
            antenaProps.Add(new AntenaProps() { Antena = 3, Used = false });
            antenaProps.Add(new AntenaProps() { Antena = 4, Used = true });

            config = new CNX
            {
                ConnectionMode = "TMR",
                Name = vName,
                IPAddress = vIPAddress,
                IPPort = vIPPort,
                IPPortA = vIPPortA,
                ComPort = vComPort,
                InitialBaudRate = vInitialBaudRate,
                FinalBaudRate = vFinalBaudRate,
                KanbanAntenaList = new[] { 1, 2, 0, 0 },
                PositionAntenaList = new[] { 1, 2, 2, 4 },
                DirectionAntenaList = new[] { 1, 1, 2, 2 },
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

            checkBoxSendAlwaysReadTagsFalse.Checked = true;

            textBoxSpecialParameter.Text = "SINGLE";

            comboBoxSupplier.Items.Add("UHF_ThingMagic");
            comboBoxSupplier.Text = comboBoxSupplier.Items[0].ToString();

            checkBoxAntena1False.Checked = true;
            checkBoxAntena2False.Checked = true;
            checkBoxAntena3False.Checked = true;
            checkBoxAntena4True.Checked = true;

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
    }
}
