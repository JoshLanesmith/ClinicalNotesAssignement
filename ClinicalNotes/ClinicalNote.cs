namespace ClinicalNotes
{
    public class ClinicalNote
    {
        // Declare all class properties
        private int id;
        public int Id { get { return id; } private set { id = value; } }

        private string? name;
        public string? Name { get { return name; } set { name = value; } }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; } }

        private List<string>? problems;
        public List<string>? Problems { get { return problems; } private set { problems = value;  } }

        private string? notes;
        public string? Notes { get { return notes; } set { notes = value; } }


        // Declare default and overloaded constructors
        public ClinicalNote() { }

        public ClinicalNote(int _id, string _name, DateTime _dateOfBirth, List<string> _problems, string _notes)
        {
            string errorMessage = "";

            _name = _name.Trim();
            _notes= _notes;

            // Validate properties and add error message if relevant
            if (string.IsNullOrEmpty(_name))
                errorMessage += "Patient name required\n";
            
            if ( _dateOfBirth > DateTime.Now)
                errorMessage += "Date of birth cannot be in the future\n";

            if (string.IsNullOrEmpty(_notes))
                errorMessage += "Notes field cannot be left blank\n";

            // If errorMessage is not empty then throw Exception
            if (errorMessage != "")
                throw new ArgumentException(errorMessage);

            // Instantiate class
            Id = _id;
            Name = _name;
            DateOfBirth = _dateOfBirth;
            Notes = _notes;
            Problems = _problems;
        }

        // Override ToString method to concatenate all class properties into a single line string
        public override string ToString()
        {
            string problemsStr = "";

            if (Problems.Count > 0)
            {
                problemsStr = String.Join(';', Problems);
            }

            string singleLineNote = Notes;

            singleLineNote = singleLineNote.Replace('\n', ';');

            string record = $"{Id}|{Name}|{DateOfBirth}|{problemsStr}|{singleLineNote}";
            return record;
        }
    }
}