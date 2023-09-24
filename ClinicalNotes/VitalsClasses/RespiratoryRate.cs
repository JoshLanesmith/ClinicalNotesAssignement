using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicalNotes.VitalsClasses
{
    public class RespiratoryRate : IVital
    {
        // Declere regex patter for respiratory rate and properties for vital measurements
        private const string regexPattern = @"[r|R][r|R]:? (\d{2,3})";
        public string RegexPattern { get { return regexPattern; } }

        private int breathsPerMinute;
        public int BreathsPerMinute { get { return breathsPerMinute; } set { breathsPerMinute = value; } }

        public RespiratoryRate() { }

        public RespiratoryRate(int _breathsPerMinute)
        {
            BreathsPerMinute = _breathsPerMinute;
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
            if (BreathsPerMinute < 12)
                return 1;

            else if (BreathsPerMinute > 16)
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

            return $"RR: {BreathsPerMinute} bpm{rating}";
        }
    }
}