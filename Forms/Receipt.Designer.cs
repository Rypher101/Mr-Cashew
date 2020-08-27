namespace Mr_Cashew.Forms
{
    partial class Receipt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPS = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCashew = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.txtQTY = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtReceipt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCshAdd = new System.Windows.Forms.Button();
            this.dgvReceipt = new System.Windows.Forms.DataGridView();
            this.cmsReceipt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.goodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliverdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.onilneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteThisReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCashew = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCashew = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).BeginInit();
            this.cmsReceipt.SuspendLayout();
            this.cmsCashew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashew)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(402, 30);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(132, 31);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New Receipt";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contact No : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Payment Status : ";
            // 
            // txtContact
            // 
            this.txtContact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtContact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtContact.Location = new System.Drawing.Point(116, 31);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(200, 20);
            this.txtContact.TabIndex = 7;
            this.txtContact.TextChanged += new System.EventHandler(this.txtContact_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(116, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Date : ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy MMMM dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(104, 154);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Name : ";
            // 
            // cmbPS
            // 
            this.cmbPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPS.FormattingEnabled = true;
            this.cmbPS.Items.AddRange(new object[] {
            "Pending",
            "Online",
            "Cash"});
            this.cmbPS.Location = new System.Drawing.Point(104, 113);
            this.cmbPS.Name = "cmbPS";
            this.cmbPS.Size = new System.Drawing.Size(200, 21);
            this.cmbPS.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Cashew : ";
            // 
            // cmbCashew
            // 
            this.cmbCashew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashew.FormattingEnabled = true;
            this.cmbCashew.Location = new System.Drawing.Point(96, 66);
            this.cmbCashew.Name = "cmbCashew";
            this.cmbCashew.Size = new System.Drawing.Size(200, 21);
            this.cmbCashew.TabIndex = 19;
            this.cmbCashew.SelectedIndexChanged += new System.EventHandler(this.cmbCashew_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Size : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "QTY : ";
            // 
            // cmbSize
            // 
            this.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(96, 109);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(200, 21);
            this.cmbSize.TabIndex = 23;
            // 
            // txtQTY
            // 
            this.txtQTY.Location = new System.Drawing.Point(96, 154);
            this.txtQTY.Name = "txtQTY";
            this.txtQTY.Size = new System.Drawing.Size(200, 20);
            this.txtQTY.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.cmbPS);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 236);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Receipt Details";
            // 
            // txtReceipt
            // 
            this.txtReceipt.Location = new System.Drawing.Point(96, 27);
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.Size = new System.Drawing.Size(200, 20);
            this.txtReceipt.TabIndex = 29;
            this.txtReceipt.TextChanged += new System.EventHandler(this.txtReveipt_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Receipt No : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtReceipt);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnCshAdd);
            this.groupBox2.Controls.Add(this.cmbSize);
            this.groupBox2.Controls.Add(this.txtQTY);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbCashew);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(626, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 236);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cashew Details";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(96, 191);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(47, 13);
            this.lblTotal.TabIndex = 31;
            this.lblTotal.Text = "Rs. 0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Total :";
            // 
            // btnCshAdd
            // 
            this.btnCshAdd.Location = new System.Drawing.Point(362, 148);
            this.btnCshAdd.Name = "btnCshAdd";
            this.btnCshAdd.Size = new System.Drawing.Size(96, 31);
            this.btnCshAdd.TabIndex = 28;
            this.btnCshAdd.Text = "Add";
            this.btnCshAdd.UseVisualStyleBackColor = true;
            this.btnCshAdd.Click += new System.EventHandler(this.btnCshAdd_Click);
            // 
            // dgvReceipt
            // 
            this.dgvReceipt.AllowUserToAddRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvReceipt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReceipt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceipt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReceipt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceipt.ContextMenuStrip = this.cmsReceipt;
            this.dgvReceipt.Location = new System.Drawing.Point(12, 246);
            this.dgvReceipt.MultiSelect = false;
            this.dgvReceipt.Name = "dgvReceipt";
            this.dgvReceipt.ReadOnly = true;
            this.dgvReceipt.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReceipt.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceipt.Size = new System.Drawing.Size(608, 369);
            this.dgvReceipt.TabIndex = 28;
            this.dgvReceipt.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReceipt_CellMouseDown);
            this.dgvReceipt.DoubleClick += new System.EventHandler(this.dgvReceipt_DoubleClick);
            // 
            // cmsReceipt
            // 
            this.cmsReceipt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem,
            this.toolStripSeparator2,
            this.goodsToolStripMenuItem,
            this.paymentToolStripMenuItem,
            this.toolStripSeparator3,
            this.searchToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteThisReceiptToolStripMenuItem});
            this.cmsReceipt.Name = "cmsReceipt";
            this.cmsReceipt.Size = new System.Drawing.Size(197, 132);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.backToolStripMenuItem.Text = "Refresh List";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // goodsToolStripMenuItem
            // 
            this.goodsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendingToolStripMenuItem,
            this.deliverdToolStripMenuItem});
            this.goodsToolStripMenuItem.Name = "goodsToolStripMenuItem";
            this.goodsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.goodsToolStripMenuItem.Text = "Goods";
            // 
            // pendingToolStripMenuItem
            // 
            this.pendingToolStripMenuItem.Name = "pendingToolStripMenuItem";
            this.pendingToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.pendingToolStripMenuItem.Text = "Pending";
            this.pendingToolStripMenuItem.Click += new System.EventHandler(this.pendingToolStripMenuItem_Click);
            // 
            // deliverdToolStripMenuItem
            // 
            this.deliverdToolStripMenuItem.Name = "deliverdToolStripMenuItem";
            this.deliverdToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.deliverdToolStripMenuItem.Text = "Deliverd";
            this.deliverdToolStripMenuItem.Click += new System.EventHandler(this.deliverdToolStripMenuItem_Click);
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendingToolStripMenuItem1,
            this.onlineToolStripMenuItem,
            this.cashToolStripMenuItem});
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.paymentToolStripMenuItem.Text = "Payment";
            // 
            // pendingToolStripMenuItem1
            // 
            this.pendingToolStripMenuItem1.Name = "pendingToolStripMenuItem1";
            this.pendingToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.pendingToolStripMenuItem1.Text = "Pending";
            this.pendingToolStripMenuItem1.Click += new System.EventHandler(this.pendingToolStripMenuItem1_Click);
            // 
            // onlineToolStripMenuItem
            // 
            this.onlineToolStripMenuItem.Name = "onlineToolStripMenuItem";
            this.onlineToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.onlineToolStripMenuItem.Text = "Online";
            this.onlineToolStripMenuItem.Click += new System.EventHandler(this.onlineToolStripMenuItem_Click);
            // 
            // cashToolStripMenuItem
            // 
            this.cashToolStripMenuItem.Name = "cashToolStripMenuItem";
            this.cashToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.cashToolStripMenuItem.Text = "Cash";
            this.cashToolStripMenuItem.Click += new System.EventHandler(this.cashToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(193, 6);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receiptIDToolStripMenuItem,
            this.nameToolStripMenuItem,
            this.contactNumberToolStripMenuItem,
            this.goodStatusToolStripMenuItem,
            this.paymentStatusToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // receiptIDToolStripMenuItem
            // 
            this.receiptIDToolStripMenuItem.Name = "receiptIDToolStripMenuItem";
            this.receiptIDToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.receiptIDToolStripMenuItem.Text = "Receipt ID";
            this.receiptIDToolStripMenuItem.Click += new System.EventHandler(this.receiptIDToolStripMenuItem_Click);
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.nameToolStripMenuItem.Text = "Name";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // contactNumberToolStripMenuItem
            // 
            this.contactNumberToolStripMenuItem.Name = "contactNumberToolStripMenuItem";
            this.contactNumberToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.contactNumberToolStripMenuItem.Text = "Contact Number";
            this.contactNumberToolStripMenuItem.Click += new System.EventHandler(this.contactNumberToolStripMenuItem_Click);
            // 
            // goodStatusToolStripMenuItem
            // 
            this.goodStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendingToolStripMenuItem2,
            this.deliveredToolStripMenuItem});
            this.goodStatusToolStripMenuItem.Name = "goodStatusToolStripMenuItem";
            this.goodStatusToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.goodStatusToolStripMenuItem.Text = "Goods Status";
            this.goodStatusToolStripMenuItem.Click += new System.EventHandler(this.goodStatusToolStripMenuItem_Click);
            // 
            // pendingToolStripMenuItem2
            // 
            this.pendingToolStripMenuItem2.Name = "pendingToolStripMenuItem2";
            this.pendingToolStripMenuItem2.Size = new System.Drawing.Size(123, 22);
            this.pendingToolStripMenuItem2.Text = "Pending";
            this.pendingToolStripMenuItem2.Click += new System.EventHandler(this.pendingToolStripMenuItem2_Click);
            // 
            // deliveredToolStripMenuItem
            // 
            this.deliveredToolStripMenuItem.Name = "deliveredToolStripMenuItem";
            this.deliveredToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.deliveredToolStripMenuItem.Text = "Delivered";
            this.deliveredToolStripMenuItem.Click += new System.EventHandler(this.deliveredToolStripMenuItem_Click);
            // 
            // paymentStatusToolStripMenuItem
            // 
            this.paymentStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendingToolStripMenuItem3,
            this.onilneToolStripMenuItem,
            this.cashToolStripMenuItem1});
            this.paymentStatusToolStripMenuItem.Name = "paymentStatusToolStripMenuItem";
            this.paymentStatusToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.paymentStatusToolStripMenuItem.Text = "Payment Status";
            // 
            // pendingToolStripMenuItem3
            // 
            this.pendingToolStripMenuItem3.Name = "pendingToolStripMenuItem3";
            this.pendingToolStripMenuItem3.Size = new System.Drawing.Size(118, 22);
            this.pendingToolStripMenuItem3.Text = "Pending";
            this.pendingToolStripMenuItem3.Click += new System.EventHandler(this.pendingToolStripMenuItem3_Click);
            // 
            // onilneToolStripMenuItem
            // 
            this.onilneToolStripMenuItem.Name = "onilneToolStripMenuItem";
            this.onilneToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.onilneToolStripMenuItem.Text = "Onilne";
            this.onilneToolStripMenuItem.Click += new System.EventHandler(this.onilneToolStripMenuItem_Click);
            // 
            // cashToolStripMenuItem1
            // 
            this.cashToolStripMenuItem1.Name = "cashToolStripMenuItem1";
            this.cashToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.cashToolStripMenuItem1.Text = "Cash";
            this.cashToolStripMenuItem1.Click += new System.EventHandler(this.cashToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // deleteThisReceiptToolStripMenuItem
            // 
            this.deleteThisReceiptToolStripMenuItem.Name = "deleteThisReceiptToolStripMenuItem";
            this.deleteThisReceiptToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.deleteThisReceiptToolStripMenuItem.Text = "Delete Selected Receipt";
            this.deleteThisReceiptToolStripMenuItem.Click += new System.EventHandler(this.deleteThisReceiptToolStripMenuItem_Click);
            // 
            // cmsCashew
            // 
            this.cmsCashew.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsCashew.Name = "cmsCashew";
            this.cmsCashew.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // dgvCashew
            // 
            this.dgvCashew.AllowUserToAddRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCashew.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCashew.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCashew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCashew.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashew.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCashew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashew.ContextMenuStrip = this.cmsCashew;
            this.dgvCashew.Location = new System.Drawing.Point(626, 246);
            this.dgvCashew.MultiSelect = false;
            this.dgvCashew.Name = "dgvCashew";
            this.dgvCashew.ReadOnly = true;
            this.dgvCashew.RowHeadersVisible = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCashew.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCashew.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashew.Size = new System.Drawing.Size(482, 369);
            this.dgvCashew.TabIndex = 29;
            this.dgvCashew.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCashew_CellMouseDown);
            // 
            // Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 627);
            this.Controls.Add(this.dgvCashew);
            this.Controls.Add(this.dgvReceipt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Receipt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Receipt_FormClosing);
            this.Load += new System.EventHandler(this.Receipt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).EndInit();
            this.cmsReceipt.ResumeLayout(false);
            this.cmsCashew.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCashew;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.TextBox txtQTY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCshAdd;
        private System.Windows.Forms.TextBox txtReceipt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvReceipt;
        private System.Windows.Forms.DataGridView dgvCashew;
        private System.Windows.Forms.ContextMenuStrip cmsCashew;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsReceipt;
        private System.Windows.Forms.ToolStripMenuItem goodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deliverdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem onlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteThisReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deliveredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem onilneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashToolStripMenuItem1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label10;
    }
}