namespace LanesmithJAssignment3
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstNotes = new System.Windows.Forms.ListBox();
            this.btnNewNote = new System.Windows.Forms.Button();
            this.grbEncounterNote = new System.Windows.Forms.GroupBox();
            this.btnDeleteNote = new System.Windows.Forms.Button();
            this.btnUpdateNote = new System.Windows.Forms.Button();
            this.btnAddNote = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            this.rtxNotes = new System.Windows.Forms.RichTextBox();
            this.lblVitals = new System.Windows.Forms.Label();
            this.lstVitals = new System.Windows.Forms.ListBox();
            this.btnRemoveProblem = new System.Windows.Forms.Button();
            this.lblProblems = new System.Windows.Forms.Label();
            this.lstProblems = new System.Windows.Forms.ListBox();
            this.btnAddProblem = new System.Windows.Forms.Button();
            this.txtNewProblem = new System.Windows.Forms.TextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtNoteId = new System.Windows.Forms.TextBox();
            this.lblNewProblem = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNoteId = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.grbEncounterNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstNotes
            // 
            this.lstNotes.FormattingEnabled = true;
            this.lstNotes.ItemHeight = 15;
            this.lstNotes.Location = new System.Drawing.Point(23, 79);
            this.lstNotes.Name = "lstNotes";
            this.lstNotes.Size = new System.Drawing.Size(196, 499);
            this.lstNotes.TabIndex = 0;
            this.lstNotes.SelectedIndexChanged += new System.EventHandler(this.lstNotes_SelectedIndexChanged);
            // 
            // btnNewNote
            // 
            this.btnNewNote.Location = new System.Drawing.Point(23, 41);
            this.btnNewNote.Name = "btnNewNote";
            this.btnNewNote.Size = new System.Drawing.Size(124, 23);
            this.btnNewNote.TabIndex = 1;
            this.btnNewNote.Text = "Start New Note";
            this.btnNewNote.UseVisualStyleBackColor = true;
            this.btnNewNote.Click += new System.EventHandler(this.btnNewNote_Click);
            // 
            // grbEncounterNote
            // 
            this.grbEncounterNote.Controls.Add(this.btnDeleteNote);
            this.grbEncounterNote.Controls.Add(this.btnUpdateNote);
            this.grbEncounterNote.Controls.Add(this.btnAddNote);
            this.grbEncounterNote.Controls.Add(this.lblNotes);
            this.grbEncounterNote.Controls.Add(this.rtxNotes);
            this.grbEncounterNote.Controls.Add(this.lblVitals);
            this.grbEncounterNote.Controls.Add(this.lstVitals);
            this.grbEncounterNote.Controls.Add(this.btnRemoveProblem);
            this.grbEncounterNote.Controls.Add(this.lblProblems);
            this.grbEncounterNote.Controls.Add(this.lstProblems);
            this.grbEncounterNote.Controls.Add(this.btnAddProblem);
            this.grbEncounterNote.Controls.Add(this.txtNewProblem);
            this.grbEncounterNote.Controls.Add(this.dtpDateOfBirth);
            this.grbEncounterNote.Controls.Add(this.txtName);
            this.grbEncounterNote.Controls.Add(this.txtNoteId);
            this.grbEncounterNote.Controls.Add(this.lblNewProblem);
            this.grbEncounterNote.Controls.Add(this.lblDateOfBirth);
            this.grbEncounterNote.Controls.Add(this.lblName);
            this.grbEncounterNote.Controls.Add(this.lblNoteId);
            this.grbEncounterNote.Location = new System.Drawing.Point(255, 41);
            this.grbEncounterNote.Name = "grbEncounterNote";
            this.grbEncounterNote.Size = new System.Drawing.Size(859, 537);
            this.grbEncounterNote.TabIndex = 2;
            this.grbEncounterNote.TabStop = false;
            this.grbEncounterNote.Text = "Add/Edit/Delete Encounter Note:";
            // 
            // btnDeleteNote
            // 
            this.btnDeleteNote.Location = new System.Drawing.Point(216, 499);
            this.btnDeleteNote.Name = "btnDeleteNote";
            this.btnDeleteNote.Size = new System.Drawing.Size(96, 23);
            this.btnDeleteNote.TabIndex = 18;
            this.btnDeleteNote.Text = "Delete Note";
            this.btnDeleteNote.UseVisualStyleBackColor = true;
            this.btnDeleteNote.Click += new System.EventHandler(this.btnDeleteNote_Click);
            // 
            // btnUpdateNote
            // 
            this.btnUpdateNote.Location = new System.Drawing.Point(105, 499);
            this.btnUpdateNote.Name = "btnUpdateNote";
            this.btnUpdateNote.Size = new System.Drawing.Size(96, 23);
            this.btnUpdateNote.TabIndex = 17;
            this.btnUpdateNote.Text = "Update Note";
            this.btnUpdateNote.UseVisualStyleBackColor = true;
            this.btnUpdateNote.Click += new System.EventHandler(this.btnUpdateNote_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.Location = new System.Drawing.Point(14, 499);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(75, 23);
            this.btnAddNote.TabIndex = 16;
            this.btnAddNote.Text = "Add Note";
            this.btnAddNote.UseVisualStyleBackColor = true;
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(13, 213);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(41, 15);
            this.lblNotes.TabIndex = 15;
            this.lblNotes.Text = "Notes:";
            // 
            // rtxNotes
            // 
            this.rtxNotes.Location = new System.Drawing.Point(14, 231);
            this.rtxNotes.Name = "rtxNotes";
            this.rtxNotes.Size = new System.Drawing.Size(825, 262);
            this.rtxNotes.TabIndex = 14;
            this.rtxNotes.Text = "";
            this.rtxNotes.Enter += new System.EventHandler(this.rtxNotes_Enter);
            this.rtxNotes.Leave += new System.EventHandler(this.rtxNotes_Leave);
            // 
            // lblVitals
            // 
            this.lblVitals.AutoSize = true;
            this.lblVitals.Location = new System.Drawing.Point(684, 25);
            this.lblVitals.Name = "lblVitals";
            this.lblVitals.Size = new System.Drawing.Size(38, 15);
            this.lblVitals.TabIndex = 13;
            this.lblVitals.Text = "Vitals:";
            // 
            // lstVitals
            // 
            this.lstVitals.FormattingEnabled = true;
            this.lstVitals.ItemHeight = 15;
            this.lstVitals.Location = new System.Drawing.Point(684, 43);
            this.lstVitals.Name = "lstVitals";
            this.lstVitals.Size = new System.Drawing.Size(149, 169);
            this.lstVitals.TabIndex = 12;
            // 
            // btnRemoveProblem
            // 
            this.btnRemoveProblem.Location = new System.Drawing.Point(491, 188);
            this.btnRemoveProblem.Name = "btnRemoveProblem";
            this.btnRemoveProblem.Size = new System.Drawing.Size(149, 23);
            this.btnRemoveProblem.TabIndex = 11;
            this.btnRemoveProblem.Text = "Remove Problem";
            this.btnRemoveProblem.UseVisualStyleBackColor = true;
            this.btnRemoveProblem.Click += new System.EventHandler(this.btnRemoveProblem_Click);
            // 
            // lblProblems
            // 
            this.lblProblems.AutoSize = true;
            this.lblProblems.Location = new System.Drawing.Point(491, 25);
            this.lblProblems.Name = "lblProblems";
            this.lblProblems.Size = new System.Drawing.Size(60, 15);
            this.lblProblems.TabIndex = 10;
            this.lblProblems.Text = "Problems:";
            // 
            // lstProblems
            // 
            this.lstProblems.FormattingEnabled = true;
            this.lstProblems.ItemHeight = 15;
            this.lstProblems.Location = new System.Drawing.Point(491, 43);
            this.lstProblems.Name = "lstProblems";
            this.lstProblems.Size = new System.Drawing.Size(149, 139);
            this.lstProblems.TabIndex = 9;
            // 
            // btnAddProblem
            // 
            this.btnAddProblem.Location = new System.Drawing.Point(381, 158);
            this.btnAddProblem.Name = "btnAddProblem";
            this.btnAddProblem.Size = new System.Drawing.Size(75, 23);
            this.btnAddProblem.TabIndex = 8;
            this.btnAddProblem.Text = "Add";
            this.btnAddProblem.UseVisualStyleBackColor = true;
            this.btnAddProblem.Click += new System.EventHandler(this.btnAddProblem_Click);
            // 
            // txtNewProblem
            // 
            this.txtNewProblem.Location = new System.Drawing.Point(121, 159);
            this.txtNewProblem.Name = "txtNewProblem";
            this.txtNewProblem.Size = new System.Drawing.Size(243, 23);
            this.txtNewProblem.TabIndex = 7;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(121, 119);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(156, 23);
            this.dtpDateOfBirth.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(121, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(335, 23);
            this.txtName.TabIndex = 5;
            // 
            // txtNoteId
            // 
            this.txtNoteId.Location = new System.Drawing.Point(121, 43);
            this.txtNoteId.Name = "txtNoteId";
            this.txtNoteId.Size = new System.Drawing.Size(100, 23);
            this.txtNoteId.TabIndex = 4;
            // 
            // lblNewProblem
            // 
            this.lblNewProblem.AutoSize = true;
            this.lblNewProblem.Location = new System.Drawing.Point(13, 162);
            this.lblNewProblem.Name = "lblNewProblem";
            this.lblNewProblem.Size = new System.Drawing.Size(79, 15);
            this.lblNewProblem.TabIndex = 3;
            this.lblNewProblem.Text = "New Problem";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(13, 125);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(76, 15);
            this.lblDateOfBirth.TabIndex = 2;
            this.lblDateOfBirth.Text = "Date of Birth:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 83);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Patient Name:";
            // 
            // lblNoteId
            // 
            this.lblNoteId.AutoSize = true;
            this.lblNoteId.Location = new System.Drawing.Point(13, 46);
            this.lblNoteId.Name = "lblNoteId";
            this.lblNoteId.Size = new System.Drawing.Size(50, 15);
            this.lblNoteId.TabIndex = 0;
            this.lblNoteId.Text = "Note ID:";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(30, 598);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(93, 15);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Result Messages";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 679);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.grbEncounterNote);
            this.Controls.Add(this.btnNewNote);
            this.Controls.Add(this.lstNotes);
            this.Name = "MainForm";
            this.Text = "Encounter Notes";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grbEncounterNote.ResumeLayout(false);
            this.grbEncounterNote.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstNotes;
        private Button btnNewNote;
        private GroupBox grbEncounterNote;
        private Button btnDeleteNote;
        private Button btnUpdateNote;
        private Button btnAddNote;
        private Label lblNotes;
        private RichTextBox rtxNotes;
        private Label lblVitals;
        private ListBox lstVitals;
        private Button btnRemoveProblem;
        private Label lblProblems;
        private ListBox lstProblems;
        private Button btnAddProblem;
        private TextBox txtNewProblem;
        private DateTimePicker dtpDateOfBirth;
        private TextBox txtName;
        private TextBox txtNoteId;
        private Label lblNewProblem;
        private Label lblDateOfBirth;
        private Label lblName;
        private Label lblNoteId;
        private Label lblMessage;
    }
}