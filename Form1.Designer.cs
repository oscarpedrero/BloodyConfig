namespace BloodyConfig
{
    partial class BloodyConfig
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBtns = new System.Windows.Forms.Panel();
            this.BloodyBoss = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBtns
            // 
            this.panelBtns.Controls.Add(this.BloodyBoss);
            this.panelBtns.Location = new System.Drawing.Point(12, 12);
            this.panelBtns.Name = "panelBtns";
            this.panelBtns.Size = new System.Drawing.Size(1253, 51);
            this.panelBtns.TabIndex = 1;
            this.panelBtns.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BloodyBoss
            // 
            this.BloodyBoss.Location = new System.Drawing.Point(0, 0);
            this.BloodyBoss.Name = "BloodyBoss";
            this.BloodyBoss.Size = new System.Drawing.Size(230, 51);
            this.BloodyBoss.TabIndex = 2;
            this.BloodyBoss.Text = "BloodyBoss";
            this.BloodyBoss.UseVisualStyleBackColor = true;
            this.BloodyBoss.Click += new System.EventHandler(this.BloodyBoss_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Location = new System.Drawing.Point(12, 69);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1253, 702);
            this.panelContenedor.TabIndex = 2;
            // 
            // BloodyConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 783);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelBtns);
            this.Name = "BloodyConfig";
            this.Text = "BloodyConfig";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelBtns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBtns;
        private System.Windows.Forms.Button BloodyBoss;
        private System.Windows.Forms.Panel panelContenedor;
    }
}

