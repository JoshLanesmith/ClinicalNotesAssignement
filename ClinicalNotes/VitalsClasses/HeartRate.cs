using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicalNotes.VitalsClasses
{
    public class HeartRate : IVital
    {
        // Declere regex patter for heart rate and properties for vital measurements
        private const string regexPattern = @"[h|H][r|R]:? (\d{2,3})";
        public string RegexPattern { get { return regexPattern; } }

        private int beatsPerMinute;
        public int BeatsPerMinute { get { return beatsPerMinute; } set { beatsPerMinute = value; } }

        public HeartRate() { }

        public HeartRate(int _beatsPerMinute)
        {
            BeatsPerMinute = _beatsPerMinute;
        }

        // Find all matches in note for the regex pattern
        public static MatchCollection FindMatches(string note)
        {
            MatchCollection matches = Regex.Matches(note, regexPattern);

            return matches;
        }

        // Evaluate if vital is high, low, or normal
        public int EvaluateVital()
        {
            if (BeatsPerMinute < 60)
                return 1;

            else if (BeatsPerMinute > 100)
                return 2;

            else
                return 0;
        }

        // Define ToString Override
        public override string ToString()
        {
            string rating = "";

            switch (EvaluateVital())
            {
                case 1:
                    rating = " (Low)";
                    break;
                case 2:
                    rating = " (high)";
                    break;
                default:
                    break;
            }

            return $"HR: {BeatsPerMinute} bpm{rating}";
        }
    }
}