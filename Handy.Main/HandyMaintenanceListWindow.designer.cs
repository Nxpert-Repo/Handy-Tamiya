namespace Handy
{
    partial class HandyMaintenanceListWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.TabMaintence = new System.Windows.Forms.TabControl();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabHostName = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabHandyInfo = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTerminalNumber = new System.Windows.Forms.TextBox();
            this.lblBuildNumber = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.tabFTP = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ProgressFTP = new System.Windows.Forms.ProgressBar();
            this.ckFTPSEND = new System.Windows.Forms.CheckBox();
            this.txtFTPPASS = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFTPUSER = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFTPSERVER = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.lblArchivedFileSize = new System.Windows.Forms.Label();
            this.lblMovementFileSize = new System.Windows.Forms.Label();
            this.lblMITFileSize = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.optArchive = new System.Windows.Forms.RadioButton();
            this.lblTagFileSize = new System.Windows.Forms.Label();
            this.optInventory = new System.Windows.Forms.RadioButton();
            this.label18 = new System.Windows.Forms.Label();
            this.lblArchiveRecord = new System.Windows.Forms.Label();
            this.optTag = new System.Windows.Forms.RadioButton();
            this.lblDBInvRecord = new System.Windows.Forms.Label();
            this.optMovement = new System.Windows.Forms.RadioButton();
            this.lblDBMovedRecord = new System.Windows.Forms.Label();
            this.lblDBTagRecord = new System.Windows.Forms.Label();
            this.panelSpecialChar = new System.Windows.Forms.Panel();
            this.btnEquals = new System.Windows.Forms.Button();
            this.btnBackSlash = new System.Windows.Forms.Button();
            this.btnSlash = new System.Windows.Forms.Button();
            this.btnQuestion = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnDash = new System.Windows.Forms.Button();
            this.btnUnderscore = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnAmpersand = new System.Windows.Forms.Button();
            this.btnPercent = new System.Windows.Forms.Button();
            this.btnDollar = new System.Windows.Forms.Button();
            this.btnSharp = new System.Windows.Forms.Button();
            this.btnAt = new System.Windows.Forms.Button();
            this.btnExclamation = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TabMaintence.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabHostName.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabHandyInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabFTP.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSpecialChar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMaintence
            // 
            this.TabMaintence.Controls.Add(this.tabDatabase);
            this.TabMaintence.Controls.Add(this.tabHostName);
            this.TabMaintence.Controls.Add(this.tabHandyInfo);
            this.TabMaintence.Controls.Add(this.tabFTP);
            this.TabMaintence.Controls.Add(this.tabLog);
            this.TabMaintence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.TabMaintence.Location = new System.Drawing.Point(4, 38);
            this.TabMaintence.Name = "TabMaintence";
            this.TabMaintence.SelectedIndex = 0;
            this.TabMaintence.Size = new System.Drawing.Size(233, 200);
            this.TabMaintence.TabIndex = 3;
            // 
            // tabDatabase
            // 
            this.tabDatabase.BackColor = System.Drawing.Color.White;
            this.tabDatabase.Controls.Add(this.panel3);
            this.tabDatabase.Location = new System.Drawing.Point(4, 25);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Size = new System.Drawing.Size(225, 171);
            this.tabDatabase.Text = "Database ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtDataSource);
            this.panel3.Controls.Add(this.txtDatabase);
            this.panel3.Controls.Add(this.txtPassword);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtUser);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(7, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 160);
            // 
            // txtDataSource
            // 
            this.txtDataSource.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.txtDataSource.ForeColor = System.Drawing.Color.Black;
            this.txtDataSource.Location = new System.Drawing.Point(11, 22);
            this.txtDataSource.Multiline = true;
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(178, 25);
            this.txtDataSource.TabIndex = 1;
            this.txtDataSource.GotFocus += new System.EventHandler(this.txtDataSource_GotFocus);
            // 
            // txtDatabase
            // 
            this.txtDatabase.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.txtDatabase.ForeColor = System.Drawing.Color.Black;
            this.txtDatabase.Location = new System.Drawing.Point(11, 68);
            this.txtDatabase.Multiline = true;
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(178, 25);
            this.txtDatabase.TabIndex = 2;
            this.txtDatabase.GotFocus += new System.EventHandler(this.txtDatabase_GotFocus);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(93, 126);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(96, 25);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.GotFocus += new System.EventHandler(this.txtPassword_GotFocus);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.Text = "Data Source";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.Text = "DB Password";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.txtUser.ForeColor = System.Drawing.Color.Black;
            this.txtUser.Location = new System.Drawing.Point(93, 97);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(96, 25);
            this.txtUser.TabIndex = 3;
            this.txtUser.GotFocus += new System.EventHandler(this.txtUser_GotFocus);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.Text = "Database Name";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.Text = "DB User";
            // 
            // tabHostName
            // 
            this.tabHostName.BackColor = System.Drawing.Color.White;
            this.tabHostName.Controls.Add(this.panel4);
            this.tabHostName.Location = new System.Drawing.Point(4, 25);
            this.tabHostName.Name = "tabHostName";
            this.tabHostName.Size = new System.Drawing.Size(225, 171);
            this.tabHostName.Text = "Host Name ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtHostName);
            this.panel4.Controls.Add(this.txtIP);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(7, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(209, 160);
            // 
            // txtHostName
            // 
            this.txtHostName.BackColor = System.Drawing.Color.White;
            this.txtHostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.txtHostName.ForeColor = System.Drawing.Color.Black;
            this.txtHostName.Location = new System.Drawing.Point(11, 46);
            this.txtHostName.Multiline = true;
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(185, 25);
            this.txtHostName.TabIndex = 1;
            this.txtHostName.GotFocus += new System.EventHandler(this.txtHostName_GotFocus);
            // 
            // txtIP
            // 
            this.txtIP.BackColor = System.Drawing.Color.White;
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.txtIP.ForeColor = System.Drawing.Color.Black;
            this.txtIP.Location = new System.Drawing.Point(11, 97);
            this.txtIP.Multiline = true;
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(185, 25);
            this.txtIP.TabIndex = 2;
            this.txtIP.GotFocus += new System.EventHandler(this.txtIP_GotFocus);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.Text = "Host Name";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(9, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.Text = "IP Address";
            // 
            // tabHandyInfo
            // 
            this.tabHandyInfo.BackColor = System.Drawing.Color.White;
            this.tabHandyInfo.Controls.Add(this.panel2);
            this.tabHandyInfo.Location = new System.Drawing.Point(4, 25);
            this.tabHandyInfo.Name = "tabHandyInfo";
            this.tabHandyInfo.Size = new System.Drawing.Size(225, 171);
            this.tabHandyInfo.Text = "Handy Info";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtTerminalNumber);
            this.panel2.Controls.Add(this.lblBuildNumber);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.lblSerialNumber);
            this.panel2.Controls.Add(this.lblModel);
            this.panel2.Location = new System.Drawing.Point(7, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 160);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(12, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 14);
            this.label10.Text = "Serial Number";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(12, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(190, 14);
            this.label12.Text = "Assembly Version";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(12, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 14);
            this.label9.Text = "Model";
            // 
            // txtTerminalNumber
            // 
            this.txtTerminalNumber.BackColor = System.Drawing.Color.White;
            this.txtTerminalNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTerminalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.txtTerminalNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTerminalNumber.Location = new System.Drawing.Point(130, 9);
            this.txtTerminalNumber.MaxLength = 3;
            this.txtTerminalNumber.Name = "txtTerminalNumber";
            this.txtTerminalNumber.Size = new System.Drawing.Size(76, 28);
            this.txtTerminalNumber.TabIndex = 8;
            this.txtTerminalNumber.Text = "000";
            this.txtTerminalNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTerminalNumber_KeyPress);
            // 
            // lblBuildNumber
            // 
            this.lblBuildNumber.BackColor = System.Drawing.Color.White;
            this.lblBuildNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.lblBuildNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBuildNumber.Location = new System.Drawing.Point(11, 127);
            this.lblBuildNumber.Name = "lblBuildNumber";
            this.lblBuildNumber.Size = new System.Drawing.Size(190, 20);
            this.lblBuildNumber.Text = "Build Number";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 27);
            this.label13.Text = "Terminal No";
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.BackColor = System.Drawing.Color.White;
            this.lblSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.lblSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSerialNumber.Location = new System.Drawing.Point(11, 87);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(190, 20);
            this.lblSerialNumber.Text = "Serial Number";
            // 
            // lblModel
            // 
            this.lblModel.BackColor = System.Drawing.Color.White;
            this.lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.lblModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblModel.Location = new System.Drawing.Point(11, 50);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(190, 20);
            this.lblModel.Text = "Model";
            // 
            // tabFTP
            // 
            this.tabFTP.BackColor = System.Drawing.Color.White;
            this.tabFTP.Controls.Add(this.panel6);
            this.tabFTP.Location = new System.Drawing.Point(4, 25);
            this.tabFTP.Name = "tabFTP";
            this.tabFTP.Size = new System.Drawing.Size(225, 171);
            this.tabFTP.Text = "FTP";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.ProgressFTP);
            this.panel6.Controls.Add(this.ckFTPSEND);
            this.panel6.Controls.Add(this.txtFTPPASS);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.txtFTPUSER);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.txtFTPSERVER);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Location = new System.Drawing.Point(6, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(214, 165);
            // 
            // ProgressFTP
            // 
            this.ProgressFTP.Location = new System.Drawing.Point(8, 147);
            this.ProgressFTP.Name = "ProgressFTP";
            this.ProgressFTP.Size = new System.Drawing.Size(197, 10);
            this.ProgressFTP.Visible = false;
            // 
            // ckFTPSEND
            // 
            this.ckFTPSEND.Checked = true;
            this.ckFTPSEND.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckFTPSEND.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.ckFTPSEND.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ckFTPSEND.Location = new System.Drawing.Point(6, 119);
            this.ckFTPSEND.Name = "ckFTPSEND";
            this.ckFTPSEND.Size = new System.Drawing.Size(205, 22);
            this.ckFTPSEND.TabIndex = 11;
            this.ckFTPSEND.Text = "Send Handy Log(s) to Server";
            // 
            // txtFTPPASS
            // 
            this.txtFTPPASS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFTPPASS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.txtFTPPASS.ForeColor = System.Drawing.Color.Black;
            this.txtFTPPASS.Location = new System.Drawing.Point(93, 85);
            this.txtFTPPASS.Multiline = true;
            this.txtFTPPASS.Name = "txtFTPPASS";
            this.txtFTPPASS.Size = new System.Drawing.Size(113, 25);
            this.txtFTPPASS.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(7, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 20);
            this.label15.Text = "Password";
            // 
            // txtFTPUSER
            // 
            this.txtFTPUSER.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFTPUSER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.txtFTPUSER.ForeColor = System.Drawing.Color.Black;
            this.txtFTPUSER.Location = new System.Drawing.Point(93, 56);
            this.txtFTPUSER.Multiline = true;
            this.txtFTPUSER.Name = "txtFTPUSER";
            this.txtFTPUSER.Size = new System.Drawing.Size(113, 25);
            this.txtFTPUSER.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(8, 58);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 20);
            this.label16.Text = "User";
            // 
            // txtFTPSERVER
            // 
            this.txtFTPSERVER.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFTPSERVER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.txtFTPSERVER.ForeColor = System.Drawing.Color.Black;
            this.txtFTPSERVER.Location = new System.Drawing.Point(8, 26);
            this.txtFTPSERVER.Multiline = true;
            this.txtFTPSERVER.Name = "txtFTPSERVER";
            this.txtFTPSERVER.Size = new System.Drawing.Size(198, 25);
            this.txtFTPSERVER.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(6, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(161, 20);
            this.label14.Text = "Server Host\\IP";
            // 
            // tabLog
            // 
            this.tabLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabLog.Controls.Add(this.panel1);
            this.tabLog.Location = new System.Drawing.Point(4, 25);
            this.tabLog.Name = "tabLog";
            this.tabLog.Size = new System.Drawing.Size(225, 171);
            this.tabLog.Text = "Log Files";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.lblArchivedFileSize);
            this.panel1.Controls.Add(this.lblMovementFileSize);
            this.panel1.Controls.Add(this.lblMITFileSize);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.optArchive);
            this.panel1.Controls.Add(this.lblTagFileSize);
            this.panel1.Controls.Add(this.optInventory);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.lblArchiveRecord);
            this.panel1.Controls.Add(this.optTag);
            this.panel1.Controls.Add(this.lblDBInvRecord);
            this.panel1.Controls.Add(this.optMovement);
            this.panel1.Controls.Add(this.lblDBMovedRecord);
            this.panel1.Controls.Add(this.lblDBTagRecord);
            this.panel1.Location = new System.Drawing.Point(2, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 160);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Teal;
            this.label17.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(8, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(140, 21);
            this.label17.Text = "Text File";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblArchivedFileSize
            // 
            this.lblArchivedFileSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblArchivedFileSize.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblArchivedFileSize.ForeColor = System.Drawing.Color.Black;
            this.lblArchivedFileSize.Location = new System.Drawing.Point(103, 127);
            this.lblArchivedFileSize.Name = "lblArchivedFileSize";
            this.lblArchivedFileSize.Size = new System.Drawing.Size(53, 20);
            this.lblArchivedFileSize.Text = "[0 KB]";
            this.lblArchivedFileSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblArchivedFileSize.Visible = false;
            // 
            // lblMovementFileSize
            // 
            this.lblMovementFileSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMovementFileSize.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblMovementFileSize.ForeColor = System.Drawing.Color.Black;
            this.lblMovementFileSize.Location = new System.Drawing.Point(102, 103);
            this.lblMovementFileSize.Name = "lblMovementFileSize";
            this.lblMovementFileSize.Size = new System.Drawing.Size(54, 20);
            this.lblMovementFileSize.Text = "[0 KB]";
            this.lblMovementFileSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblMovementFileSize.Visible = false;
            // 
            // lblMITFileSize
            // 
            this.lblMITFileSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblMITFileSize.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblMITFileSize.ForeColor = System.Drawing.Color.Black;
            this.lblMITFileSize.Location = new System.Drawing.Point(103, 55);
            this.lblMITFileSize.Name = "lblMITFileSize";
            this.lblMITFileSize.Size = new System.Drawing.Size(53, 20);
            this.lblMITFileSize.Text = "[0 KB]";
            this.lblMITFileSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(6, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 19);
            this.label11.Text = "CLEAR DATA";
            // 
            // optArchive
            // 
            this.optArchive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.optArchive.Checked = true;
            this.optArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.optArchive.ForeColor = System.Drawing.Color.Black;
            this.optArchive.Location = new System.Drawing.Point(8, 127);
            this.optArchive.Name = "optArchive";
            this.optArchive.Size = new System.Drawing.Size(100, 20);
            this.optArchive.TabIndex = 8;
            this.optArchive.Text = "Archive";
            this.optArchive.Visible = false;
            // 
            // lblTagFileSize
            // 
            this.lblTagFileSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblTagFileSize.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblTagFileSize.ForeColor = System.Drawing.Color.Black;
            this.lblTagFileSize.Location = new System.Drawing.Point(102, 79);
            this.lblTagFileSize.Name = "lblTagFileSize";
            this.lblTagFileSize.Size = new System.Drawing.Size(54, 20);
            this.lblTagFileSize.Text = "[0 KB]";
            this.lblTagFileSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblTagFileSize.Visible = false;
            // 
            // optInventory
            // 
            this.optInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.optInventory.Checked = true;
            this.optInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.optInventory.ForeColor = System.Drawing.Color.Black;
            this.optInventory.Location = new System.Drawing.Point(8, 55);
            this.optInventory.Name = "optInventory";
            this.optInventory.Size = new System.Drawing.Size(100, 20);
            this.optInventory.TabIndex = 3;
            this.optInventory.Text = "Inventory";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Teal;
            this.label18.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(148, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 21);
            this.label18.Text = "Database";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblArchiveRecord
            // 
            this.lblArchiveRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblArchiveRecord.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblArchiveRecord.ForeColor = System.Drawing.Color.Black;
            this.lblArchiveRecord.Location = new System.Drawing.Point(154, 127);
            this.lblArchiveRecord.Name = "lblArchiveRecord";
            this.lblArchiveRecord.Size = new System.Drawing.Size(58, 20);
            this.lblArchiveRecord.Text = "0";
            this.lblArchiveRecord.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblArchiveRecord.Visible = false;
            // 
            // optTag
            // 
            this.optTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.optTag.Checked = true;
            this.optTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.optTag.ForeColor = System.Drawing.Color.Black;
            this.optTag.Location = new System.Drawing.Point(8, 79);
            this.optTag.Name = "optTag";
            this.optTag.Size = new System.Drawing.Size(100, 20);
            this.optTag.TabIndex = 1;
            this.optTag.Text = "Tagging";
            this.optTag.Visible = false;
            // 
            // lblDBInvRecord
            // 
            this.lblDBInvRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblDBInvRecord.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblDBInvRecord.ForeColor = System.Drawing.Color.Black;
            this.lblDBInvRecord.Location = new System.Drawing.Point(154, 55);
            this.lblDBInvRecord.Name = "lblDBInvRecord";
            this.lblDBInvRecord.Size = new System.Drawing.Size(58, 20);
            this.lblDBInvRecord.Text = "0";
            this.lblDBInvRecord.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // optMovement
            // 
            this.optMovement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.optMovement.Checked = true;
            this.optMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.optMovement.ForeColor = System.Drawing.Color.Black;
            this.optMovement.Location = new System.Drawing.Point(8, 103);
            this.optMovement.Name = "optMovement";
            this.optMovement.Size = new System.Drawing.Size(100, 20);
            this.optMovement.TabIndex = 2;
            this.optMovement.Text = "Movement";
            this.optMovement.Visible = false;
            // 
            // lblDBMovedRecord
            // 
            this.lblDBMovedRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblDBMovedRecord.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblDBMovedRecord.ForeColor = System.Drawing.Color.Black;
            this.lblDBMovedRecord.Location = new System.Drawing.Point(154, 103);
            this.lblDBMovedRecord.Name = "lblDBMovedRecord";
            this.lblDBMovedRecord.Size = new System.Drawing.Size(58, 20);
            this.lblDBMovedRecord.Text = "0";
            this.lblDBMovedRecord.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDBMovedRecord.Visible = false;
            // 
            // lblDBTagRecord
            // 
            this.lblDBTagRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblDBTagRecord.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblDBTagRecord.ForeColor = System.Drawing.Color.Black;
            this.lblDBTagRecord.Location = new System.Drawing.Point(154, 79);
            this.lblDBTagRecord.Name = "lblDBTagRecord";
            this.lblDBTagRecord.Size = new System.Drawing.Size(58, 20);
            this.lblDBTagRecord.Text = "0";
            this.lblDBTagRecord.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDBTagRecord.Visible = false;
            // 
            // panelSpecialChar
            // 
            this.panelSpecialChar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelSpecialChar.Controls.Add(this.btnEquals);
            this.panelSpecialChar.Controls.Add(this.btnBackSlash);
            this.panelSpecialChar.Controls.Add(this.btnSlash);
            this.panelSpecialChar.Controls.Add(this.btnQuestion);
            this.panelSpecialChar.Controls.Add(this.btnPlus);
            this.panelSpecialChar.Controls.Add(this.btnDash);
            this.panelSpecialChar.Controls.Add(this.btnUnderscore);
            this.panelSpecialChar.Controls.Add(this.btnClose);
            this.panelSpecialChar.Controls.Add(this.btnOpen);
            this.panelSpecialChar.Controls.Add(this.btnAmpersand);
            this.panelSpecialChar.Controls.Add(this.btnPercent);
            this.panelSpecialChar.Controls.Add(this.btnDollar);
            this.panelSpecialChar.Controls.Add(this.btnSharp);
            this.panelSpecialChar.Controls.Add(this.btnAt);
            this.panelSpecialChar.Controls.Add(this.btnExclamation);
            this.panelSpecialChar.Location = new System.Drawing.Point(4, 240);
            this.panelSpecialChar.Name = "panelSpecialChar";
            this.panelSpecialChar.Size = new System.Drawing.Size(233, 43);
            // 
            // btnEquals
            // 
            this.btnEquals.BackColor = System.Drawing.Color.Teal;
            this.btnEquals.ForeColor = System.Drawing.Color.White;
            this.btnEquals.Location = new System.Drawing.Point(63, 22);
            this.btnEquals.Name = "btnEquals";
            this.btnEquals.Size = new System.Drawing.Size(20, 20);
            this.btnEquals.TabIndex = 14;
            this.btnEquals.Text = "=";
            this.btnEquals.Click += new System.EventHandler(this.btnEquals_Click);
            // 
            // btnBackSlash
            // 
            this.btnBackSlash.BackColor = System.Drawing.Color.Teal;
            this.btnBackSlash.ForeColor = System.Drawing.Color.White;
            this.btnBackSlash.Location = new System.Drawing.Point(43, 22);
            this.btnBackSlash.Name = "btnBackSlash";
            this.btnBackSlash.Size = new System.Drawing.Size(20, 20);
            this.btnBackSlash.TabIndex = 13;
            this.btnBackSlash.Text = "/";
            this.btnBackSlash.Click += new System.EventHandler(this.btnBackSlash_Click);
            // 
            // btnSlash
            // 
            this.btnSlash.BackColor = System.Drawing.Color.Teal;
            this.btnSlash.ForeColor = System.Drawing.Color.White;
            this.btnSlash.Location = new System.Drawing.Point(23, 22);
            this.btnSlash.Name = "btnSlash";
            this.btnSlash.Size = new System.Drawing.Size(20, 20);
            this.btnSlash.TabIndex = 12;
            this.btnSlash.Text = "\\";
            this.btnSlash.Click += new System.EventHandler(this.btnSlash_Click);
            // 
            // btnQuestion
            // 
            this.btnQuestion.BackColor = System.Drawing.Color.Teal;
            this.btnQuestion.ForeColor = System.Drawing.Color.White;
            this.btnQuestion.Location = new System.Drawing.Point(3, 22);
            this.btnQuestion.Name = "btnQuestion";
            this.btnQuestion.Size = new System.Drawing.Size(20, 20);
            this.btnQuestion.TabIndex = 11;
            this.btnQuestion.Text = "?";
            this.btnQuestion.Click += new System.EventHandler(this.btnQuestion_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.Teal;
            this.btnPlus.ForeColor = System.Drawing.Color.White;
            this.btnPlus.Location = new System.Drawing.Point(203, 2);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(20, 20);
            this.btnPlus.TabIndex = 10;
            this.btnPlus.Text = "+";
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnDash
            // 
            this.btnDash.BackColor = System.Drawing.Color.Teal;
            this.btnDash.ForeColor = System.Drawing.Color.White;
            this.btnDash.Location = new System.Drawing.Point(183, 2);
            this.btnDash.Name = "btnDash";
            this.btnDash.Size = new System.Drawing.Size(20, 20);
            this.btnDash.TabIndex = 9;
            this.btnDash.Text = "-";
            this.btnDash.Click += new System.EventHandler(this.btnDash_Click);
            // 
            // btnUnderscore
            // 
            this.btnUnderscore.BackColor = System.Drawing.Color.Teal;
            this.btnUnderscore.ForeColor = System.Drawing.Color.White;
            this.btnUnderscore.Location = new System.Drawing.Point(163, 2);
            this.btnUnderscore.Name = "btnUnderscore";
            this.btnUnderscore.Size = new System.Drawing.Size(20, 20);
            this.btnUnderscore.TabIndex = 8;
            this.btnUnderscore.Text = "_";
            this.btnUnderscore.Click += new System.EventHandler(this.btnUnderscore_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Teal;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(143, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = ")";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Teal;
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(123, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(20, 20);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "(";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnAmpersand
            // 
            this.btnAmpersand.BackColor = System.Drawing.Color.Teal;
            this.btnAmpersand.ForeColor = System.Drawing.Color.White;
            this.btnAmpersand.Location = new System.Drawing.Point(103, 2);
            this.btnAmpersand.Name = "btnAmpersand";
            this.btnAmpersand.Size = new System.Drawing.Size(20, 20);
            this.btnAmpersand.TabIndex = 5;
            this.btnAmpersand.Text = "&&";
            this.btnAmpersand.Click += new System.EventHandler(this.btnAmpersand_Click);
            // 
            // btnPercent
            // 
            this.btnPercent.BackColor = System.Drawing.Color.Teal;
            this.btnPercent.ForeColor = System.Drawing.Color.White;
            this.btnPercent.Location = new System.Drawing.Point(83, 2);
            this.btnPercent.Name = "btnPercent";
            this.btnPercent.Size = new System.Drawing.Size(20, 20);
            this.btnPercent.TabIndex = 4;
            this.btnPercent.Text = "%";
            this.btnPercent.Click += new System.EventHandler(this.btnPercent_Click);
            // 
            // btnDollar
            // 
            this.btnDollar.BackColor = System.Drawing.Color.Teal;
            this.btnDollar.ForeColor = System.Drawing.Color.White;
            this.btnDollar.Location = new System.Drawing.Point(63, 2);
            this.btnDollar.Name = "btnDollar";
            this.btnDollar.Size = new System.Drawing.Size(20, 20);
            this.btnDollar.TabIndex = 3;
            this.btnDollar.Text = "$";
            this.btnDollar.Click += new System.EventHandler(this.btnDollar_Click);
            // 
            // btnSharp
            // 
            this.btnSharp.BackColor = System.Drawing.Color.Teal;
            this.btnSharp.ForeColor = System.Drawing.Color.White;
            this.btnSharp.Location = new System.Drawing.Point(43, 2);
            this.btnSharp.Name = "btnSharp";
            this.btnSharp.Size = new System.Drawing.Size(20, 20);
            this.btnSharp.TabIndex = 2;
            this.btnSharp.Text = "#";
            this.btnSharp.Click += new System.EventHandler(this.btnSharp_Click);
            // 
            // btnAt
            // 
            this.btnAt.BackColor = System.Drawing.Color.Teal;
            this.btnAt.ForeColor = System.Drawing.Color.White;
            this.btnAt.Location = new System.Drawing.Point(23, 2);
            this.btnAt.Name = "btnAt";
            this.btnAt.Size = new System.Drawing.Size(20, 20);
            this.btnAt.TabIndex = 1;
            this.btnAt.Text = "@";
            this.btnAt.Click += new System.EventHandler(this.btnAt_Click);
            // 
            // btnExclamation
            // 
            this.btnExclamation.BackColor = System.Drawing.Color.Teal;
            this.btnExclamation.ForeColor = System.Drawing.Color.White;
            this.btnExclamation.Location = new System.Drawing.Point(3, 2);
            this.btnExclamation.Name = "btnExclamation";
            this.btnExclamation.Size = new System.Drawing.Size(20, 20);
            this.btnExclamation.TabIndex = 0;
            this.btnExclamation.Text = "!";
            this.btnExclamation.Click += new System.EventHandler(this.btnExclamation_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(11, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 25);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(11, 93);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(256, 25);
            this.textBox2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(9, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.Text = "Host Name";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.label8.ForeColor = System.Drawing.Color.DarkGreen;
            this.label8.Location = new System.Drawing.Point(9, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 20);
            this.label8.Text = "IP Address";
            // 
            // HandyMaintenanceListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(242, 321);
            this.Controls.Add(this.TabMaintence);
            this.Controls.Add(this.panelSpecialChar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HandyMaintenanceListWindow";
            this.Text = "Maintenance";
            this.Load += new System.EventHandler(this.HandyMaintenanceListWindow_Load);
            this.Controls.SetChildIndex(this.panelSpecialChar, 0);
            this.Controls.SetChildIndex(this.TabMaintence, 0);
            this.TabMaintence.ResumeLayout(false);
            this.tabDatabase.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabHostName.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabHandyInfo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabFTP.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelSpecialChar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMaintence;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabPage tabHostName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelSpecialChar;
        private System.Windows.Forms.Button btnDollar;
        private System.Windows.Forms.Button btnSharp;
        private System.Windows.Forms.Button btnAt;
        private System.Windows.Forms.Button btnExclamation;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnDash;
        private System.Windows.Forms.Button btnUnderscore;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnAmpersand;
        private System.Windows.Forms.Button btnPercent;
        private System.Windows.Forms.Button btnEquals;
        private System.Windows.Forms.Button btnBackSlash;
        private System.Windows.Forms.Button btnSlash;
        private System.Windows.Forms.Button btnQuestion;
        private System.Windows.Forms.TabPage tabHandyInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblBuildNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTerminalNumber;
        private System.Windows.Forms.TabPage tabFTP;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.ProgressBar ProgressFTP;
        private System.Windows.Forms.CheckBox ckFTPSEND;
        private System.Windows.Forms.TextBox txtFTPPASS;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtFTPUSER;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtFTPSERVER;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblArchivedFileSize;
        private System.Windows.Forms.Label lblMovementFileSize;
        private System.Windows.Forms.Label lblMITFileSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton optArchive;
        private System.Windows.Forms.Label lblTagFileSize;
        private System.Windows.Forms.RadioButton optInventory;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblArchiveRecord;
        private System.Windows.Forms.RadioButton optTag;
        private System.Windows.Forms.Label lblDBInvRecord;
        private System.Windows.Forms.RadioButton optMovement;
        private System.Windows.Forms.Label lblDBMovedRecord;
        private System.Windows.Forms.Label lblDBTagRecord;
    }
}