namespace DbConsole
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            lib.Visual.Components.SyntaxSettings syntaxSettings1 = new lib.Visual.Components.SyntaxSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            lib.Visual.Components.SyntaxSettings syntaxSettings2 = new lib.Visual.Components.SyntaxSettings();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdColumns = new System.Windows.Forms.DataGridView();
            this.Campos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.cmTables = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.novaTabelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoverTabela = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLimparTabela = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparadorRemoverLimpar = new System.Windows.Forms.ToolStripSeparator();
            this.organizarPorNomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizarPorChaveEstrangeiraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizarPorCriaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exibirSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirInsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilterTables = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabDados = new System.Windows.Forms.TabControl();
            this.tbSql = new System.Windows.Forms.TabPage();
            this.grdRegistros = new System.Windows.Forms.DataGridView();
            this.lblErroGrid = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtScript = new lib.Visual.Components.SyntaxRichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEsquema = new System.Windows.Forms.TabPage();
            this.grdEsquema = new System.Windows.Forms.DataGridView();
            this.cmbEsquema = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtDependencias = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstInstrucoes = new System.Windows.Forms.ListBox();
            this.tbLog = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstReportTotalizar = new System.Windows.Forms.CheckedListBox();
            this.lstReportExibir = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnExecutarReport = new System.Windows.Forms.Button();
            this.cmbReportStyle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTempaltes = new System.Windows.Forms.ComboBox();
            this.bsNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.bsRegistros = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.txtSql = new lib.Visual.Components.SyntaxRichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.conexõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirConexãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limparToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbEscreverMaiusculo = new System.Windows.Forms.ToolStripMenuItem();
            this.cbEditarDados = new System.Windows.Forms.ToolStripMenuItem();
            this.cbPontoVirgula = new System.Windows.Forms.ToolStripMenuItem();
            this.cbEsquema = new System.Windows.Forms.ToolStripMenuItem();
            this.cbLimitar = new System.Windows.Forms.ToolStripMenuItem();
            this.cbUsaSchema = new System.Windows.Forms.ToolStripMenuItem();
            this.cbUtilizaColchetes = new System.Windows.Forms.ToolStripMenuItem();
            this.cbSemBinding = new System.Windows.Forms.ToolStripMenuItem();
            this.cbEstiloVisual = new System.Windows.Forms.ToolStripMenuItem();
            this.cbInsertIdentity = new System.Windows.Forms.ToolStripMenuItem();
            this.cbExibeRemoverLimpar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbUpdateColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.cbTablesAndViews = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformarEmMaiúsculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.substituirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metadataComDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpesaDasTabelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truncateDasTabelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoçãoDasTabelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeCamposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeChavesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelasPorTamanhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processosAbertosSQLServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.executarArquivoDeScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compararBasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnCancelProgress = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.lblBanco = new System.Windows.Forms.Label();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdColumns)).BeginInit();
            this.cmTables.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabDados.SuspendLayout();
            this.tbSql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRegistros)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbEsquema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEsquema)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tbLog.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsNavigator)).BeginInit();
            this.bsNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegistros)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdColumns);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.lstTables);
            this.panel1.Controls.Add(this.txtFilterTables);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 536);
            this.panel1.TabIndex = 0;
            // 
            // grdColumns
            // 
            this.grdColumns.AllowUserToAddRows = false;
            this.grdColumns.AllowUserToDeleteRows = false;
            this.grdColumns.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grdColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdColumns.BackgroundColor = System.Drawing.Color.DarkGray;
            this.grdColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Campos,
            this.Tipo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdColumns.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdColumns.Location = new System.Drawing.Point(0, 370);
            this.grdColumns.Margin = new System.Windows.Forms.Padding(4);
            this.grdColumns.Name = "grdColumns";
            this.grdColumns.ReadOnly = true;
            this.grdColumns.RowHeadersVisible = false;
            this.grdColumns.RowHeadersWidth = 51;
            this.grdColumns.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            this.grdColumns.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdColumns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdColumns.Size = new System.Drawing.Size(267, 166);
            this.grdColumns.TabIndex = 3;
            // 
            // Campos
            // 
            this.Campos.DataPropertyName = "Campos";
            this.Campos.HeaderText = "Campos";
            this.Campos.MinimumWidth = 6;
            this.Campos.Name = "Campos";
            this.Campos.ReadOnly = true;
            this.Campos.Width = 125;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 125;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 364);
            this.splitter2.Margin = new System.Windows.Forms.Padding(4);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(267, 6);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // lstTables
            // 
            this.lstTables.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTables.ContextMenuStrip = this.cmTables;
            this.lstTables.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTables.ForeColor = System.Drawing.Color.Black;
            this.lstTables.FormattingEnabled = true;
            this.lstTables.ItemHeight = 20;
            this.lstTables.Location = new System.Drawing.Point(0, 22);
            this.lstTables.Margin = new System.Windows.Forms.Padding(4);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(267, 342);
            this.lstTables.TabIndex = 0;
            this.lstTables.SelectedIndexChanged += new System.EventHandler(this.lstTables_SelectedIndexChanged);
            // 
            // cmTables
            // 
            this.cmTables.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmTables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaTabelaToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.btnRemoverTabela,
            this.btnLimparTabela,
            this.SeparadorRemoverLimpar,
            this.organizarPorNomeToolStripMenuItem,
            this.organizarPorChaveEstrangeiraToolStripMenuItem,
            this.organizarPorCriaçãoToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exibirSQLToolStripMenuItem,
            this.exibirInsertToolStripMenuItem,
            this.exibirUpdateToolStripMenuItem,
            this.exibirDeleteToolStripMenuItem});
            this.cmTables.Name = "cmTables";
            this.cmTables.Size = new System.Drawing.Size(293, 280);
            // 
            // novaTabelaToolStripMenuItem
            // 
            this.novaTabelaToolStripMenuItem.Name = "novaTabelaToolStripMenuItem";
            this.novaTabelaToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.novaTabelaToolStripMenuItem.Text = "Nova Tabela";
            this.novaTabelaToolStripMenuItem.Visible = false;
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Visible = false;
            // 
            // btnRemoverTabela
            // 
            this.btnRemoverTabela.Name = "btnRemoverTabela";
            this.btnRemoverTabela.Size = new System.Drawing.Size(292, 24);
            this.btnRemoverTabela.Text = "Remover";
            this.btnRemoverTabela.Visible = false;
            this.btnRemoverTabela.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // btnLimparTabela
            // 
            this.btnLimparTabela.Name = "btnLimparTabela";
            this.btnLimparTabela.Size = new System.Drawing.Size(292, 24);
            this.btnLimparTabela.Text = "Limpar";
            this.btnLimparTabela.Visible = false;
            this.btnLimparTabela.Click += new System.EventHandler(this.limparToolStripMenuItem1_Click);
            // 
            // SeparadorRemoverLimpar
            // 
            this.SeparadorRemoverLimpar.Name = "SeparadorRemoverLimpar";
            this.SeparadorRemoverLimpar.Size = new System.Drawing.Size(289, 6);
            this.SeparadorRemoverLimpar.Visible = false;
            // 
            // organizarPorNomeToolStripMenuItem
            // 
            this.organizarPorNomeToolStripMenuItem.Name = "organizarPorNomeToolStripMenuItem";
            this.organizarPorNomeToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.organizarPorNomeToolStripMenuItem.Text = "Organizar por Nome";
            this.organizarPorNomeToolStripMenuItem.Click += new System.EventHandler(this.organizarPorNomeToolStripMenuItem_Click);
            // 
            // organizarPorChaveEstrangeiraToolStripMenuItem
            // 
            this.organizarPorChaveEstrangeiraToolStripMenuItem.Name = "organizarPorChaveEstrangeiraToolStripMenuItem";
            this.organizarPorChaveEstrangeiraToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.organizarPorChaveEstrangeiraToolStripMenuItem.Text = "Organizar por Chave Estrangeira";
            this.organizarPorChaveEstrangeiraToolStripMenuItem.Click += new System.EventHandler(this.organizarPorChaveEstrangeiraToolStripMenuItem_Click);
            // 
            // organizarPorCriaçãoToolStripMenuItem
            // 
            this.organizarPorCriaçãoToolStripMenuItem.Name = "organizarPorCriaçãoToolStripMenuItem";
            this.organizarPorCriaçãoToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.organizarPorCriaçãoToolStripMenuItem.Text = "Organizar por Criação";
            this.organizarPorCriaçãoToolStripMenuItem.Click += new System.EventHandler(this.organizarPorCriaçãoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(289, 6);
            // 
            // exibirSQLToolStripMenuItem
            // 
            this.exibirSQLToolStripMenuItem.Name = "exibirSQLToolStripMenuItem";
            this.exibirSQLToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.exibirSQLToolStripMenuItem.Text = "Exibir Select";
            this.exibirSQLToolStripMenuItem.Click += new System.EventHandler(this.exibirSQLToolStripMenuItem_Click);
            // 
            // exibirInsertToolStripMenuItem
            // 
            this.exibirInsertToolStripMenuItem.Name = "exibirInsertToolStripMenuItem";
            this.exibirInsertToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.exibirInsertToolStripMenuItem.Text = "Exibir Insert";
            this.exibirInsertToolStripMenuItem.Click += new System.EventHandler(this.exibirInsertToolStripMenuItem_Click);
            // 
            // exibirUpdateToolStripMenuItem
            // 
            this.exibirUpdateToolStripMenuItem.Name = "exibirUpdateToolStripMenuItem";
            this.exibirUpdateToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.exibirUpdateToolStripMenuItem.Text = "Exibir Update";
            this.exibirUpdateToolStripMenuItem.Click += new System.EventHandler(this.exibirUpdateToolStripMenuItem_Click);
            // 
            // exibirDeleteToolStripMenuItem
            // 
            this.exibirDeleteToolStripMenuItem.Name = "exibirDeleteToolStripMenuItem";
            this.exibirDeleteToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.exibirDeleteToolStripMenuItem.Text = "Exibir Delete";
            this.exibirDeleteToolStripMenuItem.Click += new System.EventHandler(this.exibirDeleteToolStripMenuItem_Click);
            // 
            // txtFilterTables
            // 
            this.txtFilterTables.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFilterTables.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFilterTables.Location = new System.Drawing.Point(0, 0);
            this.txtFilterTables.Name = "txtFilterTables";
            this.txtFilterTables.Size = new System.Drawing.Size(267, 22);
            this.txtFilterTables.TabIndex = 4;
            this.txtFilterTables.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(267, 28);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(7, 536);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.splitter3);
            this.panel2.Controls.Add(this.txtSql);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(274, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(705, 536);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabDados);
            this.panel3.Controls.Add(this.bsNavigator);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 126);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(705, 410);
            this.panel3.TabIndex = 2;
            // 
            // tabDados
            // 
            this.tabDados.Controls.Add(this.tbSql);
            this.tabDados.Controls.Add(this.tabPage2);
            this.tabDados.Controls.Add(this.tbEsquema);
            this.tabDados.Controls.Add(this.tabPage4);
            this.tabDados.Controls.Add(this.tabPage3);
            this.tabDados.Controls.Add(this.tbLog);
            this.tabDados.Controls.Add(this.tabPage1);
            this.tabDados.Controls.Add(this.tabPage5);
            this.tabDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDados.Location = new System.Drawing.Point(0, 27);
            this.tabDados.Margin = new System.Windows.Forms.Padding(4);
            this.tabDados.Name = "tabDados";
            this.tabDados.SelectedIndex = 0;
            this.tabDados.Size = new System.Drawing.Size(705, 383);
            this.tabDados.TabIndex = 2;
            // 
            // tbSql
            // 
            this.tbSql.BackColor = System.Drawing.Color.Gray;
            this.tbSql.Controls.Add(this.grdRegistros);
            this.tbSql.Controls.Add(this.lblErroGrid);
            this.tbSql.Location = new System.Drawing.Point(4, 25);
            this.tbSql.Margin = new System.Windows.Forms.Padding(4);
            this.tbSql.Name = "tbSql";
            this.tbSql.Padding = new System.Windows.Forms.Padding(4);
            this.tbSql.Size = new System.Drawing.Size(697, 354);
            this.tbSql.TabIndex = 0;
            this.tbSql.Text = "Dados";
            // 
            // grdRegistros
            // 
            this.grdRegistros.AllowUserToAddRows = false;
            this.grdRegistros.AllowUserToResizeRows = false;
            this.grdRegistros.BackgroundColor = System.Drawing.Color.DarkGray;
            this.grdRegistros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdRegistros.ColumnHeadersHeight = 29;
            this.grdRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRegistros.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRegistros.EnableHeadersVisualStyles = false;
            this.grdRegistros.Location = new System.Drawing.Point(4, 4);
            this.grdRegistros.Margin = new System.Windows.Forms.Padding(4);
            this.grdRegistros.Name = "grdRegistros";
            this.grdRegistros.ReadOnly = true;
            this.grdRegistros.RowHeadersWidth = 51;
            this.grdRegistros.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdRegistros.Size = new System.Drawing.Size(689, 330);
            this.grdRegistros.TabIndex = 2;
            this.grdRegistros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRegistros_CellDoubleClick);
            this.grdRegistros.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdRegistros_DataError);
            // 
            // lblErroGrid
            // 
            this.lblErroGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblErroGrid.Location = new System.Drawing.Point(4, 334);
            this.lblErroGrid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErroGrid.Name = "lblErroGrid";
            this.lblErroGrid.Size = new System.Drawing.Size(689, 16);
            this.lblErroGrid.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtScript);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(697, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Estrutura";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtScript
            // 
            this.txtScript.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScript.Location = new System.Drawing.Point(4, 4);
            this.txtScript.Margin = new System.Windows.Forms.Padding(4);
            this.txtScript.Name = "txtScript";
            this.txtScript.ReadOnly = true;
            syntaxSettings1.BeginComment = null;
            syntaxSettings1.Comment = null;
            syntaxSettings1.CommentColor = System.Drawing.Color.Empty;
            syntaxSettings1.EnableComments = false;
            syntaxSettings1.EnableMembers = false;
            syntaxSettings1.EnableNumbers = false;
            syntaxSettings1.EnableStrings = false;
            syntaxSettings1.EndComment = null;
            syntaxSettings1.KeywordColor = System.Drawing.Color.Empty;
            syntaxSettings1.MemberColor = System.Drawing.Color.Empty;
            syntaxSettings1.NumberColor = System.Drawing.Color.Empty;
            syntaxSettings1.StringColor = System.Drawing.Color.Empty;
            this.txtScript.Settings = syntaxSettings1;
            this.txtScript.Size = new System.Drawing.Size(689, 275);
            this.txtScript.TabIndex = 0;
            this.txtScript.Text = "";
            this.txtScript.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtAlias);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(4, 279);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(689, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "\'";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(553, 23);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 4;
            this.button3.Text = "Alteração";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(445, 23);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "Inserção";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Estrutura";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(72, 27);
            this.txtAlias.Margin = new System.Windows.Forms.Padding(4);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(256, 22);
            this.txtAlias.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apelido";
            // 
            // tbEsquema
            // 
            this.tbEsquema.Controls.Add(this.grdEsquema);
            this.tbEsquema.Controls.Add(this.cmbEsquema);
            this.tbEsquema.Location = new System.Drawing.Point(4, 25);
            this.tbEsquema.Margin = new System.Windows.Forms.Padding(4);
            this.tbEsquema.Name = "tbEsquema";
            this.tbEsquema.Padding = new System.Windows.Forms.Padding(4);
            this.tbEsquema.Size = new System.Drawing.Size(697, 354);
            this.tbEsquema.TabIndex = 6;
            this.tbEsquema.Text = "Esquema";
            this.tbEsquema.UseVisualStyleBackColor = true;
            this.tbEsquema.Enter += new System.EventHandler(this.tbEsquema_Enter);
            // 
            // grdEsquema
            // 
            this.grdEsquema.AllowUserToAddRows = false;
            this.grdEsquema.AllowUserToDeleteRows = false;
            this.grdEsquema.AllowUserToResizeRows = false;
            this.grdEsquema.ColumnHeadersHeight = 29;
            this.grdEsquema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdEsquema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEsquema.Location = new System.Drawing.Point(4, 28);
            this.grdEsquema.Margin = new System.Windows.Forms.Padding(4);
            this.grdEsquema.Name = "grdEsquema";
            this.grdEsquema.ReadOnly = true;
            this.grdEsquema.RowHeadersWidth = 51;
            this.grdEsquema.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdEsquema.Size = new System.Drawing.Size(689, 322);
            this.grdEsquema.TabIndex = 1;
            // 
            // cmbEsquema
            // 
            this.cmbEsquema.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbEsquema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEsquema.FormattingEnabled = true;
            this.cmbEsquema.Location = new System.Drawing.Point(4, 4);
            this.cmbEsquema.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEsquema.Name = "cmbEsquema";
            this.cmbEsquema.Size = new System.Drawing.Size(689, 24);
            this.cmbEsquema.TabIndex = 2;
            this.cmbEsquema.SelectedIndexChanged += new System.EventHandler(this.cmbEsquema_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtDependencias);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(697, 354);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "Dependências";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtDependencias
            // 
            this.txtDependencias.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDependencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDependencias.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDependencias.Location = new System.Drawing.Point(4, 4);
            this.txtDependencias.Margin = new System.Windows.Forms.Padding(4);
            this.txtDependencias.Multiline = true;
            this.txtDependencias.Name = "txtDependencias";
            this.txtDependencias.ReadOnly = true;
            this.txtDependencias.Size = new System.Drawing.Size(689, 346);
            this.txtDependencias.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lstInstrucoes);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(697, 354);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Últimas Instruções";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lstInstrucoes
            // 
            this.lstInstrucoes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstInstrucoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInstrucoes.FormattingEnabled = true;
            this.lstInstrucoes.ItemHeight = 16;
            this.lstInstrucoes.Location = new System.Drawing.Point(4, 4);
            this.lstInstrucoes.Margin = new System.Windows.Forms.Padding(4);
            this.lstInstrucoes.Name = "lstInstrucoes";
            this.lstInstrucoes.Size = new System.Drawing.Size(689, 346);
            this.lstInstrucoes.TabIndex = 0;
            this.lstInstrucoes.SelectedIndexChanged += new System.EventHandler(this.lstInstrucoes_SelectedIndexChanged);
            // 
            // tbLog
            // 
            this.tbLog.Controls.Add(this.txtLog);
            this.tbLog.Location = new System.Drawing.Point(4, 25);
            this.tbLog.Margin = new System.Windows.Forms.Padding(4);
            this.tbLog.Name = "tbLog";
            this.tbLog.Padding = new System.Windows.Forms.Padding(4);
            this.tbLog.Size = new System.Drawing.Size(697, 354);
            this.tbLog.TabIndex = 3;
            this.tbLog.Text = "Logs";
            this.tbLog.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(4, 4);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(689, 346);
            this.txtLog.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(697, 354);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Relatorio";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstReportTotalizar);
            this.groupBox3.Controls.Add(this.lstReportExibir);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(4, 59);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(689, 157);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Exibir Colunas                                                          | Totali" +
    "zar Colunas";
            // 
            // lstReportTotalizar
            // 
            this.lstReportTotalizar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstReportTotalizar.CheckOnClick = true;
            this.lstReportTotalizar.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstReportTotalizar.FormattingEnabled = true;
            this.lstReportTotalizar.Location = new System.Drawing.Point(336, 19);
            this.lstReportTotalizar.Margin = new System.Windows.Forms.Padding(4);
            this.lstReportTotalizar.Name = "lstReportTotalizar";
            this.lstReportTotalizar.Size = new System.Drawing.Size(332, 134);
            this.lstReportTotalizar.TabIndex = 1;
            // 
            // lstReportExibir
            // 
            this.lstReportExibir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstReportExibir.CheckOnClick = true;
            this.lstReportExibir.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstReportExibir.FormattingEnabled = true;
            this.lstReportExibir.Location = new System.Drawing.Point(4, 19);
            this.lstReportExibir.Margin = new System.Windows.Forms.Padding(4);
            this.lstReportExibir.Name = "lstReportExibir";
            this.lstReportExibir.Size = new System.Drawing.Size(332, 134);
            this.lstReportExibir.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.btnExecutarReport);
            this.groupBox4.Controls.Add(this.cmbReportStyle);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.cmbReportType);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(4, 216);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(689, 134);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " Construir ";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(8, 23);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(160, 95);
            this.button7.TabIndex = 0;
            this.button7.Text = "Exibir em PDF";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(515, 90);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(159, 28);
            this.button6.TabIndex = 8;
            this.button6.Text = "Executar e Salvar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnExecutarReport
            // 
            this.btnExecutarReport.Location = new System.Drawing.Point(345, 90);
            this.btnExecutarReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExecutarReport.Name = "btnExecutarReport";
            this.btnExecutarReport.Size = new System.Drawing.Size(159, 28);
            this.btnExecutarReport.TabIndex = 6;
            this.btnExecutarReport.Text = "Executar e Exibir";
            this.btnExecutarReport.UseVisualStyleBackColor = true;
            this.btnExecutarReport.Click += new System.EventHandler(this.btnExecutarReport_Click);
            // 
            // cmbReportStyle
            // 
            this.cmbReportStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportStyle.FormattingEnabled = true;
            this.cmbReportStyle.Items.AddRange(new object[] {
            "Simples",
            "Formulário Padrão"});
            this.cmbReportStyle.Location = new System.Drawing.Point(176, 92);
            this.cmbReportStyle.Margin = new System.Windows.Forms.Padding(4);
            this.cmbReportStyle.Name = "cmbReportStyle";
            this.cmbReportStyle.Size = new System.Drawing.Size(160, 24);
            this.cmbReportStyle.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Estilo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(515, 41);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(156, 28);
            this.button5.TabIndex = 7;
            this.button5.Text = "Exportar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(349, 41);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 28);
            this.button4.TabIndex = 5;
            this.button4.Text = "Exibir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Tabela",
            "Formulário"});
            this.cmbReportType.Location = new System.Drawing.Point(176, 43);
            this.cmbReportType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(160, 24);
            this.cmbReportType.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReportName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(689, 55);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Nome do Relatório ";
            // 
            // txtReportName
            // 
            this.txtReportName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReportName.Location = new System.Drawing.Point(4, 19);
            this.txtReportName.Margin = new System.Windows.Forms.Padding(4);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(681, 22);
            this.txtReportName.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtCode);
            this.tabPage5.Controls.Add(this.panel4);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(697, 354);
            this.tabPage5.TabIndex = 7;
            this.tabPage5.Text = "Code";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(0, 104);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(697, 250);
            this.txtCode.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtNamespace);
            this.panel4.Controls.Add(this.button8);
            this.panel4.Controls.Add(this.txtTemplatePath);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.cmbTempaltes);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(697, 104);
            this.panel4.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Namespace";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(3, 71);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(372, 22);
            this.txtNamespace.TabIndex = 6;
            this.txtNamespace.TextChanged += new System.EventHandler(this.txtNamespace_TextChanged);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(659, 26);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(30, 23);
            this.button8.TabIndex = 5;
            this.button8.Text = "...";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.Location = new System.Drawing.Point(3, 26);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.Size = new System.Drawing.Size(650, 22);
            this.txtTemplatePath.TabIndex = 4;
            this.txtTemplatePath.TextChanged += new System.EventHandler(this.txtTemplatePath_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Template";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Pasta de templates";
            // 
            // cmbTempaltes
            // 
            this.cmbTempaltes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTempaltes.FormattingEnabled = true;
            this.cmbTempaltes.Location = new System.Drawing.Point(381, 71);
            this.cmbTempaltes.Name = "cmbTempaltes";
            this.cmbTempaltes.Size = new System.Drawing.Size(308, 24);
            this.cmbTempaltes.TabIndex = 1;
            this.cmbTempaltes.SelectedValueChanged += new System.EventHandler(this.cmbTempaltes_SelectedValueChanged);
            // 
            // bsNavigator
            // 
            this.bsNavigator.AddNewItem = this.btnAdd;
            this.bsNavigator.BindingSource = this.bsRegistros;
            this.bsNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bsNavigator.DeleteItem = this.btnDelete;
            this.bsNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bsNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnAdd,
            this.btnDelete});
            this.bsNavigator.Location = new System.Drawing.Point(0, 0);
            this.bsNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bsNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bsNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bsNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bsNavigator.Name = "bsNavigator";
            this.bsNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bsNavigator.Size = new System.Drawing.Size(705, 27);
            this.bsNavigator.TabIndex = 0;
            this.bsNavigator.Text = "bindingNavigator1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeftAutoMirrorImage = true;
            this.btnAdd.Size = new System.Drawing.Size(29, 24);
            this.btnAdd.Text = "Add new";
            this.btnAdd.Visible = false;
            // 
            // bsRegistros
            // 
            this.bsRegistros.AllowNew = true;
            this.bsRegistros.PositionChanged += new System.EventHandler(this.bsRegistros_PositionChanged);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(48, 24);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeftAutoMirrorImage = true;
            this.btnDelete.Size = new System.Drawing.Size(29, 24);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Visible = false;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(65, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 120);
            this.splitter3.Margin = new System.Windows.Forms.Padding(4);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(705, 6);
            this.splitter3.TabIndex = 1;
            this.splitter3.TabStop = false;
            // 
            // txtSql
            // 
            this.txtSql.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSql.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSql.Location = new System.Drawing.Point(0, 0);
            this.txtSql.Margin = new System.Windows.Forms.Padding(4);
            this.txtSql.Name = "txtSql";
            this.txtSql.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            syntaxSettings2.BeginComment = null;
            syntaxSettings2.Comment = null;
            syntaxSettings2.CommentColor = System.Drawing.Color.Empty;
            syntaxSettings2.EnableComments = false;
            syntaxSettings2.EnableMembers = false;
            syntaxSettings2.EnableNumbers = false;
            syntaxSettings2.EnableStrings = false;
            syntaxSettings2.EndComment = null;
            syntaxSettings2.KeywordColor = System.Drawing.Color.Empty;
            syntaxSettings2.MemberColor = System.Drawing.Color.Empty;
            syntaxSettings2.NumberColor = System.Drawing.Color.Empty;
            syntaxSettings2.StringColor = System.Drawing.Color.Empty;
            this.txtSql.Settings = syntaxSettings2;
            this.txtSql.Size = new System.Drawing.Size(705, 120);
            this.txtSql.TabIndex = 0;
            this.txtSql.Text = "";
            this.txtSql.TextChanged += new System.EventHandler(this.txtSql_TextChanged);
            this.txtSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSql_KeyDown);
            this.txtSql.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSql_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conexõesToolStripMenuItem,
            this.mnConnection,
            this.configuraçõesToolStripMenuItem,
            this.ferramentasToolStripMenuItem,
            this.consultarToolStripMenuItem,
            this.executarToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(979, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // conexõesToolStripMenuItem
            // 
            this.conexõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarToolStripMenuItem,
            this.novoToolStripMenuItem,
            this.atualizarToolStripMenuItem,
            this.exibirConexãoToolStripMenuItem,
            this.limparToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.conexõesToolStripMenuItem.Name = "conexõesToolStripMenuItem";
            this.conexõesToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.conexõesToolStripMenuItem.Text = "Cone&xões";
            this.conexõesToolStripMenuItem.Click += new System.EventHandler(this.conexõesToolStripMenuItem_Click);
            // 
            // adicionarToolStripMenuItem
            // 
            this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.adicionarToolStripMenuItem.Text = "&Adicionar Conexão";
            this.adicionarToolStripMenuItem.Click += new System.EventHandler(this.adicionarToolStripMenuItem_Click);
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.novoToolStripMenuItem.Text = "&Nova Instância";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
            // 
            // atualizarToolStripMenuItem
            // 
            this.atualizarToolStripMenuItem.Name = "atualizarToolStripMenuItem";
            this.atualizarToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.atualizarToolStripMenuItem.Text = "Atua&lizar";
            this.atualizarToolStripMenuItem.Click += new System.EventHandler(this.atualizarToolStripMenuItem_Click);
            // 
            // exibirConexãoToolStripMenuItem
            // 
            this.exibirConexãoToolStripMenuItem.Name = "exibirConexãoToolStripMenuItem";
            this.exibirConexãoToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.exibirConexãoToolStripMenuItem.Text = "&Exibir Conexão";
            this.exibirConexãoToolStripMenuItem.Click += new System.EventHandler(this.exibirConexãoToolStripMenuItem_Click);
            // 
            // limparToolStripMenuItem
            // 
            this.limparToolStripMenuItem.Name = "limparToolStripMenuItem";
            this.limparToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.limparToolStripMenuItem.Text = "&Limpar";
            this.limparToolStripMenuItem.Click += new System.EventHandler(this.limparToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.sairToolStripMenuItem.Text = "&Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // mnConnection
            // 
            this.mnConnection.Name = "mnConnection";
            this.mnConnection.Size = new System.Drawing.Size(101, 24);
            this.mnConnection.Text = "&Usar Banco";
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbEscreverMaiusculo,
            this.cbEditarDados,
            this.cbPontoVirgula,
            this.cbEsquema,
            this.cbLimitar,
            this.cbUsaSchema,
            this.cbUtilizaColchetes,
            this.cbSemBinding,
            this.cbEstiloVisual,
            this.cbInsertIdentity,
            this.cbExibeRemoverLimpar,
            this.toolStripSeparator1,
            this.tiposToolStripMenuItem,
            this.cbUpdateColumns,
            this.cbTablesAndViews});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.configuraçõesToolStripMenuItem.Text = "Confi&gurações";
            // 
            // cbEscreverMaiusculo
            // 
            this.cbEscreverMaiusculo.CheckOnClick = true;
            this.cbEscreverMaiusculo.Name = "cbEscreverMaiusculo";
            this.cbEscreverMaiusculo.Size = new System.Drawing.Size(404, 26);
            this.cbEscreverMaiusculo.Text = "&Escrever apenas com letra maiúscula";
            this.cbEscreverMaiusculo.Click += new System.EventHandler(this.cbEscreverMaiusculo_Click);
            // 
            // cbEditarDados
            // 
            this.cbEditarDados.CheckOnClick = true;
            this.cbEditarDados.Name = "cbEditarDados";
            this.cbEditarDados.Size = new System.Drawing.Size(404, 26);
            this.cbEditarDados.Text = "&Permite editar dados";
            this.cbEditarDados.Click += new System.EventHandler(this.cbEditarDados_Click);
            // 
            // cbPontoVirgula
            // 
            this.cbPontoVirgula.Checked = true;
            this.cbPontoVirgula.CheckOnClick = true;
            this.cbPontoVirgula.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPontoVirgula.Name = "cbPontoVirgula";
            this.cbPontoVirgula.Size = new System.Drawing.Size(404, 26);
            this.cbPontoVirgula.Text = "&Auto executar após ponto e vírgula";
            // 
            // cbEsquema
            // 
            this.cbEsquema.Checked = true;
            this.cbEsquema.CheckOnClick = true;
            this.cbEsquema.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEsquema.Name = "cbEsquema";
            this.cbEsquema.Size = new System.Drawing.Size(404, 26);
            this.cbEsquema.Text = "Utiliza esquema de dados";
            this.cbEsquema.Click += new System.EventHandler(this.cbEsquema_Click);
            // 
            // cbLimitar
            // 
            this.cbLimitar.Checked = true;
            this.cbLimitar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLimitar.Name = "cbLimitar";
            this.cbLimitar.Size = new System.Drawing.Size(404, 26);
            this.cbLimitar.Text = "Limitar dados da Pesquisa";
            this.cbLimitar.Click += new System.EventHandler(this.limitarDadosDaPesquisaToolStripMenuItem_Click);
            // 
            // cbUsaSchema
            // 
            this.cbUsaSchema.Checked = true;
            this.cbUsaSchema.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUsaSchema.Name = "cbUsaSchema";
            this.cbUsaSchema.Size = new System.Drawing.Size(404, 26);
            this.cbUsaSchema.Text = "Utilizar Schema";
            this.cbUsaSchema.Click += new System.EventHandler(this.cbUsaSchema_Click);
            // 
            // cbUtilizaColchetes
            // 
            this.cbUtilizaColchetes.Checked = true;
            this.cbUtilizaColchetes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUtilizaColchetes.Name = "cbUtilizaColchetes";
            this.cbUtilizaColchetes.Size = new System.Drawing.Size(404, 26);
            this.cbUtilizaColchetes.Text = "Utilizar colchetes em campos e tabelas";
            this.cbUtilizaColchetes.Click += new System.EventHandler(this.cbUtilizaColchetes_Click);
            // 
            // cbSemBinding
            // 
            this.cbSemBinding.Name = "cbSemBinding";
            this.cbSemBinding.Size = new System.Drawing.Size(404, 26);
            this.cbSemBinding.Text = "Não usar Binding";
            this.cbSemBinding.Click += new System.EventHandler(this.cbBinding_Click);
            // 
            // cbEstiloVisual
            // 
            this.cbEstiloVisual.CheckOnClick = true;
            this.cbEstiloVisual.Name = "cbEstiloVisual";
            this.cbEstiloVisual.Size = new System.Drawing.Size(404, 26);
            this.cbEstiloVisual.Text = "&Habilitar estilo visual no DataGrid";
            this.cbEstiloVisual.Click += new System.EventHandler(this.cbEstiloVisual_Click);
            // 
            // cbInsertIdentity
            // 
            this.cbInsertIdentity.Name = "cbInsertIdentity";
            this.cbInsertIdentity.Size = new System.Drawing.Size(404, 26);
            this.cbInsertIdentity.Text = "Usar Insert Identity em migração de dados";
            this.cbInsertIdentity.Click += new System.EventHandler(this.cbInsertIdentity_Click);
            // 
            // cbExibeRemoverLimpar
            // 
            this.cbExibeRemoverLimpar.Name = "cbExibeRemoverLimpar";
            this.cbExibeRemoverLimpar.Size = new System.Drawing.Size(404, 26);
            this.cbExibeRemoverLimpar.Text = "Exibir opções para Remover e Limpar Tabelas";
            this.cbExibeRemoverLimpar.Click += new System.EventHandler(this.cbExibeRemoverLimpar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(401, 6);
            // 
            // tiposToolStripMenuItem
            // 
            this.tiposToolStripMenuItem.Name = "tiposToolStripMenuItem";
            this.tiposToolStripMenuItem.Size = new System.Drawing.Size(404, 26);
            this.tiposToolStripMenuItem.Text = "Tipos de dados";
            this.tiposToolStripMenuItem.Click += new System.EventHandler(this.tiposToolStripMenuItem_Click);
            // 
            // cbUpdateColumns
            // 
            this.cbUpdateColumns.Checked = true;
            this.cbUpdateColumns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUpdateColumns.Name = "cbUpdateColumns";
            this.cbUpdateColumns.Size = new System.Drawing.Size(404, 26);
            this.cbUpdateColumns.Text = "Atualiza tipos de dados pelo esquema de dados";
            this.cbUpdateColumns.Click += new System.EventHandler(this.cpUpdateColumns_Click);
            // 
            // cbTablesAndViews
            // 
            this.cbTablesAndViews.Checked = true;
            this.cbTablesAndViews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTablesAndViews.Name = "cbTablesAndViews";
            this.cbTablesAndViews.Size = new System.Drawing.Size(404, 26);
            this.cbTablesAndViews.Text = "Exibir Tabelas e Views";
            this.cbTablesAndViews.Click += new System.EventHandler(this.cbTablesAndViews_Click);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transformarEmMaiúsculoToolStripMenuItem,
            this.substituirToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exportarToolStripMenuItem,
            this.exibirToolStripMenuItem,
            this.toolStripMenuItem2,
            this.executarArquivoDeScriptToolStripMenuItem,
            this.compararBasesToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.ferramentasToolStripMenuItem.Text = "&Ferramentas";
            // 
            // transformarEmMaiúsculoToolStripMenuItem
            // 
            this.transformarEmMaiúsculoToolStripMenuItem.Name = "transformarEmMaiúsculoToolStripMenuItem";
            this.transformarEmMaiúsculoToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.transformarEmMaiúsculoToolStripMenuItem.Text = "&Transformar em maiúsculo";
            this.transformarEmMaiúsculoToolStripMenuItem.Click += new System.EventHandler(this.transformarEmMaiúsculoToolStripMenuItem_Click);
            // 
            // substituirToolStripMenuItem
            // 
            this.substituirToolStripMenuItem.Name = "substituirToolStripMenuItem";
            this.substituirToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.substituirToolStripMenuItem.Text = "&Substituir";
            this.substituirToolStripMenuItem.Click += new System.EventHandler(this.substituirToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(266, 6);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metadataToolStripMenuItem,
            this.dadosToolStripMenuItem,
            this.metadataComDadosToolStripMenuItem,
            this.limpesaDasTabelasToolStripMenuItem,
            this.truncateDasTabelasToolStripMenuItem,
            this.remoçãoDasTabelasToolStripMenuItem,
            this.listaDeCamposToolStripMenuItem,
            this.fastCodeToolStripMenuItem,
            this.removeChavesToolStripMenuItem});
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.exportarToolStripMenuItem.Text = "Exportar";
            // 
            // metadataToolStripMenuItem
            // 
            this.metadataToolStripMenuItem.Name = "metadataToolStripMenuItem";
            this.metadataToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.metadataToolStripMenuItem.Text = "Metadata";
            this.metadataToolStripMenuItem.Click += new System.EventHandler(this.metadataToolStripMenuItem_Click);
            // 
            // dadosToolStripMenuItem
            // 
            this.dadosToolStripMenuItem.Name = "dadosToolStripMenuItem";
            this.dadosToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.dadosToolStripMenuItem.Text = "Dados";
            this.dadosToolStripMenuItem.Click += new System.EventHandler(this.dadosToolStripMenuItem_Click);
            // 
            // metadataComDadosToolStripMenuItem
            // 
            this.metadataComDadosToolStripMenuItem.Name = "metadataComDadosToolStripMenuItem";
            this.metadataComDadosToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.metadataComDadosToolStripMenuItem.Text = "Metadata com Dados";
            this.metadataComDadosToolStripMenuItem.Click += new System.EventHandler(this.metadataComDadosToolStripMenuItem_Click);
            // 
            // limpesaDasTabelasToolStripMenuItem
            // 
            this.limpesaDasTabelasToolStripMenuItem.Name = "limpesaDasTabelasToolStripMenuItem";
            this.limpesaDasTabelasToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.limpesaDasTabelasToolStripMenuItem.Text = "Limpesa das Tabelas";
            this.limpesaDasTabelasToolStripMenuItem.Click += new System.EventHandler(this.limpesaDasTabelasToolStripMenuItem_Click);
            // 
            // truncateDasTabelasToolStripMenuItem
            // 
            this.truncateDasTabelasToolStripMenuItem.Name = "truncateDasTabelasToolStripMenuItem";
            this.truncateDasTabelasToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.truncateDasTabelasToolStripMenuItem.Text = "Truncate das tabelas";
            this.truncateDasTabelasToolStripMenuItem.Click += new System.EventHandler(this.truncateDasTabelasToolStripMenuItem_Click);
            // 
            // remoçãoDasTabelasToolStripMenuItem
            // 
            this.remoçãoDasTabelasToolStripMenuItem.Name = "remoçãoDasTabelasToolStripMenuItem";
            this.remoçãoDasTabelasToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.remoçãoDasTabelasToolStripMenuItem.Text = "Remoção das Tabelas";
            this.remoçãoDasTabelasToolStripMenuItem.Click += new System.EventHandler(this.remoçãoDasTabelasToolStripMenuItem_Click);
            // 
            // listaDeCamposToolStripMenuItem
            // 
            this.listaDeCamposToolStripMenuItem.Name = "listaDeCamposToolStripMenuItem";
            this.listaDeCamposToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.listaDeCamposToolStripMenuItem.Text = "Lista de Campos";
            this.listaDeCamposToolStripMenuItem.Click += new System.EventHandler(this.listaDeCamposToolStripMenuItem_Click);
            // 
            // fastCodeToolStripMenuItem
            // 
            this.fastCodeToolStripMenuItem.Name = "fastCodeToolStripMenuItem";
            this.fastCodeToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.fastCodeToolStripMenuItem.Text = "Fast Code";
            this.fastCodeToolStripMenuItem.Click += new System.EventHandler(this.fastCodeToolStripMenuItem_Click);
            // 
            // removeChavesToolStripMenuItem
            // 
            this.removeChavesToolStripMenuItem.Name = "removeChavesToolStripMenuItem";
            this.removeChavesToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.removeChavesToolStripMenuItem.Text = "Remove Chaves";
            this.removeChavesToolStripMenuItem.Click += new System.EventHandler(this.removeChavesToolStripMenuItem_Click);
            // 
            // exibirToolStripMenuItem
            // 
            this.exibirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabelasPorTamanhoToolStripMenuItem,
            this.processosAbertosSQLServerToolStripMenuItem});
            this.exibirToolStripMenuItem.Name = "exibirToolStripMenuItem";
            this.exibirToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.exibirToolStripMenuItem.Text = "Exibir";
            // 
            // tabelasPorTamanhoToolStripMenuItem
            // 
            this.tabelasPorTamanhoToolStripMenuItem.Name = "tabelasPorTamanhoToolStripMenuItem";
            this.tabelasPorTamanhoToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.tabelasPorTamanhoToolStripMenuItem.Text = "Tabelas por tamanho";
            this.tabelasPorTamanhoToolStripMenuItem.Click += new System.EventHandler(this.tabelasPorTamanhoToolStripMenuItem_Click);
            // 
            // processosAbertosSQLServerToolStripMenuItem
            // 
            this.processosAbertosSQLServerToolStripMenuItem.Name = "processosAbertosSQLServerToolStripMenuItem";
            this.processosAbertosSQLServerToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.processosAbertosSQLServerToolStripMenuItem.Text = "Eliminar processos abertos";
            this.processosAbertosSQLServerToolStripMenuItem.Click += new System.EventHandler(this.processosAbertosSQLServerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(266, 6);
            // 
            // executarArquivoDeScriptToolStripMenuItem
            // 
            this.executarArquivoDeScriptToolStripMenuItem.Name = "executarArquivoDeScriptToolStripMenuItem";
            this.executarArquivoDeScriptToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.executarArquivoDeScriptToolStripMenuItem.Text = "Executar arquivo de script";
            this.executarArquivoDeScriptToolStripMenuItem.Click += new System.EventHandler(this.executarArquivoDeScriptToolStripMenuItem_Click);
            // 
            // compararBasesToolStripMenuItem
            // 
            this.compararBasesToolStripMenuItem.Name = "compararBasesToolStripMenuItem";
            this.compararBasesToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.compararBasesToolStripMenuItem.Text = "Comparar Bases";
            this.compararBasesToolStripMenuItem.Click += new System.EventHandler(this.compararBasesToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.consultarToolStripMenuItem.Text = "Consu&ltar [F5]";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click);
            // 
            // executarToolStripMenuItem
            // 
            this.executarToolStripMenuItem.Name = "executarToolStripMenuItem";
            this.executarToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.executarToolStripMenuItem.Text = "&Executar [F6]";
            this.executarToolStripMenuItem.Click += new System.EventHandler(this.executarToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.sobreToolStripMenuItem.Text = "&Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // dlgSave
            // 
            this.dlgSave.Filter = "SQL|*.sql";
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.Progress);
            this.pnlProgress.Controls.Add(this.lblProgress);
            this.pnlProgress.Controls.Add(this.btnCancelProgress);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgress.Location = new System.Drawing.Point(0, 564);
            this.pnlProgress.Margin = new System.Windows.Forms.Padding(4);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(979, 50);
            this.pnlProgress.TabIndex = 5;
            this.pnlProgress.Visible = false;
            this.pnlProgress.VisibleChanged += new System.EventHandler(this.pnlProgress_VisibleChanged);
            // 
            // Progress
            // 
            this.Progress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Progress.Location = new System.Drawing.Point(0, 20);
            this.Progress.Margin = new System.Windows.Forms.Padding(4);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(898, 30);
            this.Progress.TabIndex = 2;
            // 
            // lblProgress
            // 
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProgress.Location = new System.Drawing.Point(0, 0);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(898, 20);
            this.lblProgress.TabIndex = 1;
            // 
            // btnCancelProgress
            // 
            this.btnCancelProgress.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelProgress.Location = new System.Drawing.Point(898, 0);
            this.btnCancelProgress.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelProgress.Name = "btnCancelProgress";
            this.btnCancelProgress.Size = new System.Drawing.Size(81, 50);
            this.btnCancelProgress.TabIndex = 0;
            this.btnCancelProgress.Text = "Cancelar";
            this.btnCancelProgress.UseVisualStyleBackColor = true;
            this.btnCancelProgress.Click += new System.EventHandler(this.btnCancelProgress_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "SQL|*.sql";
            // 
            // lblBanco
            // 
            this.lblBanco.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBanco.Location = new System.Drawing.Point(0, 614);
            this.lblBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(979, 16);
            this.lblBanco.TabIndex = 8;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(979, 630);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.lblBanco);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmPrincipal";
            this.Text = "Database Console";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Principal_FormClosed);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdColumns)).EndInit();
            this.cmTables.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabDados.ResumeLayout(false);
            this.tbSql.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRegistros)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbEsquema.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEsquema)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tbLog.ResumeLayout(false);
            this.tbLog.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsNavigator)).EndInit();
            this.bsNavigator.ResumeLayout(false);
            this.bsNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegistros)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Splitter splitter2;
    private System.Windows.Forms.ListBox lstTables;
    private System.Windows.Forms.Splitter splitter3;
    private lib.Visual.Components.SyntaxRichTextBox txtSql;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem conexõesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem limparToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mnConnection;
    private System.Windows.Forms.ContextMenuStrip cmTables;
    private System.Windows.Forms.ToolStripMenuItem novaTabelaToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem btnRemoverTabela;
    private System.Windows.Forms.ToolStripMenuItem btnLimparTabela;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.BindingSource bsRegistros;
    private System.Windows.Forms.BindingNavigator bsNavigator;
    private System.Windows.Forms.ToolStripButton btnAdd;
    private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
    private System.Windows.Forms.ToolStripButton btnDelete;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
    private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
    private System.Windows.Forms.TabControl tabDados;
    private System.Windows.Forms.TabPage tbSql;
    private System.Windows.Forms.DataGridView grdRegistros;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabPage tbLog;
    private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cbEscreverMaiusculo;
    private System.Windows.Forms.ToolStripMenuItem cbEditarDados;
    private System.Windows.Forms.ToolStripMenuItem cbPontoVirgula;
    private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem transformarEmMaiúsculoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem substituirToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem executarToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cbEstiloVisual;
    private System.Windows.Forms.TextBox txtLog;
    private lib.Visual.Components.SyntaxRichTextBox txtScript;
    private System.Windows.Forms.ListBox lstInstrucoes;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem tiposToolStripMenuItem;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox txtAlias;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.SaveFileDialog dlgSave;
    private System.Windows.Forms.Panel pnlProgress;
    private System.Windows.Forms.ProgressBar Progress;
    private System.Windows.Forms.Button btnCancelProgress;
    private System.Windows.Forms.Label lblProgress;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem metadataToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem dadosToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem metadataComDadosToolStripMenuItem;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.CheckedListBox lstReportTotalizar;
    private System.Windows.Forms.CheckedListBox lstReportExibir;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox txtReportName;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.ComboBox cmbReportType;
    private System.Windows.Forms.ComboBox cmbReportStyle;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblErroGrid;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.TextBox txtDependencias;
    private System.Windows.Forms.ToolStripMenuItem cbEsquema;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem executarArquivoDeScriptToolStripMenuItem;
    private System.Windows.Forms.OpenFileDialog dlgOpen;
    private System.Windows.Forms.ToolStripSeparator SeparadorRemoverLimpar;
    private System.Windows.Forms.ToolStripMenuItem organizarPorNomeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem organizarPorChaveEstrangeiraToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem organizarPorCriaçãoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem limpesaDasTabelasToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem remoçãoDasTabelasToolStripMenuItem;
    private System.Windows.Forms.Button btnExecutarReport;
    private System.Windows.Forms.ToolStripMenuItem cbLimitar;
    private System.Windows.Forms.ToolStripMenuItem cbSemBinding;
    private System.Windows.Forms.ToolStripMenuItem cbUsaSchema;
    private System.Windows.Forms.ToolStripMenuItem cbInsertIdentity;
    private System.Windows.Forms.Label lblBanco;
    private System.Windows.Forms.TabPage tbEsquema;
    private System.Windows.Forms.DataGridView grdEsquema;
    private System.Windows.Forms.ComboBox cmbEsquema;
    private System.Windows.Forms.ToolStripMenuItem exibirConexãoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem atualizarToolStripMenuItem;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.ToolStripMenuItem cbUpdateColumns;
    private System.Windows.Forms.ToolStripMenuItem cbExibeRemoverLimpar;
    private System.Windows.Forms.ToolStripMenuItem listaDeCamposToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
    private System.Windows.Forms.DataGridView grdColumns;
    private System.Windows.Forms.DataGridViewTextBoxColumn Campos;
    private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem exibirSQLToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exibirInsertToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exibirUpdateToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exibirDeleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cbUtilizaColchetes;
    private System.Windows.Forms.ToolStripMenuItem exibirToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tabelasPorTamanhoToolStripMenuItem;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.ToolStripMenuItem cbTablesAndViews;
    private System.Windows.Forms.ToolStripMenuItem truncateDasTabelasToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeChavesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem compararBasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processosAbertosSQLServerToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFilterTables;
        private System.Windows.Forms.ToolStripMenuItem fastCodeToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox txtTemplatePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTempaltes;
        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNamespace;
    }
}

