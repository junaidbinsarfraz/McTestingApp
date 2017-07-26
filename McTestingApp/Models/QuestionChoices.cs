using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace McTestingApp.Models
{
    public class QuestionChoices
    {
        public string Question { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public string CorrectChoice { get; set; }
    }
}