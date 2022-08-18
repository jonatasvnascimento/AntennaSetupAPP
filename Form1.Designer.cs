
namespace AntennaSetupAPP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.buttonConfigurarCFG = new System.Windows.Forms.Button();
            this.buttonGerarCFG = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.panelMenu.Controls.Add(this.buttonGerarCFG);
            this.panelMenu.Controls.Add(this.buttonConfigurarCFG);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 450);
            this.panelMenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // buttonConfigurarCFG
            // 
            this.buttonConfigurarCFG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.buttonConfigurarCFG.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonConfigurarCFG.FlatAppearance.BorderSize = 0;
            this.buttonConfigurarCFG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfigurarCFG.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonConfigurarCFG.ForeColor = System.Drawing.Color.White;
            this.buttonConfigurarCFG.Location = new System.Drawing.Point(0, 100);
            this.buttonConfigurarCFG.Name = "buttonConfigurarCFG";
            this.buttonConfigurarCFG.Size = new System.Drawing.Size(200, 34);
            this.buttonConfigurarCFG.TabIndex = 1;
            this.buttonConfigurarCFG.Text = "Configurar CFG";
            this.buttonConfigurarCFG.UseVisualStyleBackColor = false;
            // 
            // buttonGerarCFG
            // 
            this.buttonGerarCFG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.buttonGerarCFG.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGerarCFG.FlatAppearance.BorderSize = 0;
            this.buttonGerarCFG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGerarCFG.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGerarCFG.ForeColor = System.Drawing.Color.White;
            this.buttonGerarCFG.Location = new System.Drawing.Point(0, 134);
            this.buttonGerarCFG.Name = "buttonGerarCFG";
            this.buttonGerarCFG.Size = new System.Drawing.Size(200, 34);
            this.buttonGerarCFG.TabIndex = 2;
            this.buttonGerarCFG.Text = "Gerar CFG";
            this.buttonGerarCFG.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button buttonConfigurarCFG;
        private System.Windows.Forms.Button buttonGerarCFG;
    }
}

