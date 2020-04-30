using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvengersUnityIdentity.Models
{
    /// <summary>
    /// Classe Mission
    /// </summary>
    public enum Urgence { Faible = 0, Standard = 1, Urgent = 2, Prioritaire = 3 }
    public enum Statut { Attente = 0, Active = 1, Achevée = 2, Annulée = 3 }
    public class Mission
    {
        public int MissionID { get; set; }

        [Required]
        [Display(Name = "Titre de l'incident")]
        public int IncidendID { get; set; }
        public virtual Incident Incident { get; set; }

        [Required]
        public string Titre { get; set; }

        [Required]
        [Display(Name ="Statut de la mission")]
        public Statut Statut { get; set; }

        [Required]
        [Display(Name ="Niveau d'urgence")]
        public Urgence Urgence { get; set; }

        [Required]
        [Display(Name ="Heros engagé")]
        public int HeroID { get; set; }
        public virtual Heros Heros { get; set; }

        public virtual Rapport Rapport { get; set; }

        public virtual Satisfaction Satisfaction { get; set; }


    }
}