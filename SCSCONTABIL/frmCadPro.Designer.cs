namespace SCSCONTABIL
{
    partial class frmCadPro
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
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIes = new System.Windows.Forms.MaskedTextBox();
            this.txtImu = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtNomePro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCad = new System.Windows.Forms.Button();
            this.btnVol = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(221, 35);
            this.txtCnpj.Mask = "99.999.999/9999-99";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(208, 22);
            this.txtCnpj.TabIndex = 0;
            this.txtCnpj.Click += new System.EventHandler(this.txtCnpj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Digite o CNPJ do fornecedor*:";
            // 
            // btnFor
            // 
            this.btnFor.Location = new System.Drawing.Point(435, 35);
            this.btnFor.Name = "btnFor";
            this.btnFor.Size = new System.Drawing.Size(75, 23);
            this.btnFor.TabIndex = 1;
            this.btnFor.Text = "Buscar";
            this.btnFor.UseVisualStyleBackColor = true;
            this.btnFor.Click += new System.EventHandler(this.btnFor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIes);
            this.groupBox1.Controls.Add(this.txtImu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRazao);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(16, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 157);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do Fornecedor";
            // 
            // txtIes
            // 
            this.txtIes.Location = new System.Drawing.Point(162, 118);
            this.txtIes.Mask = " 000.000.000.000";
            this.txtIes.Name = "txtIes";
            this.txtIes.ReadOnly = true;
            this.txtIes.Size = new System.Drawing.Size(312, 22);
            this.txtIes.TabIndex = 5;
            this.txtIes.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtImu
            // 
            this.txtImu.Location = new System.Drawing.Point(162, 90);
            this.txtImu.Mask = "00.000";
            this.txtImu.Name = "txtImu";
            this.txtImu.ReadOnly = true;
            this.txtImu.Size = new System.Drawing.Size(312, 22);
            this.txtImu.TabIndex = 4;
            this.txtImu.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Inscrição Estadual*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inscrição Municipal*:";
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(162, 60);
            this.txtNome.MaxLength = 40;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(313, 22);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome Fantasia*:";
            // 
            // txtRazao
            // 
            this.txtRazao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazao.Location = new System.Drawing.Point(162, 32);
            this.txtRazao.MaxLength = 40;
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.ReadOnly = true;
            this.txtRazao.Size = new System.Drawing.Size(313, 22);
            this.txtRazao.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Razão Social*:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtQtd);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtPreco);
            this.groupBox2.Controls.Add(this.txtNomePro);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(16, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 131);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados do Produto";
            // 
            // txtQtd
            // 
            this.txtQtd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtd.Location = new System.Drawing.Point(104, 87);
            this.txtQtd.MaxLength = 11;
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(370, 22);
            this.txtQtd.TabIndex = 11;
            this.txtQtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtd_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Quantidade*:";
            // 
            // txtPreco
            // 
            this.txtPreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPreco.Location = new System.Drawing.Point(104, 59);
            this.txtPreco.MaxLength = 666;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPreco.Size = new System.Drawing.Size(370, 22);
            this.txtPreco.TabIndex = 7;
            this.txtPreco.TextChanged += new System.EventHandler(this.txtPreco_TextChanged);
            this.txtPreco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPreco_KeyPress);
            this.txtPreco.Leave += new System.EventHandler(this.txtPreco_Leave);
            // 
            // txtNomePro
            // 
            this.txtNomePro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomePro.Location = new System.Drawing.Point(104, 28);
            this.txtNomePro.MaxLength = 40;
            this.txtNomePro.Name = "txtNomePro";
            this.txtNomePro.Size = new System.Drawing.Size(370, 22);
            this.txtNomePro.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Preço*(R$):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nome*:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(178, 390);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(32, 17);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "      ";
            this.lblStatus.SizeChanged += new System.EventHandler(this.lblStatus_SizeChanged);
            // 
            // btnCad
            // 
            this.btnCad.Location = new System.Drawing.Point(111, 425);
            this.btnCad.Name = "btnCad";
            this.btnCad.Size = new System.Drawing.Size(86, 23);
            this.btnCad.TabIndex = 8;
            this.btnCad.Text = "Cadastrar";
            this.btnCad.UseVisualStyleBackColor = true;
            this.btnCad.Click += new System.EventHandler(this.btnCad_Click);
            // 
            // btnVol
            // 
            this.btnVol.Location = new System.Drawing.Point(334, 425);
            this.btnVol.Name = "btnVol";
            this.btnVol.Size = new System.Drawing.Size(85, 23);
            this.btnVol.TabIndex = 9;
            this.btnVol.Text = "Voltar";
            this.btnVol.UseVisualStyleBackColor = true;
            this.btnVol.Click += new System.EventHandler(this.btnVol_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 464);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(265, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Todos os campos com * são obrigatórios";
            // 
            // frmCadPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 487);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnVol);
            this.Controls.Add(this.btnCad);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCnpj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCadPro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCadPro";
            this.Load += new System.EventHandler(this.frmCadPro_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtIes;
        private System.Windows.Forms.MaskedTextBox txtImu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNomePro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCad;
        private System.Windows.Forms.Button btnVol;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.Label label8;
    }
}