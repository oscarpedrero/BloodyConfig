namespace BloodyConfig
{
    partial class vistaBloodyBoss
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabModConfig = new System.Windows.Forms.TabPage();
            this.tabBossConfig = new System.Windows.Forms.TabPage();
            this.listBosses = new System.Windows.Forms.ListBox();
            this.anadiJefe = new System.Windows.Forms.Button();
            this.eliminarJefe = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panelConfigJefe = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mainTabControl.SuspendLayout();
            this.tabBossConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabModConfig);
            this.mainTabControl.Controls.Add(this.tabBossConfig);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1253, 735);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabModConfig
            // 
            this.tabModConfig.Location = new System.Drawing.Point(4, 22);
            this.tabModConfig.Name = "tabModConfig";
            this.tabModConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabModConfig.Size = new System.Drawing.Size(1245, 709);
            this.tabModConfig.TabIndex = 0;
            this.tabModConfig.Text = "Mod Config";
            this.tabModConfig.UseVisualStyleBackColor = true;
            // 
            // tabBossConfig
            // 
            this.tabBossConfig.Controls.Add(this.button2);
            this.tabBossConfig.Controls.Add(this.button1);
            this.tabBossConfig.Controls.Add(this.panelConfigJefe);
            this.tabBossConfig.Controls.Add(this.eliminarJefe);
            this.tabBossConfig.Controls.Add(this.anadiJefe);
            this.tabBossConfig.Controls.Add(this.listBosses);
            this.tabBossConfig.Location = new System.Drawing.Point(4, 22);
            this.tabBossConfig.Name = "tabBossConfig";
            this.tabBossConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabBossConfig.Size = new System.Drawing.Size(1245, 709);
            this.tabBossConfig.TabIndex = 1;
            this.tabBossConfig.Text = "Boss Config";
            this.tabBossConfig.UseVisualStyleBackColor = true;
            // 
            // listBosses
            // 
            this.listBosses.FormattingEnabled = true;
            this.listBosses.Location = new System.Drawing.Point(3, 54);
            this.listBosses.Name = "listBosses";
            this.listBosses.Size = new System.Drawing.Size(186, 589);
            this.listBosses.TabIndex = 0;
            // 
            // anadiJefe
            // 
            this.anadiJefe.Location = new System.Drawing.Point(6, 652);
            this.anadiJefe.Name = "anadiJefe";
            this.anadiJefe.Size = new System.Drawing.Size(89, 23);
            this.anadiJefe.TabIndex = 1;
            this.anadiJefe.Text = "Add";
            this.anadiJefe.UseVisualStyleBackColor = true;
            this.anadiJefe.Click += new System.EventHandler(this.anadiJefe_Click);
            // 
            // eliminarJefe
            // 
            this.eliminarJefe.Location = new System.Drawing.Point(100, 652);
            this.eliminarJefe.Name = "eliminarJefe";
            this.eliminarJefe.Size = new System.Drawing.Size(89, 23);
            this.eliminarJefe.TabIndex = 2;
            this.eliminarJefe.Text = "Delete";
            this.eliminarJefe.UseVisualStyleBackColor = true;
            this.eliminarJefe.Click += new System.EventHandler(this.eliminarJefe_Click);
            // 
            // panelConfigJefe
            // 
            this.panelConfigJefe.Location = new System.Drawing.Point(195, 6);
            this.panelConfigJefe.Name = "panelConfigJefe";
            this.panelConfigJefe.Size = new System.Drawing.Size(1044, 697);
            this.panelConfigJefe.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Import JSON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ImportFileButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Export JSON";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ExportFileButton_Click);
            // 
            // vistaBloodyBoss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainTabControl);
            this.Name = "vistaBloodyBoss";
            this.Size = new System.Drawing.Size(1253, 735);
            this.Load += new System.EventHandler(this.filtroPrincipal_Load);
            this.mainTabControl.ResumeLayout(false);
            this.tabBossConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabModConfig;
        private System.Windows.Forms.TabPage tabBossConfig;
        private System.Windows.Forms.ListBox listBosses;
        private System.Windows.Forms.Button anadiJefe;
        private System.Windows.Forms.Button eliminarJefe;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panelConfigJefe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
