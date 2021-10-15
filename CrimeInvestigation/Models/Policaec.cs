using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeInvestigation.Models
{
    public class Policaec
    {
        [Key]
        [Display(Name = "ID")]
        public int policaecId { get; set; }
        
        [Display(Name = "Име")]
        public string Ime { get; set; }
        [Display(Name = "Презиме")]
        public string Prezime { get; set; }
        
        [Display(Name = "Години искуство")]
        public int iskustvo { get; set; }
        [Display(Name = "Слика")]
        public string urlslika { get; set; }


    }
}