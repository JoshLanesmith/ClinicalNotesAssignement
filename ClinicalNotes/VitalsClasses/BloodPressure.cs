using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicalNotes.VitalsClasses
{
    public class BloodPressure : IVital
    {
        // Declere regex patter for blood pressure and properties for vital measurements
        private const string regexPattern = @"[b|B][p|P]:? (\d{2,3})/(\d{2,3})";
        public string RegexPattern { get { return regexPattern; } }

        private int systolic;
        public int Systolic { get { return systolic; } set { systolic = value; } }

        private int diastolic;
        public int Diastolic { get { return diastolic; } set { diastolic = value; } }

        public BloodPressure() { }

        public BloodPressure(int _systolic, int _diastolic)
        {
            Systolic = _systolic;
            Diastolic = _diastolic;
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
            if (Systolic < 90 && Diastolic < 60)
                return 1;

            else if (Systolic > 130 && Diastolic > 80)
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

            return $"BP: {Systolic}/{Diastolic} mmHg{rating}";
        }
    }
}
