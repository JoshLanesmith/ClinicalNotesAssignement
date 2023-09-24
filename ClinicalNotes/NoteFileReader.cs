using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalNotes
{
    public static class NoteFileReader
    {
        public static int GetNewID(string filePath)
        {
            // Get all notes from txt file
            List<ClinicalNote> clinicalNotes = GetNotes(filePath);

            // Isolate the currently used IDs as a list
            List<int> usedIds = new List<int>();
            foreach (ClinicalNote note in clinicalNotes)
            {
                usedIds.Add(note.Id);
            }

            //Sort the list of IDs in decending order and return the value of current highest value +1
            if (usedIds.Count > 0)
            {
                usedIds.Sort((a, b) => b.CompareTo(a));

                return usedIds[0] + 1;
            }
            else
            {
                return 1;
            }
        }

        public static List<ClinicalNote> GetNotes(string filePath)
        {
            using StreamReader reader = new StreamReader(filePath, true);

            List<ClinicalNote> clinicalNotes = new List<ClinicalNote>();

            // Read through txt file and use each line to instantiate an instance of a ClinicalNote and add to list of notes
            while(reader.Peek() != -1)
            {
                string row = reader.ReadLine();
                string[] cols = row.Split("|");
                
                int id = int.Parse(cols[0]);
                string name = cols[1];
                DateTime dateOfBirth = DateTime.Parse(cols[2]);
                List<string> problems = new List<string>();
                if (!string.IsNullOrEmpty(cols[3]))
                {
                    string[] probArray = cols[3].Split(";");
                    problems = probArray.ToList();
                }

                string note = cols[4].Replace(';', '\n');

                ClinicalNote clinicalNote = new ClinicalNote(id, name, dateOfBirth, problems, note);

                clinicalNotes.Add(clinicalNote);
            }

            // Return full list of notes from txt file
            return clinicalNotes;
        }

        public static ClinicalNote FindNote(string filePath, int id)
        {
            // Get all notes from txt file
            List<ClinicalNote> clinicalNotes = GetNotes(filePath);

            ClinicalNote clinicalNote = new ClinicalNote();

            // Read through list of notes and isolate the note matching the provided ID
            foreach (ClinicalNote note in clinicalNotes)
            {
                if (note.Id == id)
                {
                    clinicalNote = note;
                }
            }

            // Return the found clinical Note
            return clinicalNote;
        }
    }
}
