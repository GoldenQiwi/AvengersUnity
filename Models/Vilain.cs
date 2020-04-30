using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvengersUnityIdentity.Models
{
    /// <summary>
    /// Classe Vilain
    /// </summary>
    public class Vilain
    {
        public int VilainID { get; set; }

        [Required]
        [Display(Name ="Pseudonyme")]
        public string Nom { get; set; }

        public string Pouvoir { get; set; }

        public string Point_Faible { get; set; }

        public string Commentaire { get; set; }

    }
}