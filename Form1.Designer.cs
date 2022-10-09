namespace WordTemplateUploader
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.parseExlBtn = new System.Windows.Forms.Button();
            this.directoryTxtBox = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.getExcelBtn = new System.Windows.Forms.Button();
            this.getExcelTxtBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.loadingLbl = new System.Windows.Forms.Label();
            this.listNameTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tokenTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.crossLbl = new System.Windows.Forms.Label();
            this.tickLbl = new System.Windows.Forms.Label();
            this.WhisperDataTxtBox = new System.Windows.Forms.TextBox();
            this.WHisperListBox = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.findWithOwnerTxtBox = new System.Windows.Forms.TextBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.newOwnerTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.systAdmLstBox = new System.Windows.Forms.ListBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // parseExlBtn
            // 
            this.parseExlBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.parseExlBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.parseExlBtn.Location = new System.Drawing.Point(12, 321);
            this.parseExlBtn.Name = "parseExlBtn";
            this.parseExlBtn.Size = new System.Drawing.Size(340, 33);
            this.parseExlBtn.TabIndex = 0;
            this.parseExlBtn.Text = "Zahájit instalaci";
            this.parseExlBtn.UseVisualStyleBackColor = false;
            this.parseExlBtn.Click += new System.EventHandler(this.parseExlBtn_Click);
            // 
            // directoryTxtBox
            // 
            this.directoryTxtBox.Location = new System.Drawing.Point(52, 149);
            this.directoryTxtBox.Name = "directoryTxtBox";
            this.directoryTxtBox.Size = new System.Drawing.Size(237, 20);
            this.directoryTxtBox.TabIndex = 3;
            // 
            // browseBtn
            // 
            this.browseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.browseBtn.Location = new System.Drawing.Point(52, 175);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(237, 32);
            this.browseBtn.TabIndex = 4;
            this.browseBtn.Text = "Nahrát složku";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // getExcelBtn
            // 
            this.getExcelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.getExcelBtn.Location = new System.Drawing.Point(52, 94);
            this.getExcelBtn.Name = "getExcelBtn";
            this.getExcelBtn.Size = new System.Drawing.Size(237, 26);
            this.getExcelBtn.TabIndex = 7;
            this.getExcelBtn.Text = "Nahrát Excel";
            this.getExcelBtn.UseVisualStyleBackColor = true;
            this.getExcelBtn.Click += new System.EventHandler(this.getExcelBtn_Click);
            // 
            // getExcelTxtBox
            // 
            this.getExcelTxtBox.Location = new System.Drawing.Point(52, 68);
            this.getExcelTxtBox.Name = "getExcelTxtBox";
            this.getExcelTxtBox.Size = new System.Drawing.Size(237, 20);
            this.getExcelTxtBox.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.getExcelTxtBox);
            this.panel2.Controls.Add(this.getExcelBtn);
            this.panel2.Controls.Add(this.browseBtn);
            this.panel2.Controls.Add(this.directoryTxtBox);
            this.panel2.Location = new System.Drawing.Point(433, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 259);
            this.panel2.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(86, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Vlastní Instalace";
            // 
            // loadingLbl
            // 
            this.loadingLbl.AutoSize = true;
            this.loadingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadingLbl.Location = new System.Drawing.Point(194, 209);
            this.loadingLbl.Name = "loadingLbl";
            this.loadingLbl.Size = new System.Drawing.Size(111, 24);
            this.loadingLbl.TabIndex = 11;
            this.loadingLbl.Text = "Nahrávám...";
            this.loadingLbl.Visible = false;
            // 
            // listNameTxtBox
            // 
            this.listNameTxtBox.Location = new System.Drawing.Point(20, 106);
            this.listNameTxtBox.Name = "listNameTxtBox";
            this.listNameTxtBox.Size = new System.Drawing.Size(127, 20);
            this.listNameTxtBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(16, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "List";
            // 
            // tokenTxtBox
            // 
            this.tokenTxtBox.Location = new System.Drawing.Point(20, 48);
            this.tokenTxtBox.Name = "tokenTxtBox";
            this.tokenTxtBox.Size = new System.Drawing.Size(240, 20);
            this.tokenTxtBox.TabIndex = 1;
            this.tokenTxtBox.TextChanged += new System.EventHandler(this.tokenTxtBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Token";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.crossLbl);
            this.panel1.Controls.Add(this.loadingLbl);
            this.panel1.Controls.Add(this.tickLbl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tokenTxtBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listNameTxtBox);
            this.panel1.Location = new System.Drawing.Point(12, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 259);
            this.panel1.TabIndex = 9;
            // 
            // crossLbl
            // 
            this.crossLbl.AutoSize = true;
            this.crossLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.crossLbl.ForeColor = System.Drawing.Color.Red;
            this.crossLbl.Location = new System.Drawing.Point(280, 48);
            this.crossLbl.Name = "crossLbl";
            this.crossLbl.Size = new System.Drawing.Size(25, 24);
            this.crossLbl.TabIndex = 8;
            this.crossLbl.Text = "X";
            this.crossLbl.Visible = false;
            // 
            // tickLbl
            // 
            this.tickLbl.AutoSize = true;
            this.tickLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tickLbl.ForeColor = System.Drawing.Color.Lime;
            this.tickLbl.Location = new System.Drawing.Point(274, 41);
            this.tickLbl.Name = "tickLbl";
            this.tickLbl.Size = new System.Drawing.Size(31, 31);
            this.tickLbl.TabIndex = 7;
            this.tickLbl.Text = "✓";
            this.tickLbl.Visible = false;
            // 
            // WhisperDataTxtBox
            // 
            this.WhisperDataTxtBox.Location = new System.Drawing.Point(16, 48);
            this.WhisperDataTxtBox.Multiline = true;
            this.WhisperDataTxtBox.Name = "WhisperDataTxtBox";
            this.WhisperDataTxtBox.ReadOnly = true;
            this.WhisperDataTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WhisperDataTxtBox.Size = new System.Drawing.Size(289, 199);
            this.WhisperDataTxtBox.TabIndex = 12;
            // 
            // WHisperListBox
            // 
            this.WHisperListBox.FormattingEnabled = true;
            this.WHisperListBox.Items.AddRange(new object[] {
            "Systemy",
            "SelfService",
            "Revize squadem šablon",
            "Důvěrnost",
            "Tribe",
            "Jazyky",
            "Systém admin",
            "Logo",
            "Systémová sada",
            "Jméno v šabloně"});
            this.WHisperListBox.Location = new System.Drawing.Point(311, 48);
            this.WHisperListBox.Name = "WHisperListBox";
            this.WHisperListBox.Size = new System.Drawing.Size(143, 199);
            this.WHisperListBox.TabIndex = 13;
            this.WHisperListBox.SelectedIndexChanged += new System.EventHandler(this.WHisperListBox_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.WhisperDataTxtBox);
            this.panel3.Controls.Add(this.WHisperListBox);
            this.panel3.Location = new System.Drawing.Point(808, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(490, 259);
            this.panel3.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(129, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Číselníkové hodnoty";
            // 
            // findWithOwnerTxtBox
            // 
            this.findWithOwnerTxtBox.Location = new System.Drawing.Point(946, 396);
            this.findWithOwnerTxtBox.Name = "findWithOwnerTxtBox";
            this.findWithOwnerTxtBox.Size = new System.Drawing.Size(316, 20);
            this.findWithOwnerTxtBox.TabIndex = 15;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(946, 495);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(316, 23);
            this.findBtn.TabIndex = 16;
            this.findBtn.Text = "Nahrad";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(862, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Old Owner";
            // 
            // newOwnerTxtBox
            // 
            this.newOwnerTxtBox.Location = new System.Drawing.Point(946, 449);
            this.newOwnerTxtBox.Name = "newOwnerTxtBox";
            this.newOwnerTxtBox.Size = new System.Drawing.Size(316, 20);
            this.newOwnerTxtBox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(865, 455);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "New Owner";
            // 
            // systAdmLstBox
            // 
            this.systAdmLstBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.systAdmLstBox.FormattingEnabled = true;
            this.systAdmLstBox.ItemHeight = 24;
            this.systAdmLstBox.Items.AddRange(new object[] {
            "cssab",
            "eom",
            "MSOFFICE"});
            this.systAdmLstBox.Location = new System.Drawing.Point(646, 396);
            this.systAdmLstBox.Name = "systAdmLstBox";
            this.systAdmLstBox.Size = new System.Drawing.Size(120, 100);
            this.systAdmLstBox.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 629);
            this.Controls.Add(this.systAdmLstBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.newOwnerTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.findWithOwnerTxtBox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.parseExlBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Word Template Uploader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button parseExlBtn;
        private System.Windows.Forms.TextBox directoryTxtBox;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button getExcelBtn;
        private System.Windows.Forms.TextBox getExcelTxtBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label loadingLbl;
        private System.Windows.Forms.TextBox listNameTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tokenTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label crossLbl;
        private System.Windows.Forms.Label tickLbl;
        private System.Windows.Forms.TextBox WhisperDataTxtBox;
        private System.Windows.Forms.ListBox WHisperListBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox findWithOwnerTxtBox;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox newOwnerTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox systAdmLstBox;
    }
}

