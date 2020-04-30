using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvengersUnityIdentity.Models
{
    /// <summary>
    /// Classe Pays
    /// </summary>
    public class Pays
    {
        public int PaysID { get; set; }

        [Required]
        [Display(Name ="Nom du pays")]
        public string Nom_Pays { get; set; }

        public virtual ICollection<Civil> Civils { get; set; }

        public virtual ICollection<Organisation> Organisations { get; set; }
    }
}