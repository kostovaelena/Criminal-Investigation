using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrimeInvestigation.Models
{
    public class AddToCase2
    {
        public int caseId { get; set; }
        public int policaecId { get; set; }
        public List<Policaec> policajci { get; set; }
        public AddToCase2()
        {
            policajci = new List<Policaec>();
        }
    }
}