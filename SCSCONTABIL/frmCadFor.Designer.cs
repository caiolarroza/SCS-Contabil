namespace SCSCONTABIL
{
    partial class frmCadFor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIes = new System.Windows.Forms.MaskedTextBox();
            this.txtImu = new System.Windows.Forms.MaskedTextBox();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.btnCep = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEst = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtMun = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBai = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCom = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumEnd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNumTel = new System.Windows.Forms.MaskedTextBox();
            this.txtDdd = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIes);
            this.groupBox1.Controls.Add(this.txtImu);
            this.groupBox1.Controls.Add(this.txtCnpj);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRazao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 183);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Empresa";
            // 
            // txtIes
            // 
            this.txtIes.Location = new System.Drawing.Point(162, 144);
            this.txtIes.Mask = " 000.000.000.000";
            this.txtIes.Name = "txtIes";
            this.txtIes.Size = new System.Drawing.Size(312, 22);
            this.txtIes.TabIndex = 4;
            this.txtIes.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIes.Click += new System.EventHandler(this.txtIes_Click);
            // 
            // txtImu
            // 
            this.txtImu.Location = new System.Drawing.Point(162, 116);
            this.txtImu.Mask = "00.000";
            this.txtImu.Name = "txtImu";
            this.txtImu.Size = new System.Drawing.Size(312, 22);
            this.txtImu.TabIndex = 3;
            this.txtImu.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtImu.Click += new System.EventHandler(this.txtImu_Click);
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(162, 88);
            this.txtCnpj.Mask = "99.999.999/9999-99";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(312, 22);
            this.txtCnpj.TabIndex = 2;
            this.txtCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCnpj.Click += new System.EventHandler(this.txtCnpj_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Inscrição Estadual*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inscrição Municipal*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "CNPJ*:";
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(162, 60);
            this.txtNome.MaxLength = 40;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(313, 22);
            this.txtNome.TabIndex = 1;
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
            this.txtRazao.Size = new System.Drawing.Size(313, 22);
            this.txtRazao.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razão Social*:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCep);
            this.groupBox3.Controls.Add(this.btnCep);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtEst);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txtMun);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtBai);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtCom);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtNumEnd);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtEnd);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(12, 275);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 246);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Endereço";
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(141, 37);
            this.txtCep.Mask = "99999-999";
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(87, 22);
            this.txtCep.TabIndex = 7;
            this.txtCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCep.Click += new System.EventHandler(this.txtCep_Click);
            // 
            // btnCep
            // 
            this.btnCep.Location = new System.Drawing.Point(250, 37);
            this.btnCep.Name = "btnCep";
            this.btnCep.Size = new System.Drawing.Size(112, 23);
            this.btnCep.TabIndex = 8;
            this.btnCep.Text = "Buscar CEP";
            this.btnCep.UseVisualStyleBackColor = true;
            this.btnCep.Click += new System.EventHandler(this.btnCep_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 17);
            this.label17.TabIndex = 14;
            this.label17.Text = "CEP*: ";
            // 
            // txtEst
            // 
            this.txtEst.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEst.Location = new System.Drawing.Point(141, 213);
            this.txtEst.MaxLength = 2;
            this.txtEst.Name = "txtEst";
            this.txtEst.Size = new System.Drawing.Size(333, 22);
            this.txtEst.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 216);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 17);
            this.label18.TabIndex = 10;
            this.label18.Text = "Estado*:";
            // 
            // txtMun
            // 
            this.txtMun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMun.Location = new System.Drawing.Point(141, 182);
            this.txtMun.MaxLength = 30;
            this.txtMun.Name = "txtMun";
            this.txtMun.Size = new System.Drawing.Size(333, 22);
            this.txtMun.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Municipio*: ";
            // 
            // txtBai
            // 
            this.txtBai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBai.Location = new System.Drawing.Point(141, 154);
            this.txtBai.MaxLength = 30;
            this.txtBai.Name = "txtBai";
            this.txtBai.Size = new System.Drawing.Size(333, 22);
            this.txtBai.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Bairro*:";
            // 
            // txtCom
            // 
            this.txtCom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCom.Location = new System.Drawing.Point(141, 126);
            this.txtCom.MaxLength = 30;
            this.txtCom.Name = "txtCom";
            this.txtCom.Size = new System.Drawing.Size(333, 22);
            this.txtCom.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "Complemento:";
            // 
            // txtNumEnd
            // 
            this.txtNumEnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumEnd.Location = new System.Drawing.Point(141, 98);
            this.txtNumEnd.MaxLength = 7;
            this.txtNumEnd.Name = "txtNumEnd";
            this.txtNumEnd.Size = new System.Drawing.Size(333, 22);
            this.txtNumEnd.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Número*:";
            // 
            // txtEnd
            // 
            this.txtEnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEnd.Location = new System.Drawing.Point(141, 70);
            this.txtEnd.MaxLength = 60;
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(333, 22);
            this.txtEnd.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Rua/Avenida*:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(152, 558);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(82, 23);
            this.btnCadastrar.TabIndex = 15;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(290, 558);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(82, 23);
            this.btnVoltar.TabIndex = 16;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(227, 524);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "           ";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.SizeChanged += new System.EventHandler(this.lblStatus_SizeChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 584);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(265, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Todos os campos com * são obrigatórios";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNumTel);
            this.groupBox2.Controls.Add(this.txtDdd);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 68);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contato";
            // 
            // txtNumTel
            // 
            this.txtNumTel.Location = new System.Drawing.Point(135, 28);
            this.txtNumTel.Mask = "0000-0000";
            this.txtNumTel.Name = "txtNumTel";
            this.txtNumTel.Size = new System.Drawing.Size(87, 22);
            this.txtNumTel.TabIndex = 6;
            this.txtNumTel.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtNumTel.Click += new System.EventHandler(this.txtNumTel_Click);
            // 
            // txtDdd
            // 
            this.txtDdd.Location = new System.Drawing.Point(91, 28);
            this.txtDdd.Mask = "(00)";
            this.txtDdd.Name = "txtDdd";
            this.txtDdd.Size = new System.Drawing.Size(39, 22);
            this.txtDdd.TabIndex = 5;
            this.txtDdd.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtDdd.Click += new System.EventHandler(this.txtDdd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Telefone*: ";
            // 
            // frmCadFor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 610);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCadFor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Fornecedor";
            this.Load += new System.EventHandler(this.frmCadFor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtEst;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtMun;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumEnd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnCep;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.MaskedTextBox txtIes;
        private System.Windows.Forms.MaskedTextBox txtImu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox txtNumTel;
        private System.Windows.Forms.MaskedTextBox txtDdd;
        private System.Windows.Forms.Label label8;
    }
}