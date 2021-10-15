using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeInvestigation.Models
{
    public class Osomnichen
    {
      
        [Key]
        public int ID { get; set; }
        [Display(Name = "Име")]
        public string Ime { get; set; }
        [Display(Name = "Презиме")]
        public string  Prezime { get; set; }
        [Display(Name = "Години")]
        public int Godini { get; set; }
        [Display(Name = "Опис")]
        public string opisOsomnichen { get; set; }
        [Display(Name = "Слика")]
        public string Slika { get; set; }
        [Display(Name = "Тип на обвинение")]
        public string tipObvinenie { get; set; }
        public virtual List<Case>cases { get; set; }
        public bool IsAvailable { get; set; }
        public Osomnichen()
        {
            cases = new List<Case>();
        }



    }
}