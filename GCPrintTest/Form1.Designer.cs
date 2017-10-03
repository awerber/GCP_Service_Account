namespace GCPrintTest
{
    partial class Form1
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPrinterNameFromList = new System.Windows.Forms.Label();
            this.btnPrintDocFromName = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUnsharePrinter = new System.Windows.Forms.Button();
            this.cboPrinters = new System.Windows.Forms.ComboBox();
            this.btnPrintDoc = new System.Windows.Forms.Button();
            this.GetDocument = new System.Windows.Forms.OpenFileDialog();
            this.grpAddPrinter = new System.Windows.Forms.GroupBox();
            this.btnCapabilitesFile = new System.Windows.Forms.Button();
            this.txtCapabilities = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProxy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDefault_display_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.litname = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblInviteResponse = new System.Windows.Forms.Label();
            this.litPrinterIDForInvite = new System.Windows.Forms.Label();
            this.btnInvite = new System.Windows.Forms.Button();
            this.chkNotify = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.litEmail = new System.Windows.Forms.Label();
            this.txtPrinterID = new System.Windows.Forms.TextBox();
            this.litPrinterID = new System.Windows.Forms.Label();
            this.btnSharePrinter = new System.Windows.Forms.Button();
            this.txtNewDisplayName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblNameFromList = new System.Windows.Forms.Label();
            this.lblPrinterID = new System.Windows.Forms.Label();
            this.GetCapabilities = new System.Windows.Forms.OpenFileDialog();
            this.lblNewDefaultDisplayName = new System.Windows.Forms.Label();
            this.lblAgencyID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboGCPPrinterType = new System.Windows.Forms.ComboBox();
            this.btnMakeName = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnFilterPrintersByType = new System.Windows.Forms.Button();
            this.btnUnfilteredPrinters = new System.Windows.Forms.Button();
            this.btnTestCapabilities = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.grpAddPrinter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.btnTestCapabilities);
            this.groupBox2.Controls.Add(this.lblPrinterNameFromList);
            this.groupBox2.Controls.Add(this.btnPrintDocFromName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnUnsharePrinter);
            this.groupBox2.Controls.Add(this.cboPrinters);
            this.groupBox2.Controls.Add(this.btnPrintDoc);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(785, 145);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Service account component";
            // 
            // lblPrinterNameFromList
            // 
            this.lblPrinterNameFromList.AutoSize = true;
            this.lblPrinterNameFromList.Location = new System.Drawing.Point(452, 24);
            this.lblPrinterNameFromList.Name = "lblPrinterNameFromList";
            this.lblPrinterNameFromList.Size = new System.Drawing.Size(83, 13);
            this.lblPrinterNameFromList.TabIndex = 5;
            this.lblPrinterNameFromList.Text = "-- printer name --";
            // 
            // btnPrintDocFromName
            // 
            this.btnPrintDocFromName.Location = new System.Drawing.Point(152, 19);
            this.btnPrintDocFromName.Name = "btnPrintDocFromName";
            this.btnPrintDocFromName.Size = new System.Drawing.Size(289, 23);
            this.btnPrintDocFromName.TabIndex = 4;
            this.btnPrintDocFromName.Text = "Print a document using printer Name (from list below)";
            this.btnPrintDocFromName.UseVisualStyleBackColor = true;
            this.btnPrintDocFromName.Click += new System.EventHandler(this.btnPrintDocFromName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Printers";
            // 
            // btnUnsharePrinter
            // 
            this.btnUnsharePrinter.Location = new System.Drawing.Point(0, 101);
            this.btnUnsharePrinter.Name = "btnUnsharePrinter";
            this.btnUnsharePrinter.Size = new System.Drawing.Size(163, 23);
            this.btnUnsharePrinter.TabIndex = 2;
            this.btnUnsharePrinter.Text = "Unshare selected printer";
            this.btnUnsharePrinter.UseVisualStyleBackColor = true;
            // 
            // cboPrinters
            // 
            this.cboPrinters.FormattingEnabled = true;
            this.cboPrinters.Location = new System.Drawing.Point(6, 65);
            this.cboPrinters.Name = "cboPrinters";
            this.cboPrinters.Size = new System.Drawing.Size(749, 21);
            this.cboPrinters.TabIndex = 1;
            this.cboPrinters.SelectedIndexChanged += new System.EventHandler(this.cboPrinters_SelectedIndexChanged);
            // 
            // btnPrintDoc
            // 
            this.btnPrintDoc.Location = new System.Drawing.Point(6, 19);
            this.btnPrintDoc.Name = "btnPrintDoc";
            this.btnPrintDoc.Size = new System.Drawing.Size(113, 23);
            this.btnPrintDoc.TabIndex = 0;
            this.btnPrintDoc.Text = "Print a document";
            this.btnPrintDoc.UseVisualStyleBackColor = true;
            this.btnPrintDoc.Click += new System.EventHandler(this.btnPrintDoc_Click);
            // 
            // grpAddPrinter
            // 
            this.grpAddPrinter.Controls.Add(this.btnCapabilitesFile);
            this.grpAddPrinter.Controls.Add(this.txtCapabilities);
            this.grpAddPrinter.Controls.Add(this.label5);
            this.grpAddPrinter.Controls.Add(this.txtProxy);
            this.grpAddPrinter.Controls.Add(this.label4);
            this.grpAddPrinter.Controls.Add(this.txtTag);
            this.grpAddPrinter.Controls.Add(this.label3);
            this.grpAddPrinter.Controls.Add(this.txtDefault_display_name);
            this.grpAddPrinter.Controls.Add(this.label2);
            this.grpAddPrinter.Controls.Add(this.txtName);
            this.grpAddPrinter.Controls.Add(this.litname);
            this.grpAddPrinter.Controls.Add(this.btnRegister);
            this.grpAddPrinter.Controls.Add(this.lblInviteResponse);
            this.grpAddPrinter.Controls.Add(this.litPrinterIDForInvite);
            this.grpAddPrinter.Controls.Add(this.btnInvite);
            this.grpAddPrinter.Controls.Add(this.chkNotify);
            this.grpAddPrinter.Controls.Add(this.textBox2);
            this.grpAddPrinter.Controls.Add(this.litEmail);
            this.grpAddPrinter.Controls.Add(this.txtPrinterID);
            this.grpAddPrinter.Controls.Add(this.litPrinterID);
            this.grpAddPrinter.Controls.Add(this.btnSharePrinter);
            this.grpAddPrinter.Location = new System.Drawing.Point(12, 163);
            this.grpAddPrinter.Name = "grpAddPrinter";
            this.grpAddPrinter.Size = new System.Drawing.Size(785, 219);
            this.grpAddPrinter.TabIndex = 18;
            this.grpAddPrinter.TabStop = false;
            this.grpAddPrinter.Text = "Add Printer functions";
            // 
            // btnCapabilitesFile
            // 
            this.btnCapabilitesFile.Location = new System.Drawing.Point(242, 163);
            this.btnCapabilitesFile.Name = "btnCapabilitesFile";
            this.btnCapabilitesFile.Size = new System.Drawing.Size(118, 23);
            this.btnCapabilitesFile.TabIndex = 20;
            this.btnCapabilitesFile.Text = "Get Capabilities File";
            this.btnCapabilitesFile.UseVisualStyleBackColor = true;
            this.btnCapabilitesFile.Click += new System.EventHandler(this.btnCapabilitesFile_Click);
            // 
            // txtCapabilities
            // 
            this.txtCapabilities.Location = new System.Drawing.Point(71, 165);
            this.txtCapabilities.Name = "txtCapabilities";
            this.txtCapabilities.Size = new System.Drawing.Size(165, 20);
            this.txtCapabilities.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "capabilities";
            // 
            // txtProxy
            // 
            this.txtProxy.Location = new System.Drawing.Point(71, 139);
            this.txtProxy.Name = "txtProxy";
            this.txtProxy.Size = new System.Drawing.Size(165, 20);
            this.txtProxy.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "proxy";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(71, 113);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(165, 20);
            this.txtTag.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "tag";
            // 
            // txtDefault_display_name
            // 
            this.txtDefault_display_name.Location = new System.Drawing.Point(127, 87);
            this.txtDefault_display_name.Name = "txtDefault_display_name";
            this.txtDefault_display_name.Size = new System.Drawing.Size(109, 20);
            this.txtDefault_display_name.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "default_display_name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(127, 61);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(109, 20);
            this.txtName.TabIndex = 11;
            // 
            // litname
            // 
            this.litname.AutoSize = true;
            this.litname.Location = new System.Drawing.Point(12, 69);
            this.litname.Name = "litname";
            this.litname.Size = new System.Drawing.Size(33, 13);
            this.litname.TabIndex = 10;
            this.litname.Text = "name";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(56, 28);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(122, 23);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Register Printer";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblInviteResponse
            // 
            this.lblInviteResponse.AutoSize = true;
            this.lblInviteResponse.Location = new System.Drawing.Point(613, 100);
            this.lblInviteResponse.Name = "lblInviteResponse";
            this.lblInviteResponse.Size = new System.Drawing.Size(108, 13);
            this.lblInviteResponse.TabIndex = 8;
            this.lblInviteResponse.Text = "-- response to invite --";
            // 
            // litPrinterIDForInvite
            // 
            this.litPrinterIDForInvite.AutoSize = true;
            this.litPrinterIDForInvite.Location = new System.Drawing.Point(619, 72);
            this.litPrinterIDForInvite.Name = "litPrinterIDForInvite";
            this.litPrinterIDForInvite.Size = new System.Drawing.Size(130, 13);
            this.litPrinterIDForInvite.TabIndex = 7;
            this.litPrinterIDForInvite.Text = "use printer ID in box to left";
            // 
            // btnInvite
            // 
            this.btnInvite.Location = new System.Drawing.Point(614, 28);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(150, 23);
            this.btnInvite.TabIndex = 6;
            this.btnInvite.Text = "Invite New share";
            this.btnInvite.UseVisualStyleBackColor = true;
            this.btnInvite.Click += new System.EventHandler(this.btnInvite_Click);
            // 
            // chkNotify
            // 
            this.chkNotify.AutoSize = true;
            this.chkNotify.Checked = true;
            this.chkNotify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotify.Location = new System.Drawing.Point(372, 136);
            this.chkNotify.Name = "chkNotify";
            this.chkNotify.Size = new System.Drawing.Size(150, 17);
            this.chkNotify.TabIndex = 5;
            this.chkNotify.Text = "Send notification to email?";
            this.chkNotify.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(372, 98);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(222, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "andrew_werber@tritonmsllc.com";
            // 
            // litEmail
            // 
            this.litEmail.AutoSize = true;
            this.litEmail.Location = new System.Drawing.Point(267, 101);
            this.litEmail.Name = "litEmail";
            this.litEmail.Size = new System.Drawing.Size(71, 13);
            this.litEmail.TabIndex = 3;
            this.litEmail.Text = "email to notify";
            // 
            // txtPrinterID
            // 
            this.txtPrinterID.Location = new System.Drawing.Point(372, 69);
            this.txtPrinterID.Name = "txtPrinterID";
            this.txtPrinterID.Size = new System.Drawing.Size(222, 20);
            this.txtPrinterID.TabIndex = 2;
            // 
            // litPrinterID
            // 
            this.litPrinterID.AutoSize = true;
            this.litPrinterID.Location = new System.Drawing.Point(287, 72);
            this.litPrinterID.Name = "litPrinterID";
            this.litPrinterID.Size = new System.Drawing.Size(51, 13);
            this.litPrinterID.TabIndex = 1;
            this.litPrinterID.Text = "Printer ID";
            // 
            // btnSharePrinter
            // 
            this.btnSharePrinter.Location = new System.Drawing.Point(372, 28);
            this.btnSharePrinter.Name = "btnSharePrinter";
            this.btnSharePrinter.Size = new System.Drawing.Size(163, 23);
            this.btnSharePrinter.TabIndex = 0;
            this.btnSharePrinter.Text = "Share Printer";
            this.btnSharePrinter.UseVisualStyleBackColor = true;
            this.btnSharePrinter.Click += new System.EventHandler(this.btnSharePrinter_Click);
            // 
            // txtNewDisplayName
            // 
            this.txtNewDisplayName.Location = new System.Drawing.Point(176, 496);
            this.txtNewDisplayName.Name = "txtNewDisplayName";
            this.txtNewDisplayName.Size = new System.Drawing.Size(174, 20);
            this.txtNewDisplayName.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 503);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Free text";
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(90, 437);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(53, 20);
            this.txtNewName.TabIndex = 21;
            this.txtNewName.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "new name";
            this.label7.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(27, 403);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(205, 23);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update selected Printer (to rename it)";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblNameFromList
            // 
            this.lblNameFromList.AutoSize = true;
            this.lblNameFromList.Location = new System.Drawing.Point(24, 529);
            this.lblNameFromList.Name = "lblNameFromList";
            this.lblNameFromList.Size = new System.Drawing.Size(129, 13);
            this.lblNameFromList.TabIndex = 24;
            this.lblNameFromList.Text = "-- name from combo box --";
            // 
            // lblPrinterID
            // 
            this.lblPrinterID.AutoSize = true;
            this.lblPrinterID.Location = new System.Drawing.Point(180, 529);
            this.lblPrinterID.Name = "lblPrinterID";
            this.lblPrinterID.Size = new System.Drawing.Size(68, 13);
            this.lblPrinterID.TabIndex = 25;
            this.lblPrinterID.Text = "-- printer ID --";
            // 
            // lblNewDefaultDisplayName
            // 
            this.lblNewDefaultDisplayName.AutoSize = true;
            this.lblNewDefaultDisplayName.Location = new System.Drawing.Point(147, 561);
            this.lblNewDefaultDisplayName.Name = "lblNewDefaultDisplayName";
            this.lblNewDefaultDisplayName.Size = new System.Drawing.Size(144, 13);
            this.lblNewDefaultDisplayName.TabIndex = 26;
            this.lblNewDefaultDisplayName.Text = "-- new default display name --";
            // 
            // lblAgencyID
            // 
            this.lblAgencyID.AutoSize = true;
            this.lblAgencyID.Location = new System.Drawing.Point(238, 440);
            this.lblAgencyID.Name = "lblAgencyID";
            this.lblAgencyID.Size = new System.Drawing.Size(37, 13);
            this.lblAgencyID.TabIndex = 27;
            this.lblAgencyID.Text = "85001";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(181, 440);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Agency ID:";
            // 
            // cboGCPPrinterType
            // 
            this.cboGCPPrinterType.FormattingEnabled = true;
            this.cboGCPPrinterType.Location = new System.Drawing.Point(176, 469);
            this.cboGCPPrinterType.Name = "cboGCPPrinterType";
            this.cboGCPPrinterType.Size = new System.Drawing.Size(174, 21);
            this.cboGCPPrinterType.TabIndex = 29;
            // 
            // btnMakeName
            // 
            this.btnMakeName.Location = new System.Drawing.Point(356, 498);
            this.btnMakeName.Name = "btnMakeName";
            this.btnMakeName.Size = new System.Drawing.Size(151, 23);
            this.btnMakeName.TabIndex = 30;
            this.btnMakeName.Text = "Make new default name";
            this.btnMakeName.UseVisualStyleBackColor = true;
            this.btnMakeName.Click += new System.EventHandler(this.btnMakeName_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(110, 477);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Printer type";
            // 
            // btnFilterPrintersByType
            // 
            this.btnFilterPrintersByType.Location = new System.Drawing.Point(559, 469);
            this.btnFilterPrintersByType.Name = "btnFilterPrintersByType";
            this.btnFilterPrintersByType.Size = new System.Drawing.Size(217, 23);
            this.btnFilterPrintersByType.TabIndex = 32;
            this.btnFilterPrintersByType.Text = "Filter printers (above) by printer type";
            this.btnFilterPrintersByType.UseVisualStyleBackColor = true;
            this.btnFilterPrintersByType.Click += new System.EventHandler(this.btnFilterPrintersByType_Click);
            // 
            // btnUnfilteredPrinters
            // 
            this.btnUnfilteredPrinters.Location = new System.Drawing.Point(559, 503);
            this.btnUnfilteredPrinters.Name = "btnUnfilteredPrinters";
            this.btnUnfilteredPrinters.Size = new System.Drawing.Size(217, 23);
            this.btnUnfilteredPrinters.TabIndex = 33;
            this.btnUnfilteredPrinters.Text = "Fill printer combo box unfiltered";
            this.btnUnfilteredPrinters.UseVisualStyleBackColor = true;
            this.btnUnfilteredPrinters.Click += new System.EventHandler(this.btnUnfilteredPrinters_Click);
            // 
            // btnTestCapabilities
            // 
            this.btnTestCapabilities.Location = new System.Drawing.Point(183, 101);
            this.btnTestCapabilities.Name = "btnTestCapabilities";
            this.btnTestCapabilities.Size = new System.Drawing.Size(428, 23);
            this.btnTestCapabilities.TabIndex = 6;
            this.btnTestCapabilities.Text = "Print a document using printer Name (from list below) using method with capabilit" +
    "ies";
            this.btnTestCapabilities.UseVisualStyleBackColor = true;
            this.btnTestCapabilities.Click += new System.EventHandler(this.btnTestCapabilities_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 627);
            this.Controls.Add(this.btnUnfilteredPrinters);
            this.Controls.Add(this.btnFilterPrintersByType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnMakeName);
            this.Controls.Add(this.cboGCPPrinterType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblAgencyID);
            this.Controls.Add(this.lblNewDefaultDisplayName);
            this.Controls.Add(this.lblPrinterID);
            this.Controls.Add(this.lblNameFromList);
            this.Controls.Add(this.txtNewDisplayName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.grpAddPrinter);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpAddPrinter.ResumeLayout(false);
            this.grpAddPrinter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPrintDoc;
        private System.Windows.Forms.OpenFileDialog GetDocument;
        private System.Windows.Forms.ComboBox cboPrinters;
        private System.Windows.Forms.Button btnUnsharePrinter;
        private System.Windows.Forms.GroupBox grpAddPrinter;
        private System.Windows.Forms.Button btnSharePrinter;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label litEmail;
        private System.Windows.Forms.TextBox txtPrinterID;
        private System.Windows.Forms.Label litPrinterID;
        private System.Windows.Forms.CheckBox chkNotify;
        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.Label litPrinterIDForInvite;
        private System.Windows.Forms.Label lblInviteResponse;
        private System.Windows.Forms.TextBox txtCapabilities;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProxy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDefault_display_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label litname;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewDisplayName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblNameFromList;
        private System.Windows.Forms.Label lblPrinterID;
        private System.Windows.Forms.Button btnCapabilitesFile;
        private System.Windows.Forms.OpenFileDialog GetCapabilities;
        private System.Windows.Forms.Label lblPrinterNameFromList;
        private System.Windows.Forms.Button btnPrintDocFromName;
        private System.Windows.Forms.Label lblNewDefaultDisplayName;
        private System.Windows.Forms.Label lblAgencyID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboGCPPrinterType;
        private System.Windows.Forms.Button btnMakeName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnFilterPrintersByType;
        private System.Windows.Forms.Button btnUnfilteredPrinters;
        private System.Windows.Forms.Button btnTestCapabilities;
    }
}

