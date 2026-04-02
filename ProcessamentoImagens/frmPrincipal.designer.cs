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
            this.components = new System.ComponentModel.Container();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnPontoMedioElipse = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPontoMedioCircunferencia = new System.Windows.Forms.RadioButton();
            this.btnTrigonometria = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPontoMedioRetas = new System.Windows.Forms.RadioButton();
            this.btnEquacaoCircunferencia = new System.Windows.Forms.RadioButton();
            this.btnEquacaoReta = new System.Windows.Forms.RadioButton();
            this.btnDDA = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pictBoxImg1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.listViewPoligono = new System.Windows.Forms.ListView();
            this.btnAddPoligono = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExcluirPoligono = new System.Windows.Forms.Button();
            this.lbVertices = new System.Windows.Forms.Label();
            this.listViewVertices = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAplicarTranslacao = new System.Windows.Forms.Button();
            this.numUpDownTranslacaoY = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numUpDownTranslacaoX = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAplicarEscala = new System.Windows.Forms.Button();
            this.numUpDownEscalaY = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numUpDownEscalaX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAplicarRotacao = new System.Windows.Forms.Button();
            this.numUpDownGrauRotacao = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAplicarCisalhamento = new System.Windows.Forms.Button();
            this.numUpDownYCisalhamento = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numUpDownXCisalhamento = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxYReflexao = new System.Windows.Forms.CheckBox();
            this.checkBoxXReflexao = new System.Windows.Forms.CheckBox();
            this.btnAplicarReflexao = new System.Windows.Forms.Button();
            this.btnAplicarTudo2d = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTranslacaoY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTranslacaoX)).BeginInit();
            this.flowLayoutPanel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownEscalaY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownEscalaX)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownGrauRotacao)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownYCisalhamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownXCisalhamento)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(12, 589);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(170, 23);
            this.btnLimpar.TabIndex = 107;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox6);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(170, 344);
            this.flowLayoutPanel1.TabIndex = 108;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnPontoMedioElipse);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.btnPontoMedioCircunferencia);
            this.groupBox6.Controls.Add(this.btnTrigonometria);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.btnPontoMedioRetas);
            this.groupBox6.Controls.Add(this.btnEquacaoCircunferencia);
            this.groupBox6.Controls.Add(this.btnEquacaoReta);
            this.groupBox6.Controls.Add(this.btnDDA);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(11, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(150, 335);
            this.groupBox6.TabIndex = 121;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Primitivas Gráficas";
            // 
            // btnPontoMedioElipse
            // 
            this.btnPontoMedioElipse.AutoSize = true;
            this.btnPontoMedioElipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPontoMedioElipse.Location = new System.Drawing.Point(6, 267);
            this.btnPontoMedioElipse.Name = "btnPontoMedioElipse";
            this.btnPontoMedioElipse.Size = new System.Drawing.Size(85, 17);
            this.btnPontoMedioElipse.TabIndex = 1;
            this.btnPontoMedioElipse.TabStop = true;
            this.btnPontoMedioElipse.Text = "Ponto Médio";
            this.btnPontoMedioElipse.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 19);
            this.label6.TabIndex = 116;
            this.label6.Text = "Elipse";
            // 
            // btnPontoMedioCircunferencia
            // 
            this.btnPontoMedioCircunferencia.AutoSize = true;
            this.btnPontoMedioCircunferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPontoMedioCircunferencia.Location = new System.Drawing.Point(6, 218);
            this.btnPontoMedioCircunferencia.Name = "btnPontoMedioCircunferencia";
            this.btnPontoMedioCircunferencia.Size = new System.Drawing.Size(85, 17);
            this.btnPontoMedioCircunferencia.TabIndex = 115;
            this.btnPontoMedioCircunferencia.TabStop = true;
            this.btnPontoMedioCircunferencia.Text = "Ponto Médio";
            this.btnPontoMedioCircunferencia.UseVisualStyleBackColor = true;
            // 
            // btnTrigonometria
            // 
            this.btnTrigonometria.AutoSize = true;
            this.btnTrigonometria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrigonometria.Location = new System.Drawing.Point(6, 194);
            this.btnTrigonometria.Name = "btnTrigonometria";
            this.btnTrigonometria.Size = new System.Drawing.Size(89, 17);
            this.btnTrigonometria.TabIndex = 114;
            this.btnTrigonometria.TabStop = true;
            this.btnTrigonometria.Text = "Trigonometria";
            this.btnTrigonometria.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Circunferência";
            // 
            // btnPontoMedioRetas
            // 
            this.btnPontoMedioRetas.AutoSize = true;
            this.btnPontoMedioRetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPontoMedioRetas.Location = new System.Drawing.Point(5, 125);
            this.btnPontoMedioRetas.Name = "btnPontoMedioRetas";
            this.btnPontoMedioRetas.Size = new System.Drawing.Size(85, 17);
            this.btnPontoMedioRetas.TabIndex = 3;
            this.btnPontoMedioRetas.TabStop = true;
            this.btnPontoMedioRetas.Text = "Ponto Médio";
            this.btnPontoMedioRetas.UseVisualStyleBackColor = true;
            // 
            // btnEquacaoCircunferencia
            // 
            this.btnEquacaoCircunferencia.AutoSize = true;
            this.btnEquacaoCircunferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquacaoCircunferencia.Location = new System.Drawing.Point(6, 171);
            this.btnEquacaoCircunferencia.Name = "btnEquacaoCircunferencia";
            this.btnEquacaoCircunferencia.Size = new System.Drawing.Size(139, 17);
            this.btnEquacaoCircunferencia.TabIndex = 113;
            this.btnEquacaoCircunferencia.TabStop = true;
            this.btnEquacaoCircunferencia.Text = "Equação Circunferência";
            this.btnEquacaoCircunferencia.UseVisualStyleBackColor = true;
            // 
            // btnEquacaoReta
            // 
            this.btnEquacaoReta.AutoSize = true;
            this.btnEquacaoReta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquacaoReta.Location = new System.Drawing.Point(5, 79);
            this.btnEquacaoReta.Name = "btnEquacaoReta";
            this.btnEquacaoReta.Size = new System.Drawing.Size(109, 17);
            this.btnEquacaoReta.TabIndex = 1;
            this.btnEquacaoReta.TabStop = true;
            this.btnEquacaoReta.Text = "Equação da Reta";
            this.btnEquacaoReta.UseVisualStyleBackColor = true;
            // 
            // btnDDA
            // 
            this.btnDDA.AutoSize = true;
            this.btnDDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDDA.Location = new System.Drawing.Point(5, 102);
            this.btnDDA.Name = "btnDDA";
            this.btnDDA.Size = new System.Drawing.Size(48, 17);
            this.btnDDA.TabIndex = 2;
            this.btnDDA.TabStop = true;
            this.btnDDA.Text = "DDA";
            this.btnDDA.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Retas";
            // 
            // pictBoxImg1
            // 
            this.pictBoxImg1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictBoxImg1.Location = new System.Drawing.Point(184, 12);
            this.pictBoxImg1.Name = "pictBoxImg1";
            this.pictBoxImg1.Size = new System.Drawing.Size(650, 600);
            this.pictBoxImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictBoxImg1.TabIndex = 110;
            this.pictBoxImg1.TabStop = false;
            this.pictBoxImg1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictBoxImg1_MouseClick);
            this.pictBoxImg1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictBoxImg1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Polígonos";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.listViewPoligono);
            this.flowLayoutPanel3.Controls.Add(this.btnAddPoligono);
            this.flowLayoutPanel3.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel3.Controls.Add(this.btnExcluirPoligono);
            this.flowLayoutPanel3.Controls.Add(this.lbVertices);
            this.flowLayoutPanel3.Controls.Add(this.listViewVertices);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(837, 12);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(169, 600);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // listViewPoligono
            // 
            this.listViewPoligono.HideSelection = false;
            this.listViewPoligono.Location = new System.Drawing.Point(3, 23);
            this.listViewPoligono.Name = "listViewPoligono";
            this.listViewPoligono.Size = new System.Drawing.Size(159, 154);
            this.listViewPoligono.TabIndex = 1;
            this.listViewPoligono.UseCompatibleStateImageBehavior = false;
            this.listViewPoligono.SelectedIndexChanged += new System.EventHandler(this.listViewPoligono_SelectedIndexChanged);
            // 
            // btnAddPoligono
            // 
            this.btnAddPoligono.Location = new System.Drawing.Point(3, 183);
            this.btnAddPoligono.Name = "btnAddPoligono";
            this.btnAddPoligono.Size = new System.Drawing.Size(159, 23);
            this.btnAddPoligono.TabIndex = 2;
            this.btnAddPoligono.Text = "Add Polígono";
            this.btnAddPoligono.UseVisualStyleBackColor = true;
            this.btnAddPoligono.Click += new System.EventHandler(this.btnAddPoligono_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(3, 212);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(159, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluirPoligono
            // 
            this.btnExcluirPoligono.BackColor = System.Drawing.Color.Red;
            this.btnExcluirPoligono.ForeColor = System.Drawing.Color.White;
            this.btnExcluirPoligono.Location = new System.Drawing.Point(3, 241);
            this.btnExcluirPoligono.Name = "btnExcluirPoligono";
            this.btnExcluirPoligono.Size = new System.Drawing.Size(159, 23);
            this.btnExcluirPoligono.TabIndex = 6;
            this.btnExcluirPoligono.Text = "Excluir";
            this.btnExcluirPoligono.UseVisualStyleBackColor = false;
            this.btnExcluirPoligono.Visible = false;
            this.btnExcluirPoligono.Click += new System.EventHandler(this.btnExcluirPoligono_Click);
            // 
            // lbVertices
            // 
            this.lbVertices.AutoSize = true;
            this.lbVertices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVertices.Location = new System.Drawing.Point(3, 267);
            this.lbVertices.Name = "lbVertices";
            this.lbVertices.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lbVertices.Size = new System.Drawing.Size(67, 30);
            this.lbVertices.TabIndex = 7;
            this.lbVertices.Text = "Vertices";
            this.lbVertices.Visible = false;
            // 
            // listViewVertices
            // 
            this.listViewVertices.HideSelection = false;
            this.listViewVertices.Location = new System.Drawing.Point(3, 300);
            this.listViewVertices.Name = "listViewVertices";
            this.listViewVertices.Size = new System.Drawing.Size(159, 154);
            this.listViewVertices.TabIndex = 8;
            this.listViewVertices.UseCompatibleStateImageBehavior = false;
            this.listViewVertices.Visible = false;
            this.listViewVertices.SelectedIndexChanged += new System.EventHandler(this.listViewVertices_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAplicarTranslacao);
            this.groupBox1.Controls.Add(this.numUpDownTranslacaoY);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.numUpDownTranslacaoX);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 103);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Translação (T)";
            // 
            // btnAplicarTranslacao
            // 
            this.btnAplicarTranslacao.Location = new System.Drawing.Point(6, 71);
            this.btnAplicarTranslacao.Name = "btnAplicarTranslacao";
            this.btnAplicarTranslacao.Size = new System.Drawing.Size(115, 26);
            this.btnAplicarTranslacao.TabIndex = 5;
            this.btnAplicarTranslacao.Text = "Aplicar";
            this.btnAplicarTranslacao.UseVisualStyleBackColor = true;
            this.btnAplicarTranslacao.Click += new System.EventHandler(this.btnAplicarTranslacao_Click);
            // 
            // numUpDownTranslacaoY
            // 
            this.numUpDownTranslacaoY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDownTranslacaoY.Location = new System.Drawing.Point(30, 45);
            this.numUpDownTranslacaoY.Maximum = new decimal(new int[] {
            650,
            0,
            0,
            0});
            this.numUpDownTranslacaoY.Minimum = new decimal(new int[] {
            650,
            0,
            0,
            -2147483648});
            this.numUpDownTranslacaoY.Name = "numUpDownTranslacaoY";
            this.numUpDownTranslacaoY.Size = new System.Drawing.Size(91, 22);
            this.numUpDownTranslacaoY.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "Y";
            // 
            // numUpDownTranslacaoX
            // 
            this.numUpDownTranslacaoX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDownTranslacaoX.Location = new System.Drawing.Point(30, 19);
            this.numUpDownTranslacaoX.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numUpDownTranslacaoX.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            -2147483648});
            this.numUpDownTranslacaoX.Name = "numUpDownTranslacaoX";
            this.numUpDownTranslacaoX.Size = new System.Drawing.Size(91, 22);
            this.numUpDownTranslacaoX.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "X";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label11);
            this.flowLayoutPanel5.Controls.Add(this.groupBox3);
            this.flowLayoutPanel5.Controls.Add(this.groupBox1);
            this.flowLayoutPanel5.Controls.Add(this.groupBox4);
            this.flowLayoutPanel5.Controls.Add(this.groupBox2);
            this.flowLayoutPanel5.Controls.Add(this.groupBox5);
            this.flowLayoutPanel5.Controls.Add(this.btnAplicarTudo2d);
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(1012, 12);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(155, 600);
            this.flowLayoutPanel5.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "Transformações:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnAplicarEscala);
            this.groupBox3.Controls.Add(this.numUpDownEscalaY);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.numUpDownEscalaX);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 103);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Escala (S)";
            // 
            // btnAplicarEscala
            // 
            this.btnAplicarEscala.Location = new System.Drawing.Point(6, 71);
            this.btnAplicarEscala.Name = "btnAplicarEscala";
            this.btnAplicarEscala.Size = new System.Drawing.Size(115, 26);
            this.btnAplicarEscala.TabIndex = 5;
            this.btnAplicarEscala.Text = "Aplicar";
            this.btnAplicarEscala.UseVisualStyleBackColor = true;
            this.btnAplicarEscala.Click += new System.EventHandler(this.btnAplicarEscala_Click);
            // 
            // numUpDownEscalaY
            // 
            this.numUpDownEscalaY.DecimalPlaces = 2;
            this.numUpDownEscalaY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numUpDownEscalaY.Location = new System.Drawing.Point(30, 45);
            this.numUpDownEscalaY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDownEscalaY.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numUpDownEscalaY.Name = "numUpDownEscalaY";
            this.numUpDownEscalaY.Size = new System.Drawing.Size(91, 22);
            this.numUpDownEscalaY.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Y";
            // 
            // numUpDownEscalaX
            // 
            this.numUpDownEscalaX.DecimalPlaces = 2;
            this.numUpDownEscalaX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numUpDownEscalaX.Location = new System.Drawing.Point(30, 19);
            this.numUpDownEscalaX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDownEscalaX.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numUpDownEscalaX.Name = "numUpDownEscalaX";
            this.numUpDownEscalaX.Size = new System.Drawing.Size(91, 22);
            this.numUpDownEscalaX.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "X";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAplicarRotacao);
            this.groupBox4.Controls.Add(this.numUpDownGrauRotacao);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 241);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(143, 73);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Rotação (R)";
            // 
            // btnAplicarRotacao
            // 
            this.btnAplicarRotacao.Location = new System.Drawing.Point(6, 44);
            this.btnAplicarRotacao.Name = "btnAplicarRotacao";
            this.btnAplicarRotacao.Size = new System.Drawing.Size(115, 26);
            this.btnAplicarRotacao.TabIndex = 5;
            this.btnAplicarRotacao.Text = "Aplicar";
            this.btnAplicarRotacao.UseVisualStyleBackColor = true;
            this.btnAplicarRotacao.Click += new System.EventHandler(this.btnAplicarRotacao_Click);
            // 
            // numUpDownGrauRotacao
            // 
            this.numUpDownGrauRotacao.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDownGrauRotacao.Location = new System.Drawing.Point(6, 18);
            this.numUpDownGrauRotacao.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numUpDownGrauRotacao.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numUpDownGrauRotacao.Name = "numUpDownGrauRotacao";
            this.numUpDownGrauRotacao.Size = new System.Drawing.Size(94, 22);
            this.numUpDownGrauRotacao.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "°";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAplicarCisalhamento);
            this.groupBox2.Controls.Add(this.numUpDownYCisalhamento);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numUpDownXCisalhamento);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 103);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cisalhamento";
            // 
            // btnAplicarCisalhamento
            // 
            this.btnAplicarCisalhamento.Location = new System.Drawing.Point(6, 71);
            this.btnAplicarCisalhamento.Name = "btnAplicarCisalhamento";
            this.btnAplicarCisalhamento.Size = new System.Drawing.Size(115, 26);
            this.btnAplicarCisalhamento.TabIndex = 5;
            this.btnAplicarCisalhamento.Text = "Aplicar";
            this.btnAplicarCisalhamento.UseVisualStyleBackColor = true;
            this.btnAplicarCisalhamento.Click += new System.EventHandler(this.btnAplicarCisalhamento_Click);
            // 
            // numUpDownYCisalhamento
            // 
            this.numUpDownYCisalhamento.Location = new System.Drawing.Point(30, 45);
            this.numUpDownYCisalhamento.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numUpDownYCisalhamento.Name = "numUpDownYCisalhamento";
            this.numUpDownYCisalhamento.Size = new System.Drawing.Size(91, 22);
            this.numUpDownYCisalhamento.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Y";
            // 
            // numUpDownXCisalhamento
            // 
            this.numUpDownXCisalhamento.Location = new System.Drawing.Point(30, 19);
            this.numUpDownXCisalhamento.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numUpDownXCisalhamento.Name = "numUpDownXCisalhamento";
            this.numUpDownXCisalhamento.Size = new System.Drawing.Size(91, 22);
            this.numUpDownXCisalhamento.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "X";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxYReflexao);
            this.groupBox5.Controls.Add(this.checkBoxXReflexao);
            this.groupBox5.Controls.Add(this.btnAplicarReflexao);
            this.groupBox5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(3, 429);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(143, 106);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Reflexão";
            // 
            // checkBoxYReflexao
            // 
            this.checkBoxYReflexao.AutoSize = true;
            this.checkBoxYReflexao.Location = new System.Drawing.Point(6, 47);
            this.checkBoxYReflexao.Name = "checkBoxYReflexao";
            this.checkBoxYReflexao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxYReflexao.Size = new System.Drawing.Size(69, 20);
            this.checkBoxYReflexao.TabIndex = 7;
            this.checkBoxYReflexao.Text = "Eixo Y";
            this.checkBoxYReflexao.UseVisualStyleBackColor = true;
            // 
            // checkBoxXReflexao
            // 
            this.checkBoxXReflexao.AutoSize = true;
            this.checkBoxXReflexao.Location = new System.Drawing.Point(6, 21);
            this.checkBoxXReflexao.Name = "checkBoxXReflexao";
            this.checkBoxXReflexao.Size = new System.Drawing.Size(70, 20);
            this.checkBoxXReflexao.TabIndex = 6;
            this.checkBoxXReflexao.Text = "Eixo X";
            this.checkBoxXReflexao.UseVisualStyleBackColor = true;
            // 
            // btnAplicarReflexao
            // 
            this.btnAplicarReflexao.Location = new System.Drawing.Point(6, 73);
            this.btnAplicarReflexao.Name = "btnAplicarReflexao";
            this.btnAplicarReflexao.Size = new System.Drawing.Size(115, 26);
            this.btnAplicarReflexao.TabIndex = 5;
            this.btnAplicarReflexao.Text = "Aplicar";
            this.btnAplicarReflexao.UseVisualStyleBackColor = true;
            this.btnAplicarReflexao.Click += new System.EventHandler(this.btnAplicarReflexao_Click);
            // 
            // btnAplicarTudo2d
            // 
            this.btnAplicarTudo2d.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAplicarTudo2d.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarTudo2d.Location = new System.Drawing.Point(3, 541);
            this.btnAplicarTudo2d.Name = "btnAplicarTudo2d";
            this.btnAplicarTudo2d.Size = new System.Drawing.Size(143, 26);
            this.btnAplicarTudo2d.TabIndex = 8;
            this.btnAplicarTudo2d.Text = "APLICAR TUDO";
            this.btnAplicarTudo2d.UseVisualStyleBackColor = false;
            this.btnAplicarTudo2d.Click += new System.EventHandler(this.btnAplicarTudo2d_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 617);
            this.Controls.Add(this.flowLayoutPanel5);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.pictBoxImg1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnLimpar);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário Principal";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTranslacaoY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTranslacaoX)).EndInit();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownEscalaY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownEscalaX)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownGrauRotacao)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownYCisalhamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownXCisalhamento)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictBoxImg1;
        private System.Windows.Forms.RadioButton btnEquacaoReta;
        private System.Windows.Forms.RadioButton btnDDA;
        private System.Windows.Forms.RadioButton btnPontoMedioRetas;
        private System.Windows.Forms.RadioButton btnPontoMedioElipse;
        private System.Windows.Forms.RadioButton btnEquacaoCircunferencia;
        private System.Windows.Forms.RadioButton btnTrigonometria;
        private System.Windows.Forms.RadioButton btnPontoMedioCircunferencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewPoligono;
        private System.Windows.Forms.Button btnAddPoligono;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExcluirPoligono;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numUpDownTranslacaoY;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numUpDownTranslacaoX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAplicarTranslacao;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAplicarEscala;
        private System.Windows.Forms.NumericUpDown numUpDownEscalaY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numUpDownEscalaX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAplicarRotacao;
        private System.Windows.Forms.NumericUpDown numUpDownGrauRotacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAplicarCisalhamento;
        private System.Windows.Forms.NumericUpDown numUpDownYCisalhamento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numUpDownXCisalhamento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAplicarReflexao;
        private System.Windows.Forms.Label lbVertices;
        private System.Windows.Forms.ListView listViewVertices;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxYReflexao;
        private System.Windows.Forms.CheckBox checkBoxXReflexao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAplicarTudo2d;
    }
}

