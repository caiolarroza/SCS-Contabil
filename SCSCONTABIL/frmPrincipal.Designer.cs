namespace SCSCONTABIL
{
    partial class frmPrincipal
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCadUsu = new System.Windows.Forms.Button();
            this.btnCadFor = new System.Windows.Forms.Button();
            this.btnCadPro = new System.Windows.Forms.Button();
            this.btnConPro = new System.Windows.Forms.Button();
            this.btnConFor = new System.Windows.Forms.Button();
            this.btnConUsu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro";
            // 
            // btnCadUsu
            // 
            this.btnCadUsu.Location = new System.Drawing.Point(38, 85);
            this.btnCadUsu.Name = "btnCadUsu";
            this.btnCadUsu.Size = new System.Drawing.Size(165, 23);
            this.btnCadUsu.TabIndex = 1;
            this.btnCadUsu.Text = "Cadastrar Usuário";
            this.btnCadUsu.UseVisualStyleBackColor = true;
            this.btnCadUsu.Click += new System.EventHandler(this.btnCadUsu_Click);
            // 
            // btnCadFor
            // 
            this.btnCadFor.Location = new System.Drawing.Point(38, 124);
            this.btnCadFor.Name = "btnCadFor";
            this.btnCadFor.Size = new System.Drawing.Size(165, 23);
            this.btnCadFor.TabIndex = 2;
            this.btnCadFor.Text = "Cadastrar Fornecedor";
            this.btnCadFor.UseVisualStyleBackColor = true;
            // 
            // btnCadPro
            // 
            this.btnCadPro.Location = new System.Drawing.Point(38, 164);
            this.btnCadPro.Name = "btnCadPro";
            this.btnCadPro.Size = new System.Drawing.Size(165, 23);
            this.btnCadPro.TabIndex = 3;
            this.btnCadPro.Text = "Cadastrar Produto";
            this.btnCadPro.UseVisualStyleBackColor = true;
            // 
            // btnConPro
            // 
            this.btnConPro.Location = new System.Drawing.Point(303, 164);
            this.btnConPro.Name = "btnConPro";
            this.btnConPro.Size = new System.Drawing.Size(165, 23);
            this.btnConPro.TabIndex = 7;
            this.btnConPro.Text = "Consultar Produto";
            this.btnConPro.UseVisualStyleBackColor = true;
            // 
            // btnConFor
            // 
            this.btnConFor.Location = new System.Drawing.Point(303, 124);
            this.btnConFor.Name = "btnConFor";
            this.btnConFor.Size = new System.Drawing.Size(165, 23);
            this.btnConFor.TabIndex = 6;
            this.btnConFor.Text = "Consultar Fornecedor";
            this.btnConFor.UseVisualStyleBackColor = true;
            // 
            // btnConUsu
            // 
            this.btnConUsu.Location = new System.Drawing.Point(303, 85);
            this.btnConUsu.Name = "btnConUsu";
            this.btnConUsu.Size = new System.Drawing.Size(165, 23);
            this.btnConUsu.TabIndex = 5;
            this.btnConUsu.Text = "Consultar Usuário";
            this.btnConUsu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Consulta";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(213, 256);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 8;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 291);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnConPro);
            this.Controls.Add(this.btnConFor);
            this.Controls.Add(this.btnConUsu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCadPro);
            this.Controls.Add(this.btnCadFor);
            this.Controls.Add(this.btnCadUsu);
            this.Controls.Add(this.label1);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCadUsu;
        private System.Windows.Forms.Button btnCadFor;
        private System.Windows.Forms.Button btnCadPro;
        private System.Windows.Forms.Button btnConPro;
        private System.Windows.Forms.Button btnConFor;
        private System.Windows.Forms.Button btnConUsu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSair;
    }
}