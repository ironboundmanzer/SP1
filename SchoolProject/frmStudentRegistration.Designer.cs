namespace School_Project_Devendra
{
    partial class frmStudentRegistration
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
            this.btnExit = new System.Windows.Forms.Button();
            this.dTPickerJoinSchoolDate = new System.Windows.Forms.DateTimePicker();
            this.dTPickerDOB = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblRegistrationNo = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveAndUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBrowsePhoto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJoinedSchoolDate = new System.Windows.Forms.TextBox();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.lblFatherName = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.txtDOB = new System.Windows.Forms.TextBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblAadhar = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtBloodGroup = new System.Windows.Forms.TextBox();
            this.btnSaveNExit = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtAadharNo = new System.Windows.Forms.TextBox();
            this.pbStudentPhoto = new System.Windows.Forms.PictureBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtSiblingInformation = new System.Windows.Forms.TextBox();
            this.txtGuardianName = new System.Windows.Forms.TextBox();
            this.txtClassTeacherContactNo = new System.Windows.Forms.TextBox();
            this.txtRollNo = new System.Windows.Forms.TextBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.lblHomeAddress = new System.Windows.Forms.Label();
            this.lblGuardianName = new System.Windows.Forms.Label();
            this.lblRollNo = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtHomeAddress = new System.Windows.Forms.TextBox();
            this.txtClassTeacher = new System.Windows.Forms.TextBox();
            this.txtGuardianContactNo = new System.Windows.Forms.TextBox();
            this.lblGuardianContactNo = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblBloodGroup = new System.Windows.Forms.Label();
            this.lblJoinSchoolDate = new System.Windows.Forms.Label();
            this.lblSiblingInfo = new System.Windows.Forms.Label();
            this.lblClassTeacherContactNo = new System.Windows.Forms.Label();
            this.lblClassTeacher = new System.Windows.Forms.Label();
            this.lblRegistrationType = new System.Windows.Forms.Label();
            this.cbRegistrationType = new System.Windows.Forms.ComboBox();
            this.panelDataDelete = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentPhoto)).BeginInit();
            this.panelDataDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(625, 544);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 30);
            this.btnExit.TabIndex = 12055;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dTPickerJoinSchoolDate
            // 
            this.dTPickerJoinSchoolDate.Location = new System.Drawing.Point(884, 272);
            this.dTPickerJoinSchoolDate.Name = "dTPickerJoinSchoolDate";
            this.dTPickerJoinSchoolDate.Size = new System.Drawing.Size(19, 20);
            this.dTPickerJoinSchoolDate.TabIndex = 12038;
            this.dTPickerJoinSchoolDate.CloseUp += new System.EventHandler(this.dTPickerJoinSchoolDate_CloseUp);
            this.dTPickerJoinSchoolDate.ValueChanged += new System.EventHandler(this.dTPickerJoinSchoolDate_ValueChanged);
            // 
            // dTPickerDOB
            // 
            this.dTPickerDOB.Location = new System.Drawing.Point(418, 169);
            this.dTPickerDOB.Name = "dTPickerDOB";
            this.dTPickerDOB.Size = new System.Drawing.Size(19, 20);
            this.dTPickerDOB.TabIndex = 12027;
            this.dTPickerDOB.CloseUp += new System.EventHandler(this.dTPickerDOB_CloseUp);
            this.dTPickerDOB.ValueChanged += new System.EventHandler(this.dTPickerDOB_ValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(509, 544);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 12054;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblRegistrationNo
            // 
            this.lblRegistrationNo.AutoSize = true;
            this.lblRegistrationNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrationNo.Location = new System.Drawing.Point(621, 14);
            this.lblRegistrationNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistrationNo.Name = "lblRegistrationNo";
            this.lblRegistrationNo.Size = new System.Drawing.Size(0, 24);
            this.lblRegistrationNo.TabIndex = 12053;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbGender
            // 
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "MALE",
            "FEMALE",
            "UNSPECIFIED"});
            this.cbGender.Location = new System.Drawing.Point(668, 137);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(235, 21);
            this.cbGender.TabIndex = 12026;
            this.cbGender.Text = "SELECT GENDER";
            this.cbGender.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbGender_KeyPress);
            // 
            // btnDelete
            // 
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(391, 544);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 12052;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveAndUpdate
            // 
            this.btnSaveAndUpdate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveAndUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndUpdate.Location = new System.Drawing.Point(276, 544);
            this.btnSaveAndUpdate.Name = "btnSaveAndUpdate";
            this.btnSaveAndUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnSaveAndUpdate.TabIndex = 12051;
            this.btnSaveAndUpdate.Text = "Save";
            this.btnSaveAndUpdate.UseVisualStyleBackColor = true;
            this.btnSaveAndUpdate.Click += new System.EventHandler(this.btnSaveAndUpdate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 390);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1057, 137);
            this.dataGridView1.TabIndex = 12050;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnBrowsePhoto
            // 
            this.btnBrowsePhoto.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBrowsePhoto.Location = new System.Drawing.Point(942, 269);
            this.btnBrowsePhoto.Name = "btnBrowsePhoto";
            this.btnBrowsePhoto.Size = new System.Drawing.Size(96, 32);
            this.btnBrowsePhoto.TabIndex = 12049;
            this.btnBrowsePhoto.Text = "Browse Photo";
            this.btnBrowsePhoto.UseVisualStyleBackColor = true;
            this.btnBrowsePhoto.Click += new System.EventHandler(this.btnBrowsePhoto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(422, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 24);
            this.label1.TabIndex = 12048;
            this.label1.Text = "Registration No    : ";
            // 
            // txtJoinedSchoolDate
            // 
            this.txtJoinedSchoolDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJoinedSchoolDate.Location = new System.Drawing.Point(668, 272);
            this.txtJoinedSchoolDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtJoinedSchoolDate.MaxLength = 12;
            this.txtJoinedSchoolDate.Name = "txtJoinedSchoolDate";
            this.txtJoinedSchoolDate.ReadOnly = true;
            this.txtJoinedSchoolDate.Size = new System.Drawing.Size(221, 20);
            this.txtJoinedSchoolDate.TabIndex = 12057;
            this.txtJoinedSchoolDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJoinedSchoolDate_KeyPress);
            // 
            // txtFatherName
            // 
            this.txtFatherName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFatherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherName.Location = new System.Drawing.Point(668, 109);
            this.txtFatherName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFatherName.MaxLength = 50;
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(235, 20);
            this.txtFatherName.TabIndex = 12024;
            // 
            // lblFatherName
            // 
            this.lblFatherName.AutoSize = true;
            this.lblFatherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFatherName.Location = new System.Drawing.Point(467, 109);
            this.lblFatherName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFatherName.Name = "lblFatherName";
            this.lblFatherName.Size = new System.Drawing.Size(174, 20);
            this.lblFatherName.TabIndex = 12047;
            this.lblFatherName.Text = "Father Name                 :";
            // 
            // txtSection
            // 
            this.txtSection.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.Location = new System.Drawing.Point(668, 190);
            this.txtSection.Margin = new System.Windows.Forms.Padding(4);
            this.txtSection.MaxLength = 5;
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(235, 20);
            this.txtSection.TabIndex = 12030;
            this.txtSection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSection_KeyPress);
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.Location = new System.Drawing.Point(468, 188);
            this.lblSection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(175, 20);
            this.lblSection.TabIndex = 12046;
            this.lblSection.Text = "Section                           :";
            // 
            // txtDOB
            // 
            this.txtDOB.Location = new System.Drawing.Point(202, 169);
            this.txtDOB.MaxLength = 10;
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.ReadOnly = true;
            this.txtDOB.Size = new System.Drawing.Size(219, 20);
            this.txtDOB.TabIndex = 12056;
            this.txtDOB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDOB_KeyPress);
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(22, 167);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(156, 20);
            this.lblDOB.TabIndex = 12043;
            this.lblDOB.Text = "DOB                           :";
            // 
            // lblAadhar
            // 
            this.lblAadhar.AutoSize = true;
            this.lblAadhar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAadhar.Location = new System.Drawing.Point(468, 163);
            this.lblAadhar.Name = "lblAadhar";
            this.lblAadhar.Size = new System.Drawing.Size(173, 20);
            this.lblAadhar.TabIndex = 12042;
            this.lblAadhar.Text = "Aadhar No                     :";
            // 
            // txtNotes
            // 
            this.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(202, 337);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4);
            this.txtNotes.MaxLength = 100;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(235, 46);
            this.txtNotes.TabIndex = 12045;
            // 
            // txtBloodGroup
            // 
            this.txtBloodGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBloodGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBloodGroup.Location = new System.Drawing.Point(202, 229);
            this.txtBloodGroup.Margin = new System.Windows.Forms.Padding(4);
            this.txtBloodGroup.MaxLength = 3;
            this.txtBloodGroup.Name = "txtBloodGroup";
            this.txtBloodGroup.Size = new System.Drawing.Size(235, 20);
            this.txtBloodGroup.TabIndex = 12031;
            this.txtBloodGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBloodGroup_KeyPress);
            // 
            // btnSaveNExit
            // 
            this.btnSaveNExit.BackColor = System.Drawing.Color.DarkRed;
            this.btnSaveNExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNExit.ForeColor = System.Drawing.Color.White;
            this.btnSaveNExit.Location = new System.Drawing.Point(848, 791);
            this.btnSaveNExit.Name = "btnSaveNExit";
            this.btnSaveNExit.Size = new System.Drawing.Size(145, 41);
            this.btnSaveNExit.TabIndex = 12036;
            this.btnSaveNExit.Text = "Save and Exit";
            this.btnSaveNExit.UseVisualStyleBackColor = false;
            this.btnSaveNExit.Visible = false;
            // 
            // txtName
            // 
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(202, 109);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(235, 20);
            this.txtName.TabIndex = 12023;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(22, 107);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(155, 20);
            this.lblName.TabIndex = 12033;
            this.lblName.Text = "Name                         :";
            // 
            // txtAadharNo
            // 
            this.txtAadharNo.Location = new System.Drawing.Point(668, 164);
            this.txtAadharNo.MaxLength = 12;
            this.txtAadharNo.Name = "txtAadharNo";
            this.txtAadharNo.Size = new System.Drawing.Size(235, 20);
            this.txtAadharNo.TabIndex = 12028;
            this.txtAadharNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAadharNo_KeyPress);
            // 
            // pbStudentPhoto
            // 
            this.pbStudentPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbStudentPhoto.Location = new System.Drawing.Point(942, 109);
            this.pbStudentPhoto.Name = "pbStudentPhoto";
            this.pbStudentPhoto.Size = new System.Drawing.Size(141, 154);
            this.pbStudentPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStudentPhoto.TabIndex = 12040;
            this.pbStudentPhoto.TabStop = false;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(468, 135);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(175, 20);
            this.lblGender.TabIndex = 12037;
            this.lblGender.Text = "Gender                           :";
            // 
            // txtSiblingInformation
            // 
            this.txtSiblingInformation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSiblingInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSiblingInformation.Location = new System.Drawing.Point(202, 309);
            this.txtSiblingInformation.Margin = new System.Windows.Forms.Padding(4);
            this.txtSiblingInformation.MaxLength = 20;
            this.txtSiblingInformation.Name = "txtSiblingInformation";
            this.txtSiblingInformation.Size = new System.Drawing.Size(235, 20);
            this.txtSiblingInformation.TabIndex = 12039;
            this.txtSiblingInformation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSiblingInformation_KeyPress);
            // 
            // txtGuardianName
            // 
            this.txtGuardianName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGuardianName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuardianName.Location = new System.Drawing.Point(668, 218);
            this.txtGuardianName.Margin = new System.Windows.Forms.Padding(4);
            this.txtGuardianName.MaxLength = 50;
            this.txtGuardianName.Name = "txtGuardianName";
            this.txtGuardianName.Size = new System.Drawing.Size(235, 20);
            this.txtGuardianName.TabIndex = 12032;
            this.txtGuardianName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGuardianName_KeyPress);
            // 
            // txtClassTeacherContactNo
            // 
            this.txtClassTeacherContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassTeacherContactNo.Location = new System.Drawing.Point(668, 343);
            this.txtClassTeacherContactNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtClassTeacherContactNo.MaxLength = 10;
            this.txtClassTeacherContactNo.Name = "txtClassTeacherContactNo";
            this.txtClassTeacherContactNo.Size = new System.Drawing.Size(235, 20);
            this.txtClassTeacherContactNo.TabIndex = 12044;
            this.txtClassTeacherContactNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassTeacherContactNo_KeyPress);
            // 
            // txtRollNo
            // 
            this.txtRollNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRollNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRollNo.Location = new System.Drawing.Point(202, 137);
            this.txtRollNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtRollNo.MaxLength = 20;
            this.txtRollNo.Name = "txtRollNo";
            this.txtRollNo.Size = new System.Drawing.Size(235, 20);
            this.txtRollNo.TabIndex = 12025;
            this.txtRollNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRollNo_KeyPress);
            // 
            // txtClass
            // 
            this.txtClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClass.Location = new System.Drawing.Point(202, 199);
            this.txtClass.Margin = new System.Windows.Forms.Padding(4);
            this.txtClass.MaxLength = 15;
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(235, 20);
            this.txtClass.TabIndex = 12029;
            this.txtClass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClass_KeyPress);
            // 
            // lblHomeAddress
            // 
            this.lblHomeAddress.AutoSize = true;
            this.lblHomeAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomeAddress.Location = new System.Drawing.Point(22, 257);
            this.lblHomeAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomeAddress.Name = "lblHomeAddress";
            this.lblHomeAddress.Size = new System.Drawing.Size(155, 20);
            this.lblHomeAddress.TabIndex = 12017;
            this.lblHomeAddress.Text = "Home Address         :";
            // 
            // lblGuardianName
            // 
            this.lblGuardianName.AutoSize = true;
            this.lblGuardianName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuardianName.Location = new System.Drawing.Point(468, 216);
            this.lblGuardianName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuardianName.Name = "lblGuardianName";
            this.lblGuardianName.Size = new System.Drawing.Size(173, 20);
            this.lblGuardianName.TabIndex = 12016;
            this.lblGuardianName.Text = "Guardian Name            :";
            // 
            // lblRollNo
            // 
            this.lblRollNo.AutoSize = true;
            this.lblRollNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRollNo.Location = new System.Drawing.Point(22, 137);
            this.lblRollNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRollNo.Name = "lblRollNo";
            this.lblRollNo.Size = new System.Drawing.Size(156, 20);
            this.lblRollNo.TabIndex = 12013;
            this.lblRollNo.Text = "Roll No                       :";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(22, 197);
            this.lblClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(156, 20);
            this.lblClass.TabIndex = 12012;
            this.lblClass.Text = "Class                          :";
            // 
            // txtHomeAddress
            // 
            this.txtHomeAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHomeAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHomeAddress.Location = new System.Drawing.Point(202, 254);
            this.txtHomeAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtHomeAddress.MaxLength = 300;
            this.txtHomeAddress.Multiline = true;
            this.txtHomeAddress.Name = "txtHomeAddress";
            this.txtHomeAddress.Size = new System.Drawing.Size(235, 47);
            this.txtHomeAddress.TabIndex = 12034;
            // 
            // txtClassTeacher
            // 
            this.txtClassTeacher.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClassTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassTeacher.Location = new System.Drawing.Point(668, 302);
            this.txtClassTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.txtClassTeacher.MaxLength = 20;
            this.txtClassTeacher.Name = "txtClassTeacher";
            this.txtClassTeacher.Size = new System.Drawing.Size(235, 20);
            this.txtClassTeacher.TabIndex = 12041;
            this.txtClassTeacher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassTeacher_KeyPress);
            // 
            // txtGuardianContactNo
            // 
            this.txtGuardianContactNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGuardianContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuardianContactNo.Location = new System.Drawing.Point(668, 246);
            this.txtGuardianContactNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtGuardianContactNo.MaxLength = 10;
            this.txtGuardianContactNo.Name = "txtGuardianContactNo";
            this.txtGuardianContactNo.Size = new System.Drawing.Size(235, 20);
            this.txtGuardianContactNo.TabIndex = 12035;
            this.txtGuardianContactNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGuardianContactNo_KeyPress);
            // 
            // lblGuardianContactNo
            // 
            this.lblGuardianContactNo.AutoSize = true;
            this.lblGuardianContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuardianContactNo.Location = new System.Drawing.Point(468, 242);
            this.lblGuardianContactNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuardianContactNo.Name = "lblGuardianContactNo";
            this.lblGuardianContactNo.Size = new System.Drawing.Size(175, 20);
            this.lblGuardianContactNo.TabIndex = 12022;
            this.lblGuardianContactNo.Text = "Guardian Contact No   :";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(22, 340);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(155, 20);
            this.lblNotes.TabIndex = 12021;
            this.lblNotes.Text = "Notes                         :";
            // 
            // lblBloodGroup
            // 
            this.lblBloodGroup.AutoSize = true;
            this.lblBloodGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBloodGroup.Location = new System.Drawing.Point(22, 227);
            this.lblBloodGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBloodGroup.Name = "lblBloodGroup";
            this.lblBloodGroup.Size = new System.Drawing.Size(155, 20);
            this.lblBloodGroup.TabIndex = 12020;
            this.lblBloodGroup.Text = "Blood Group             :";
            // 
            // lblJoinSchoolDate
            // 
            this.lblJoinSchoolDate.AutoSize = true;
            this.lblJoinSchoolDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoinSchoolDate.Location = new System.Drawing.Point(468, 272);
            this.lblJoinSchoolDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJoinSchoolDate.Name = "lblJoinSchoolDate";
            this.lblJoinSchoolDate.Size = new System.Drawing.Size(176, 20);
            this.lblJoinSchoolDate.TabIndex = 12019;
            this.lblJoinSchoolDate.Text = "Joined School Date      :";
            // 
            // lblSiblingInfo
            // 
            this.lblSiblingInfo.AutoSize = true;
            this.lblSiblingInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiblingInfo.Location = new System.Drawing.Point(22, 305);
            this.lblSiblingInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSiblingInfo.Name = "lblSiblingInfo";
            this.lblSiblingInfo.Size = new System.Drawing.Size(157, 20);
            this.lblSiblingInfo.TabIndex = 12018;
            this.lblSiblingInfo.Text = "Sibling Information   :";
            // 
            // lblClassTeacherContactNo
            // 
            this.lblClassTeacherContactNo.AutoSize = true;
            this.lblClassTeacherContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassTeacherContactNo.Location = new System.Drawing.Point(469, 323);
            this.lblClassTeacherContactNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassTeacherContactNo.Name = "lblClassTeacherContactNo";
            this.lblClassTeacherContactNo.Size = new System.Drawing.Size(173, 40);
            this.lblClassTeacherContactNo.TabIndex = 12015;
            this.lblClassTeacherContactNo.Text = "Class Teacher \r\nContact No                    :";
            // 
            // lblClassTeacher
            // 
            this.lblClassTeacher.AutoSize = true;
            this.lblClassTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassTeacher.Location = new System.Drawing.Point(468, 300);
            this.lblClassTeacher.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassTeacher.Name = "lblClassTeacher";
            this.lblClassTeacher.Size = new System.Drawing.Size(174, 20);
            this.lblClassTeacher.TabIndex = 12014;
            this.lblClassTeacher.Text = "Class Teacher               :";
            // 
            // lblRegistrationType
            // 
            this.lblRegistrationType.AutoSize = true;
            this.lblRegistrationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrationType.Location = new System.Drawing.Point(308, 60);
            this.lblRegistrationType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistrationType.Name = "lblRegistrationType";
            this.lblRegistrationType.Size = new System.Drawing.Size(145, 20);
            this.lblRegistrationType.TabIndex = 12058;
            this.lblRegistrationType.Text = "Registration Type : ";
            // 
            // cbRegistrationType
            // 
            this.cbRegistrationType.FormattingEnabled = true;
            this.cbRegistrationType.Items.AddRange(new object[] {
            "STUDENT",
            "FACULTY",
            "HOUSE KEEPING",
            "GUEST"});
            this.cbRegistrationType.Location = new System.Drawing.Point(476, 59);
            this.cbRegistrationType.Name = "cbRegistrationType";
            this.cbRegistrationType.Size = new System.Drawing.Size(235, 21);
            this.cbRegistrationType.TabIndex = 12059;
            this.cbRegistrationType.Text = "SELECT REGISTRATION TYPE";
            this.cbRegistrationType.SelectedIndexChanged += new System.EventHandler(this.cbRegistrationType_SelectedIndexChanged);
            // 
            // panelDataDelete
            // 
            this.panelDataDelete.BackColor = System.Drawing.Color.GhostWhite;
            this.panelDataDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDataDelete.Controls.Add(this.label2);
            this.panelDataDelete.Controls.Add(this.btnYes);
            this.panelDataDelete.Controls.Add(this.btnNo);
            this.panelDataDelete.Controls.Add(this.pictureBox1);
            this.panelDataDelete.Controls.Add(this.shapeContainer1);
            this.panelDataDelete.Location = new System.Drawing.Point(373, 199);
            this.panelDataDelete.Name = "panelDataDelete";
            this.panelDataDelete.Size = new System.Drawing.Size(307, 164);
            this.panelDataDelete.TabIndex = 12060;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SchoolProject.Properties.Resources.Cancel;
            this.pictureBox1.Location = new System.Drawing.Point(274, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(305, 162);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 10;
            this.lineShape1.X2 = 298;
            this.lineShape1.Y1 = 126;
            this.lineShape1.Y2 = 126;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 154;
            this.lineShape2.X2 = 154;
            this.lineShape2.Y1 = 130;
            this.lineShape2.Y2 = 154;
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(184, 129);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(116, 30);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(6, 129);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(123, 30);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(41, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Are you sure to delete Record !!!";
            // 
            // frmStudentRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 611);
            this.Controls.Add(this.panelDataDelete);
            this.Controls.Add(this.cbRegistrationType);
            this.Controls.Add(this.lblRegistrationType);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dTPickerJoinSchoolDate);
            this.Controls.Add(this.dTPickerDOB);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblRegistrationNo);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSaveAndUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBrowsePhoto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJoinedSchoolDate);
            this.Controls.Add(this.txtFatherName);
            this.Controls.Add(this.lblFatherName);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.txtDOB);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lblAadhar);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtBloodGroup);
            this.Controls.Add(this.btnSaveNExit);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtAadharNo);
            this.Controls.Add(this.pbStudentPhoto);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtSiblingInformation);
            this.Controls.Add(this.txtGuardianName);
            this.Controls.Add(this.txtClassTeacherContactNo);
            this.Controls.Add(this.txtRollNo);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.lblHomeAddress);
            this.Controls.Add(this.lblGuardianName);
            this.Controls.Add(this.lblRollNo);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.txtHomeAddress);
            this.Controls.Add(this.txtClassTeacher);
            this.Controls.Add(this.txtGuardianContactNo);
            this.Controls.Add(this.lblGuardianContactNo);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblBloodGroup);
            this.Controls.Add(this.lblJoinSchoolDate);
            this.Controls.Add(this.lblSiblingInfo);
            this.Controls.Add(this.lblClassTeacherContactNo);
            this.Controls.Add(this.lblClassTeacher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmStudentRegistration";
            this.Text = "frmStudentRegistration";
            this.Load += new System.EventHandler(this.frmStudentRegistration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentPhoto)).EndInit();
            this.panelDataDelete.ResumeLayout(false);
            this.panelDataDelete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dTPickerJoinSchoolDate;
        private System.Windows.Forms.DateTimePicker dTPickerDOB;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblRegistrationNo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSaveAndUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBrowsePhoto;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtJoinedSchoolDate;
        public System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.Label lblFatherName;
        public System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.Label lblSection;
        public System.Windows.Forms.TextBox txtDOB;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblAadhar;
        public System.Windows.Forms.TextBox txtNotes;
        public System.Windows.Forms.TextBox txtBloodGroup;
        private System.Windows.Forms.Button btnSaveNExit;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        public System.Windows.Forms.TextBox txtAadharNo;
        public System.Windows.Forms.PictureBox pbStudentPhoto;
        private System.Windows.Forms.Label lblGender;
        public System.Windows.Forms.TextBox txtSiblingInformation;
        public System.Windows.Forms.TextBox txtGuardianName;
        public System.Windows.Forms.TextBox txtClassTeacherContactNo;
        public System.Windows.Forms.TextBox txtRollNo;
        public System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblHomeAddress;
        private System.Windows.Forms.Label lblGuardianName;
        private System.Windows.Forms.Label lblRollNo;
        private System.Windows.Forms.Label lblClass;
        public System.Windows.Forms.TextBox txtHomeAddress;
        public System.Windows.Forms.TextBox txtClassTeacher;
        public System.Windows.Forms.TextBox txtGuardianContactNo;
        private System.Windows.Forms.Label lblGuardianContactNo;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.Label lblJoinSchoolDate;
        private System.Windows.Forms.Label lblSiblingInfo;
        private System.Windows.Forms.Label lblClassTeacherContactNo;
        private System.Windows.Forms.Label lblClassTeacher;
        private System.Windows.Forms.Label lblRegistrationType;
        private System.Windows.Forms.ComboBox cbRegistrationType;
        private System.Windows.Forms.Panel panelDataDelete;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;


    }
}