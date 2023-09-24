using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicalNotes.VitalsClasses
{
    public class Temperature : IVital
    {
        // Declere regex patter for tempurature and properties for vital measurements
        private const string regexPattern = @"[t|T]:? (\d{2}(?:.\d)?)";
        public string RegexPattern { get { return regexPattern; } }

        private double bodyTempurature;
        public double BodyTempurature { get { return bodyTempurature; } set { bodyTempurature = value; } }

        public Temperature() { }

        public Temperature(double _bodyTempurature)
        {
            BodyTempurature = _bodyTempurature;
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
            if (BodyTempurature < 36.5)
                return 1;

            else if (BodyTempurature > 37.2)
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

            return $"T: {string.Format("{0}°C", BodyTempurature)}{rating}";
        }
    }
}