using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClinicalNotes
{
    public static class NoteFileWriter
    {
        public static void AddNewNote(string filePath, ClinicalNote note)
        {
            using StreamWriter textIn = new StreamWriter(filePath, true);
                // Append line of appointment details to end of text file
                textIn.WriteLine(note.ToString());
        }

        public static void UpdateNote(string filePath, ClinicalNote toBeReplaced, ClinicalNote updatedNote)
        {
            // Declare file path for temp file
            string tempFile = @"..\..\..\temp_update_file.txt";

            try
            {
                //Read through primary file and copy notes to temp file and update the toBeReplaced note with the updated Note
                using (StreamReader reader = new StreamReader(filePath, true))
                using (StreamWriter writer = new StreamWriter(tempFile))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == toBeReplaced.ToString())
                        {
                            writer.WriteLine(updatedNote.ToString());
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                // Override primary field with updated tempfile
                File.Move(tempFile, filePath, true);
            }
            catch (Exception)
            {
                // If error is thrown and tempFile exists then delete tempFile to avoid data leaks
                if (File.Exists(tempFile))
                    File.Delete(tempFile);

                // Throw message that file did not update properly
                throw new Exception("File not updated properly");
            }

        }

        public static void DeleteNote(string filePath, ClinicalNote toBeDeleted)
        {
            // Declare file path for temp file
            string tempFile = @"..\..\..\temp_update_file.txt";

            try
            {
                //Read through primary file and copy notes to temp file except for the note toBeDeleted
                using (StreamReader reader = new StreamReader(filePath, true))
                using (StreamWriter writer = new StreamWriter(tempFile))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != toBeDeleted.ToString())
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                File.Move(tempFile, filePath, true);
            }
            catch (Exception)
            {
                // If error is thrown and tempFile exists then delete tempFile to avoid data leaks
                if (File.Exists(tempFile))
                    File.Delete(tempFile);

                // Throw message that file did not delete properly
                throw new Exception("Note not deleted due to program error");
            }

        }
    }
}
