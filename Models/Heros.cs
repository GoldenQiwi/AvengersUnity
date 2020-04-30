using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AvengersUnityIdentity.Models
{
    /// <summary>
    /// Classe Heros
    /// </summary>
    public class Heros
    {
        [Key]
        [ForeignKey("Civil")]
        [Display(Name ="Nom identité Civil")]
        public int HeroID { get; set; }

        [Required]
        [Display(Name ="Pseudonyme")]
        public string Nom { get; set; }

        public string Pouvoir { get; set; }

        [Display(Name ="Point faible")]
        public string Point_Faible { get; set; }

        [Display(Name ="Informations complémentaires")]
        public string Commentaire { get; set; }

        public virtual Civil Civil { get; set; }
        public ICollection<Mission> Missions { get; set; }

        
    }
}