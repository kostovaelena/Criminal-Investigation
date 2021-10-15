using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrimeInvestigation.Models
{
    public class AddToCase
    {
        public int caseId { get; set; }
        public int osomnichenId { get; set; }
        public List<Osomnichen> osomnicheni { get; set; }
        public AddToCase()
        {
            osomnicheni = new List<Osomnichen>();
        }
    }
}