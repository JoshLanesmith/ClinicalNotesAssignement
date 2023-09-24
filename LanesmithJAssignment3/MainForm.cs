using ClinicalNotes;
using ClinicalNotes.VitalsClasses;
using System.Reflection;
using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;

namespace LanesmithJAssignment3
{
    public partial class MainForm : Form
    {
        //Define file path of text file to store notes
        const string filePath = @"..\..\..\clinical_notes.txt";
        string currentMode = "";

        private Timer timer;
        private bool isRepeating;

        #region FORM MODES
        private void AwaitingNoteMode()
        {
            // Disable the relevant controls for WAIT Mode
            txtNoteId.Enabled = false;
            txtName.Enabled = false;
            dtpDateOfBirth.Enabled = false;
            txtNewProblem.Enabled = false;
            btnAddProblem.Enabled = false;
            lstProblems.Enabled = false;
            btnRemoveProblem.Enabled = false;
            lstVitals.Enabled = false;
            rtxNotes.Enabled = false;
            btnAddNote.Enabled = false;
            btnUpdateNote.Enabled = false;
            btnDeleteNote.Enabled = false;

            // Track the current form mode
            currentMode = "WAIT";
        }

        private void AddMode()
        {
            // Enable the relevant controls for ADD Mode
            txtNoteId.Enabled = false;
            txtName.Enabled = true;
            dtpDateOfBirth.Enabled = true;
            txtNewProblem.Enabled = true;
            btnAddProblem.Enabled = true;
            lstProblems.Enabled = true;
            btnRemoveProblem.Enabled = true;
            lstVitals.Enabled = true;
            rtxNotes.Enabled = true;
            btnAddNote.Enabled = true;
            btnUpdateNote.Enabled = false;
            btnDeleteNote.Enabled = false;

            // Track the current form mode
            currentMode = "ADD";
        }

        private void EditMode()
        {
            // Enable the relevant controls for EDIT Mode
            txtNoteId.Enabled = false;
            txtName.Enabled = true;
            dtpDateOfBirth.Enabled = true;
            txtNewProblem.Enabled = true;
            btnAddProblem.Enabled = true;
            lstProblems.Enabled = true;
            btnRemoveProblem.Enabled = true;
            lstVitals.Enabled = true;
            rtxNotes.Enabled = true;
            btnAddNote.Enabled = false;
            btnUpdateNote.Enabled = true;
            btnDeleteNote.Enabled = true;

            // Track the current form mode
            currentMode = "EDIT";
        }

        #endregion
        public MainForm()
        {
            InitializeComponent();

            // Set parameters for the timer when to read the note for vitals while user is actively typing
            isRepeating = false;
            timer = new Timer();
            timer.Interval = 2000; // 10 seconds
            timer.Tick += Timer_Tick;
        }

        // Define the Tick Function for the Timer to read the note for vitals and display in the list box
        private void Timer_Tick(object? sender, EventArgs e)
        {
            List<IVital> vitals = SearchNoteForVitals(rtxNotes.Text.Trim());

            lstVitals.Items.Clear();
            lstVitals.Items.AddRange(vitals.ToArray());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set mode when first loading form
            AwaitingNoteMode();

            // If notes .txt file doesn't exist then create file
            if (!File.Exists(filePath))
                using (File.Create(filePath)) { }

            // read the existing .txt file to retrieve notes into a list and display the note tiltes in the list box
            List<ClinicalNote> notes = NoteFileReader.GetNotes(filePath);

            foreach (ClinicalNote note in notes)
            {
                lstNotes.Items.Add($"{note.Name} (Note: {note.Id})");
            }

            lblMessage.Text = "";
        }

        private void btnNewNote_Click(object sender, EventArgs e)
        {
            // Display message box to warn user if they might lose data when loading a new note
            string messageBox = "OK";

            if (currentMode == "EDIT")
            {
                messageBox = MessageBox.Show("Do you want to continue?\nAny unsaved changes to the current note will be lost.",
                    "Continue",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question).ToString();
            }
            else if (currentMode == "ADD")
            {
                messageBox = MessageBox.Show("Do you want to continue?\nThe current note has not been saved/added, and will be lost.",
                    "Continue",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question).ToString();
            }

            // If user confirms action then create fresh form with new unique ID
            if (messageBox == "OK")
            {
                ClearNoteFields();

                AddMode();

                txtNoteId.Text = NoteFileReader.GetNewID(filePath).ToString();

                lblMessage.Text = "";
            }
        }

        private void btnAddProblem_Click(object sender, EventArgs e)
        {
            // Add a new problem to the problem list box
            lstProblems.Items.Add(txtNewProblem.Text);
            txtNewProblem.Text = "";

            lblMessage.Text = "";
        }

        private void btnRemoveProblem_Click(object sender, EventArgs e)
        {
            // Remove the selected problem from the list box or throw error if nothing is selected
            try
            {
                lstProblems.Items.RemoveAt(lstProblems.SelectedIndex);

                lblMessage.Text = "";
            }
            catch (ArgumentOutOfRangeException)
            {
                lblMessage.Text = "Select the problem to remove";
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            try
            {
                // save user inputs into variables
                int id = int.Parse(txtNoteId.Text);
                string name = txtName.Text.Trim();
                DateTime dateOfBirth = dtpDateOfBirth.Value;
                string notes = rtxNotes.Text.Trim();
                List<string> problems = new List<string>(lstProblems.Items.Cast<String>().ToList());

                // Instantiate clinicalNote with user inputs
                ClinicalNote clinicalNote = new ClinicalNote(id, name, dateOfBirth, problems, notes);

                // Add the clinicalNote to the txt file
                NoteFileWriter.AddNewNote(filePath, clinicalNote);

                // Read rich text box notes for vitals and display in list box
                List<IVital> vitals = SearchNoteForVitals(notes);

                lstVitals.Items.Clear();
                lstVitals.Items.AddRange(vitals.ToArray());

                // Create note title and add to note list box
                string noteTitle = $"{name} (Note: {id})";

                lstNotes.Items.Add(noteTitle);

                currentMode = "TEMP";

                lstNotes.SelectedItems.Clear();
                lstNotes.SelectedItems.Add(noteTitle);

                // Change mode to EDIT and display success message
                EditMode();

                lblMessage.Text = "New note created";
            }
            catch (ArgumentException ex)
            {
                currentMode = "ADD";
                lblMessage.Text = ex.Message;
            }
            catch (Exception ex)
            {
                currentMode = "ADD";
                lblMessage.Text = ex.Message;
            }
        }

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstNotes.SelectedItem != null)
            {
                // Display message box to warn user if they might lose data when loading a new note
                string messageBox = "OK";

                if (currentMode == "EDIT")
                {
                    messageBox = MessageBox.Show("Do you want to continue?\nAny unsaved changes to the current note will be lost.", 
                        "Continue",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question).ToString();
                }
                else if (currentMode == "ADD")
                {
                    messageBox = MessageBox.Show("Do you want to continue?\nThe current note has not been saved/added, and will be lost.",
                        "Continue",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question).ToString();
                }

                if (messageBox == "OK")
                {
                    // Isolate selected note and read the title for the ID
                    string noteTitle = lstNotes.SelectedItem.ToString();

                    int startIndexOfId = noteTitle.LastIndexOf(" ") + 1;
                    int strLengthOfId = noteTitle.Length - startIndexOfId - 1;

                    int noteId = int.Parse(noteTitle.Substring(startIndexOfId, strLengthOfId));

                    // Find the note from the txt file using the noteID
                    ClinicalNote note = NoteFileReader.FindNote(filePath, noteId);

                    // Load note into form fields
                    txtNoteId.Text = note.Id.ToString();
                    txtName.Text = note.Name;
                    dtpDateOfBirth.Value = note.DateOfBirth;
                    lstProblems.Items.Clear();
                    lstProblems.Items.AddRange(note.Problems.ToArray());

                    rtxNotes.Text = note.Notes;

                    // Read rich text box notes for vitals and display in list box
                    List<IVital> vitals = SearchNoteForVitals(note.Notes);

                    lstVitals.Items.Clear();
                    lstVitals.Items.AddRange(vitals.ToArray());

                    lblMessage.Text = "";

                    // Change mode to EDIT and display success message
                    EditMode();
                }
            }
        }

        private void btnUpdateNote_Click(object sender, EventArgs e)
        {
            try
            {
                // save user inputs into variables
                int id = int.Parse(txtNoteId.Text);
                string name = txtName.Text.Trim();
                DateTime dateOfBirth = dtpDateOfBirth.Value;
                string notes = rtxNotes.Text.Trim();

                List<string> problems = new List<string>(lstProblems.Items.Cast<String>().ToList());

                // Instantiate updated clinicalNote with user inputs
                ClinicalNote updatedNote = new ClinicalNote(id, name, dateOfBirth, problems, notes);

                // Find the old note from the txt file using the noteID
                ClinicalNote noteToBeReplaced = NoteFileReader.FindNote(filePath, updatedNote.Id);

                // Update the note in the txt file
                NoteFileWriter.UpdateNote(filePath, noteToBeReplaced, updatedNote);

                // Read rich text box notes for vitals and display in list box
                List<IVital> vitals = SearchNoteForVitals(notes);

                lstVitals.Items.Clear();
                lstVitals.Items.AddRange(vitals.ToArray());

                // Display success message
                lblMessage.Text = "Note Successfully Updated";
            }
            catch (ArgumentException ex)
            {
                lblMessage.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            try
            {
                // Display message box to ask user to confirm if they want to delete the note
                string messageBox = MessageBox.Show("Are you sure you want to delete this note?", 
                    "Delete", 
                    MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Question).ToString();

                if (messageBox == "OK")
                {
                    // Find note to be deleted in txt field and clear the fields
                    ClinicalNote noteToBeDeleted = NoteFileReader.FindNote(filePath, int.Parse(txtNoteId.Text));

                    ClearNoteFields();

                    // Remove the note from the notes list box
                    string noteTitle = $"{noteToBeDeleted.Name} (Note: {noteToBeDeleted.Id})";
                    lstNotes.Items.RemoveAt(lstNotes.Items.IndexOf(noteTitle));

                    // Delete the note from the txt file, change the mode to WAIT, and display success message
                    NoteFileWriter.DeleteNote(filePath, noteToBeDeleted);

                    AwaitingNoteMode();

                    lblMessage.Text = "Note Successfully Deleted";
                }
                else
                {
                    return;
                }
            }
            catch (ArgumentException ex)
            {
                lblMessage.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void ClearNoteFields()
        {
            // Set all form values to blank or default
            txtNoteId.Text = "";
            txtName.Text = "";
            dtpDateOfBirth.Value = DateTime.Now;
            lstProblems.Items.Clear();
            lstVitals.Items.Clear();
            rtxNotes.Text = "";
        }

        private List<IVital> SearchNoteForVitals(string note)
        {
            // Delclare list of type instance to store all vitals extracted from note
            List<IVital> vitals = new List<IVital>();

            // Define list of vital Class Types
            List<Type> vitalTypes = new List<Type>{ typeof(BloodPressure), typeof(HeartRate), typeof(RespiratoryRate), typeof(Temperature) };

            // Loop through list of Class Types to read note for each vital type separately
            foreach (Type vitalType in vitalTypes)
            {
                // Create instance of the FindMatches method in the current Class Type
                MethodInfo? findMatchesMethod = vitalType.GetMethod("FindMatches", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(string) }, null);

                // Invoke the FindMatches method and save the results in a Match Collection
                MatchCollection matchedVitals = (MatchCollection)findMatchesMethod.Invoke(null, new object[] { note });
                
                // Loop through each match in the match collection
                foreach (Match match in matchedVitals)
                {
                    // Delclare variable for vital measurements and constructor
                    List<object> vitalMeasurements = new List<object>();
                    ConstructorInfo? constructor;

                    // If vitalType is of type Tempurature then call constructur that accepts doubles, else accepts ints
                    if (vitalType == typeof(Temperature))
                    {
                        // Loop through groups in maches to and add vital measurements to list
                        for (int i = 1; i < match.Groups.Count; i++)
                        {
                            vitalMeasurements.Add(double.Parse(match.Groups[i].Value));
                        }

                        // Instantiate constructor that accepts list of vitalMeasurements as doubles
                        constructor = vitalType.GetConstructor(Enumerable.Repeat(typeof(double), vitalMeasurements.Count()).ToArray());
                    }
                    else
                    {
                        // Loop through groups in maches to and add vital measurements to list
                        for (int i = 1; i < match.Groups.Count; i++)
                        {
                            vitalMeasurements.Add(int.Parse(match.Groups[i].Value));
                        }

                        // Instantiate constructor that accepts list of vitalMeasurements as ints
                        constructor = vitalType.GetConstructor(Enumerable.Repeat(typeof(int), vitalMeasurements.Count()).ToArray());
                    }
                    
                    // Invoke constructor for the current match and cast to type of interface IVital
                    IVital instance = (IVital)constructor.Invoke(vitalMeasurements.Cast<object>().ToArray());

                    // Add instance to the vitals list
                    vitals.Add(instance);
                }
                
            }

            // Return lsit of vitals
            return vitals;
        }

        private void rtxNotes_Enter(object sender, EventArgs e)
        {
            // Start timer when Enter event is triggered for the rich text box
            if (!isRepeating)
            {
                isRepeating = true;
                timer.Start();
            }
        }

        private void rtxNotes_Leave(object sender, EventArgs e)
        {
            // Stop timer when Leave event is triggered for the rich text box
            if (isRepeating)
            {
                isRepeating = false;
                timer.Stop();
            }
        }
    }
}