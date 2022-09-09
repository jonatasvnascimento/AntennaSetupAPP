
namespace AntennaSetupAPP.View
{
    partial class FormGerarCNX
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSaveUHF = new System.Windows.Forms.Button();
            this.buttonOpenFolderSystem = new System.Windows.Forms.Button();
            this.buttonTestConnectionAntenna = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPathFolder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(879, 499);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 70F;
            this.Column2.HeaderText = "System";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Path";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 70F;
            this.Column4.HeaderText = "Modify";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 70F;
            this.Column5.HeaderText = "Create";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // buttonSaveUHF
            // 
            this.buttonSaveUHF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.buttonSaveUHF.FlatAppearance.BorderSize = 0;
            this.buttonSaveUHF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveUHF.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSaveUHF.ForeColor = System.Drawing.Color.White;
            this.buttonSaveUHF.Location = new System.Drawing.Point(300, 554);
            this.buttonSaveUHF.Name = "buttonSaveUHF";
            this.buttonSaveUHF.Size = new System.Drawing.Size(185, 27);
            this.buttonSaveUHF.TabIndex = 2;
            this.buttonSaveUHF.Text = "Salve";
            this.buttonSaveUHF.UseVisualStyleBackColor = false;
            this.buttonSaveUHF.Click += new System.EventHandler(this.buttonSaveUHF_Click);
            // 
            // buttonOpenFolderSystem
            // 
            this.buttonOpenFolderSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.buttonOpenFolderSystem.FlatAppearance.BorderSize = 0;
            this.buttonOpenFolderSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenFolderSystem.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonOpenFolderSystem.ForeColor = System.Drawing.Color.White;
            this.buttonOpenFolderSystem.Location = new System.Drawing.Point(491, 554);
            this.buttonOpenFolderSystem.Name = "buttonOpenFolderSystem";
            this.buttonOpenFolderSystem.Size = new System.Drawing.Size(185, 27);
            this.buttonOpenFolderSystem.TabIndex = 3;
            this.buttonOpenFolderSystem.Text = "Open Folder";
            this.buttonOpenFolderSystem.UseVisualStyleBackColor = false;
            this.buttonOpenFolderSystem.Click += new System.EventHandler(this.buttonOpenFolderSystem_Click);
            // 
            // buttonTestConnectionAntenna
            // 
            this.buttonTestConnectionAntenna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.buttonTestConnectionAntenna.FlatAppearance.BorderSize = 0;
            this.buttonTestConnectionAntenna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTestConnectionAntenna.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonTestConnectionAntenna.ForeColor = System.Drawing.Color.White;
            this.buttonTestConnectionAntenna.Location = new System.Drawing.Point(682, 554);
            this.buttonTestConnectionAntenna.Name = "buttonTestConnectionAntenna";
            this.buttonTestConnectionAntenna.Size = new System.Drawing.Size(185, 27);
            this.buttonTestConnectionAntenna.TabIndex = 4;
            this.buttonTestConnectionAntenna.Text = "Test Connection";
            this.buttonTestConnectionAntenna.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Path Folder: ";
            // 
            // labelPathFolder
            // 
            this.labelPathFolder.AutoSize = true;
            this.labelPathFolder.ForeColor = System.Drawing.Color.White;
            this.labelPathFolder.Location = new System.Drawing.Point(100, 506);
            this.labelPathFolder.Name = "labelPathFolder";
            this.labelPathFolder.Size = new System.Drawing.Size(35, 17);
            this.labelPathFolder.TabIndex = 6;
            this.labelPathFolder.Text = "Path";
            // 
            // FormGerarCNX
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(879, 593);
            this.Controls.Add(this.labelPathFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTestConnectionAntenna);
            this.Controls.Add(this.buttonOpenFolderSystem);
            this.Controls.Add(this.buttonSaveUHF);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGerarCNX";
            this.Text = "FormGerarCNX";
            this.Load += new System.EventHandler(this.FormGerarCNX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button buttonSaveUHF;
        private System.Windows.Forms.Button buttonOpenFolderSystem;
        private System.Windows.Forms.Button buttonTestConnectionAntenna;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPathFolder;
    }
}