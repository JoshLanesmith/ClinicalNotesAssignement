using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicalNotes.VitalsClasses
{
    //Define interface for vitals
    public interface IVital
    {
        string RegexPattern { get; }

        int EvaluateVital();

        string ToString();
    }
}
