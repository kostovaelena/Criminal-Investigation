using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeInvestigation.Models
{
    public class Ischeznat
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Име")]
        public string Ime { get; set; }
        [Display(Name = "Презиме")]
        public string Prezime { get; set; }
        [Display(Name = "Години")]
        public int Godini { get; set; }
        [Display(Name = "Град на живеење")]
        public string Grad { get; set; }
        [Display(Name = "Адреса на живеење")]
        public string Adresa { get; set; }
        [Display(Name = "Датум на исчезнување")]
        public string Datum { get; set; }
        [Display(Name = "Време на исчезнување")]
        public string Vreme { get; set; }
        [Display(Name = "Последен пат виден")]
        public string Mesto { get; set; }
        [Display(Name = "Надворешен изглед")]
        public string Izgled { get; set; }
        [Display(Name = "Слика")]
        public string Slika { get; set; }

    }
}