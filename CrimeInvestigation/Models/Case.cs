using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeInvestigation.Models
{
    public class Case
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Име")]
        public string Ime { get; set; }
        [Display(Name = "Презиме")]
        public string Prezime { get; set; }
        [Display(Name = "Време")]
        public string Vreme { get; set; }
        [Display(Name = "Локација")]
        public string Lokacija { get; set; }
        [Display(Name = "Тип")]
        public string Tip { get; set; }
        [Display(Name = "Опис")]
        public string Opis { get; set; }
        public virtual List<Osomnichen>osomnicheni { get; set; }
        public virtual List<Policaec> policajci { get; set; }

        public Case()
        {
            osomnicheni = new List<Osomnichen>();
            policajci = new List<Policaec>();

        }


    }
}