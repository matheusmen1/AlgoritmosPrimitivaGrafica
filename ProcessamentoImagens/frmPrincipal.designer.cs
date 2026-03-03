namespace ProcessamentoImagens
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
            this.btnAbrirImagem = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnEquacaoReta = new System.Windows.Forms.RadioButton();
            this.btnDDA = new System.Windows.Forms.RadioButton();
            this.btnPontoMedioRetas = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnEquacaoCircunferencia = new System.Windows.Forms.RadioButton();
            this.btnTrigonometria = new System.Windows.Forms.RadioButton();
            this.btnPontoMedioCircunferencia = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnPontoMedioElipse = new System.Windows.Forms.RadioButton();
            this.pictBoxImg1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbrirImagem
            // 
            this.btnAbrirImagem.Location = new System.Drawing.Point(5, 512);
            this.btnAbrirImagem.Name = "btnAbrirImagem";
            this.btnAbrirImagem.Size = new System.Drawing.Size(101, 23);
            this.btnAbrirImagem.TabIndex = 106;
            this.btnAbrirImagem.Text = "Abrir Imagem";
            this.btnAbrirImagem.UseVisualStyleBackColor = true;
            this.btnAbrirImagem.Click += new System.EventHandler(this.btnAbrirImagem_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(112, 512);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(101, 23);
            this.btnLimpar.TabIndex = 107;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.btnEquacaoReta);
            this.flowLayoutPanel1.Controls.Add(this.btnDDA);
            this.flowLayoutPanel1.Controls.Add(this.btnPontoMedioRetas);
            this.flowLayoutPanel1.Controls.Add(this.textBox2);
            this.flowLayoutPanel1.Controls.Add(this.btnEquacaoCircunferencia);
            this.flowLayoutPanel1.Controls.Add(this.btnTrigonometria);
            this.flowLayoutPanel1.Controls.Add(this.btnPontoMedioCircunferencia);
            this.flowLayoutPanel1.Controls.Add(this.textBox3);
            this.flowLayoutPanel1.Controls.Add(this.btnPontoMedioElipse);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 53);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(153, 244);
            this.flowLayoutPanel1.TabIndex = 108;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 111;
            this.textBox1.Text = "Retas";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEquacaoReta
            // 
            this.btnEquacaoReta.AutoSize = true;
            this.btnEquacaoReta.Location = new System.Drawing.Point(3, 29);
            this.btnEquacaoReta.Name = "btnEquacaoReta";
            this.btnEquacaoReta.Size = new System.Drawing.Size(109, 17);
            this.btnEquacaoReta.TabIndex = 1;
            this.btnEquacaoReta.TabStop = true;
            this.btnEquacaoReta.Text = "Equação da Reta";
            this.btnEquacaoReta.UseVisualStyleBackColor = true;
            this.btnEquacaoReta.CheckedChanged += new System.EventHandler(this.btnEquacaoReta_CheckedChanged);
            // 
            // btnDDA
            // 
            this.btnDDA.AutoSize = true;
            this.btnDDA.Location = new System.Drawing.Point(3, 52);
            this.btnDDA.Name = "btnDDA";
            this.btnDDA.Size = new System.Drawing.Size(48, 17);
            this.btnDDA.TabIndex = 2;
            this.btnDDA.TabStop = true;
            this.btnDDA.Text = "DDA";
            this.btnDDA.UseVisualStyleBackColor = true;
            this.btnDDA.CheckedChanged += new System.EventHandler(this.btnDDA_CheckedChanged);
            // 
            // btnPontoMedioRetas
            // 
            this.btnPontoMedioRetas.AutoSize = true;
            this.btnPontoMedioRetas.Location = new System.Drawing.Point(3, 75);
            this.btnPontoMedioRetas.Name = "btnPontoMedioRetas";
            this.btnPontoMedioRetas.Size = new System.Drawing.Size(85, 17);
            this.btnPontoMedioRetas.TabIndex = 3;
            this.btnPontoMedioRetas.TabStop = true;
            this.btnPontoMedioRetas.Text = "Ponto Médio";
            this.btnPontoMedioRetas.UseVisualStyleBackColor = true;
            this.btnPontoMedioRetas.CheckedChanged += new System.EventHandler(this.btnPontoMedioRetas_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 98);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 112;
            this.textBox2.Text = "Circunferência";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEquacaoCircunferencia
            // 
            this.btnEquacaoCircunferencia.AutoSize = true;
            this.btnEquacaoCircunferencia.Location = new System.Drawing.Point(3, 124);
            this.btnEquacaoCircunferencia.Name = "btnEquacaoCircunferencia";
            this.btnEquacaoCircunferencia.Size = new System.Drawing.Size(139, 17);
            this.btnEquacaoCircunferencia.TabIndex = 113;
            this.btnEquacaoCircunferencia.TabStop = true;
            this.btnEquacaoCircunferencia.Text = "Equação Circunferência";
            this.btnEquacaoCircunferencia.UseVisualStyleBackColor = true;
            this.btnEquacaoCircunferencia.CheckedChanged += new System.EventHandler(this.btnEquacaoCircunferencia_CheckedChanged);
            // 
            // btnTrigonometria
            // 
            this.btnTrigonometria.AutoSize = true;
            this.btnTrigonometria.Location = new System.Drawing.Point(3, 147);
            this.btnTrigonometria.Name = "btnTrigonometria";
            this.btnTrigonometria.Size = new System.Drawing.Size(89, 17);
            this.btnTrigonometria.TabIndex = 114;
            this.btnTrigonometria.TabStop = true;
            this.btnTrigonometria.Text = "Trigonometria";
            this.btnTrigonometria.UseVisualStyleBackColor = true;
            this.btnTrigonometria.CheckedChanged += new System.EventHandler(this.btnTrigonometria_CheckedChanged);
            // 
            // btnPontoMedioCircunferencia
            // 
            this.btnPontoMedioCircunferencia.AutoSize = true;
            this.btnPontoMedioCircunferencia.Location = new System.Drawing.Point(3, 170);
            this.btnPontoMedioCircunferencia.Name = "btnPontoMedioCircunferencia";
            this.btnPontoMedioCircunferencia.Size = new System.Drawing.Size(85, 17);
            this.btnPontoMedioCircunferencia.TabIndex = 115;
            this.btnPontoMedioCircunferencia.TabStop = true;
            this.btnPontoMedioCircunferencia.Text = "Ponto Médio";
            this.btnPontoMedioCircunferencia.UseVisualStyleBackColor = true;
            this.btnPontoMedioCircunferencia.CheckedChanged += new System.EventHandler(this.btnPontoMedioCircunferencia_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(3, 193);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 113;
            this.textBox3.Text = "Elipse";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPontoMedioElipse
            // 
            this.btnPontoMedioElipse.AutoSize = true;
            this.btnPontoMedioElipse.Location = new System.Drawing.Point(3, 219);
            this.btnPontoMedioElipse.Name = "btnPontoMedioElipse";
            this.btnPontoMedioElipse.Size = new System.Drawing.Size(85, 17);
            this.btnPontoMedioElipse.TabIndex = 1;
            this.btnPontoMedioElipse.TabStop = true;
            this.btnPontoMedioElipse.Text = "Ponto Médio";
            this.btnPontoMedioElipse.UseVisualStyleBackColor = true;
            this.btnPontoMedioElipse.CheckedChanged += new System.EventHandler(this.btnPontoMedioElipse_CheckedChanged);
            // 
            // pictBoxImg1
            // 
            this.pictBoxImg1.Location = new System.Drawing.Point(315, 25);
            this.pictBoxImg1.Name = "pictBoxImg1";
            this.pictBoxImg1.Size = new System.Drawing.Size(746, 510);
            this.pictBoxImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictBoxImg1.TabIndex = 110;
            this.pictBoxImg1.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 608);
            this.Controls.Add(this.pictBoxImg1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnAbrirImagem);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário Principal";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAbrirImagem;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictBoxImg1;
        private System.Windows.Forms.RadioButton btnEquacaoReta;
        private System.Windows.Forms.RadioButton btnDDA;
        private System.Windows.Forms.RadioButton btnPontoMedioRetas;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RadioButton btnPontoMedioElipse;
        private System.Windows.Forms.RadioButton btnEquacaoCircunferencia;
        private System.Windows.Forms.RadioButton btnTrigonometria;
        private System.Windows.Forms.RadioButton btnPontoMedioCircunferencia;
    }
}

