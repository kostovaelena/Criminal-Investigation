using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CrimeInvestigation.Models
{
    public class Begstvo
    {
        [Key]
        [Display(Name = "Име")]
        public string Ime { get; set; }
        [Display(Name = "Презиме")]
        public string Prezime { get; set; }
        [Display(Name = "Години")]
        public int Godini { get; set; }
        [Display(Name = "Слика")]
        public string Slika { get; set; }
        [Display(Name = "Датум на исчезнување")]
        public string Datum { get; set; }
        [Display(Name = "Последен пат виден")]
        public string Mesto { get; set; }
        
    }
}