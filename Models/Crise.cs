using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AvengersUnityIdentity.Models
{
    /// <summary>
    /// Classe Crise
    /// </summary>
    public class Crise
    {
        public enum Type { Procès=0, Dommages_collatéraux=1, Heros_Demasqué=2, Nouveau_vilain=3 }
        public int CriseID { get; set; }

        [Required]
        [Display(Name ="Type de crise")]
        public Type Type_Crise { get; set; }

        [Required]
        public string Objet {get; set;}

        [Required]
        [Display(Name = "Brève description de la crise")]
        public string Contenu { get; set; }

    }
}