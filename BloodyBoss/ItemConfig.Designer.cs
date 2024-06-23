namespace BloodyConfig.BloodyBoss
{
    partial class ItemConfig
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
            this.chance = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.stack = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.saveBTN = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.languagesBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.itemBox = new System.Windows.Forms.ComboBox();
            this.prefabGUID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chance
            // 
            this.chance.Location = new System.Drawing.Point(63, 176);
            this.chance.Name = "chance";
            this.chance.Size = new System.Drawing.Size(45, 20);
            this.chance.TabIndex = 74;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(60, 159);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(47, 13);
            this.label39.TabIndex = 73;
            this.label39.Text = "Chance:";
            // 
            // stack
            // 
            this.stack.Location = new System.Drawing.Point(9, 176);
            this.stack.Name = "stack";
            this.stack.Size = new System.Drawing.Size(45, 20);
            this.stack.TabIndex = 72;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 159);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(38, 13);
            this.label38.TabIndex = 71;
            this.label38.Text = "Stack:";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(9, 72);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(290, 20);
            this.name.TabIndex = 68;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 55);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(38, 13);
            this.label24.TabIndex = 67;
            this.label24.Text = "Name:";
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(9, 233);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(290, 35);
            this.saveBTN.TabIndex = 75;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 79;
            this.label7.Text = "Language";
            // 
            // languagesBox
            // 
            this.languagesBox.FormattingEnabled = true;
            this.languagesBox.Location = new System.Drawing.Point(7, 16);
            this.languagesBox.Name = "languagesBox";
            this.languagesBox.Size = new System.Drawing.Size(98, 21);
            this.languagesBox.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "New From Prefab:";
            // 
            // itemBox
            // 
            this.itemBox.FormattingEnabled = true;
            this.itemBox.Location = new System.Drawing.Point(119, 16);
            this.itemBox.Name = "itemBox";
            this.itemBox.Size = new System.Drawing.Size(180, 21);
            this.itemBox.TabIndex = 77;
            // 
            // prefabGUID
            // 
            this.prefabGUID.Location = new System.Drawing.Point(9, 119);
            this.prefabGUID.Name = "prefabGUID";
            this.prefabGUID.Size = new System.Drawing.Size(290, 20);
            this.prefabGUID.TabIndex = 81;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "PrefabGUID:";
            // 
            // ItemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.prefabGUID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.languagesBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemBox);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.chance);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.stack);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label24);
            this.Name = "ItemConfig";
            this.Size = new System.Drawing.Size(369, 302);
            this.Load += new System.EventHandler(this.ItemConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chance;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox stack;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox languagesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox itemBox;
        private System.Windows.Forms.TextBox prefabGUID;
        private System.Windows.Forms.Label label2;
    }
}
